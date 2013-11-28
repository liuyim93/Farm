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
            drop1.Items.Insert(0,"请选择分类");
            drop2.Items.Insert(0, "请选择分类");
            drop3.Items.Insert(0, "请选择分类");
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
            dlstImg.DataSource = ImageBll.GetAllImage();
            dlstImg.DataBind();
            BindDrop1();                        
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
    }

    public void BindDrop3() 
    {
        int id = Convert.ToInt32(drop2.SelectedValue);
        drop3.DataSource = ImageTypeBll.GetImageTypebyParentID(id);
        drop3.DataTextField = "TypeName";
        drop3.DataValueField = "ImgTypeID";
        drop3.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtImgName.Text == "")
        {
            lblMsg.Text = "请输入图片名称";
            txtImgName.Focus();
        }
        else if (drop1.SelectedValue == "0")
        {
            lblMsg.Text = "请选择分类";
            drop1.Focus();
        }
        else if (hfImgUrl.Value == "")
        {
            lblMsg.Text = "请先上传图片，在提交。谢谢！";
        }
        else 
        {
            Model.Image img = new Model.Image();
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

            if (drop3.SelectedValue != "0")
            {
                img.ImgTypeID = Convert.ToInt32(drop3.SelectedValue);
            }
            else 
            {
                if (drop2.SelectedValue != "0")
                {
                    img.ImgTypeID = Convert.ToInt32(drop2.SelectedValue);
                }
                else 
                {
                    img.ImgTypeID = Convert.ToInt32(drop1.SelectedValue);
                }
            }
            if (hfImgID.Value == "")
            {
                ImageBll.AddImage(img);
                MessageBox.Alert("添加成功", Page);
            }
            else 
            {
                
            }
            ClearText();
            Bind();
        }

    }

    public void ClearText() 
    {
        txtImgName.Text = "";
        txtRemark.Text = "";
        drop1.SelectedValue = "0";
        drop2.SelectedValue = "0";
        drop3.SelectedValue = "0";
        hfImgID.Value = "";
        hfImgUrl.Value = "";
        chkShow.Checked = true;
    }

    protected void dlstImg_ItemCommand(object source, DataListCommandEventArgs e)
    {

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
                    string filename = DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "");
                    fileupload1.SaveAs("~/Upload/"+filename);
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