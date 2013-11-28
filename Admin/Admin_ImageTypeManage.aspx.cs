using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;

public partial class Admin_Admin_ImageTypeManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drop1.Items.Insert(0, "请选择父分类");
            drop2.Items.Insert(0, "请选择父分类");
            drop3.Items.Insert(0, "请选择父分类");
            Bind();           
            drop1.SelectedValue = "0";
            drop2.SelectedValue = "0";
            drop3.SelectedValue = "0";            
        }
    }

    public void Bind()
    {
        if (Session["AdminID"] == null || Session["AdminName"] == null)
        {
            Response.Redirect("Admin_Login.aspx");
        }
        else
        {
            gvwImgType.DataSource = ImageTypeBll.GetAllImageType();
            gvwImgType.DataBind();
            BindDrop1();
            if (drop1.SelectedItem.Text != "请选择父分类")
            {
                BindDrop2();
                if (drop2.SelectedItem.Text!="请选择父分类")
                {
                    BindDrop3();
                }
            }
            else 
            {
                drop2.Visible = false;
                drop3.Visible = false;
            }
        }
    }

    public void BindDrop1() 
    {
        drop1.DataSource = ImageTypeBll.GetImageTypebyParentID(0);
        drop1.DataTextField = "TypeName";
        drop1.DataValueField = "ImgTypeID";
        drop1.DataBind();
    }
    public void BindDrop2()
    {
        int parentId = Convert.ToInt32(drop1.SelectedValue);
        List<ImageType> list = ImageTypeBll.GetImageTypebyParentID(parentId);
        if (list.Count > 0)
        {
            drop2.DataSource = list;
            drop2.DataTextField = "TypeName";
            drop2.DataValueField = "ImgTypeID";
            drop2.DataBind();
            drop2.Visible = true;
        }
        else
        {
            drop2.Visible = false;
        }            
    }

    public void BindDrop3() 
    {
        int parentId = Convert.ToInt32(drop2.SelectedValue);
        List<ImageType> list = ImageTypeBll.GetImageTypebyParentID(parentId);
        if (list.Count > 0)
        {
            drop3.DataSource = list;
            drop3.DataTextField = "TypeName";
            drop3.DataValueField = "ImgTypeID";
            drop3.DataBind();
            drop3.Visible = true;
        }
        else
        {
            drop3.Visible = false;
        }                        
    }

    protected void drop3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void drop1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drop1.SelectedItem.Text == "请选择父分类")
        {
            drop2.Visible = false;
            drop3.Visible = false;
        }
        else 
        {
            BindDrop2();
        }
    }

    protected void drop2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drop2.SelectedItem.Text == "请选择父分类")
        {
            drop3.Visible = false;
        }
        else 
        {
            BindDrop3();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtTypeName.Text == "")
        {
            lblMsg.Text = "请输入图片分类名称";
            txtTypeName.Focus();
        }
        else
        {
            ImageType imgType = new ImageType();
            imgType.Remark = txtRemark.Text;
            imgType.TypeName = txtTypeName.Text;
            if (drop1.SelectedItem.Text == "请选择父分类") 
            {
                imgType.Rank = 0;
            } 
            else 
            {
                imgType.Rank = Convert.ToInt32(txtRank.Text.Trim());
            }
            if (chkShow.Checked)
            {
                imgType.IsShow = 1;
            }
            else 
            {
                imgType.IsShow = 0;
            }

            if (drop3.SelectedItem.Text != "请选择父分类")
            {
                imgType.ParentID = Convert.ToInt32(drop3.SelectedValue);
            }
            else 
            {
                if (drop2.SelectedItem.Text != "请选择父分类")
                {
                    imgType.ParentID = Convert.ToInt32(drop2.SelectedValue);
                }
                else 
                {
                    if (drop1.SelectedItem.Text != "请选择父分类")
                    {
                        imgType.ParentID = Convert.ToInt32(drop1.SelectedValue);
                    }
                    else 
                    {
                        imgType.ParentID = 0;
                    }
                }
            }
            if (hfImgTypeID.Value == "")
            {
                ImageTypeBll.AddImageType(imgType);
                MessageBox.Alert("添加成功!", Page);
            }
            else 
            {
                imgType.ImgTypeID = Convert.ToInt32(hfImgTypeID.Value);
                ImageTypeBll.UpdateImageType(imgType);
                MessageBox.Alert("修改成功",Page);
            }                        
            ClearText();
            Bind();
        }
    }

    public void ClearText() 
    {
        txtTypeName.Text = "";
        txtRank.Text = "";
        txtRemark.Text = "";
        chkShow.Checked = true;
        hfImgTypeID.Value = "";
        drop1.SelectedItem.Text = "请选择父分类";
        drop2.SelectedItem.Text = "请选择父分类";
        drop3.SelectedItem.Text = "请选择父分类";
    }
    protected void gvwImgType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {
            Label lblNum = e.Row.FindControl("lblNum") as Label;
            lblNum.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
    protected void gvwImgType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "change":
                int imTypeId = Convert.ToInt32(e.CommandArgument);
                List<ImageType> list = ImageTypeBll.GetImageType(imTypeId);
                txtTypeName.Text=list[0].TypeName;
                hfImgTypeID.Value=list[0].ImgTypeID.ToString();
                txtRank.Text=list[0].Rank.ToString();
                txtRemark.Text=list[0].Remark;
                if (list[0].IsShow==1)
                {
                    chkShow.Checked=true;
                }else
                {
                    chkShow.Checked = false;
                }

                if (list[0].ParentID == 0)
                {
                    BindDrop1();
                    drop1.SelectedItem.Text = "请选择父分类";
                    drop1.Visible = true;
                    drop2.Visible = false;
                    drop3.Visible = false;
                }
                else 
                {
                    int Id=list[0].ParentID;
                    List<ImageType> list1 = ImageTypeBll.GetImageType(Id);
                    if (list1[0].ParentID == 0)
                    {
                        BindDrop1();
                        drop1.SelectedValue = list[0].ParentID.ToString();
                        BindDrop2();
                        drop2.SelectedItem.Text = "请选择父分类";
                    }
                    else 
                    {
                        int id=list1[0].ParentID;
                        List<ImageType> list2 = ImageTypeBll.GetImageType(id);
                        if (list2[0].ParentID == 0)
                        {
                            BindDrop1();
                            drop1.SelectedValue = id.ToString();
                            BindDrop2();
                            drop2.SelectedValue = list1[0].ImgTypeID.ToString();
                            BindDrop3();
                            drop3.SelectedItem.Text = "请选择父分类";
                        }
                        else 
                        {
                            int typeId=list2[0].ParentID;                            
                            BindDrop1();
                            drop1.SelectedValue=typeId.ToString();
                            BindDrop2();
                            drop2.SelectedValue=list2[0].ImgTypeID.ToString();
                            BindDrop3();
                            drop3.SelectedValue=list1[0].ImgTypeID.ToString();
                        }
                    }
                }
                break;
            case "del":
                int imgTypeId = Convert.ToInt32(e.CommandArgument);
                ImageTypeBll.DeleteImageType(imgTypeId);
                MessageBox.Alert("删除成功！",Page);
                Bind();
                break;
            default:
                break;
        }
    }
}