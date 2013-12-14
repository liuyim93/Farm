using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class UserControl_FoodMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dlstFoodMenu.DataSource = ImageTypeBll.GetFood();
            dlstFoodMenu.DataBind();
        }        
    }
}