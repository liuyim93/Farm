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
            if (list[0].Detail.Length > 340)
            {
                ltlFarmIntro.Text = list[0].Detail.Substring(0, 340)+"...";
            }
            else 
            {
                ltlFarmIntro.Text = list[0].Detail;
            }
        }
        dlstImage.DataSource = ImageBll.GetHomeTopImage_Top5();
        dlstImage.DataBind();
        dlstMarquee.DataSource = ImageBll.GetHomeBottomImage_Top10();
        dlstMarquee.DataBind();
    }
    protected void dlstImage_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Image img = e.Item.FindControl("imgTop") as Image;
            string imgUrls = img.ImageUrl;
            string[] ImgUrl = imgUrls.Split('/');
            string urlStr = string.Empty;
            for (int i = 0; i < ImgUrl.Length; i++)
            {
                if (i != 0 && i != ImgUrl.Length - 1)
                {
                    urlStr += ImgUrl[i] + "/";
                }
                else if (i == ImgUrl.Length - 1)
                {
                    urlStr += ImgUrl[i];
                }
            }
            img.ImageUrl = urlStr;
        }
    }
    protected void dlstMarquee_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Image img = e.Item.FindControl("imgBottom") as Image;
            string imgUrls = img.ImageUrl;
            string[] ImgUrl = imgUrls.Split('/');
            string urlStr = string.Empty;
            for (int i = 0; i < ImgUrl.Length; i++)
            {
                if (i != 0 && i != ImgUrl.Length - 1)
                {
                    urlStr += ImgUrl[i] + "/";
                }
                else if (i == ImgUrl.Length - 1)
                {
                    urlStr += ImgUrl[i];
                }
            }
            img.ImageUrl = urlStr;
        }
    }
}