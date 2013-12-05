using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;

public partial class Advise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtLinkman.Text == "")
        {
            MessageBox.Alert("联系人不能为空", Page);
        }
        else if (txtDetail.Text == "")
        {
            MessageBox.Alert("留言内容不能为空", Page);
        }
        else 
        {
            Model.Advise advise = new Model.Advise();
            advise.RealName = txtLinkman.Text.Trim();
            advise.Phone = txtPhone.Text;
            advise.Email = txtEmail.Text;
            advise.LoadTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            advise.Title = "";
            advise.Reply = "";
            advise.Detail = txtDetail.Text;
            advise.IPAdress = HttpContext.Current.Request.UserHostAddress;
            AdviseBll.AddAdvise(advise);
            MessageBox.AlertAndRedirect("留言成功，我们会尽快的回复您！","AdviseList.aspx",Page);
        }
    }
}