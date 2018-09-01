using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;

namespace WZ.Data
{
    public class User_Ticket_1L
    {
        /// <summary>
        /// 是否有购物券可以使用
        /// </summary>
        /// <param name="pNumber">购物券号码</param>
        /// <param name="?"></param>
        /// <returns></returns>
        public static bool IsUse(string pNumber,out double pPrice)
        {
            string sql = "select tic_Price from User_Ticket_1 where tic_Status=0 and tic_Number=@tic_Number";
            IDataParameter[] dp = { 
                                            DbHelp.Def.AddParam("@tic_Number",pNumber),
                                            };

            using (IDataReader dr = DbHelp.Read(sql, dp))
            {
                if (dr.Read())
                {
                    pPrice = double.Parse(dr["tic_Price"].ToString());
                    return true;
                }
                else
                {
                    pPrice = 0;
                    return false;
                }
            }
        }

    }
}
