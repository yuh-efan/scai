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
using WZ.Data.Layout;

/*
 * 查找 相关菜谱
 * 
 * */
namespace WZ.Web.search
{
    public partial class relateCaiPu : WZ.Client.Data.General.BasePage
    {
        protected int id;
        protected int t;
        protected string title;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Req.GetID();
            t = Fn.IsInt(Req.GetQueryString("t"), 0);

            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            switch (t)
            {
                case 0://来自产品页
                    FromPro();
                    break;

                case 1://来自食谱页
                    FromCaiPu();
                    break;
            }
        }

        private void FromPro()
        {
            string sql;
            sql = "select ProName from vgPro_Info where ProSN="+id;
            title = DbHelp.First(sql);

            string sqlSelect, sqlFrom, sqlWhere, sqlOrder, pkName;

            sqlSelect = "select ProSN,ProName,PicS";
            sqlFrom = " from vgCaiPu_Info";
            sqlWhere = " where ProSN in (select FK_CaiPu from CaiPu_Pro where FK_Pro=" + id + ")";
            sqlOrder = " order by EditDate desc";
            pkName = "ProSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(24));//页记录 16
            pg.load();
            this.rpList.dt = pg.GetDataTable();
            this.rpList.listEvent = new CycleEvent(CaiPuLay.d_list2);
            this.ucPS1.f = pg;
        }

        private void FromCaiPu()
        {
            string sql;
            sql = "select ProName from vgCaiPu_Info where ProSN=" + id;
            title = DbHelp.First(sql);

            string sqlSelect, sqlFrom, sqlWhere, sqlOrder, pkName;

            sqlSelect = "select ProSN,ProName,PicS";
            sqlFrom = " from vgCaiPu_Info";
            sqlWhere = " where ProSN in (select FK_CaiPu from CaiPu_Pro where FK_Pro in (select FK_Pro from CaiPu_Pro where FK_CaiPu=" + id + "))";
            sqlOrder = " order by EditDate desc";
            pkName = "ProSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(24));//页记录 16
            pg.load();
            this.rpList.dt = pg.GetDataTable();
            this.rpList.listEvent = new CycleEvent(CaiPuLay.list1);
            this.ucPS1.f = pg;
        }
    }
}
