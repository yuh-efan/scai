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

/*
 * 已购买的商品
 * 
 * */
namespace WZ.Web.user
{
    public partial class buyProList : WZ.Client.Data.General.PageUser
    {
        protected string buyCout;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sOrder = " order by op_AddDate desc";
            string sWhere = " where FK_User=" + LoginInfo.UserID;
            string sFrom = " from Ord_Pro op left join Pro_Info pi on FK_Pro=pi.ProSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0) from Ord_Pro op" + sWhere;
            pv.SQLRead = "select op_ID from Ord_Pro op" + sWhere + sOrder;
            pv.SQL = "select FK_Pro,op_ProName,PicS,op_AddDate" + sFrom + " where op_ID in({0})" + sOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(12));
            pg.load();
            DataTable dt = pg.GetDataTable();
            buyCout = dt.Rows.Count.ToString();
            Bind.BGRepeater(dt, this.rpPro);
            this.ucPS1.f = pg;
        }
    }
}