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
using System.Text;
using WZ.Data.Layout;
using WZ.Common.CacheData;
using WZ.Common.ICommon;
using WZ.Common;

namespace WZ.Web.floatLayer
{
    public partial class survey : WZ.Client.Data.General.FloatPage
    {
        private static DbCache cac = new DbCache("/floatLayer/survey.aspx/");

        protected string QuSN;
        protected string QuName;
        protected string ShowType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            Vote();
        }

        //客户调查
        private void Vote()
        {
            string sql = "select top 1 QuSN,ShowType,QuName from Questionnaire where IsOpen=1 order by Taxis asc,QuSN desc";
            DataTable dt = cac.GetDataTable("questionnaire_home", sql);
            if (dt.Rows.Count == 0)
                return;

            QuSN = dt.Rows[0]["QuSN"].ToString();
            QuName = dt.Rows[0]["QuName"].ToString();
            ShowType = dt.Rows[0]["ShowType"].ToString();

            if (ShowType == "0")
                ShowType = "checkbox";
            else
                ShowType = "radio";

            sql = "select * from Questionnaire_Vote where FK_Questionnaire=" + QuSN + " order by Taxis asc";
            dt = cac.GetDataTable("vote_home", sql);
            this.rpVote.dt = dt;
            this.rpVote.listEvent = new CycleEventText(VoteHome);
        }

        private StringBuilder VoteHome(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li><input name=\"cVote\" id=\"cVote" + drw["VoteSN"] + "\" type=\"" + ShowType + "\" value=\"" + drw["VoteSN"] + "\" />");
                sb.Append("<label for=\"cVote" + drw["VoteSN"] + "\">" + drw["VoteName"] + "</label>");
                sb.Append("</li>");
            }
            return sb;
        }

        
    }
}
