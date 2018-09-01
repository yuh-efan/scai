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

namespace WZ.Web.search
{
    /// <summary>
    /// 新闻搜索
    /// 
    /// url: {0-{1}-{2}.html
    /// 0:ClassID 
    /// 1:页码 
    /// 2:显示模式(0:图片 1:列表)
    /// 5 关键词在第五位,3,4暂时空着
    /// </summary>
    public partial class news : System.Web.UI.Page
    {
        protected int id;
        protected string className;

        protected string keyword;//关键词
        protected string keywordEncode;//编码后的关键词

        private int pageIndex;
        private UrlQuery uq = new UrlQuery();

        private int item;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Fn.IsInt(uq.GetQueryString(0), 0);
            pageIndex = Fn.IsInt(uq.GetQueryString(1), 1);
            keyword = uq.GetQueryString(5);//关键词在第五位,3,4暂时空着
            keywordEncode = Server.UrlEncode(keyword);
            item = Fn.IsInt(uq.GetQueryString(2), 0);

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
            if (keyword.Length > 0)
                this.curPath.Text += "  <span class=\"search-color\">" + keyword + "</span>";

            string sqlSelect, sqlFrom, sqlWhere = string.Empty, sqlOrder, pkName;
            sqlSelect = "select NewsSN,Source,Title,EditDate,Detail,UrlType,Url";
            sqlFrom = " from News_Info";

            if (id > 0)
            {
                sqlWhere = " where FK_News_Class" + id;
            }

            if (item > 0)
            {
                string aw = sqlWhere.Length > 0 ? " and " : " where ";
                sqlWhere += aw + "Item&" + item + "=" + item;
            }

            if (keyword.Length > 0)
            {
                string aw = sqlWhere.Length > 0 ? " and " : " where ";
                sqlWhere += aw + " Title like '%'+@Title+'%'";
            }

            sqlOrder = " order by EditDate desc";
            pkName = "NewsSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;

            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@Title",keyword)
                                  };

            pv.DataParm = dp;
            Paging pg = new Paging(pv, new PagingUrlVar(8, pageIndex));//页记录
            pg.load();
            Bind.BGRepeater(pg.GetDataTable(), this.rpNewsList);

            this.ucPS1.f = pg;
            this.ucPS1.cs = Request.Url.AbsolutePath + "?s=" + id + "-{0}----" + keywordEncode;
        }
    }
}
