using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class ContactUs : System.Web.UI.Page
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
        List<Intro> list = IntroBll.GetContactUs();
        if (list.Count>0)
        {
            lblDetail.Text=list[0].Detail;
        }
    }
}