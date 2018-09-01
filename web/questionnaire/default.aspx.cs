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

namespace WZ.Web.questionnaire
{
    public partial class _default : WZ.Client.Data.General.BasePage
    {
        protected string QuSN;
        protected string QuName;
        protected string ShowType;
        protected string lNum;

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select top 1 QuSN,ShowType,QuName from Questionnaire where IsOpen=1 order by Taxis asc,QuSN desc";
            DataTable dt = DbHelp.GetDataTable(sql);
            if (dt.Rows.Count == 0)
                return;

            QuSN = dt.Rows[0]["QuSN"].ToString();
            QuName = dt.Rows[0]["QuName"].ToString();
            ShowType = dt.Rows[0]["ShowType"].ToString();

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

            if (!Page.IsPostBack)
            {
                LL();
            }
        }

        protected void LL()
        {
            Vote();
            MsgList();
        }

        //客户调查
        private void Vote()
        {
            if (ShowType == "0")
                ShowType = "checkbox";
            else
                ShowType = "radio";

            string sql = "select VoteSN,VoteName,Total from Questionnaire_Vote where FK_Questionnaire=" + QuSN + " order by Taxis asc";
            DataTable dt = DbHelp.GetDataTable(sql);
            Bind.BGRepeater(dt, rpVote, false);

            Bind.BGRepeater(dt, rpVoteN);
        }

        private void MsgList()
        {
            int cur_pageIndex = Fn.IsInt(Req.GetForm("ajax_page"), 1);

            string sqlSelect, sqlFrom, sqlWhere, sqlOrder, pkName;

            sqlSelect = "select Detail,N.AddDate as AddDate,UserName";
            sqlFrom = " from Questionnaire_Msg as N left join User_Info as U on N.FK_User=U.UserSN";
            sqlWhere = " where Purview=1 and FK_Questionnaire=" + QuSN;
            sqlOrder = " order by N.AddDate desc";
            pkName = "MsgSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;
            Paging pg = new Paging(pv, new PagingUrlVar(30, cur_pageIndex));//页记录 30
            pg.load();

            Bind.BGRepeater(pg.GetDataTable(), this.rpList);

            this.ucPS1.f = pg;
            this.ucPS1.cs = "javascript:ajaxPage('ajax_page_msg',{0});";

            lNum = pg.um.records_count.ToString();
        }

        private void MsgList_ajaxPage()
        {
            MsgList();
            Response.Write(Fn.GetControlHtml(this.comment));
            Response.End();
        }
    }
}
