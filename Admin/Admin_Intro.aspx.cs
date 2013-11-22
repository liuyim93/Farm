using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;
using Model;
using BLL;

public partial class Admin_Admin_Intro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindIntroType();
            Bind();
        }
    }


    public void BindIntroType() 
    {
        if (Session["AdminID"] == null || Session["AdminName"] == null)
        {
            Response.Redirect("Admin_Login.aspx");
        }
        else 
        {
            dropIntroType.DataSource = IntroBll.GetIntroType();
            dropIntroType.DataTextField = "TypeName";
            dropIntroType.DataValueField = "IntroTypeID";
            dropIntroType.DataBind();
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
            int introTypeId = Convert.ToInt32(dropIntroType.SelectedValue);
            List<Intro> list = IntroBll.GetIntrobyTypeId(introTypeId);
            lblTitle.Text = dropIntroType.SelectedItem.Text;
            FCKeditor.Value=list[0].Detail;
            hfIntroID.Value=list[0].IntroID.ToString();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (FCKeditor.Value == "")
        {
            MessageBox.Alert("内容不能为空！", Page);
        }
        else 
        {
            Intro intro = new Intro();
            intro.IntroID = Convert.ToInt32(hfIntroID.Value);
            intro.Detail = FCKeditor.Value;
            intro.LoadTime = DateTime.Now;
            IntroBll.UpdateIntro(intro);
            MessageBox.Alert("修改成功！",Page);
            Bind();
        }
    }

    protected void dropIntroType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind();
    }
}