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
using WZ.Data;
using WZ.Common;

namespace WZ.Web.pro
{
    public partial class msgList : System.Web.UI.Page
    {
         protected SqlDataSelect d;
        protected int id;
        protected string cou;

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
            string sql = "select ProName from vgPro_Info where ProSN=" + id;
            d = new SqlDataSelect(sql);
            if (d.Count < 1)
                return;

            int cur_pageIndex = Fn.IsInt(Req.GetForm("ajax_page"), 1);
            string sqlSelect, sqlFrom, sqlWhere, sqlOrder, pkName;

            sqlSelect = "select ev.Detail,ev.ReDetail,ev.AddDate,ui.UserName";
            sqlFrom = " from Pro_Msg ev left join User_Info ui on ev.FK_User=ui.UserSN";
            sqlWhere = " where Purview=1 and FK_Pro=" + id;
            sqlOrder = " order by ev.AddDate desc";
            pkName = "MsgSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(30, cur_pageIndex));
            pg.load();

            DataTable dt = pg.GetDataTable();
            cou = pg.um.records_count.ToString();
            Bind.BGRepeater(dt, this.rpList);
            this.ucPS1.f = pg;
            this.ucPS1.cs = "javascript:ajaxPage('ajax_page_msg',{0});";
        }

        private void MsgList_ajaxPage()
        {
            LL();
            Response.Write(Fn.GetControlHtml(this.comment));
            Response.End();
        }
    }
}
