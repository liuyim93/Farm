using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class NewsTypeDal
    {
        /// <summary>
        /// 添加文章分类
        /// </summary>
        /// <param name="newsType"></param>
        /// <returns></returns>
        public static int AddNewsType(NewsType newsType)
        {
            string sql = "insert into NewsType (TypeName,Remark)values(@TypeName,@Remark)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@TypeName", newsType.TypeName),
                new OleDbParameter("@Remark", newsType.Remark));
        }

        /// <summary>
        /// 查询文章分类
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<NewsType> GetNewsType(string sql)
        {
            List<NewsType> list = new List<NewsType>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    NewsType newsType = new NewsType();
                    newsType.NewsTypeID = Convert.ToInt32(row["NewsTypeID"]);
                    newsType.Remark=row["Remark"].ToString();
                    newsType.TypeName=row["TypeName"].ToString();
                    list.Add(newsType);
                }
            }
            return list;
        }

        /// <summary>
        /// 修改文章分类
        /// </summary>
        /// <param name="newsType"></param>
        /// <returns></returns>
        public static int UpdateNewsType(NewsType newsType) 
        {
            string sql = "update NewsType set TypeName=@TypeName,Remark=@Remark where NewsTypeID=@NewsTypeID";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@TypeName", newsType.TypeName),
                new OleDbParameter("@Remark", newsType.Remark),
                new OleDbParameter("@NewsTypeID", newsType.NewsTypeID));
        }

        /// <summary>
        /// 删除文章分类
        /// </summary>
        /// <param name="newsTypeId"></param>
        /// <returns></returns>
        public static int DeleteNewsType(int newsTypeId) 
        {
            string sql = "delete from NewsType where NewsTypeID="+newsTypeId;
            return SqlHelper.DoSql(sql);
        }
    }
}
