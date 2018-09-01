using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Model;
using WZ.Common;
using System.Web;

namespace WZ.Data
{
    /// <summary>
    /// 会员等级日志
    /// </summary>
    public class Log_SetUserLevelL
    {
        #region help
        protected IDbHelp curHelp;

        public Log_SetUserLevelL()
        {
            this.curHelp = new DefaultHelp();
        }

        public Log_SetUserLevelL(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        public bool Add(Log_SetUserLevelM pMod)
        {
            pMod.IP = HttpContext.Current.Request.UserHostAddress;

            const string sSQL = "insert into Log_SetUserLevel(FK_User,Operator,SetLevel,Remark,IP) values(@FK_User,@Operator,@SetLevel,@Remark,@IP)";
            IDataParameter[] dp = { 
                                      DbHelp.Def.AddParam("@FK_User",pMod.FK_User),
                                      DbHelp.Def.AddParam("@Operator",pMod.Operator),
                                    DbHelp.Def.AddParam("@SetLevel",pMod.SetLevel),
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
            pv.SQLCount = "select count(0) from Log_SetUserLevel" + sWhere;
            pv.SQLRead = "select SULSN from Log_SetUserLevel" + sWhere + sOrder;
            pv.SQL = "select SULSN,FK_User,Operator,SetLevel,Remark,AddDate,IP from Log_SetUserLevel where SULSN in({0})" + sOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(pPageSize));
            pg.load();
            return pg;
        }
    }
}
