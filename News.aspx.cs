using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;

public partial class News : System.Web.UI.Page
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
        DataTable dt=NewsBll.GetAllnews();
        if (dt.Rows.Count>0)
        {
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.PageSize = AspNetPager1.PageSize;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            dlstNews.DataSource = pds.DataSource;
            dlstNews.DataBind();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
}