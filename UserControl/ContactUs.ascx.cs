using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class UserControl_ContactUs : System.Web.UI.UserControl
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
        List<FarmInfo> list = InfoBll.GetFarmInfo();
        if (list.Count>0)
        {
            lblAdress.Text=list[0].Adress;
            lblEmail.Text=list[0].Email;
            lblLinkman.Text=list[0].Linkman;
            lblMobile.Text=list[0].Mobile;
            lblPhone.Text=list[0].Phone;
        }
    }
}