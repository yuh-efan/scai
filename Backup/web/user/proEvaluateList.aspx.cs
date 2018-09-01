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

/*
 * 我的商品评价 
 * 
 * */
namespace WZ.Web.user
{
    public partial class proEvaluateList : WZ.Client.Data.General.PageUser
    {
        protected ItemHandler kpAudit = new ItemHandler("Audit");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sqlSelect, sqlFrom, sqlWhere, sqlOrder, pkName;

            sqlSelect = "select ev.Fraction,ev.Detail,ev.ReDetail,ev.AddDate,ev.purview,ui.UserName,pi.ProSN,pi.ProName,pi.PicS";
            sqlFrom = " from Pro_Evaluate ev left join User_Info ui on ev.FK_User=ui.UserSN left join vgPro_Info pi on ev.FK_Pro=pi.ProSN";
            sqlWhere = " where ev.FK_User=" + LoginInfo.UserID;
            sqlOrder = " order by ev.purview asc, ev.AddDate desc";
            pkName = "EvalSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(10));
            pg.load();

            DataTable dt = pg.GetDataTable();
            Bind.BGRepeater(dt, this.rpList);
            this.ucPS1.f = pg;
        }
    }
}