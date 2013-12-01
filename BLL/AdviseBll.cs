﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
     public class AdviseBll
    {
         /// <summary>
         /// 添加留言
         /// </summary>
         /// <param name="advise"></param>
         /// <returns></returns>
         public static int AddAdvise(Advise advise) 
         {
             return AdviseDal.AddAdvise(advise);
         }

         /// <summary>
         /// 查询待回复的留言
         /// </summary>
         /// <returns></returns>
         public static List<Advise> GetAdviseUnReply() 
         {
             string sql = "select * from Advise where Reply=''";
             return AdviseDal.GetAdvise(sql);
         }

         /// <summary>
         /// 查询已回复的留言
         /// </summary>
         /// <returns></returns>
         public static List<Advise> GetAdviseReplyed() 
         {
             string sql = "select * from Advise where Reply<>''";
             return AdviseDal.GetAdvise(sql);
         }

         /// <summary>
         /// 修改回复
         /// </summary>
         /// <param name="adviseId"></param>
         /// <param name="reply"></param>
         /// <returns></returns>
         public static int UpdateAdvise(int adviseId,string reply) 
         {
             return AdviseDal.UpdateAdvise(adviseId,reply);
         }

         /// <summary>
         /// 删除留言
         /// </summary>
         /// <param name="adviseId"></param>
         /// <returns></returns>
         public static int DeleteAdvise(int adviseId) 
         {
             return AdviseDal.DeleteAdvise(adviseId);
         }
    }
}