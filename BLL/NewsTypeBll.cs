using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class NewsTypeBll
    {
        /// <summary>
        /// 添加文章分类
        /// </summary>
        /// <param name="newsType"></param>
        /// <returns></returns>
        public static int AddNewsType(NewsType newsType) 
        {
            return NewsTypeDal.AddNewsType(newsType);
        }

        /// <summary>
        /// 查询所有的文章分类
        /// </summary>
        /// <returns></returns>
        public static List<NewsType> GetAllNewsType() 
        {
            string sql = "select * from NewsType";
            return NewsTypeDal.GetNewsType(sql);
        }

        /// <summary>
        /// 根据ID查询文章分类
        /// </summary>
        /// <param name="newsTypeId"></param>
        /// <returns></returns>
        public static List<NewsType> GetNewsType(int newsTypeId) 
        {
            string sql = "select * from NewsType where NewsTypeID="+newsTypeId;
            return NewsTypeDal.GetNewsType(sql);
        }

        /// <summary>
        /// 修改文章分类
        /// </summary>
        /// <param name="newsType"></param>
        /// <returns></returns>
        public static int UpdateNewsType(NewsType newsType) 
        {
            return NewsTypeDal.UpdateNewsType(newsType);
        }

        /// <summary>
        /// 删除文章分类
        /// </summary>
        /// <param name="newsTypeId"></param>
        /// <returns></returns>
        public static int DeleteNewsType(int newsTypeId) 
        {
            return NewsTypeDal.DeleteNewsType(newsTypeId);
        }
    }
}
