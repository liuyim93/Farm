using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class NewsBll
    {
        /// <summary>
        /// 添加文章资讯
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public static int AddNews(News news) 
        {
            return NewsDal.AddNews(news);
        }

        /// <summary>
        /// 查询所有的文章
        /// </summary>
        /// <returns></returns>
        public static List<News> GetAllNews() 
        {
            string sql = "select * from News";
            return NewsDal.GetNews(sql);
        }

        /// <summary>
        /// 根据ID查询文章资讯
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public static List<News> GetNews(int newsId) 
        {
            string sql = "select * from News where NewsID="+newsId;
            return NewsDal.GetNews(sql);
        }

        /// <summary>
        /// 根据分类查询文章
        /// </summary>
        /// <param name="newsTypeId"></param>
        /// <returns></returns>
        public static List<News> GetNewsbyTypeId(int newsTypeId) 
        {
            string sql = "select * from News where NewsTypeID="+newsTypeId;
            return NewsDal.GetNews(sql);
        }

        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public static int UpdateNews(News news) 
        {
            return NewsDal.UpdateNews(news);
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public static int DeleteNews(int newsId) 
        {
            return NewsDal.DeleteNews(newsId);
        }
    }
}
