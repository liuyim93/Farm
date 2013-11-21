using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

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
                    admin.Password=row["Password"].ToString();
                    list.Add(admin);
                }
            }
            return list;
        }
    }
}
