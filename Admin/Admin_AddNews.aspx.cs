using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using Tools;

public partial class Admin_Admin_AddNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindNewsType();
            dropNewsType.Items.Insert(0, "请选择分类");
            dropNewsType.SelectedItem.Text = "请选择分类";
            Bind();
        }
    }
    public void Bind() 
    {
        
        if (Request.QueryString["id"]!=null&&Request.QueryString["id"]!="")
        {
            int newsId = Convert.ToInt32(Request.QueryString["id"]);
            List<News> list = NewsBll.GetNews(newsId);
            if (list.Count>0)
            {
                txtAuthor.Text=list[0].Author;
                txtTitle.Text=list[0].Title;
                txtClickNum.Text=list[0].ClickNum.ToString();
                fckeditor1.Value=list[0].Detail;
                dropNewsType.SelectedValue=list[0].NewsTypeID.ToString();
                hfNewsID.Value=list[0].NewsID.ToString();
            }
        }
    }

    public void BindNewsType() 
    {
        dropNewsType.DataSource = NewsTypeBll.GetAllNewsType();
        dropNewsType.DataTextField = "TypeName";
        dropNewsType.DataValueField = "NewsTypeID";
        dropNewsType.DataBind();
    }

    public void ClearText() 
    {
        txtTitle.Text = "";
        txtClickNum.Text = "";
        txtAuthor.Text = "";
        fckeditor1.Value = "";
        hfNewsID.Value="";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text == "")
        {
            MessageBox.Alert("文章标题不能为空", Page);
            txtTitle.Focus();
        }
        else if (dropNewsType.SelectedItem.Text == "请选择分类")
        {
            MessageBox.Alert("文章分类不能为空", Page);
            dropNewsType.Focus();
        }
        else if (fckeditor1.Value == "")
        {
            MessageBox.Alert("文章内容不能为空", Page);
            fckeditor1.Focus();
        }
        else
        {
            News news = new News();
            news.Title = txtTitle.Text;
            news.Detail = fckeditor1.Value;
            news.Author = txtAuthor.Text;
            news.AdminID=Convert.ToInt32(Session["AdminID"]);
            news.NewsTypeID = Convert.ToInt32(dropNewsType.SelectedValue);
            if (txtClickNum.Text == "")
            {
                news.ClickNum = 0;
            }
            else 
            {
                news.ClickNum = Convert.ToInt32(txtClickNum.Text.Trim());
            }
            if (hfNewsID.Value == "")
            {
                news.LoadTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                NewsBll.AddNews(news);
                MessageBox.Alert("添加成功", Page);                
            }
            else 
            {
                news.NewsID = Convert.ToInt32(hfNewsID.Value);
                NewsBll.UpdateNews(news);
                MessageBox.Alert("修改成功",Page);
            }
            ClearText();
        }
    }
}