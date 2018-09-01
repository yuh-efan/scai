using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;

namespace WZ.Data
{
    public class User_CardL
    {
        /// <summary>
        /// 是否有会员卡可以使用
        /// </summary>
        /// <param name="pNumber">会员卡号码</param>
        /// <param name="?"></param>
        /// <returns></returns>
        public static bool IsUse(string pNumber, out int pExp)
        {
            string sql = "select card_Exp from User_Card where card_Status=0 and card_Number=@card_Number";
            IDataParameter[] dp = { 
                                            DbHelp.Def.AddParam("@card_Number",pNumber),
                                            };

            using (IDataReader dr = DbHelp.Read(sql, dp))
            {
                if (dr.Read())
                {
                    pExp = int.Parse(dr["card_Exp"].ToString());
                    return true;
                }
                else
                {
                    pExp = 0;
                    return false;
                }
            }
        }
    }
}
