using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using System.Data.OleDb;

namespace DAL
{
    public class IntroDal
    {
        /// <summary>
        /// 查询简介
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<Intro> GetIntro(string sql) 
        {
            List<Intro> list = new List<Intro>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Intro intro = new Intro();
                    intro.IntroID=Convert.ToInt32(row["IntroID"]);
                    intro.IntroTypeID = Convert.ToInt32(row["IntroTypeID"]);
                    intro.LoadTime = Convert.ToDateTime(row["LoadTime"]);
                    intro.Detail=row["Detail"].ToString();
                    list.Add(intro);
                }
            }
            return list;
        }

        /// <summary>
        /// 查询分类
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<IntroType> GetIntroType(string sql) 
        {
            List<IntroType>list=new List<IntroType>();
            DataSet ds = SqlHelper.GetDs(sql);
            if (ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    IntroType introType = new IntroType();
                    introType.IntroTypeID=Convert.ToInt32(row["IntroTypeID"]);
                    introType.TypeName=row["TypeName"].ToString();
                    list.Add(introType);
                }
            }
            return list;
        }

        /// <summary>
        /// 修改简介和联系我们
        /// </summary>
        /// <param name="intro"></param>
        /// <returns></returns>
        public static int UpdateIntro(Intro intro) 
        {
            string sql = "update Intro set Detail=@Detail,LoadTime=@LoadTime where IntroID="+intro.IntroID;
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, new OleDbParameter("@Detail", intro.Detail),
                new OleDbParameter("@LoadTime", intro.LoadTime.ToString("yyyy-MM-dd hh:mm:ss")));
        }
    }
}
