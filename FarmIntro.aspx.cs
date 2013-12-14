using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class FarmIntro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Intro> list = IntroBll.GetFarmIntro();
            if (list.Count>0)
            {
                lblFarmIntro.Text = list[0].Detail;
            }            
        }
    }
}