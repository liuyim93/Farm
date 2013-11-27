using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL;
using Model;
using Tools;

public partial class Admin_Admin_ManageAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Admin_Admin_ManageAdmin));
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
            gvwAdminList.DataSource = AdminBll.GetAdmin(adminId);
            gvwAdminList.DataBind();
        }
    }

    public void ClearText() 
    {
        txtAdminName.Text = "";
        txtPwd.Text = "";
        txtPwdConfirm.Text = "";
        txtRemark.Text = "";
        chkSuper.Checked = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtAdminName.Text=="")
        {
            lblMsg.Text = "用户名不能为空";
            txtAdminName.Focus();
        }
        else if (txtPwd.Text == "")
        {
            lblMsg.Text = "请输入密码";
            txtPwd.Focus();
        }
        else if (txtPwdConfirm.Text == "")
        {
            lblMsg.Text = "请确认密码";
            txtPwdConfirm.Focus();
        }
        else if (txtPwd.Text.Trim() != txtPwdConfirm.Text.Trim())
        {
            lblMsg.Text = "两次密码不一致，请重新输入密码";
            txtPwd.Text = "";
            txtPwdConfirm.Text = "";
            txtPwd.Focus();
        }
        else
        {
            Admin admin = new Admin();
            admin.UserName = txtAdminName.Text;
            admin.password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPwdConfirm.Text.Trim(), "md5");
            admin.Remark = txtRemark.Text;
            if (chkSuper.Checked == true)
            {
                admin.IsSuperAdmin = 1;
            }
            else
            {
                admin.IsSuperAdmin = 0;
            }
            AdminBll.AddAdmin(admin);
            MessageBox.Alert("添加成功", Page);
            ClearText();
            Bind();
        }
    }

    protected void gvwAdminList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="del")
        {
            int adminId =Convert.ToInt32(e.CommandArgument);
            AdminBll.DeleteAdmin(adminId);
            Bind();
        }
    }

    protected void gvwAdminList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {
            Label num = e.Row.FindControl("lblNum") as Label;
            num.Text = (e.Row.RowIndex + 1).ToString();
        }
    }

    [AjaxPro.AjaxMethod]
    public string CheckAdminName(string name) 
    {
        List<Admin> list = AdminBll.GetAdminbyName(name);
        if (list.Count > 0)
        {
            return "0";
        }
        else 
        {
            return "1";
        }
    }
}