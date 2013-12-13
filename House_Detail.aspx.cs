using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class House_Detail : System.Web.UI.Page
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
            Response.Redirect("House_Default.aspx");
        }
        else 
        {
            int imgId = Convert.ToInt32(Request.QueryString["id"]);           
            List<image> list = ImageBll.GetImage(imgId);            
            List<image> list_prev = ImageBll.GetPrevImage(list[0].ImgTypeID,imgId);
            if (list_prev.Count > 0)
            {
                lbtnPrev.Text = list_prev[0].ImgName;
                hfPrevImgID.Value=list_prev[0].ImgID.ToString();
            }
            else 
            {
                lbtnPrev.Text = "没有了";
            }
            List<image> list_next = ImageBll.GetNextImage(list[0].ImgTypeID,imgId);
            if (list_next.Count > 0)
            {
                lbtnNext.Text = list_next[0].ImgName;
                hfNextImgID.Value=list_next[0].ImgID.ToString();
            }
            else 
            {
                lbtnNext.Text = "没有了";
            }
            if (list.Count>0)
            {
                List<ImageType> list_imgType = ImageTypeBll.GetImageType(list[0].ImgTypeID);
                ltlTitle.Text=list_imgType[0].TypeName;
                ltlBrowserText.Text = ltlTitle.Text + "-金水泊山庄";
                lblImgName.Text =list[0].ImgName;
                lblRemark.Text=list[0].Remark;
                ltlTime.Text=list[0].LoadTime.ToString();
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
    protected void lbtnPrev_Click(object sender, EventArgs e)
    {
        if (lbtnPrev.Text!="没有了"&&hfPrevImgID.Value!="")
        {
            int imgId = Convert.ToInt32(hfPrevImgID.Value);
            Response.Redirect("House_Detail.aspx?id="+imgId+"");
        }
    }
    protected void lbtnNext_Click(object sender, EventArgs e)
    {
        if (lbtnNext.Text!="没有了"&&hfNextImgID.Value!="")
        {
            int imgId = Convert.ToInt32(hfNextImgID.Value);
            Response.Redirect("House_Detail.aspx?id="+imgId+"");
        }
    }
}