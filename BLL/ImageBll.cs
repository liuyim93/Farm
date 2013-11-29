using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

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
    }
}
