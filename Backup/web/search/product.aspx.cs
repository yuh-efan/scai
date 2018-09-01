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

namespace WZ.Web.search
{
    /// <summary>
    /// 产品搜索
    /// 
    /// url: {0-{1}-{2}.html
    /// 0:ClassID 
    /// 1:页码 
    /// 2:显示模式(0:图片 1:列表)
    /// </summary>
    public partial class product : WZ.Client.Data.General.BasePage
    {
        private static DbCache cac = new DbCache("/search/product.aspx/");

        private int id;
        private int t;//显示模式
        private int pageIndex;
        private DataTable dtClass;//产品分类

        protected string pageClassName;

        protected UrlQuery uq = new UrlQuery();
        protected string pageShowModel;
        protected string stypeModel = "";
        protected string modelJumpUrl;

        protected StringBuilder pageClass = new StringBuilder();
        protected string keyword;
        protected string keywordEncode;

        protected int ord;
        protected string pageOrder;
        protected string orderJumpUrl;
        protected List<ItemInfo> dircOrder = new List<ItemInfo>();

        protected byte joinType;//1:菜篮子 2:商家

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Fn.IsInt(uq.GetQueryString(0), 0);//分类id
            pageIndex = Fn.IsInt(uq.GetQueryString(1), 1);//页码
            t = Fn.IsInt(uq.GetQueryString(2), 0);//显示模式(0:图片 1:列表)
            keyword = uq.GetQueryString(5);//关键词在第五位
            keywordEncode = Server.UrlEncode(keyword);//关键词
            ord = Fn.IsInt(uq.GetQueryString(3), 0);//排序方式
            joinType = Fn.IsByte(uq.GetQueryString(7), 0);//商家类型 1:菜蓝子 2:商家

            if (!this.IsPostBack)
            {
                uq.ToString(5, keywordEncode);

                modelJumpUrl = Request.Url.AbsolutePath + "?s=" + uq.ToString(2, "{0}");

                dircOrder.Add(new ItemInfo() { id = "1", name = "价格 升" });
                dircOrder.Add(new ItemInfo() { id = "2", name = "价格 降" });
                pageOrder = Bind.GetHtmlSelect(dircOrder, "cOrder", ord.ToString(), "0", "默认");

                LL();

                uq.ToString(2, t.ToString());
                orderJumpUrl = Request.Url.AbsolutePath + "?s=" + uq.ToString(3, "{0}");
            }
        }

        private void LL()
        {
            
            this.curPath.Text += " <span class=\"search-color\">" + keyword + "</span>";

            dtClass = PubData.GetDataTable("pro_class");

            //pageClassName = Fn.GetDataTableFind(dtClass, id, "ClassName").ToString();

            List();//产品列表

            //GetClassPath gcp = new GetClassPath(GetURL.Pro.Class("{0}"));
            //ClassPath cp = new ClassPath(dtClass, gcp);
            //cp.Exe(id);

            //foreach (int cid in gcp.PathListID)
            //    oneLevelClassID = cid;
            //this.curPath.Text = gcp.GetPath;

            PathList();//分类列表
        }

        //private int oneLevelClassID = 0;
        //产品列表
        private void List()
        {
            string sqlSelect, sqlFrom, sqlWhere = string.Empty, sqlOrder, pkName;

            if (t == 1)
                sqlSelect = "select ProSN,ProName,PicS,Price,PriceMarket,Item,Number,UnitNum,StockN,Unit";
            else
                sqlSelect = "select ProSN,ProName,PicS,Price,PriceMarket,Item";

            sqlFrom = " from vgPro_Info";
            string aw = "";
            if (keyword.Length > 0)
            {
                aw = sqlWhere.Length > 0 ? " and " : " where ";
                sqlWhere += aw + "ProName like '%'+@ProName+'%'";
            }

            aw = sqlWhere.Length > 0 ? " and " : " where ";
            switch (joinType)
            {
                case 0:
                    break;

                case 1:
                    sqlWhere += aw + "JoinType=0";
                    this.curPath.Text += " （菜蓝子）";
                    break;

                case 2:
                    sqlWhere += aw + "JoinType=1";
                    this.curPath.Text += " （商家）";
                    break;
            }

            switch (ord)
            {
                case 1:
                    sqlOrder = " order by Price asc";
                    break;

                case 2:
                    sqlOrder = " order by Price desc";
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

            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@ProName",keyword)
                                  };

            pv.DataParm = dp;
            Paging pg = new Paging(pv, new PagingUrlVar(32, pageIndex));//页记录
            pg.load();

            if (t == 1)
            {
                stypeModel = "2";
                this.showPic.Visible = false;
                this.rpList.dt = pg.GetDataTable();
                this.rpList.listEvent = ProLay.f_1;
            }
            else
            {
                this.showList.Visible = false;
                this.rpPic.dt = pg.GetDataTable();
                this.rpPic.listEvent = new CycleEvent(ProLay.d_list1);
            }

            this.ucPS1.f = pg;
            this.ucPS1.cs = Request.Url.AbsolutePath + "?s=" + id + "-{0}-" + t + "-" + ord + "--" + keywordEncode;
        }

        //分类列表
        private void PathList()
        {
            //object cid = 0;
            //object cname = 0;
            //DataRow[] arrDrw1 = dtClass.Select("ClassLevel=1", "Taxis asc");
            //foreach (DataRow drw1 in arrDrw1)
            //{
            //    cid = drw1["ClassSN"];
            //    cname = drw1["ClassName"];

            //    if (oneLevelClassID > 0)
            //    {
            //        //不输入非当前分类
            //        if (cid.ToString() != oneLevelClassID.ToString())
            //            continue;
            //    }

            //    pageClass.Append("<li>");
            //    pageClass.Append("<span><a href=\"" + GetURL.Pro.Class(cid) + "\">" + cname + "</a></span>");

            //    DataRow[] arrDrw2 = dtClass.Select("PClassSN=" + cid, "Taxis asc");
            //    foreach (DataRow drw2 in arrDrw2)
            //    {
            //        pageClass.Append("<a href=\"" + GetURL.Pro.Class(drw2["ClassSN"]) + "\">" + drw2["ClassName"] + "</a>");
            //    }
            //    pageClass.Append("</li>");
            //}
        }
    }
}
