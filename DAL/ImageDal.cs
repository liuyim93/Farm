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
            string sql = "insert into [Image] (ImgName,ImgUrl,Remark,AdminID,ImgTypeID,IsShow,LoadTime)values(@ImgName,@ImgUrl,@Remark,@AdminID,@ImgTypeID,@IsShow,@LoadTime)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@ImgName", img.ImgName),
                new OleDbParameter("@ImgUrl", img.ImgUrl),
                new OleDbParameter("@Remark", img.Remark),
                new OleDbParameter("@AdminID", img.AdminID),
                new OleDbParameter("@ImgTypeID", img.ImgTypeID),
                new OleDbParameter("@IsShow", img.IsShow),
                new OleDbParameter("@LoadTime", img.LoadTime.ToString("yyyy-MM-dd hh:mm:ss")));
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
                    img.LinkUrl=row["LinkUrl"].ToString();
                    img.IsHomeTopShow = Convert.ToInt32(row["IsHomeTopShow"]);
                    img.IsHomeBottomShow = Convert.ToInt32(row["IsHomeBottomShow"]);
                    list.Add(img);
                }
            }
            return list;
        }

        // <summary>
        // 修改图片
        // </summary>
        // <param name="img"></param>
        // <returns></returns>
        //public static int UpdateImage(Image img) 
        //{
        //    string sql = "update [Image] set ImgName=@ImgName,ImgUrl=@ImgUrl,Remark=@Remark,AdminID=@AdminID,[ImgTypeID]=@ImgTypeID,IsShow=@IsShow where ImgID="+img.ImgID;
        //    return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@ImgName", img.ImgName),
        //        new OleDbParameter("@Remark", img.Remark),
        //        new OleDbParameter("@AdminID", img.AdminID),
        //        new OleDbParameter("@ImgTypeID", img.ImgTypeID),
        //        new OleDbParameter("@ImgUrl", img.ImgUrl),
        //        new OleDbParameter("@IsShow", img.IsShow));
        //}

        public static int UpdateImage(Image img) 
        {
            string sql = "update [Image] set ImgName='"+img.ImgName+"',ImgUrl='"+img.ImgUrl+"',Remark='"+img.Remark+"',AdminID="+img.AdminID+",ImgTypeID="+img.ImgTypeID+",IsShow="+img.IsShow+" where ImgID="+img.ImgID;
            return SqlHelper.DoSql(sql);
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="imgId"></param>
        /// <returns></returns>
        public static int DeleteImage(int imgId) 
        {
            string sql = "delete from [Image] where ImgID=@ImgID";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@ImgID",imgId));
        }

        /// <summary>
        /// 查询图片(datatable)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>返回表</returns>
        public static DataTable GetImages(string sql) 
        {
            DataTable dt = SqlHelper.GetDs(sql).Tables[0];
            return dt;
        }
    }
}
