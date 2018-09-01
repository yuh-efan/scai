using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;
using System.Data;

namespace WZ.Data
{
    public class Pub_Number
    {
        private int num_len = 5;
        private string num_identifier;

        public Pub_Number(string pIdentifier)
        {
            this.num_identifier = pIdentifier;
        }

        /// <summary>
        /// 生成编号
        /// </summary>
        /// <returns></returns>
        public string GenerateNumber()
        {
            return GenerateNumber(DateTime.Now.ToString("yyMMddhhmm"));
        }

        public string GenerateNumber(string pTimeFormat)
        {
            string a1 = pTimeFormat;
            string a2 = GetNumber(num_identifier);

            int i = a2.Length;
            while (i < num_len)
            {
                a2 = "0" + a2;
                i++;
            }

            return a1 + "-" + a2;
        }

        private static object lock_number = new object();

        /// <summary>
        /// 获取编号
        ///  订单:ord 
        ///  产品:pro 
        ///  会员编号:user_num
        ///  会员卡号:user_card
        ///  推广号:user_tj
        /// </summary>
        /// <param name="pIdentifier">标识符</param>
        /// <returns></returns>
        private static string GetNumber(string pIdentifier)
        {
            lock (lock_number)
            {
                IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@num_identifier",pIdentifier)
                                  };

                return DbHelp.Scalar("Get_Pub_Number", CommandType.StoredProcedure, dp).ToString();
            }
        }

        /// <summary>
        /// 生成并获取用户交易号
        /// </summary>
        /// <returns></returns>
        public static string GetUserTransactionNumber(int pUserID)
        {
            return new Pub_Number("money").GenerateNumber(pUserID + DateTime.Now.ToString("yyMMddhhmmss"));
        }
    }
}
