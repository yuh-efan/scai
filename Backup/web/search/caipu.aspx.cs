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
    /// 菜谱搜索
    /// 
    /// url: {0-{1}-{2}.html
    /// 0:ClassID 
    /// 1:页码 
    /// 2:显示模式(0:图片 1:列表)
    /// </summary>
    public partial class caipu : WZ.Client.Data.General.BasePage
    {
        private static DbCache cac = new DbCache("/search/caipu.aspx/");

        //0　分类id
        private int id;
        protected string pageClassName;

        //1 页码
        private int pageIndex;

        //2 显示模式
        private int t;
        //protected string pageShowModel;
        protected string stypeModel = "";
        protected string modelJumpUrl;

        //3 排序
        protected int ord;
        protected string pageOrder;
        protected string orderJumpUrl;
        protected List<ItemInfo> dircOrder = new List<ItemInfo>();

        //5 搜索
        protected string keyword;//关键词
        protected string keywordEncode;//编码后的关键词

        //6 菜谱属性分类
        protected string searchClassAttr;//分类属性id

        //8 Item
        protected int item;

        protected UrlQuery uq = new UrlQuery();

        //菜谱分类
        protected StringBuilder pageClass = new StringBuilder();
        private DataTable dtClass;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Fn.IsInt(uq.GetQueryString(0), 0);
            pageIndex = Fn.IsInt(uq.GetQueryString(1), 1);
            t = Fn.IsInt(uq.GetQueryString(2), 0);
            ord = Fn.IsInt(uq.GetQueryString(3), 0);

            keyword = uq.GetQueryString(5);//关键词在第五位,3,4暂时空着
            keywordEncode = Server.UrlEncode(keyword);
            searchClassAttr = Fn.IsIntArr(uq.GetQueryString(6));
            item = Fn.IsInt(uq.GetQueryString(8), 0);

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
            GetAttrClassName();
            this.curPath.Text += "  <span class=\"search-color\">";

            if (keyword.Length > 0)
                this.curPath.Text +=  keyword ;

            dtClass = PubData.GetDataTable("caipu_class");


            if (item > 0)
            {
                IList<ItemInfo> l_Item = new List<ItemInfo>();
                l_Item.Add(new ItemInfo() { id = "1", name = "精品食谱" });
                l_Item.Add(new ItemInfo() { id = "2", name = "推荐食谱" });
                ItemHandler ih_Item = new ItemHandler(l_Item);
                this.curPath.Text += ih_Item.GetDircBit(item);

            }
            this.curPath.Text += "</span>";
            //pageClassName = Fn.GetDataTableFind(dtClass, id, "ClassName").ToString();
            //this.curPath.Text += pageClassName;

            List();//产品列表

            //GetClassPath gcp = new GetClassPath(GetURL.Pro.Class("{0}"));
            //ClassPath cp = new ClassPath(dtClass, gcp);
            //cp.Exe(id);

            //foreach (int cid in gcp.PathListID)
            //    oneLevelClassID = cid;
            //this.curPath.Text = gcp.GetPath;

            PathList();//分类列表
        }

        private int oneLevelClassID = 0;
        //产品列表
        private void List()
        {
            string sqlSelect, sqlFrom, sqlWhere = string.Empty, sqlOrder, pkName;

            if (t == 1)
                sqlSelect = "select ProSN,ProName,PicS,Item,Number,UnitNum,Unit";
            else
                sqlSelect = "select ProSN,ProName,PicS,Item";

            sqlFrom = " from vgCaiPu_Info pi";

            string aw = "";

            if (keyword.Length > 0)
            {
                aw = sqlWhere.Length > 0 ? " and " : " where ";
                sqlWhere += aw + "ProName like '%'+@ProName+'%'";
            }

            if (item > 0)
            {
                aw = sqlWhere.Length > 0 ? " and " : " where ";
                sqlWhere += aw + "Item&" + item + ">0";
            }

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

            if (searchClassAttr.Length > 0)
            {
                aw = sqlWhere.Length > 0 ? " and " : " where ";
                sqlWhere += aw + "EXISTS (select top 1 AttrSN from CaiPu_ClassAttrInfo where FK_Info=pi.ProSN and FK_Info_ClassAttr2 in(" + searchClassAttr + "))";
            }

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
                this.rpList.listEvent = CaiPuLay.f_1;
            }
            else
            {
                this.showList.Visible = false;
                this.rpPic.dt = pg.GetDataTable();
                this.rpPic.listEvent = new CycleEvent(CaiPuLay.d_list2);
            }

            this.ucPS1.f = pg;
            this.ucPS1.cs = Request.Url.AbsolutePath + "?s=" + id + "-{0}-" + t + "---" + keywordEncode;
        }

        private void GetAttrClassName()
        {
            if (searchClassAttr.Length > 0)
            {
                string searchClassAttrName = string.Empty;
                string ss = "," + searchClassAttr + ",";
                DataTable dt = PubData.GetDataTable("caipu_classattr");
                foreach (DataRow drw in dt.Rows)
                {
                    if (ss.IndexOf("," + drw["ClassSN"].ToString() + ",") >= 0)
                    {
                        searchClassAttrName += drw["ClassName"].ToString() + ",";
                    }
                }

                if (searchClassAttrName.Length > 0)
                {
                    curPath.Text += "> <strong>" + searchClassAttrName.TrimEnd(',') + "</strong>";
                }
            }
        }

        //分类列表
        private void PathList()
        {
            object cid = 0;
            object cname = 0;
            DataRow[] arrDrw1 = dtClass.Select("ClassLevel=1", "Taxis asc");
            foreach (DataRow drw1 in arrDrw1)
            {
                cid = drw1["ClassSN"];
                cname = drw1["ClassName"];

                if (oneLevelClassID > 0)
                {
                    //不输入非当前分类
                    if (cid.ToString() != oneLevelClassID.ToString())
                        continue;
                }

                pageClass.Append("<li>");
                pageClass.Append("<span><a href=\"" + GetURL.CaiPu.Class(cid) + "\">" + cname + "</a></span>");

                DataRow[] arrDrw2 = dtClass.Select("PClassSN=" + cid, "Taxis asc");
                foreach (DataRow drw2 in arrDrw2)
                {
                    pageClass.Append("<a href=\"" + GetURL.CaiPu.Class(drw2["ClassSN"]) + "\">" + drw2["ClassName"] + "</a>");
                }
                pageClass.Append("</li>");
            }
        }
    }
}
