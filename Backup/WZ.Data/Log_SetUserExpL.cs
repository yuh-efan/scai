using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using WZ.Model;
using System.Web;

namespace WZ.Data
{
    /// <summary>
    /// 会员经验日志
    /// </summary>
    public class Log_SetUserExpL
    {
        #region help
        protected IDbHelp curHelp;

        public Log_SetUserExpL()
        {
            this.curHelp = new DefaultHelp();
        }

        public Log_SetUserExpL(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        public bool Add(Log_SetUserExpM pMod)
        {
            pMod.IP = HttpContext.Current.Request.UserHostAddress;

            const string sSQL = "insert into Log_SetUserExp(FK_User,FK_All,Operator,Fract_Identifier,SetValue,Remark,IP) values(@FK_User,@FK_All,@Operator,@Fract_Identifier,@SetValue,@Remark,@IP)";
            IDataParameter[] dp = { 
                                      DbHelp.Def.AddParam("@FK_User",pMod.FK_User),
                                      DbHelp.Def.AddParam("@FK_All",pMod.FK_All),
                                      DbHelp.Def.AddParam("@Operator",pMod.Operator),
                                      DbHelp.Def.AddParam("@Fract_Identifier",pMod.Fract_Identifier),
                                    DbHelp.Def.AddParam("@SetValue",pMod.SetValue),
                                    DbHelp.Def.AddParam("@Remark",pMod.Remark),
                                    DbHelp.Def.AddParam("@IP",pMod.IP),
                                      };

            return curHelp.Update(sSQL, dp) > 0;

        }

        public static Paging List(int pUserID, int pPageSize)
        {
            string sOrder = " order by AddDate desc";
            string sWhere = " where FK_User=" + pUserID;

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0) from Log_SetUserExp" + sWhere;
            pv.SQLRead = "select SUISN from Log_SetUserIntegral" + sWhere + sOrder;
            pv.SQL = "select * from Log_SetUserIntegral where SUISN in({0})" + sOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(pPageSize));
            pg.load();
            return pg;
        }

        
    }
}
