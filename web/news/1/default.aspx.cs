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
using WZ.Data.Layout;
using WZ.Common.CacheData;
using System.Text;

namespace WZ.Web.news._1
{
    public partial class _default : System.Web.UI.Page
    {
        private static DbCache cac = new DbCache("/news/1/default.aspx/");
        protected int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Req.GetID();
            if (id == 0) id = 17;

            if (!Page.IsPostBack)
                LL();
        }
        private void LL()
        {
            string sql;
            DataTable dt;

            //PPT           
            sql = "select top 5 NewsSN,Title,PicS,PicB,UrlType,Url  from news_Info where Item&2=2 order by EditDate desc";
            dt = cac.GetDataTable("news_ppt", sql);
            Bind.BGRepeater(dt, rpPPTImg);
            Bind.BGRepeater(dt, rpPPTList);

            //健康热点  NO.1
            sql = "select top 1 NewsSN,PicS,Title,Title1,Detail,UrlType,Url from news_Info where Item&1=1 order by EditDate desc";
            dt = cac.GetDataTable("news_item_1", sql);
            Bind.BGRepeater(dt, rpHotNO1);


            //健康热点 其他
            sql = "select top 5 NewsSN,Title,Title1,UrlType,Url from news_Info where Item&4=4 order by EditDate desc";
            dt = cac.GetDataTable("news_item_4", sql);
            Bind.BGRepeater(dt, rpHotList);

            //列表
            sql = "select top 10 NewsSN,Source,Title,EditDate,Detail,UrlType,Url from news_Info  where FK_News_Class=" + id + " order by EditDate desc";
            dt = cac.GetDataTable("news_class_" + id, sql);
            this.rpList.dt = dt;
            this.rpList.listEvent = new CycleEventText(NewsList);

            //独家
            sql = "select top 10 ProSN,ProName,PicS,Price from vgPro_Info where Item&1024=1024 order by EditDate desc";
            dt = cac.GetDataTable("news_Item_1024", sql);
            this.rpDJ.dt = dt;
            this.rpDJ.listEvent = new CycleEvent(ProLay.d_list4);
        }

        private StringBuilder NewsList(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.News.Info(drw) + "\" target=\"_blank\" class=\"news-title\">");
                sb.Append((drw["Source"].ToString().Length > 0 ? "[" + drw["Source"] + "]" : "") + drw["Title"] + "</a>");
                sb.Append(" <span style=\"font-size:14px;\">" + drw["EditDate"] + "</span>");
                sb.Append("<p>" + Fn.Left(Fn.ReplaceHTML(drw["Detail"].ToString()), 150, "..."));
                sb.Append("<a href=\"" + GetURL.News.Info(drw) + "\" target=\"_blank\" class=\"Detailed\">[查看详情]</a></p>");
                sb.Append("</li>");
            }
            return sb;
        }
    }
}
