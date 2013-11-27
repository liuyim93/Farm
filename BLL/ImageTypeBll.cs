using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class ImageTypeBll
    {
        /// <summary>
        /// 添加图片类型
        /// </summary>
        /// <param name="imgType"></param>
        /// <returns></returns>
        public static int AddImageType(ImageType imgType) 
        {
            return ImageTypeDal.AddImageType(imgType);
        }
    }
}
