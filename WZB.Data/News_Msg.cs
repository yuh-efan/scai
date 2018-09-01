using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;
using WZ.Model;
using System.Data;

namespace WZ.Client.Data
{
    public class News_Msg
    {
        public static Paging GetMsgList(int newsId)
        {
            string sOrder = " order by msgSN desc";
            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0) from News_Msg where  Purview='0' and FK_News=" + newsId;
            pv.SQLRead = "select msgSN from News_Msg where  Purview='0' and FK_News=" + newsId + sOrder;
            pv.SQL = "select userName,Detail,News_msg.AddDate as date from News_Msg left join User_Info on user_Info.usersn=News_msg.FK_user where msgSN in({0}) " + sOrder;
            Paging pg = new Paging(pv, new PagingUrlVar(12));
            pg.load();
            return pg;
        }

        public static int Add(News_MsgM pMod)
        {
            string sql = "insert News_msg (FK_User,FK_News,Detail,Purview) values(@FK_User,@FK_News,@Detail,@Purview)";

            IDataParameter[] param ={
                DbHelp.Def.AddParam("@FK_User",pMod.FK_User),
                DbHelp.Def.AddParam("@FK_News",pMod.FK_News),
                DbHelp.Def.AddParam("@Detail",pMod.Detail),
                DbHelp.Def.AddParam("@Purview",pMod.Purview)
                };
            int count = DbHelp.Update(sql, param);
            return count;
        }
    }
}
