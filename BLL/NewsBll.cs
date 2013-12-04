using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;

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

        /// <summary>
        /// 查询最新的5条新闻动态
        /// </summary>
        /// <returns></returns>
        public static List<News> GetNews_Top5() 
        {
            string sql = "select top 5 * from News where NewsTypeID=(select NewsTypeID from NewsType where TypeName='新闻动态') order by LoadTime desc";
            return NewsDal.GetNews(sql);
        }

        /// <summary>
        /// 查询最新的6条活动信息
        /// </summary>
        /// <returns></returns>
        public static List<News> GetActivity_Top6() 
        {
            string sql = "select top 6 * from News where NewsTypeID=(select NewsTypeID from NewsType where TypeName='精彩活动') order by LoadTime desc";
            return NewsDal.GetNews(sql);
        }

        /// <summary>
        /// 查询所有的新闻动态
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllnews() 
        {
            string sql = "select * from News order by LoadTime desc";
            return NewsDal.Getnews(sql);
        }
    }
}
