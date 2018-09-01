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
using WZ.Common;
using WZ.Client.Data;

namespace WZ.Web.user
{
    public partial class gift : WZ.Client.Data.General.PageUser
    {
        private int userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            userID = LoginInfo.UserID;
            if (!Page.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sql;
            sql = "select UserIntegral from User_Info where UserSN=" + userID;
            cUserIntegral .Text= DbHelp.First(sql, "0");

            List();
        }


        private void List()
        {
            string sqlSelect, sqlFrom, sqlWhere, sqlOrder, pkName;

            sqlSelect = "select ge.ExSN,gi.PicS,gi.GiftName,ge.AddDate,ge.ExIntegral,ge.Num";
            sqlFrom = " from Gift_ExchangeLog as ge left join Gift_Info as gi on ge.FK_Gift=gi.GiftSN";
            sqlWhere = " where ge.FK_User=" + userID;
            sqlOrder = " order by ge.AddDate desc";
            pkName = "ExSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;
            Paging pg = new Paging(pv, new PagingUrlVar(12));//页记录 12
            pg.load();

            Bind.BGRepeater(pg.GetDataTable(), this.rpList);
            this.ucPS1.f = pg;
            this.ucPS1.cs = "?p={0}";

            countN.Text=pg.um.records_count.ToString();//总数
        }

    }
}
