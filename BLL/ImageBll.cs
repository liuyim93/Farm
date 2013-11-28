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
    }
}
