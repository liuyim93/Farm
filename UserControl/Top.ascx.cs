using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class UserControl_Top : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }        
    }

    protected string picStr;
    public void Bind() 
    {
        List<image> list = ImageBll.GetPics();
        if (list.Count>0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string imgUrls = list[i].ImgUrl;
                string[] ImgUrl = imgUrls.Split('/');
                string urlStr = string.Empty;
                for (int j = 0; j < ImgUrl.Length; j++)
                {
                    if (j != 0 && j != ImgUrl.Length - 1)
                    {
                        urlStr += ImgUrl[j] + "/";
                    }
                    else if (j == ImgUrl.Length - 1)
                    {
                        urlStr += ImgUrl[j];
                    }
                }
                if (i != list.Count - 1)
                {
                    picStr += "{url:'" + urlStr + "',link:'" + list[i].LinkUrl + "',time:5000},";
                }
                else 
                {
                    picStr += "{url:'"+urlStr+"',link:'"+list[i].LinkUrl+"',time:5000}";
                }               
            }
        }
    }
}