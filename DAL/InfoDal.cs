using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.OleDb;
using DAL;

namespace DAL
{
    public class InfoDal
    {
        /// <summary>
        /// 添加网站信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int AddInfo(FarmInfo info) 
        {
            string sql = "insert into FarmInfo (FarmName,Phone,Mobile,Adress,Linkman,Email)values(@FarmName,@Phone,@Mobile,@Adress,@Linkman,@Email)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@FarmName", info.FarmName),
                new OleDbParameter("@Phone", info.Phone),
                new OleDbParameter("@Mobile", info.Mobile),
                new OleDbParameter("@Adress", info.Adress),
                new OleDbParameter("@Linkman", info.Linkman),
                new OleDbParameter("@Email", info.Email));
        }

        /// <summary>
        /// 查询网站信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<FarmInfo> GetInfo(string sql) 
        {
            List<FarmInfo> list = new List<FarmInfo>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    FarmInfo info = new FarmInfo();
                    info.InfoID = Convert.ToInt32(row["InfoID"]);
                    info.FarmName=row["FarmName"].ToString();
                    info.Phone=row["Phone"].ToString();
                    info.Linkman=row["Linkman"].ToString();
                    info.Mobile=row["Mobile"].ToString();
                    info.Adress=row["Adress"].ToString();
                    info.Email=row["Email"].ToString();
                    list.Add(info);
                }
            }
            return list;
        }

        ///// <summary>
        ///// 修改网站信息
        ///// </summary>
        ///// <param name="info"></param>
        ///// <returns></returns>
        //public static int UpdateInfo(FarmInfo info) 
        //{
        //    string sql = "update FarmInfo set FarmName=@FarmName,Phone=@Phone,Linkman=@Linkman,Mobile=@Mobile,Adress=@Adress,Email=@Email where InfoID=@InfoID";
        //    return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@InfoID", info.InfoID),
        //        new OleDbParameter("@FarmName", info.FarmName),
        //        new OleDbParameter("@Phone", info.Phone),
        //        new OleDbParameter("@Linkman", info.Linkman),
        //        new OleDbParameter("@Mobile", info.Mobile),
        //        new OleDbParameter("@Adress", info.Adress),
        //        new OleDbParameter("@Email", info.Email));
        //}

        /// <summary>
        /// 修改农庄信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int UpdateInfo(FarmInfo info) 
        {
            string sql = "update FarmInfo set FarmName='"+info.FarmName+"',Phone='"+info.Phone+"',Linkman='"+info.Linkman+"',Mobile='"+info.Mobile+"',Adress='"+info.Adress+"',Email='"+info.Email+"' where InfoID="+info.InfoID;
            return SqlHelper.DoSql(sql);
        }

    }
}
