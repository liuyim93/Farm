﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;

public partial class House_Search : System.Web.UI.Page
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
        if (Request.QueryString["typeId"] == "" || Request.QueryString["typeId"] == null)
        {
            Response.Redirect("House_Default.aspx");
        }
        else 
        {
            int imgTypeId=Convert.ToInt32(Request.QueryString["typeId"]);
            List<ImageType> list = ImageTypeBll.GetImageType(imgTypeId);
            if (list.Count>0)
            {
                ltlTitle.Text=list[0].TypeName;
                ltlBrowserText.Text = ltlTitle.Text + "-金水泊山庄";
            }
            DataTable dt = ImageBll.GetImagebyImgTypeId(imgTypeId);
            if (dt.Rows.Count>0)
            {
                this.AspNetPager1.RecordCount = dt.Rows.Count;
                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dt.DefaultView;
                pds.PageSize = AspNetPager1.PageSize;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                dlstHouseImage.DataSource = pds;
                dlstHouseImage.DataBind();
            }
        }
    }
    protected void dlstHouseImage_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Image img = e.Item.FindControl("imgHouse") as Image;
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