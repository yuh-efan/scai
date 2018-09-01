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
using System.Collections.Generic;
using WZ.Common.CacheData;
using System.Text;
using WZ.Common.Config;
using WZ.Data;
using WZ.Common;
using WZ.Client.Data;
using WZ.Data.Layout;

namespace WZ.Web.taoCan
{
    /// <summary>
    /// 分类列表
    /// 
    /// url: {0-{1}-{2}.html
    /// 0:ClassID 
    /// 1:页码 
    /// 2:显示模式(0:图片 1:列表)
    /// </summary>
    public partial class clist : WZ.Client.Data.General.BasePage
    {
        private static DbCache cac = new DbCache("/taoCan/clist.aspx/");

        private int id;
        private int t;//显示模式
        private int pageIndex;
        private DataTable dtClass;

        protected string pageClassName;
        protected UrlQuery uq = new UrlQuery();
        protected string stypeModel = "";
        protected string modelJumpUrl;
        protected StringBuilder pageClass = new StringBuilder();

        protected int ord;
        protected string pageOrder;
        protected string orderJumpUrl;
        protected Dictionary<string, string> dircOrder = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Fn.IsInt(uq.GetQueryString(0), 0);
            pageIndex = Fn.IsInt(uq.GetQueryString(1), 1);
            t = Fn.IsInt(uq.GetQueryString(2), 0);
            ord = Fn.IsInt(uq.GetQueryString(3), 0);

            if (!this.IsPostBack)
            {
                modelJumpUrl = GetURL.TaoCan.Class(uq.ToString(2, "{0}"));

                dircOrder.Add("1", "关注 升");
                dircOrder.Add("2", "关注 降");
                pageOrder = Bind.GetHtmlSelect(dircOrder, "cOrder", ord.ToString(), "0", "默认");

                LL();
                uq.ToString(2, t.ToString());
                orderJumpUrl = GetURL.TaoCan.Class(uq.ToString(3, "{0}"));
            }
        }

        private void LL()
        {
            dtClass = PubData.GetDataTable("TaoCan_Class");

            pageClassName = Fn.GetDataTableFind(dtClass, id, "ClassName").ToString();

            PathList();//分类列表
            ListTJ();//推荐
            List();//产品列表

            GetClassPath gcp = new GetClassPath(GetURL.TaoCan.Class("{0}"));
            ClassPath cp = new ClassPath(dtClass, gcp);
            cp.Exe(id);
            this.curPath.Text = " &gt; <a href=\"" + GetURL.TaoCan.Default() + "\">营养套餐</a>" + gcp.GetPath;
        }

        //产品列表
        private void List()
        {
            PagingList pl = new PagingList("vgTaoCan_Info", "ProSN", new PagingUrlVar(16, pageIndex));

            if (t == 1)
                pl.SqlSelect = "select ProSN,ProName,PicS,Item,Number,UnitNum,StockN,Unit";
            else
                pl.SqlSelect = "select ProSN,ProName,PicS,Item";

            pl.SqlFrom = "from vgTaoCan_Info a , T_TaoCan_Class_GetChildAndSelf(" + id + ") b";
            pl.SqlWhere = "where a.FK_Pro_Class=b.id";
            switch (ord)
            {
                case 1:
                    pl.SqlOrder = "order by Hit asc";
                    break;

                case 2:
                    pl.SqlOrder = "order by Hit desc";
                    break;

                default:
                    pl.SqlOrder = "order by EditDate desc";
                    break;
            }

            Paging pg = pl.List(true);

            if (t == 1)
            {
                stypeModel = "2";
                
                this.showPic.Visible = false;
                Bind.BGRepeater(pg.GetDataTable(), this.rpList);
            }
            else
            {
                this.showList.Visible = false;
                this.rpPic.dt = pg.GetDataTable();
                this.rpPic.listEvent = new CycleEvent(TaoCanLay.list1);
            }

            this.ucPS1.f = pg;
            this.ucPS1.cs = GetURL.TaoCan.Class(id + "-{0}-" + t);
        }

        //本类推荐
        private void ListTJ()
        {
            int iItem = (int)PubEnum.TaoCanItem.推荐;
            string sSQL = string.Format("select top 6 ProSN,ProName,PicS,Item from vgTaoCan_Info a,T_TaoCan_Class_GetChildAndSelf({0}) b where a.FK_Pro_Class=b.id and Item&{1}={1} order by EditDate desc", id, iItem);

            DataTable dt = cac.GetDataTable("taoCan_classTJ" + id, sSQL);
            Bind.BGRepeater(dt, this.rpTJ, false);
        }

        //分类列表
        private void PathList()
        {
            DataRow[] arrDrw1 = dtClass.Select("ClassLevel=1", "Taxis asc");
            foreach (DataRow drw1 in arrDrw1)
            {
                pageClass.Append("<li>");
                pageClass.Append("<span><a href=\"" + GetURL.TaoCan.Class(drw1["ClassSN"]) + "\">" + drw1["ClassName"] + "</a></span>");

                DataRow[] arrDrw2 = dtClass.Select("PClassSN=" + drw1["ClassSN"], "Taxis asc");
                foreach (DataRow drw2 in arrDrw2)
                {
                    pageClass.Append("<a href=\"" + GetURL.TaoCan.Class(drw2["ClassSN"]) + "\">" + drw2["ClassName"] + "</a>");
                }
                pageClass.Append("</li>");
            }
        }
    }
}
