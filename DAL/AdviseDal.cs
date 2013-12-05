using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Model;

namespace DAL
{
    public class AdviseDal
    {
        /// <summary>
        ///添加留言
        /// </summary>
        /// <param name="advise"></param>
        /// <returns></returns>
        public static int AddAdvise(Advise advise) 
        {
            string sql = "insert into Advise (RealName,Title,Phone,Email,Detail,Reply,LoadTime,IPAdress)values(@RealName,@Title,@Phone,@Email,@Detail,@Reply,@LoadTime,@IPAdress)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@RealName", advise.RealName),
                new OleDbParameter("@Title", advise.Title),
                new OleDbParameter("@Phone", advise.Phone),
                new OleDbParameter("@Email", advise.Email),
                new OleDbParameter("@Detail", advise.Detail),
                new OleDbParameter("@Reply", advise.Reply),
                new OleDbParameter("@LoadTime", advise.LoadTime),
                new OleDbParameter("@IPAdress",advise.IPAdress));
        }

        /// <summary>
        /// 查询留言
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<Advise> GetAdvise(string sql) 
        {
            List<Advise> list = new List<Advise>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Advise advise = new Advise();
                    advise.AdviseID = Convert.ToInt32(row["AdviseID"]);
                    advise.RealName=row["RealName"].ToString();
                    advise.Title=row["Title"].ToString();
                    advise.Phone=row["Phone"].ToString();
                    advise.Email=row["Email"].ToString();
                    advise.Detail=row["Detail"].ToString();
                    advise.Reply=row["Reply"].ToString();
                    advise.LoadTime=row["LoadTime"].ToString();
                    advise.IPAdress=row["IPAdress"].ToString();
                    list.Add(advise);
                }
            }
            return list;
        }

        /// <summary>
        /// 回复留言
        /// </summary>
        /// <param name="adviseId"></param>
        /// <param name="reply"></param>
        /// <returns></returns>
        public static int UpdateAdvise(int adviseId,string reply) 
        {
            string sql = "update Advise set Reply=@Reply where AdviseID=@AdviseID";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@AdviseID",adviseId),
                new OleDbParameter("@Reply",reply));
        }

        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="adviseId"></param>
        /// <returns></returns>
        public static int DeleteAdvise(int adviseId) 
        {
            string sql = "delete from Advise where AdviseID=@AdviseID";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@AdviseID",adviseId));
        }

        /// <summary>
        /// 查询留言(datatable)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>datatable</returns>
        public static DataTable Getadvise(string sql)
        {
            DataTable dt=SqlHelper.GetDs(sql).Tables[0];
            return dt;
        }
    }
}
