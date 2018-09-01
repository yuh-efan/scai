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
using WZ.Data;
using WZ.Client.Data;

/**
 * 
 * 我的推广用户
 * 
 * */
namespace WZ.Web.user
{
    public partial class promoterUser : WZ.Client.Data.General.PageUser
    {
        protected string pageUserIntegral;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            int userID = LoginInfo.UserID;
            string sqlSelect, sqlFrom, sqlWhere, sqlOrder, pkName;

            sqlSelect = "select UserSN,UserName,UserAddDate";
            sqlFrom = " from User_Info";
            sqlWhere = " where UserBTJ=" + userID;
            sqlOrder = " order by UserSN desc";
            pkName = "UserSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;
            Paging pg = new Paging(pv, new PagingUrlVar(10));
            pg.load();

            Bind.BGRepeater(pg.GetDataTable(), this.rpList);
            this.ucPS1.f = pg;
        }
    }
}
