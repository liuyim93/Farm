using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class NewsDal
    {
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public static int AddNews(News news) 
        {
            string sql = "insert into News (Title,NewsTypeID,Author,AdminID,Detail,LoadTime,ClickNum)values(@Title,@NewsTypeID,@Author,@AdminID,@Detail,@LoadTime,@ClickNum)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@Title", news.Title),
                new OleDbParameter("@NewsTypeID", news.NewsTypeID),
                new OleDbParameter("@Author", news.Author),
                new OleDbParameter("@AdminID", news.AdminID),
                new OleDbParameter("@Detail", news.Detail),
                new OleDbParameter("@LoadTime", news.LoadTime),
                new OleDbParameter("@ClickNum", news.ClickNum));
        }

        /// <summary>
        /// 查询文章信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<News> GetNews(string sql) 
        {
            List<News> list = new List<News>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    News news = new News();
                    news.NewsID = Convert.ToInt32(row["NewsID"]);
                    news.NewsTypeID = Convert.ToInt32(row["NewsTypeID"]);
                    news.Title=row["Title"].ToString();
                    news.AdminID = Convert.ToInt32(row["AdminID"]);
                    news.Author=row["Author"].ToString();
                    news.ClickNum = Convert.ToInt32(row["ClickNum"]);
                    news.Detail=row["Detail"].ToString();
                    news.LoadTime = row["LoadTime"].ToString();
                    list.Add(news);
                }
            }
            return list;
        }

        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public static int UpdateNews(News news) 
        {
            string sql = "update News set Title=@Title,NewsTypeID=@NewsTypeID,AdminID=@AdminID,Author=@Author,ClickNum=@ClickNum,Detail=@Detail where NewsID=@NewsID";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@Title", news.Title),
                new OleDbParameter("@NewsTypeID", news.NewsTypeID),
                new OleDbParameter("@AdminID", news.AdminID),
                new OleDbParameter("@Author", news.Author),
                new OleDbParameter("@ClickNum", news.ClickNum),
                new OleDbParameter("@Detail", news.Detail),
                new OleDbParameter("@NewsID", news.NewsID));
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public static int DeleteNews(int newsId) 
        {
            string sql = "delete from News where NewsID=@NewsID";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@NewsID", newsId));
        }
    }
}
