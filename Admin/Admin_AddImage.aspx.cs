using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;
using System.IO;

public partial class Admin_Admin_AddImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            Bind();            
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
            dlstImg.DataSource = ImageBll.GetAllImage();
            dlstImg.DataBind();
            BindDrop1();
            drop1.Items.Insert(0, "请选择分类");
            drop1.SelectedItem.Text = "请选择分类";            
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
        int id = Convert.ToInt32(drop1.SelectedValue);
        drop2.DataSource = ImageTypeBll.GetImageTypebyParentID(id);
        drop2.DataTextField = "TypeName";
        drop2.DataValueField = "ImgTypeID";
        drop2.DataBind();
        drop2.Items.Insert(0, "请选择分类");
        drop2.SelectedItem.Text = "请选择分类";
    }

    public void BindDrop3() 
    {
        int id = Convert.ToInt32(drop2.SelectedValue);
        drop3.DataSource = ImageTypeBll.GetImageTypebyParentID(id);
        drop3.DataTextField = "TypeName";
        drop3.DataValueField = "ImgTypeID";
        drop3.DataBind();
        drop3.Items.Insert(0, "请选择分类");
        drop3.SelectedItem.Text = "请选择分类";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtImgName.Text == "")
        {
            lblMsg.Text = "请输入图片名称";
            txtImgName.Focus();
        }
        else if (drop1.SelectedItem.Text=="请选择分类")
        {
            lblMsg.Text = "请选择分类";
            drop1.Focus();
        }
        else if (hfImgUrl.Value == "")
        {
            lblMsg.Text = "请先上传图片，在提交。";
        }
        else 
        {
            Model.image img = new Model.image();
            img.ImgName = txtImgName.Text.Trim();
            img.ImgUrl = hfImgUrl.Value;
            img.LoadTime = DateTime.Now;
            img.Remark = txtRemark.Text;
            img.AdminID=Convert.ToInt32(Session["AdminID"]);
            if (chkShow.Checked)
            {
                img.IsShow = 1;
            }
            else 
            {
                img.IsShow = 0;
            }

            if (drop3.SelectedIndex == -1)
            {
                if (drop2.SelectedItem.Text != "请选择分类")
                {
                    img.ImgTypeID = Convert.ToInt32(drop2.SelectedValue);
                }
                else
                {
                    img.ImgTypeID = Convert.ToInt32(drop1.SelectedValue);
                }
            }
            else 
            {
                if (drop3.SelectedItem.Text != "请选择分类")
                {
                    img.ImgTypeID = Convert.ToInt32(drop3.SelectedValue);
                }
                else
                {
                    if (drop2.SelectedItem.Text != "请选择分类")
                    {
                        img.ImgTypeID = Convert.ToInt32(drop2.SelectedValue);
                    }
                    else
                    {
                        img.ImgTypeID = Convert.ToInt32(drop1.SelectedValue);
                    }
                }
            }
           
            if (hfImgID.Value == "")
            {
                ImageBll.AddImage(img);
                MessageBox.Alert("添加成功", Page);
            }
            else 
            {
                img.ImgID = Convert.ToInt32(hfImgID.Value);
                ImageBll.UpdateImage(img);
                MessageBox.Alert("修改成功",Page);
            }
            ClearText();
            Bind();
        }
    }

    public void ClearText() 
    {
        txtImgName.Text = "";
        txtRemark.Text = "";
        drop1.SelectedItem.Text="请选择分类";
        drop2.SelectedItem.Text = "请选择分类";
        if (drop3.SelectedIndex == -1)
        {
            drop3.SelectedIndex = -1;
        }
        else 
        {
            drop3.SelectedItem.Text = "请选择分类";
        }        
        hfImgID.Value = "";
        hfImgUrl.Value = "";
        chkShow.Checked = true;
    }

    protected void dlstImg_ItemCommand(object source, DataListCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "change":
                int imgId = Convert.ToInt32(e.CommandArgument);
                List<Model.image> list = ImageBll.GetImage(imgId);
                txtImgName.Text=list[0].ImgName;
                txtRemark.Text=list[0].Remark;
                hfImgID.Value=list[0].ImgID.ToString();
                hfImgUrl.Value=list[0].ImgUrl;
                if (list[0].IsShow == 1)
                {
                    chkShow.Checked = true;
                }
                else 
                {
                    chkShow.Checked = false;
                }
                List<ImageType> list_type = ImageTypeBll.GetImageType(list[0].ImgTypeID);
                if (list_type[0].ParentID == 0)
                {
                    BindDrop1();
                    drop1.SelectedValue=list[0].ImgTypeID.ToString();
                    BindDrop2();
                    drop2.SelectedItem.Text = "请选择分类";
                    drop1.Visible = true;
                    drop2.Visible = true;
                    drop3.Visible = false;
                }
                else
                {
                    int Id = list_type[0].ParentID;
                    List<ImageType> list1 = ImageTypeBll.GetImageType(Id);
                    if (list1[0].ParentID == 0)
                    {
                        BindDrop1();
                        drop1.SelectedValue = list_type[0].ParentID.ToString();
                        BindDrop2();
                        drop2.SelectedValue=list_type[0].ImgTypeID.ToString();
                        BindDrop3();
                        drop3.SelectedItem.Text = "请选择分类";
                    }
                    else
                    {
                        int id = list1[0].ParentID;
                        List<ImageType> list2 = ImageTypeBll.GetImageType(id);
                        BindDrop1();
                        drop1.SelectedValue = list2[0].ImgTypeID.ToString();
                        BindDrop2();
                        drop2.SelectedValue = list1[0].ImgTypeID.ToString();
                        BindDrop3();
                        drop3.SelectedValue=list_type[0].ImgTypeID.ToString();
                    }
                }
                break;
            case "del":
                int imgID = Convert.ToInt32(e.CommandArgument);
                ImageBll.DeleteImage(imgID);
                MessageBox.Alert("删除成功",Page);
                ClearText();
                Bind();
                break;
            default:
                break;
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fileupload1.HasFile)
        {
            if (fileupload1.PostedFile.ContentLength / 1024 > 1024 * 10)
            {
                lblMsg.Text = "上传的图片大小不能超过5M";
                return;
            }
            else 
            {
                bool fileOk = false;
                string fileType = System.IO.Path.GetExtension(fileupload1.FileName);
                string[] allowExtensions = {".gif",".jpg",".bmp",".png",".jpeg" };
                for (int i = 0; i < allowExtensions.Length; i++)
                {
                    if (fileType==allowExtensions[i])
                    {
                        fileOk = true;
                    }
                }
                if (!fileOk)
                {
                    lblMsg.Text = "图片格式错误";
                    return;
                }
                else 
                {
                    string filename = DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "")+fileType;
                    fileupload1.SaveAs(Server.MapPath("../Upload/")+filename);
                    hfImgUrl.Value = "../Upload/" + filename;
                }
            }
        }
    }

    protected void drop1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drop1.SelectedValue != "0")
        {
            BindDrop2();
            drop2.Visible = true;
            drop2.SelectedItem.Text="请选择分类";
        }
        else 
        {
            drop2.Visible = false;
            drop3.Visible = false;
        }
    }

    protected void drop2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drop2.SelectedValue != "0")
        {
            BindDrop3();
            drop3.Visible = true;
            drop3.SelectedItem.Text="请选择分类";
        }
        else 
        {
            drop3.Visible = false;
        }
    }

    protected void drop3_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}