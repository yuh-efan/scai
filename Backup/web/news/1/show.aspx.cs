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
using WZ.Client.Data;
using WZ.Model;
using WZ.Data;
using WZ.Data.Layout;

namespace WZ.Web.News._1
{
    public partial class show : System.Web.UI.Page
    {
        protected int id;
        protected SqlDataSelect d;
        protected string lNum;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Req.GetID();

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
            DataTable dt;
            sql = "select Title,Detail,Source,EditDate,Vote from News_Info where NewsSN=" + id;
            d = new SqlDataSelect(sql);

            //导航栏
            curPath.Text += d.Eval("Title");

            //投票
            sql = "select ClassName,Str,PicS from Vote_Class where PClassSN=(select ClassSN from Vote_Class where Str='news') order by Taxis asc";
            dt = DbHelp.GetDataTable(sql);
            Bind.BGRepeater(dt, rpVoteList, false);

            //hit  +1
            sql = "update News_Info set Hit=Hit+1 where NewsSN=" + id;
            DbHelp.Update(sql);

            //健康食品推荐
            sql = "select top 10 ProSN,ProName,PicS,Price from vgPro_Info where JoinType=0 and Item&128=128 and Item&2=2 order by EditDate desc";
            dt = DbHelp.GetDataTable(sql);
            this.rpList.dt = dt;
            this.rpList.listEvent = new CycleEvent(ProLay.d_list3);

            List();
        }

        private void List()
        {
            //评论数
            string sql = "select count(0) from News_Msg where Purview=1 and FK_News=" + id;
            lNum = DbHelp.Scalar(sql).ToString();

            //最新评论
            sql = "select top 5 N.FK_User,Detail,N.AddDate as AddDate,UserName from News_Msg as N left join User_Info as U on N.FK_User=U.UserSN where Purview=1 and FK_News=" + id + " order by N.AddDate desc";
            DataTable dt = DbHelp.GetDataTable(sql);
            Bind.BGRepeater(dt, this.rpMsgList);
        }

        private void MsgList_ajaxPage()
        {
            List();
            Response.Write(Fn.GetControlHtml(this.comment));
            Response.End();
        }
    }
}
