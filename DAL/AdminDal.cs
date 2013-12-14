using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class AdminDal
    {

        /// <summary>
        /// 查询管理员
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<Admin> GetAdmin(string sql) 
        {
            List<Admin> list = new List<Admin>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Admin admin=new Admin();
                    admin.AdminID=Convert.ToInt32(row["AdminID"]);
                    admin.UserName=row["UserName"].ToString();
                    admin.password=row["password"].ToString();
                    admin.Remark=row["Remark"].ToString();
                    list.Add(admin);
                }
            }
            return list;
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static int AddAdmin(Admin admin) 
        {
            string sql = "INSERT INTO Admin (UserName,[password],IsSuperAdmin,Remark) values (@UserName,@password,@IsSuperAdmin,@Remark)";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@UserName", admin.UserName),
                new OleDbParameter("@password", admin.password),
                new OleDbParameter("@IsSuperAdmin", admin.IsSuperAdmin),
                new OleDbParameter("@Remark", admin.Remark));
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static int DeleteAdmin(int adminId) 
        {
            string sql = "delete from Admin where AdminID=@AdminID";
            return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@AdminID",adminId));
        }

        ///// <summary>
        ///// 修改密码
        ///// </summary>
        ///// <param name="adminId"></param>
        ///// <param name="password"></param>
        ///// <returns></returns>
        //public static int UpdatePwd(int adminId,string password) 
        //{
        //    string sql = "update Admin set [password]=@password where AdminID=@AdminID";
        //    return SqlHelper.ExecuteNonQuery(CommandType.Text,sql,new OleDbParameter("@AdminID",adminId),
        //        new OleDbParameter("@password",password));
        //}

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static int UpdatePwd(int adminId,string pwd) 
        {
            string sql = "update Admin set [password]='"+pwd+"' where AdminID="+adminId;
            return SqlHelper.DoSql(sql);
        }
    }
}
