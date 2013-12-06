using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Model;

public partial class News_Detail : System.Web.UI.Page
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
        if (Request.QueryString["id"] == "" || Request.QueryString["id"] == null)
        {
            Response.Redirect("News.aspx");
        }
        else 
        {
            int newsId=Convert.ToInt32(Request.QueryString["id"]);
            NewsBll.UpdateClickNum(newsId);
            List<Model.News> list = NewsBll.GetNews(newsId);
            if (list.Count>0)
            {
                ltlAuthor.Text=list[0].Author;
                ltlClickNum.Text=list[0].ClickNum.ToString();
                ltlTime.Text=list[0].LoadTime;
                ltlTitle.Text=list[0].Title;
                ltlBrowserText.Text = ltlTitle.Text + "-金水泊山庄";
                lblNewsName.Text = ltlTitle.Text;
                lblNewsDetail.Text=list[0].Detail;
                int newsTypeId=list[0].NewsTypeID;
                List<NewsType> list_newsType = NewsTypeBll.GetNewsType(newsTypeId);
                if (list_newsType.Count > 0)
                {
                    hlnkTitle.Text = list_newsType[0].TypeName;
                    hlnkTitle.NavigateUrl = "News_Search.aspx?id="+newsTypeId;
                }
                else 
                {
                    hlnkTitle.Text = "";
                    hlnkTitle.NavigateUrl = "#";
                }
                List<Model.News> list_prev = NewsBll.GetPrevNews(newsTypeId,newsId);
                if (list_prev.Count > 0)
                {
                    hlnkPrev.Text = list_prev[0].Title;
                    hlnkPrev.NavigateUrl = "News_Detail.aspx?id=" + list_prev[0].NewsID;
                }
                else 
                {
                    hlnkPrev.Text = "没有了";
                    hlnkPrev.NavigateUrl = "#";
                }
                List<Model.News> list_next = NewsBll.GetNextNews(newsTypeId,newsId);
                if (list_next.Count > 0)
                {
                    hlnkNext.Text = list_next[0].Title;
                    hlnkNext.NavigateUrl = "News_Detail.aspx?id=" +list_next[0].NewsID;
                }
                else 
                {
                    hlnkNext.Text = "没有了";
                    hlnkNext.NavigateUrl = "#";
                }
            }
        }
    }
}