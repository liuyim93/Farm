using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;

public partial class Admin_Admin_NewsTypeManage : System.Web.UI.Page
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
            gvwNewsType.DataSource = NewsTypeBll.GetAllNewsType();
            gvwNewsType.DataBind();
        }
    }

    public void ClearText() 
    {
        txtTypeName.Text = "";
        txtRemark.Text = "";
        hfNewsTypeID.Value = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtRemark.Text == "")
        {
            lblMsg.Text = "类别名称不能为空";
            txtRemark.Focus();
        }
        else 
        {
            NewsType newsType = new NewsType();
            newsType.Remark = txtRemark.Text;
            newsType.TypeName = txtTypeName.Text;
            if (hfNewsTypeID.Value == "")
            {
                NewsTypeBll.AddNewsType(newsType);
                MessageBox.Alert("添加成功", Page);
            }
            else 
            {
                newsType.NewsTypeID = Convert.ToInt32(hfNewsTypeID.Value);
                NewsTypeBll.UpdateNewsType(newsType);
                MessageBox.Alert("修改成功",Page);
            }
            ClearText();
            Bind();
        }
    }
    protected void gvwNewsType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "change":
                int newTypeId = Convert.ToInt32(e.CommandArgument);
                List<NewsType> list = NewsTypeBll.GetNewsType(newTypeId);
                txtRemark.Text =list[0].Remark;
                txtTypeName.Text=list[0].TypeName;
                hfNewsTypeID.Value=list[0].NewsTypeID.ToString();
                break;
            case "del":
                int newsTypeId = Convert.ToInt32(e.CommandArgument);
                NewsTypeBll.DeleteNewsType(newsTypeId);
                MessageBox.Alert("删除成功",Page);
                Bind();
                break;
            default:
                break;
        }
    }
    protected void gvwNewsType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {
            Label lblNum = e.Row.FindControl("lblNum") as Label;
            lblNum.Text = (e.Row.RowIndex + 1).ToString();
        }
    }
}