using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class AdminBll
    {
        /// <summary>
        /// 根据用户名和密码查询管理员
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static List<Admin> GetAdmin(string userName,string pwd) 
        {
            string sql = "select * from Admin where UserName='"+userName+"' and Password='"+pwd+"'";
            return AdminDal.GetAdmin(sql);
        }
    }
}
