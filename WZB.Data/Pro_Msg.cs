using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;
using WZ.Model;

namespace WZ.Client.Data
{
    public class Pro_Msg
    {
        public static Paging GetMsgList(int proId)
        {
            string sOrder = " order by msgSN desc";
            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0) from Pro_Msg where Purview='0' and FK_Pro=" + proId;
            pv.SQLRead = "select msgSN from Pro_Msg where Purview='0' and FK_Pro=" + proId + sOrder;
            pv.SQL = "select UserName,Detail,pro_msg.AddDate as date,IP from Pro_Msg left join User_Info on user_Info.usersn=pro_msg.FK_user where msgSN in({0}) " + sOrder;
            Paging pg = new Paging(pv, new PagingUrlVar(8));
            pg.load();
            return pg;
        }

        public static int Add(Pro_MsgM pMod)
        {
            string sql = "insert Pro_msg (FK_User,FK_Pro,Detail,IP,Purview) values(@FK_User,@FK_Pro,@Detail,@IP,@Purview)";

            IDataParameter[] param ={
                DbHelp.Def.AddParam("@FK_User",pMod.FK_User),
                DbHelp.Def.AddParam("@FK_Pro",pMod.FK_Pro),
                DbHelp.Def.AddParam("@Detail",pMod.Detail),
                DbHelp.Def.AddParam("@IP",pMod.IP),
                DbHelp.Def.AddParam("@Purview",pMod.Purview)
                };
            int count = DbHelp.Update(sql, param);
            return count;
        }

    }
}
