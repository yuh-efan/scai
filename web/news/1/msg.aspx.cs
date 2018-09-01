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
    public partial class msg : System.Web.UI.Page
    {
        protected int id;
        protected string title;
        protected string lNum;
        private int pageIndex;
        private UrlQuery uq = new UrlQuery();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Fn.IsInt(uq.GetQueryString(0), 0);
            pageIndex = Fn.IsInt(uq.GetQueryString(1), 1);

            string hid = Req.GetForm("hid");
            if (hid == "1")
            {
                string cmd = Req.GetForm("cmd");
                switch (cmd)
                {
                    case "ajax_page_msg":
                        MsgList_ajaxPage();
                        break;
                }
                Response.End();
            }

            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sql;

            //title
            sql = "select Title from News_Info where NewsSN=" + id;
            title = DbHelp.First(sql);

            //导航
            curPath.Text = string.Format(curPath.Text, "<a href='" + GetURL.News.Info(id.ToString()) + "'>" + title + "</a>");

            //热门评论 30天
            sql = "select top 10 NewsSN,Title,Title1,UrlType,Url from (select FK_News,count(0) as num from News_Msg where Purview=1 and AddDate> dateadd(dd,-30, getdate()) group by FK_News) as P inner join News_Info on FK_News=NewsSN order by num desc";
            DataTable dt = DbHelp.GetDataTable(sql);
            Bind.BGRepeater(dt, rpHot, false);

            List();//评论列表
        }

        //评论列表
        private void List()
        {
            //PagingList pl = new PagingList("News_Msg", "MsgSN", new PagingUrlVar(10, pageIndex));

            //pl.SqlSelect = "select N.FK_User,Detail,N.AddDate as AddDate,UserName";
            //pl.SqlFrom = "from News_Msg as N left join User_Info as U on N.FK_User=U.UserSN";
            //pl.SqlWhere = "where Purview=1 and FK_News=" + id;
            //pl.SqlOrder = "order by N.AddDate desc";

            //Paging pg = pl.List(true);

            //Bind.BGRepeater(pg.GetDataTable(), this.rpMsgList);

            //this.ucPS1.f = pg;
            //this.ucPS1.cs = GetURL.News.Msg(id) + "-{0}";

            #region ajax提交
            int cur_pageIndex = Fn.IsInt(Req.GetForm("ajax_page"), 1);

            string sqlSelect, sqlFrom, sqlWhere = string.Empty, sqlOrder, pkName;
            sqlSelect = "select N.FK_User,Detail,N.AddDate as AddDate,UserName";
            sqlFrom = " from News_Msg as N left join User_Info as U on N.FK_User=U.UserSN";
            sqlWhere = " where Purview=1 and FK_News=" + id;
            sqlOrder = " order by N.AddDate desc";

            pkName = "MsgSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;


            Paging pg = new Paging(pv, new PagingUrlVar(30, cur_pageIndex));//页记录
            pg.load();

            Bind.BGRepeater(pg.GetDataTable(), this.rpMsgList);

            lNum = pg.um.records_count.ToString();

            this.ucPS1.f = pg;
            this.ucPS1.cs = "javascript:ajaxPage('ajax_page_msg',{0});";


            #endregion
        }

        private void MsgList_ajaxPage()
        {
            List();
            Response.Write(Fn.GetControlHtml(this.comment));
            Response.End();
        }
    }
}
