using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Fun_Detail : System.Web.UI.Page
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
            Response.Redirect("Fun.aspx");
        }
        else 
        {
            int imgId = Convert.ToInt32(Request.QueryString["id"]);
            List<image> list = ImageBll.GetImage(imgId);
            if (list.Count>0)
            {
                ltlTime.Text=list[0].LoadTime.ToString();
                ltlTitle.Text=list[0].ImgName;
                ltlBrowserText.Text = ltlTitle.Text + "-金水泊山庄";
                lblImgName.Text=ltlTitle.Text;
                int imgTypeId=list[0].ImgTypeID;
                List<ImageType> list_imgType = ImageTypeBll.GetImageType(imgTypeId);
                hlnkFun.Text=list_imgType[0].TypeName;
                hlnkFun.NavigateUrl = "Fun_Search.aspx?id="+list_imgType[0].ImgTypeID;
                List<image> list_prev = ImageBll.GetPrevImage(imgTypeId,imgId);
                if (list_prev.Count > 0)
                {
                    hlnkPrev.Text = list_prev[0].ImgName;
                    hlnkPrev.NavigateUrl = "Fun_Detail.aspx?id="+list_prev[0].ImgID;
                }
                else 
                {
                    hlnkPrev.Text = "没有了";
                    hlnkPrev.NavigateUrl = "#";
                }
                List<image> list_next = ImageBll.GetNextImage(imgTypeId,imgId);
                if (list_next.Count>0)
                {
                    hlnkNext.Text=list_next[0].ImgName;
                    hlnkNext.NavigateUrl = "Fun_Detail.aspx?id="+list_next[0].ImgID;
                }else
                {
                    hlnkNext.Text = "没有了";
                    hlnkNext.NavigateUrl = "#";
                }
                string imgUrls = list[0].ImgUrl;
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
                imgFun.ImageUrl = urlStr;
            }
        }
    }
}