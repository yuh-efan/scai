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

namespace WZ.Web.news._1
{
    public partial class clist : System.Web.UI.Page
    {
        protected int id;
        protected string className;

        private int pageIndex;
        private UrlQuery uq = new UrlQuery();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Fn.IsInt(uq.GetQueryString(0), 0);
            pageIndex = Fn.IsInt(uq.GetQueryString(1), 1);
            if (!this.IsPostBack)
            {
                LL();
            }

        }
        private void LL()
        {
            string sql = "select ClassName from News_Class where ClassSN=" + id;
            className = DbHelp.First(sql);

            curPath.Text = string.Format(curPath.Text, className);

            List();//分类列表
        }

        //分类列表
        private void List()
        {
            PagingList pl = new PagingList("News_Info", "NewsSN", new PagingUrlVar(8, pageIndex));

            pl.SqlSelect = "select NewsSN,Source,Title,EditDate,Detail,UrlType,Url";
            pl.SqlFrom = "from news_Info";
            pl.SqlWhere = "where FK_News_Class=" + id;
            pl.SqlOrder = "order by EditDate desc";

            Paging pg = pl.List(true);

            Bind.BGRepeater(pg.GetDataTable(), this.rpNewsList);

            this.ucPS1.f = pg;
            this.ucPS1.cs = GetURL.News.Class(id.ToString() + "-{0}");
        }
    }
}
