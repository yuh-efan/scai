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
    /// 会员预存款日志
    /// </summary>
    public class Log_SetUserMoneyL
    {
        #region help
        protected IDbHelp curHelp;

        public Log_SetUserMoneyL()
        {
            this.curHelp = new DefaultHelp();
        }

        public Log_SetUserMoneyL(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        public bool Add(Log_SetUserMoneyM pMod)
        {
            pMod.IP = HttpContext.Current.Request.UserHostAddress;

            const string sSQL = "insert into Log_SetUserMoney(FK_User,Number,Operator,SetMoney,Remark,IP) values(@FK_User,@Number,@Operator,@SetMoney,@Remark,@IP)";
            IDataParameter[] dp = { 
                                      DbHelp.Def.AddParam("@FK_User",pMod.FK_User),
                                      DbHelp.Def.AddParam("@Number",pMod.Number),
                                      DbHelp.Def.AddParam("@Operator",pMod.Operator),
                                    DbHelp.Def.AddParam("@SetMoney",pMod.SetMoney),
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
            pv.SQLCount = "select count(0) from Log_SetUserMoney" + sWhere;
            pv.SQLRead = "select SUMID from Log_SetUserMoney" + sWhere + sOrder;
            pv.SQL = "select SUMID,FK_User,Number,Operator,SetMoney,Remark,AddDate,IP from Log_SetUserMoney where SUMID in({0})" + sOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(pPageSize));
            pg.load();
            return pg;
        }

       
    }
}
