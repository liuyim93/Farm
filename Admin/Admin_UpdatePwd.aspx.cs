using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;
using System.Web.Security;

public partial class Admin_Admin_UpdatePwd : System.Web.UI.Page
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
        if (Session["AdminName"] == null || Session["AdminID"] == null)
        {
            Response.Redirect("Admin_Login.aspx");
        }
        else 
        {
            int adminId = Convert.ToInt32(Session["AdminID"]);
            List<Admin> list = AdminBll.GetAdminbyId(adminId);
            lblAdminName.Text=list[0].UserName;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtOldPwd.Text == "")
        {
            lblMsg.Text = "请输入原密码";
            txtOldPwd.Focus();
        }
        else if (txtNewPwd.Text == "")
        {
            lblMsg.Text = "请输入新密码";
            txtNewPwd.Focus();
        }
        else if (txtPwdConfirm.Text == "")
        {
            lblMsg.Text = "请输入确认密码";
            txtPwdConfirm.Focus();
        }
        else if(txtNewPwd.Text.Trim()!=txtPwdConfirm.Text.Trim()) 
        {
            lblMsg.Text = "新密码不一致";
            txtNewPwd.Text = "";
            txtPwdConfirm.Text = "";
            txtNewPwd.Focus();
        }
        else
        {
            List<Admin> list = AdminBll.GetAdminbyId(Convert.ToInt32(Session["AdminID"]));
            string oldPwd = list[0].password;
            if (oldPwd != FormsAuthentication.HashPasswordForStoringInConfigFile(txtOldPwd.Text.Trim(), "md5"))
            {
                lblMsg.Text = "原密码错误";
                txtOldPwd.Text = "";
                txtOldPwd.Focus();
            }
            else
            {
                string newPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPwdConfirm.Text.Trim(),"md5");
                int adminId = Convert.ToInt32(Session["AdminID"]);
                AdminBll.UpdatePwd(adminId,newPwd);
                MessageBox.AlertAndRedirect("修改成功,请重新登录", "Admin_Login.aspx", Page);
            }
        }
    }
}