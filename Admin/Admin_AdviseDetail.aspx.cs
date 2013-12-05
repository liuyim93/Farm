using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;

public partial class Admin_Admin_AdviseDetail : System.Web.UI.Page
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
        if (Session["AdminName"] == null || Session["AdminID"] == null)
        {
            Response.Redirect("Admin_Login.aspx");
        }
        else 
        {
            if (Request.QueryString["id"] == "" || Request.QueryString["id"] == null)
            {
                Response.Redirect("Admin_AdviseUnReply.aspx");
            }
            else 
            {
                int adviseId = Convert.ToInt32(Request.QueryString["id"]);
                List<Advise> list = AdviseBll.GetAdvise(adviseId);
                if (list.Count>0)
                {
                    lblTitle.Text=list[0].Title;
                    lblDetail.Text=list[0].Detail;
                    lblEmail.Text=list[0].Email;
                    lblPhone.Text=list[0].Phone;
                    lblRealName.Text=list[0].RealName;
                    txtReply.Text=list[0].Reply;
                    lblTime.Text=list[0].LoadTime;
                }
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtReply.Text == "")
        {
            MessageBox.Alert("回复内容不能为空", Page);
            txtReply.Focus();
        }
        else 
        {
            int adviseId = Convert.ToInt32(Request.QueryString["id"]);
            AdviseBll.Updateadvise(adviseId,txtReply.Text);
            MessageBox.Alert("修改成功！",Page);
            Bind();
        }
    }
}