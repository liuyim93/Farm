using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tools
{
    public class GridViewPager
    {
        public GridViewPager()
        {

        }
        public static string GetPageNum(DataSet Ds, GridView GridViewName, int PageSize)
        {
            int Page = 0, AllPage = 0, Next = 0, Pre = 0, StartCount = 0, EndCount = 0;
            string PageStr = "", QueryStr = "";
            string[] Temp_Arr = null;
            string FilePath = HttpContext.Current.Request.CurrentExecutionFilePath;
            string currentPath = HttpContext.Current.Request.Url.Query;
            //string SelPage = "&nbsp;&nbsp;转到<select name=SelPage id=SelPage onchange=\"javascript:location.href=this.value\">";
            int startIndex = currentPath.IndexOf("&");
            int startIndex2 = currentPath.IndexOf("=");
            if (startIndex < 0 && startIndex2 < 0) { QueryStr = "?"; }
            if (startIndex < 0)
            {
                //QueryStr = "?";
                if (startIndex2 > 0)
                {
                    Temp_Arr = currentPath.Split('=');
                    if (Temp_Arr[0] != "?Page")
                    {
                        QueryStr = "";
                        QueryStr = Temp_Arr[0] + "=" + Temp_Arr[1] + "&";
                    }
                    else
                    { QueryStr = "?"; }

                }
            }
            else
            {
                string Temp = null;
                string[] Params_Array = null;
                string[] nameValues = currentPath.Split('&');
                QueryStr = "";
                Temp = "";
                foreach (string param in nameValues)
                {
                    if (param.IndexOf("=") > 0)
                    {
                        Params_Array = param.Split('=');
                        if (Params_Array[0] != "Page")
                        {
                            Temp += Params_Array[0] + "=" + Params_Array[1] + "&";
                        }
                    }
                }
                QueryStr = Temp;
            }

            PagedDataSource ObjPds = new PagedDataSource();
            ObjPds.DataSource = Ds.Tables[0].DefaultView;
            ObjPds.AllowPaging = true;
            int Total = Ds.Tables[0].Rows.Count;
            ObjPds.PageSize = PageSize;

            if (HttpContext.Current.Request.QueryString["Page"] != null)
            {
                Page = Convert.ToInt32(HttpContext.Current.Request.QueryString["Page"]);
            }
            else
            {
                Page = 1;
            }
            ObjPds.CurrentPageIndex = Page - 1;
            GridViewName.DataSource = ObjPds;
            GridViewName.DataBind();
            if (Page < 1) Page = 1;
            if (PageSize != 0)
            {
                AllPage = (Total / PageSize);
                AllPage = ((Total % PageSize) != 0 ? AllPage + 1 : AllPage);
                AllPage = (AllPage == 0 ? 1 : AllPage);
            }
            Next = Page + 1;
            Pre = Page - 1;
            StartCount = (Page + 5) > AllPage ? AllPage - 9 : Page - 4;  //中间页起始序号
            EndCount = Page < 5 ? 10 : Page + 5; //中间页终止序号
            if (StartCount < 1) { StartCount = 1; }//为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (AllPage < EndCount) { EndCount = AllPage; }//页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内

            PageStr = "共" + AllPage + "页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            PageStr += Page > 1 ? "<a href=\"" + FilePath + QueryStr + "Page=1\">首页</a>&nbsp;&nbsp;<a href=\"" + FilePath + QueryStr + "Page=" + Pre + "\">上一页</a>" : "首页 上一页";
            for (int xk = StartCount; xk < EndCount; xk++)
            {

                PageStr += Page == xk ? "&nbsp;&nbsp;<font color=\"#ff0000\">" + xk + "</font>" : "&nbsp;&nbsp;<a href=\"" + FilePath + QueryStr + "Page=" + xk + "\">" + xk + "</a>";

            }

            PageStr += Page != AllPage ? "&nbsp;&nbsp;<a href=\"" + FilePath + QueryStr + "Page=" + Next + "\">下一页</a>&nbsp;&nbsp;<a href=\"" + FilePath + QueryStr + "Page=" + AllPage + "\">末页</a>" : " 下一页 末页&nbsp;&nbsp;";

            return PageStr;
        }
    }
}
