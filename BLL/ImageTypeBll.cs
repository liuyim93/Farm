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

        /// <summary>
        /// 查询所有的图片分类
        /// </summary>
        /// <returns></returns>
        public static List<ImageType> GetAllImageType() 
        {
            string sql = "select * from ImageType";
            return ImageTypeDal.GetImageType(sql);
        }
        /// <summary>
        /// 根据父ID查询图片分类
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static List<ImageType> GetImageTypebyParentID(int parentId) 
        {
            string sql = "select * from ImageType where ParentID="+parentId+" order by Rank asc";
            return ImageTypeDal.GetImageType(sql);
        }

        /// <summary>
        /// 根据ID查询图片分类
        /// </summary>
        /// <param name="imgTypeId"></param>
        /// <returns></returns>
        public static List<ImageType> GetImageType(int imgTypeId) 
        {
            string sql = "select * from ImageType where ImgTypeID="+imgTypeId;
            return ImageTypeDal.GetImageType(sql);
        }

        /// <summary>
        /// 删除图片分类
        /// </summary>
        /// <param name="imgTypeId"></param>
        /// <returns></returns>
        public static int DeleteImageType(int imgTypeId) 
        {
            return ImageTypeDal.DeleteImageType(imgTypeId);
        }

        /// <summary>
        /// 修改图片分类
        /// </summary>
        /// <param name="imgType"></param>
        /// <returns></returns>
        public static int UpdateImageType(ImageType imgType) 
        {
            return ImageTypeDal.UpdateImageType(imgType);
        }

        /// <summary>
        /// 查询住宿设施分类
        /// </summary>
        /// <returns></returns>
        public static List<ImageType> GetHouse() 
        {
            string sql = "select * from ImageType where ParentID=(select ImgTypeID from ImageType where TypeName='住宿设施')";
            return ImageTypeDal.GetImageType(sql);
        }
    }
}
