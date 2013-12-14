using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class InfoBll
    {
        /// <summary>
        /// 添加网站信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int AddInfo(FarmInfo info) 
        {
            return InfoDal.AddInfo(info);
        }

        /// <summary>
        /// 查询网站信息
        /// </summary>
        /// <returns></returns>
        public static List<FarmInfo> GetFarmInfo() 
        {
            string sql = "select * from FarmInfo";
            return InfoDal.GetInfo(sql);
        }

        /// <summary>
        /// 修改网站信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int UpdateInfo(FarmInfo info) 
        {
            return InfoDal.UpdateInfo(info);
        }
    }
}
