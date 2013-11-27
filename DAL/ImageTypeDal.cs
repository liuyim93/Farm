using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class ImageTypeDal
    {
        /// <summary>
        /// 添加图片类型
        /// </summary>
        /// <param name="imgType"></param>
        /// <returns></returns>
        public static int AddImageType(ImageType imgType) 
        {
            string sql = "insert into ImageType (TypeName,IsShow,Remark,Rank,ParentID) values(@TypeName,@IsShow,@Remark,@Rank,@ParentID)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@TypeName", imgType.TypeName),
                new OleDbParameter("@IsShow", imgType.IsShow),
                new OleDbParameter("@Remark", imgType.Remark),
                new OleDbParameter("@Rank", imgType.Rank),
                new OleDbParameter("@ParentID", imgType.ParentID));
        }

        /// <summary>
        /// 查询图片分类
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<ImageType> GetImageType(string sql) 
        {
            List<ImageType> list = new List<ImageType>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ImageType imgType = new ImageType();
                    imgType.ImgTypeID = Convert.ToInt32(row["ImgTypeID"]);
                    imgType.TypeName=row["TypeName"].ToString();
                    imgType.IsShow = Convert.ToInt32(row["IsShow"]);
                    imgType.Remark=row["Remark"].ToString();
                    imgType.Rank = Convert.ToInt32(row["Rank"]);
                    imgType.ParentID = Convert.ToInt32(row["ParentID"]);
                    list.Add(imgType);
                }
            }
            return list;
        }
    }
}
