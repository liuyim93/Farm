using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class ImageBll
    {
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static int AddImage(Image img) 
        {
            return ImageDal.AddImage(img);
        }

        /// <summary>
        /// 查询所有的图片
        /// </summary>
        /// <returns></returns>
        public static List<Image> GetAllImage() 
        {
            string sql = "select * from [Image] order by LoadTime desc";
            return ImageDal.GetImage(sql);
        }

        /// <summary>
        /// 根据ID查询图片
        /// </summary>
        /// <param name="imgId"></param>
        /// <returns></returns>
        public static List<Image> GetImage(int imgId) 
        {
            string sql = "select * from [Image] where ImgID="+imgId;
            return ImageDal.GetImage(sql);
        }

        /// <summary>
        /// 修改图片信息
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static int UpdateImage(Image img) 
        {
            return ImageDal.UpdateImage(img);
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="imgId"></param>
        /// <returns></returns>
        public static int DeleteImage(int imgId) 
        {
            return ImageDal.DeleteImage(imgId);
        }

        /// <summary>
        /// 查询首页顶部5张图片
        /// </summary>
        /// <returns></returns>
        public static List<Image> GetHomeTopImage_Top5() 
        {
            string sql = "select top 5 * from [Image] where IsHomeTopShow=1";
            return ImageDal.GetImage(sql);
        }

        /// <summary>
        /// 查询首页底部10张图片
        /// </summary>
        /// <returns></returns>
        public static List<Image> GetHomeBottomImage_Top10() 
        {
            string sql = "select top 10 * from [Image] where IsHomeBottomShow=1";
            return ImageDal.GetImage(sql);
        }

        /// <summary>
        /// 查询住宿设施所有图片
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllHouseImage() 
        {
            string sql = "select * from [Image] where ImgTypeID in (select ImgTypeID from ImageType where ParentID=(select ImgTypeID from ImageType where TypeName='住宿设施'))";
            return ImageDal.GetImages(sql);
        }
    }
}
