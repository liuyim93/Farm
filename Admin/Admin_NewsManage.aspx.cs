using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;

public partial class Admin_Admin_NewsManage : System.Web.UI.Page
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
        if (Session["AdminID"] == null || Session["AdminName"] == null)
        {
            Response.Redirect("Admin_Login.aspx");
        }
        else 
        {
            gvwNewsManage.DataSource = NewsBll.GetAllNews();
            gvwNewsManage.DataBind();
        }
    }
    protected void gvwNewsManage_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="type")
        {
            int typeId = Convert.ToInt32(e.CommandArgument);
            gvwNewsManage.DataSource = NewsBll.GetNewsbyTypeId(typeId);
            gvwNewsManage.DataBind();
        }
    }
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSelectAll.Checked)
        {
            int chkNum = 0;
            for (int i = 0; i < gvwNewsManage.Rows.Count; i++)
            {
                CheckBox chkSelect = gvwNewsManage.Rows[i].FindControl("chkSelect") as CheckBox;
                if (chkSelect.Checked)
                {
                    chkNum++;
                }
            }
            if (chkNum == 0)
            {
                for (int i = 0; i < gvwNewsManage.Rows.Count; i++)
                {
                    CheckBox chkSelect = gvwNewsManage.Rows[i].FindControl("chkSelect") as CheckBox;
                    chkSelect.Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < gvwNewsManage.Rows.Count; i++)
                {
                    CheckBox chkSelect = gvwNewsManage.Rows[i].FindControl("chkSelect") as CheckBox;
                    if (chkSelect.Checked)
                    {
                        chkSelect.Checked = false;
                    }
                    else
                    {
                        chkSelect.Checked = true;
                    }
                }
            }
        }
        else 
        {
            for (int i = 0; i < gvwNewsManage.Rows.Count; i++)
            {
                 CheckBox chkSelect=gvwNewsManage.Rows[i].FindControl("chkSelect")as CheckBox;
                 chkSelect.Checked = false;
            }
        }
    }

    protected void btnDelSelect_Click(object sender, EventArgs e)
    {
        int chkNum = 0;
        for (int i = 0; i < gvwNewsManage.Rows.Count; i++)
        {
             CheckBox chkSelect=gvwNewsManage.Rows[i].FindControl("chkSelect")as CheckBox;
             if (chkSelect.Checked)
             {
                 chkNum++;
             }
        }
        if (chkNum == 0)
        {
            MessageBox.Alert("请选择要删除的数据", Page);
        }
        else 
        {
            for (int i = 0; i < gvwNewsManage.Rows.Count; i++)
            {
                 CheckBox chkSelect=gvwNewsManage.Rows[i].FindControl("chkSelect")as CheckBox;
                 if (chkSelect.Checked)
                 {
                     int newsId = Convert.ToInt32(gvwNewsManage.DataKeys[i].Value);
                     NewsBll.DeleteNews(newsId);
                 }
            }
            MessageBox.Alert("删除成功",Page);
            Bind();
        }
    }
}