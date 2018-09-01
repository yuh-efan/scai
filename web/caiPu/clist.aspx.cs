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
using WZ.Data.DataItem;

namespace WZ.Web.caiPu
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
        private static DbCache cac = new DbCache("/caiPu/clist.aspx/");

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
        protected List<ItemInfo> dircOrder = new List<ItemInfo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Fn.IsInt(uq.GetQueryString(0), 0);
            pageIndex = Fn.IsInt(uq.GetQueryString(1), 1);
            t = Fn.IsInt(uq.GetQueryString(2), 0);
            ord = Fn.IsInt(uq.GetQueryString(3), 0);

            if (!this.IsPostBack)
            {
                modelJumpUrl = GetURL.CaiPu.Class(uq.ToString(2, "{0}"));

                dircOrder.Add(new ItemInfo() { id = "1", name = "价格 升" });
                dircOrder.Add(new ItemInfo() { id = "2", name = "价格 降" });
                pageOrder = Bind.GetHtmlSelect(dircOrder, "cOrder", ord.ToString(), "0", "默认");

                LL();
                uq.ToString(2, t.ToString());
                orderJumpUrl = GetURL.CaiPu.Class(uq.ToString(3, "{0}"));
            }
        }

        private void LL()
        {
            dtClass = PubData.GetDataTable("caipu_class");

            pageClassName = Fn.GetDataTableFind(dtClass, id, "ClassName").ToString();

            PathList();//分类列表
            ListTJ();//推荐
            List();//产品列表

            GetClassPath gcp = new GetClassPath(GetURL.CaiPu.Class("{0}"));
            ClassPath cp = new ClassPath(dtClass, gcp);
            cp.Exe(id);
            this.curPath.Text = " &gt; <a href=\"" + GetURL.CaiPu.Default() + "\">烹饪课堂</a>" + gcp.GetPath;
        }

        //菜谱列表
        private void List()
        {
            string sqlSelect, sqlFrom, sqlWhere = string.Empty, sqlOrder, pkName;

            if (t == 1)
                sqlSelect = "select ProSN,ProName,PicS,Item,Number,UnitNum,StockN,Unit";
            else
                sqlSelect = "select ProSN,ProName,PicS,Item";

            sqlFrom = " from vgCaiPu_Info a inner join T_CaiPu_Class_GetChildAndSelf(" + id + ") b on a.FK_Pro_Class=b.id";

            switch (ord)
            {
                case 1:
                    sqlOrder = " order by Hit asc";
                    break;

                case 2:
                    sqlOrder = " order by Hit desc";
                    break;

                default:
                    sqlOrder = " order by EditDate desc";
                    break;
            }

            pkName = "ProSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(16, pageIndex));
            pg.load();

            if (t == 1)
            {
                stypeModel = "2";
                
                this.showPic.Visible = false;
                this.rpList.dt = pg.GetDataTable();
                this.rpList.listEvent = CaiPuLay.f_1;
            }
            else
            {
                this.showList.Visible = false;
                this.rpPic.dt = pg.GetDataTable();
                this.rpPic.listEvent = new CycleEvent(CaiPuLay.d_list2);
            }

            this.ucPS1.f = pg;
            this.ucPS1.cs = GetURL.CaiPu.Class(id + "-{0}-" + t);
        }

        //本类推荐
        private void ListTJ()
        {
            int iItem = 2;//推荐1;
            string sSQL = string.Format("select top 6 ProSN,ProName,PicS,Item from vgCaiPu_Info a,T_CaiPu_Class_GetChildAndSelf({0}) b where a.FK_Pro_Class=b.id and Item&{1}={1} order by EditDate desc", id, iItem);

            DataTable dt = cac.GetDataTable("caipulist_Item&2=2_" + id, sSQL);
            //Bind.BGRepeater(dt, this.rpTJ, false);
            if (dt.Rows.Count == 0)
            {
                this.htm_TJ.Visible = false;
            }
            else
            {
                this.rpTJ.dt = dt;
                this.rpTJ.listEvent = CaiPuLay.d_list2;
            }
        }

        //分类列表
        private void PathList()
        {
            DataRow[] arrDrw1 = dtClass.Select("ClassLevel=1", "Taxis asc");
            foreach (DataRow drw1 in arrDrw1)
            {
                pageClass.Append("<li>");
                pageClass.Append("<span><a href=\"" + GetURL.CaiPu.Class(drw1["ClassSN"]) + "\">" + drw1["ClassName"] + "</a></span>");

                DataRow[] arrDrw2 = dtClass.Select("PClassSN=" + drw1["ClassSN"], "Taxis asc");
                foreach (DataRow drw2 in arrDrw2)
                {
                    pageClass.Append("<a href=\"" + GetURL.CaiPu.Class(drw2["ClassSN"]) + "\">" + drw2["ClassName"] + "</a>");
                }
                pageClass.Append("</li>");
            }
        }
    }
}
