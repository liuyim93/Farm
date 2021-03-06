﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;

public partial class Food : System.Web.UI.Page
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
        DataTable dt = ImageBll.GetAllFood();
        if (dt.Rows.Count>0)
        {
            AspNetPager1.RecordCount = dt.Rows.Count;
            PagedDataSource pds=new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.AllowPaging = true;
            dlstFood.DataSource = pds;
            dlstFood.DataBind();
        }
    }
    protected void dlstFood_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Image img = e.Item.FindControl("imgFood") as Image;
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
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Bind();
    }
}