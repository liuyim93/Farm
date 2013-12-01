using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;

public partial class Admin_Admin_AdviseUnReply : System.Web.UI.Page
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
            gvwAdviseList.DataSource = AdviseBll.GetAdviseUnReply();
            gvwAdviseList.DataBind();
        }
    }
    protected void btnDelSelect_Click(object sender, EventArgs e)
    {
         int chkNum = 0;
        for (int i = 0; i < gvwAdviseList.Rows.Count; i++)
        {
             CheckBox chkSelect=gvwAdviseList.Rows[i].FindControl("chkSelect")as CheckBox;
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
            for (int i = 0; i < gvwAdviseList.Rows.Count; i++)
            {
                 CheckBox chkSelect=gvwAdviseList.Rows[i].FindControl("chkSelect")as CheckBox;
                 if (chkSelect.Checked)
                 {
                     int adviseId = Convert.ToInt32(gvwAdviseList.DataKeys[i].Value);
                     AdviseBll.DeleteAdvise(adviseId);
                 }
            }
            MessageBox.Alert("删除成功",Page);
            Bind();
        }
    }
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSelectAll.Checked)
        {
            int chkNum = 0;
            for (int i = 0; i < gvwAdviseList.Rows.Count; i++)
            {
                CheckBox chkSelect = gvwAdviseList.Rows[i].FindControl("chkSelect") as CheckBox;
                if (chkSelect.Checked)
                {
                    chkNum++;
                }
            }
            if (chkNum == 0)
            {
                for (int i = 0; i < gvwAdviseList.Rows.Count; i++)
                {
                    CheckBox chkSelect = gvwAdviseList.Rows[i].FindControl("chkSelect") as CheckBox;
                    chkSelect.Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < gvwAdviseList.Rows.Count; i++)
                {
                    CheckBox chkSelect = gvwAdviseList.Rows[i].FindControl("chkSelect") as CheckBox;
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
            for (int i = 0; i < gvwAdviseList.Rows.Count; i++)
            {
                CheckBox chkSelect = gvwAdviseList.Rows[i].FindControl("chkSelect") as CheckBox;
                chkSelect.Checked = false;
            }
        }
    }
}