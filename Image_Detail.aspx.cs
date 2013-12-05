using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Image_Detail : System.Web.UI.Page
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
            Response.Redirect("Index.aspx");
        }
        else 
        {
            int imgId = Convert.ToInt32(Request.QueryString["id"]);
            List<image> list = ImageBll.GetImage(imgId);
            if (list.Count>0)
            {
                lblImgName.Text=list[0].ImgName;
                ltlTitle.Text=lblImgName.Text;
                ltlTime.Text=list[0].LoadTime.ToString();
                int imgTypeId=list[0].ImgTypeID;
                List<ImageType> list_imgType = ImageTypeBll.GetImageType(imgTypeId);
                if (list_imgType.Count>0)
                {
                    hlnkTitle.Text=list_imgType[0].TypeName;
                    hlnkTitle.NavigateUrl = "ImageList.aspx?id="+imgTypeId;
                }
                List<image> list_prev = ImageBll.GetPrevImage(imgTypeId,imgId);
                if (list_prev.Count > 0)
                {
                    hlnkPrev.Text = list_prev[0].ImgName;
                    hlnkPrev.NavigateUrl = "Image_Detail.aspx?id=" + list_prev[0].ImgID;
                }
                else 
                {
                    hlnkPrev.Text = "没有了";
                    hlnkPrev.NavigateUrl = "#";
                }
                List<image> list_next = ImageBll.GetNextImage(imgTypeId,imgId);
                if (list_next.Count > 0)
                {
                    hlnkNext.Text = list_next[0].ImgName;
                    hlnkNext.NavigateUrl = "Image_Detail.aspx?id=" + list_next[0].ImgID;
                }
                else 
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
                img.ImageUrl = urlStr;
            }
        }
    }
}