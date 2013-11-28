using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Model;

namespace DAL
{
    public class ImageDal
    {
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static int AddImage(Image img)
        {
            string sql = "insert into Image (ImgName,ImgUrl,Remark,AdminID,ImgTypeID,IsShow,LoadTime)values(@ImgName,@ImgUrl,@Remark,@AdminID,@ImgTypeID,@IsShow,@LoadTime)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@ImgName", img.ImgName),
                new OleDbParameter("@ImgUrl", img.ImgUrl),
                new OleDbParameter("@Remark", img.Remark),
                new OleDbParameter("@AdminID", img.AdminID),
                new OleDbParameter("@ImgTypeID", img.ImgTypeID),
                new OleDbParameter("@IsShow", img.IsShow),
                new OleDbParameter("@LoadTime", img.LoadTime));
        }

        /// <summary>
        /// 查询图片
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<Image> GetImage(string sql)
        {
            List<Image> list = new List<Image>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Image img = new Image();
                    img.ImgID = Convert.ToInt32(row["ImgID"]);
                    img.ImgName=row["ImgName"].ToString();
                    img.ImgUrl=row["ImgUrl"].ToString();
                    img.ImgTypeID = Convert.ToInt32(row["ImgTypeID"]);
                    img.IsShow = Convert.ToInt32(row["IsShow"]);
                    img.Remark=row["Remark"].ToString();
                    img.LoadTime = Convert.ToDateTime(row["LoadTime"]);
                    list.Add(img);
                }
            }
            return list;
        }
    }
}
