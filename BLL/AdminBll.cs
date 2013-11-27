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

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static int AddAdmin(Admin admin) 
        {
            return AdminDal.AddAdmin(admin);
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static int DeleteAdmin(int adminId) 
        {
            return AdminDal.DeleteAdmin(adminId);
        }

        /// <summary>
        /// 查询除自身以外的管理员
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static List<Admin> GetAdmin(int adminId) 
        {
            string sql = "select * from Admin where AdminID<>"+adminId;
            return AdminDal.GetAdmin(sql);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static int UpdatePwd(int adminId,string pwd) 
        {
            return AdminDal.UpdatePwd(adminId,pwd);
        }

        /// <summary>
        /// 根据ID查询管理员信息
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static List<Admin> GetAdminbyId(int adminId) 
        {
            string sql = "select * from Admin where AdminID="+adminId;
            return AdminDal.GetAdmin(sql);
        }

        /// <summary>
        /// 根据登录名称查询管理员
        /// </summary>
        /// <param name="adminName"></param>
        /// <returns></returns>
        public static List<Admin> GetAdminbyName(string adminName) 
        {
            string sql = "select * from Admin where UserName='"+adminName+"'";
            return AdminDal.GetAdmin(sql);
        }
    }
}
