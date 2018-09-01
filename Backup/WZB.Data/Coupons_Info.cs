using System;
using System.Collections.Generic;
using System.Text;
using WZ.Model;
using System.Data;
using WZ.Common;
using System.Web;
using WZ.Data;

namespace WZ.Client.Data
{
    public class Coupons_Info
    {
        public static Paging List(int pUserId, string pType)
        {
            string sOrder = " order by CouponsCodeSN desc";
            string sWhere = " where FK_User=" + pUserId;

            switch (pType)
            {
                case "used":
                    sWhere += " and Status=1";
                    break;
                case "unused":
                    sWhere += " and Status=0 and getdate() between StartTime and EndTime";
                    break;
                case "out":
                    sWhere += " and Status=0 and getdate() not between StartTime and EndTime";
                    break;
                default:
                    break;
            }

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0) from Act_Coupons_Code" + sWhere;
            pv.SQLRead = "select CouponsCodeSN from Act_Coupons_Code" + sWhere + sOrder;
            pv.SQL = "select CodeNumber,Item,StartTime,EndTime,Remark,Status from Act_Coupons_Code left join Act_Rule on FK_Rule=RuleSN where CouponsCodeSN in({0})" + sOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(10));
            pg.load();
            return pg;
        }
    }
}
