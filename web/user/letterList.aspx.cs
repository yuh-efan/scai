using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using WZ.Client.Data;
using WZ.Common;
using WZ.Common.Config;
using WZ.Data.DataItem;
using Newtonsoft.Json;
using WZ.Common.ICommon;

namespace WZ.Web.user
{
    public partial class letterList : WZ.Client.Data.General.PageUser
    {
        protected ItemHandler kpRead = new ItemHandler("IsRead");

        protected void Page_Load(object sender, EventArgs e)
        {
            int hid = Fn.IsInt(Req.GetForm("hid"), 0);

            if (hid > 0)
            {
                switch (hid)
                {
                    case 1://删除
                        del();
                        break;
                }

                Response.Write(msgAjax.ReturnMessage);
                Response.End();
            }
            else
            {
                LL();
            }
        }

        private void LL()
        {
            string sqlSelect, sqlFrom, sqlWhere = string.Empty, sqlOrder, pkName;
            sqlSelect = "select LetSN,FK_User_From,FK_User_To,Title,IsRead,AddDate,(select UserName from User_Info where UserSN=User_Letter.FK_User_From) as fromUserName";
            sqlFrom = " from User_Letter";
            sqlWhere = " where FK_User_To=" + LoginInfo.UserID;
            sqlOrder = " order by AddDate desc";
            pkName = "LetSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(10));
            pg.load();
            Bind.BGRepeater(pg.GetDataTable(), this.rpList);

            this.ucPS1.f = pg;
        }

        private void del()
        {
            int id = Fn.IsInt(Req.GetForm("id"), 0);
            string sql = "delete from User_Letter where LetSN=" + id + " and FK_User_To=" + LoginInfo.UserID;
            DbHelp.Update(sql);
            msgAjax.Success("删除成功");
        }
    }
}