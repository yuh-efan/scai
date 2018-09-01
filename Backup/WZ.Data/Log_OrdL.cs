using System;
using System.Collections.Generic;
using System.Text;
using WZ.Model;
using System.Data;
using WZ.Common;
using System.Web;

namespace WZ.Data
{
    /// <summary>
    /// 订单日志
    /// </summary>
    public class Log_OrdL
    {
        #region help
        protected IDbHelp curHelp;

        public Log_OrdL()
        {
            this.curHelp = new DefaultHelp();
        }

        public Log_OrdL(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        public bool Add(Log_OrdM pMod)
        {
            pMod.IP = HttpContext.Current.Request.UserHostAddress;
            const string sSQL = "insert into Log_Ord(FK_Ord,FK_User,Operator,Remark,IP) values(@FK_Ord,@FK_User,@Operator,@Remark,@IP)";
            IDataParameter[] dp = { 
                                    DbHelp.Def.AddParam("@FK_Ord",pMod.FK_Ord),
                                    DbHelp.Def.AddParam("@FK_User",pMod.FK_User),
                                    DbHelp.Def.AddParam("@Operator",pMod.Operator),
                                    DbHelp.Def.AddParam("@Remark",pMod.Remark),
                                    DbHelp.Def.AddParam("@IP",pMod.IP),
                                      };

            return curHelp.Update(sSQL, dp) > 0;
        }

        public static Paging List(int pOrderId, int pPageSize)
        {
            string sOrder = " order by AddDate desc";
            string sWhere = " where FK_Ord=" + pOrderId;

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0) from Log_Ord" + sWhere;
            pv.SQLRead = "select LOSN from Log_Ord" + sWhere + sOrder;
            pv.SQL = "select LOSN,FK_Ord,FK_User,Operator,Remark,AddDate,IP from Log_Ord where LOSN in({0})" + sOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(pPageSize));
            pg.load();
            return pg;
        }
    }
}
