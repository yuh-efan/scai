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
using WZ.Data;
using WZ.Common.CacheData;
using System.Text;
using WZ.Common;

namespace WZ.Web.pro.team
{
    public partial class _default : System.Web.UI.Page
    {
        private static DbCache cac = new DbCache("/pro/team/default.aspx/");

        protected int classID;

        protected void Page_Load(object sender, EventArgs e)
        {
            classID = Req.GetID("classID");

            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            GetClass();
            GetPro();
        }

        private void GetClass()
        {
            string sql = "select ClassSN,ClassName from vgPro_Class where PClassSN=0 order by Taxis asc";
            DataTable dt = cac.GetDataTable("publist_PClassSN=0", sql);
            Bind.BGRepeater(dt, this.rpClass);
        }

        private void GetPro()
        {
            string sqlSelect, sqlFrom, sqlWhere = string.Empty, sqlOrder, pkName;

            sqlSelect = "select ProSN,ProName,PicS,Price2,Unit,UnitNum";
            sqlFrom = " from vgPro_Info";
            if (classID > 0)
            {
                sqlFrom = " from vgPro_Info a inner join T_Pro_Class_GetChildAndSelf(" + classID + ") b on a.FK_Pro_Class=b.id";
            }
            sqlWhere = " where Item&2048=2048";
            sqlOrder = " order by EditDate desc";
            pkName = "ProSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(16));
            pg.load();
            Bind.BGRepeater(pg.GetDataTable(), this.rpPro);

            this.ucPS1.f = pg;
        }
    }
}
