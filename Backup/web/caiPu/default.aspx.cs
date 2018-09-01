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
using WZ.Common.CacheData;
using WZ.Data;
using System.Text;
using WZ.Client.Data;
using WZ.Common.Config;
using WZ.Common;
using WZ.Data.Layout;

namespace WZ.Web.caiPu
{
    public partial class _defaul1 : WZ.Client.Data.General.BasePage
    {
        private static DbCache cac = new DbCache("/caiPu/default.aspx/");
        private DataTable dtClass;

        protected StringBuilder pageClass = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            dtClass = PubData.GetDataTable("caipu_class");
            DataTable dt;
            string sql;

            //推荐
            sql = "select top 3 ProSN,ProName,PicS,Item from vgCaiPu_Info where Item&2=2 order by EditDate desc";
            dt = cac.GetDataTable("caipulist_Item&2=2", sql);
            this.rpTJ.dt = dt;
            this.rpTJ.listEvent = CaiPuLay.d_dingo1;

            //精品
            sql = "select top 16 ProSN,ProName,PicS,Item from vgCaiPu_Info where Item&1=1 order by EditDate desc";
            dt = cac.GetDataTable("caipulist_Item&1=1", sql);
            this.rpJingPin.dt = dt;
            this.rpJingPin.listEvent = CaiPuLay.d_dingo1;

            //特价
            sql = "select top 2 ProSN,ProName,PicS,Detail2,Item from vgCaiPu_Info where Item&4=4 order by EditDate desc";
            dt = cac.GetDataTable("caipulist_Item&4=4", sql);
            this.rpTeJja.dt = dt;
            this.rpTeJja.listEvent = CaiPuLay.d_1;

            //ListCaiPu("caiPu_JP", 9, PubEnum.CaiPuItem.精品食谱, this.rpJingPin);
            //ListCaiPu("caiPu_TeiJia", 2, PubEnum.CaiPuItem.特价, this.rpTeJja);


            PathList();//分类列表
            GetNewEval();//最新评论产品
        }

        //private void ListCaiPu(string cacheName, int topN, PubEnum.CaiPuItem type,Repeater rep)
        //{
        //    int iItem = (int)type;
        //    string sSQL = string.Format("select top " + topN + " ProSN,ProName,PicS,Detail3,Item from vgCaiPu_Info where Item&{0}={0} order by EditDate desc", iItem);

        //    DataTable dt = cac.GetDataTable(cacheName, sSQL);
        //    Bind.BGRepeater(dt, rep, false);
        //}

        //分类列表
        //private void PathList()
        //{
        //    DataRow[] arrDrw1 = dtClass.Select("ClassLevel=1", "Taxis asc");
        //    foreach (DataRow drw1 in arrDrw1)
        //    {
        //        pageClass.Append("<li>");
        //        pageClass.Append("<span><a href=\"" + GetURL.CaiPu.Class(drw1["ClassSN"]) + "\">" + drw1["ClassName"] + "</a></span>");

        //        DataRow[] arrDrw2 = dtClass.Select("PClassSN=" + drw1["ClassSN"], "Taxis asc");
        //        foreach (DataRow drw2 in arrDrw2)
        //        {
        //            pageClass.Append("<a href=\"" + GetURL.CaiPu.Class(drw2["ClassSN"]) + "\">" + drw2["ClassName"] + "</a>");
        //        }
        //        pageClass.Append("</li>");
        //    }
        //}


        private void PathList()
        {
            DataRow[] arrDrw1 = dtClass.Select("ClassLevel=1", "Taxis asc");
            foreach (DataRow drw1 in arrDrw1)
            {
                pageClass.Append("<dl onmouseover=\"setChildOver(" + drw1["ClassSN"] + ",this)\" onmouseout=\"setChildOut(" + drw1["ClassSN"] + ",this)\">");
                pageClass.Append("<dt><a href=\"" + GetURL.CaiPu.Class(drw1["ClassSN"]) + "\">" + drw1["ClassName"] + "</a></dt>");
                pageClass.Append("<dd style=\"display:none;\" id=\"childHome" + drw1["ClassSN"] + "\">");
                pageClass.Append("<ul>");

                //pageClass.Append("<li>");
                //pageClass.Append("<span><a href=\"" + GetURL.CaiPu.Class(drw1["ClassSN"]) + "\">" + drw1["ClassName"] + "</a></span>");

                DataRow[] arrDrw2 = dtClass.Select("PClassSN=" + drw1["ClassSN"], "Taxis asc");
                foreach (DataRow drw2 in arrDrw2)
                {
                    pageClass.Append("<li><a href=\"" + GetURL.CaiPu.Class(drw2["ClassSN"]) + "\">" + drw2["ClassName"] + "</a></li>");
                    //pageClass.Append("<a href=\"" + GetURL.CaiPu.Class(drw2["ClassSN"]) + "\">" + drw2["ClassName"] + "</a>");
                }
                pageClass.Append("</ul>");
                pageClass.Append("</dd>");
                pageClass.Append("</dl>");
                //pageClass.Append("</li>");
            }
        }

        //最新评论产品
        public void GetNewEval()
        {
            //string sql = "select ProSN,ProName,PicS from vgCaiPu_Info where ProSN in (select top 10 FK_Pro from CaiPu_Evaluate where Purview=1 order by AddDate desc) order by EditDate desc";
            //DataTable dt = cac.GetDataTable("caipu_neweval",sql);

            //this.rpNewEval.dt = dt;
            //this.rpNewEval.listEvent = new CycleEvent(CaiPuLay.d_list2);
        }
    }
}
