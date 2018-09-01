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

namespace WZ.Web.pro
{
    /// <summary>
    /// 促销
    /// 
    /// url: {0-{1}-{2}.html
    /// 0:ClassID 
    /// 1:页码 
    /// 2:显示模式(0:图片 1:列表)
    /// </summary>
    public partial class salePromotionList : WZ.Client.Data.General.BasePage
    {
        private static DbCache cac = new DbCache("/pro/salePromotionList.aspx/");

        private int id;
        private int t;//显示模式
        private int pageIndex;
        private DataTable dtClass;//产品分类

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

            MS();//秒杀
        }

        private int oneLevelClassID = 0;
        //产品列表
        private void List()
        {
            string sqlSelect, sqlFrom, sqlWhere = string.Empty, sqlOrder, pkName;

            if (t == 1)
                sqlSelect = "select ProSN,ProName,PicS,Price,PriceMarket,Item,Number,UnitNum,StockN,Unit";
            else
                sqlSelect = "select ProSN,ProName,PicS,Price,PriceMarket,Item";

            sqlFrom = " from vgPro_Info";
            sqlWhere = " where Item&4=4";

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

            Paging pg = new Paging(pv, new PagingUrlVar(16, pageIndex));
            pg.load();

            if (t == 1)
            {
                stypeModel = "2";
                this.showPic.Visible = false;
                this.rpList.dt = pg.GetDataTable();
                this.rpList.listEvent = ProLay.f_sale1;
            }
            else
            {
                this.showList.Visible = false;
                rpPic.dt = pg.GetDataTable();
                this.rpPic.listEvent = ProLay.d_listSale;
            }

            this.ucPS1.f = pg;
            this.ucPS1.cs = Request.Url.AbsolutePath+"?s="+id + "-{0}-" + t;
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

        //秒杀
        private void MS()
        {
            //int iItem = (int)PubEnum.CaiPuItem.推荐;
            //string sSQL = string.Format("select top 6 ProSN,ProName,PicS,Item from vgCaiPu_Info a,T_CaiPu_Class_GetChildAndSelf({0}) b where a.FK_Pro_Class=b.id and Item&{1}={1} order by EditDate desc", id, iItem);

            string sql = "select ProSN,ProName,PicS,Price1 as Price from vgPro_Info where Item&16=16 and MS_StartTime<=getdate() and MS_EndTime>=getdate() order by EditDate desc";

            DataTable dt = cac.GetDataTable("pro_ms", sql);
            this.rpMS.dt = dt;
            this.rpMS.listEvent = new CycleEvent(ProLay.d_list3);
        }
    }
}
