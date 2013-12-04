using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class UserControl_NewsMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dlstNewsMenu.DataSource = NewsTypeBll.GetAllNewsType();
            dlstNewsMenu.DataBind();
        }
    }
}