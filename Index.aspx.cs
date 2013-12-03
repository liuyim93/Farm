using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Index : System.Web.UI.Page
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
        dlstNews.DataSource = NewsBll.GetNews_Top5();
        dlstNews.DataBind();
        dlstActivity.DataSource = NewsBll.GetActivity_Top6();
        dlstActivity.DataBind();
        List<Intro> list = IntroBll.GetFarmIntro();
        if (list.Count>0)
        {
            ltlFarmIntro.Text=list[0].Detail;
        }
        dlstImage.DataSource = ImageBll.GetHomeTopImage_Top5();
        dlstImage.DataBind();
        dlstMarquee.DataSource = ImageBll.GetHomeBottomImage_Top10();
        dlstMarquee.DataBind();
    }
}