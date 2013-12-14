using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Tools;
using System.Data;

public partial class Admin_Admin_Info : System.Web.UI.Page
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
            List<FarmInfo> list = InfoBll.GetFarmInfo();
            if (list.Count>0)
            {
                txtFarmName.Text=list[0].FarmName;
                txtAdress.Text=list[0].Adress;
                txtEmail.Text=list[0].Email;
                txtLinkman.Text=list[0].Linkman;
                txtMobile.Text=list[0].Mobile;
                txtPhone.Text=list[0].Phone;
                hfInfoID.Value=list[0].InfoID.ToString();
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtAdress.Text == "")
        {
            MessageBox.Alert("农庄地址不能为空！", Page);
        }
        else if(txtEmail.Text=="") 
        {
            MessageBox.Alert("邮箱不能为空！",Page);
        }
        else if (txtFarmName.Text == "")
        {
            MessageBox.Alert("农庄名称不能为空！", Page);
        }
        else if (txtLinkman.Text == "")
        {
            MessageBox.Alert("联系人不能为空！", Page);
        }
        else if (txtMobile.Text == "")
        {
            MessageBox.Alert("手机号码不能为空！", Page);
        }
        else if (txtPhone.Text == "")
        {
            MessageBox.Alert("电话号码不能为空!", Page);
        }
        else 
        {
            FarmInfo info = new FarmInfo();
            info.FarmName = txtFarmName.Text;
            info.Adress = txtAdress.Text;
            info.Email = txtEmail.Text;
            info.Linkman = txtLinkman.Text;
            info.Mobile = txtMobile.Text;
            info.Phone = txtPhone.Text;
            if (hfInfoID.Value != "")
            {
                info.InfoID = Convert.ToInt32(hfInfoID.Value);
                InfoBll.UpdateInfo(info);
                MessageBox.Alert("修改成功！",Page);
                Bind();
            }
            else 
            {
                InfoBll.AddInfo(info);
                MessageBox.Alert("添加成功！",Page);
                Bind();
            }
        }        
    }
}