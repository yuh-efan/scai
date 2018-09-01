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
using System.Text;
using WZ.Data;
using WZ.Common.Config;
using WZ.Common;
using WZ.Data.Layout;

namespace WZ.Web.basket
{
    public partial class _default : WZ.Client.Data.General.BasePage
    {
        private static DbCache cac = new DbCache("/basket/default.aspx/");
        private DataTable dtClass;

        protected StringBuilder pageClass = new StringBuilder();
        protected DataTable dtCLZ;//菜篮子
        protected DataTable dtSJ;//商家

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            dtClass = PubData.GetDataTable("pro_class");
            PathList();
            ListTJ();
            GetNewSell();//最近出售

            string sql;
            //int iItem;

            //iItem = (int)PubEnum.ProItem.推荐到菜篮子专栏栏目;
            //推荐到专栏栏目 512 菜篮子
            sql = "select top 14 ProSN,ProName,PicS,Price,PriceMarket from vgPro_Info where JoinType=0 and Item&512=512 order by EditDate desc";
            dtCLZ = cac.GetDataTable("prolist_JoinType=0 and Item&512=512", sql);

            //推荐到专栏栏目 512 商家
            sql = "select top 14 ProSN,ProName,PicS,Price,PriceMarket from vgPro_Info where JoinType=1 and Item&512=512 order by EditDate desc";
            dtSJ = cac.GetDataTable("prolist_JoinType=1 and Item&512=512", sql); 
        }

        //推荐
        private void ListTJ()
        {
            //int iItem = (int)PubEnum.ProItem.推荐到菜篮子专栏首页;
            //推荐到菜篮子专栏首页 32
            string sql = "select top 4 ProSN,ProName,PicS,Price,PriceMarket from vgPro_Info where Item&32=32 order by EditDate desc";
            this.rpTJ.dt = cac.GetDataTable("prolist_Item&32=32", sql);
            this.rpTJ.listEvent = new CycleEvent(ProLay.e_list2);

            //Bind.BGRepeater(dt, this.rpTJ, false);
        }

        //最近出售
        public void GetNewSell()
        {
            string sql = "select ProSN,ProName,PicS,Price from vgPro_Info where ProSN in (select top 10 FK_Pro from Log_ProSell order by AddDate desc) order by EditDate desc";
            DataTable dt = cac.GetDataTable("prolist_newsale",sql);

            this.rpNewSell.dt = dt;
            this.rpNewSell.listEvent = ProLay.d_list4;
        }

        //分类列表
        //private void PathList()
        //{
        //    DataRow[] arrDrw1 = dtClass.Select("ClassLevel=1", "Taxis asc");
        //    foreach (DataRow drw1 in arrDrw1)
        //    {
        //        pageClass.Append("<li>");
        //        pageClass.Append("<span><a href=\"" + GetURL.Pro.Class(drw1["ClassSN"]) + "\">" + drw1["ClassName"] + "</a></span>");

        //        DataRow[] arrDrw2 = dtClass.Select("PClassSN=" + drw1["ClassSN"], "Taxis asc");
        //        foreach (DataRow drw2 in arrDrw2)
        //        {
        //            pageClass.Append("<a href=\"" + GetURL.Pro.Class(drw2["ClassSN"]) + "\">" + drw2["ClassName"] + "</a>");
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
                pageClass.Append("<dt><a href=\"" + GetURL.Pro.Class(drw1["ClassSN"]) + "\">" + drw1["ClassName"] + "</a></dt>");
                pageClass.Append("<dd style=\"display:none;\" id=\"childHome" + drw1["ClassSN"] + "\">");
                pageClass.Append("<ul>");

                //pageClass.Append("<li>");
                //pageClass.Append("<span><a href=\"" + GetURL.CaiPu.Class(drw1["ClassSN"]) + "\">" + drw1["ClassName"] + "</a></span>");

                DataRow[] arrDrw2 = dtClass.Select("PClassSN=" + drw1["ClassSN"], "Taxis asc");
                foreach (DataRow drw2 in arrDrw2)
                {
                    pageClass.Append("<li><a href=\"" + GetURL.Pro.Class(drw2["ClassSN"]) + "\">" + drw2["ClassName"] + "</a></li>");
                    //pageClass.Append("<a href=\"" + GetURL.CaiPu.Class(drw2["ClassSN"]) + "\">" + drw2["ClassName"] + "</a>");
                }
                pageClass.Append("</ul>");
                pageClass.Append("</dd>");
                pageClass.Append("</dl>");
                //pageClass.Append("</li>");
            }
        }
    }
}
