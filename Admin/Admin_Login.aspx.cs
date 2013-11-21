using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using BLL;
using Model;

public partial class Admin_Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            uid.Focus();
            Session.Clear();
        }
    }
    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
        if (uid.Value == "")
        {
            labmsg.Text = "<script lanage='javascript'>alert('请输入用户名！');</script>";
        }
        else if (pwd.Value == "")
        {
            labmsg.Text = "<script lanage='javascript'>alert('请输入用户密码！');</script>";
        }
        else if (code.Value == "")
        {
            labmsg.Text = "<script lanage='javascript'>alert('请输入验证码！');</script>";
        }
        else 
        {
            string userName = uid.Value;
            string password = pwd.Value;
            List<Admin> list_admin = AdminBll.GetAdmin(userName,password);
            if (list_admin.Count<0)
            {
                
            }
        }
    }
}