using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;
using System.Data;

namespace WZ.Data
{
    public class Activity_InfoL
    {
        /// <summary>
        /// 是否开启此活动
        /// </summary>
        /// <param name="pIdentifier"></param>
        /// <returns></returns>
        public static bool IsOpen(string pIdentifier)
        {
            string sql = "select top 1 1 from Activity_Info where act_Status=1 and act_Identifier=@act_Identifier";
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@act_Identifier",pIdentifier),
                                  };

            return (DbHelp.First(sql, dp, "0") == "1");
        }
    }
}
