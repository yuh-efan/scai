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

namespace WZ.Web.gift
{
    public partial class _default1 : System.Web.UI.Page
    {
        protected int id;
        private int pageIndex;
        private UrlQuery uq = new UrlQuery();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Fn.IsInt(uq.GetQueryString(0), 0);
            pageIndex = Fn.IsInt(uq.GetQueryString(1), 1);
            if (!Page.IsPostBack)
                LL();
        }

        private void LL()
        {
            string sql;
            DataTable dt;

            //排行
            sql = "select top 8 GiftSN,GiftName,Integral from Gift_Info order by ExchangeN desc";
            dt = DbHelp.GetDataTable(sql);
            Bind.BGRepeater(dt, rpRank);

            //强档推进
            sql = "select top 5 GiftSN,GiftName,Integral,PicS from Gift_Info where Item&1=1 order by EditDate desc";
            dt = DbHelp.GetDataTable(sql);
            Bind.BGRepeater(dt, rpAdv);

            //分类
            sql = "select ClassSN,ClassName from Gift_Class order by Taxis asc";
            dt = DbHelp.GetDataTable(sql);
            Bind.BGRepeater(dt, rpClass);

            //列表
            List();
        }

        //评论列表
        private void List()
        {
            PagingList pl = new PagingList("Gift_Info", "GiftSN", new PagingUrlVar(12, pageIndex));

            pl.SqlSelect = "select GiftSN,GiftName,Integral,PicS";
            pl.SqlFrom = "from Gift_Info";
            pl.SqlWhere = id == 0 ? "" : "where FK_Gift_Class=" + id;
            pl.SqlOrder = "order by ExchangeN desc";

            Paging pg = pl.List(true);

            Bind.BGRepeater(pg.GetDataTable(), this.rpList);

            this.ucPS1.f = pg;
            this.ucPS1.cs = "?s=" + id + "-{0}#locate";
        }



    }
}
