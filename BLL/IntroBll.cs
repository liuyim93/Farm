using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;


namespace BLL
{
    public class IntroBll
    {
        /// <summary>
        /// 根据ID查询简介
        /// </summary>
        /// <param name="introId"></param>
        /// <returns></returns>
        public static List<Intro> GetIntro(int introId) 
        {
            string sql = "select * from Intro where IntroID="+introId;
            return IntroDal.GetIntro(sql);
        }

        /// <summary>
        /// 根据分类ID查询简介
        /// </summary>
        /// <param name="introTypeId"></param>
        /// <returns></returns>
        public static List<Intro> GetIntrobyTypeId(int introTypeId) 
        {
            string sql = "select * from Intro where IntroTypeID="+introTypeId;
            return IntroDal.GetIntro(sql);
        }

        /// <summary>
        /// 查询所有的分类
        /// </summary>
        /// <returns></returns>
        public static List<IntroType> GetIntroType() 
        {
            string sql = "select * from IntroType";
            return IntroDal.GetIntroType(sql);
        }

        /// <summary>
        /// 修改简介、联系我们
        /// </summary>
        /// <param name="intro"></param>
        /// <returns></returns>
        public static int UpdateIntro(Intro intro) 
        {
            return IntroDal.UpdateIntro(intro);
        }
    }
}
