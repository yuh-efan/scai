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
using WZ.Client.Data;
using WZ.Common.CacheData;
using System.Text;
using System.Collections.Generic;

namespace WZ.Web.gift
{
    public partial class _default : System.Web.UI.Page
    {
        private static DbCache cac = new DbCache("/gift/default.aspx/");

        protected string page_UserName;
        protected string page_UserIntegral;
        protected string page_UserConsumeIntegral;

        protected void Page_Load(object sender, EventArgs e)
        {
            string hid = Req.GetForm("hid");
            if (hid == "1")
            {
                string cmd = Req.GetForm("cmd");
                switch (cmd)
                {
                    case "ajax_page_def":
                        List_ajaxPage();
                        break;
                }
                Response.End();
            }

            LL();
        }

        private void LL()
        {
            string sql;
            DataTable dt;

            if (LoginInfo.IsLogin())
            {
                this.login1.Visible = false;
            }
            else
            {
                this.login2.Visible = false;

                page_UserName = LoginInfo.UserName;
                sql = "select UserIntegral,UserConsumeIntegral from User_Info where UserSN=" + LoginInfo.UserID;
                using (IDataReader dr = DbHelp.Read(sql))
                {
                    if (dr.Read())
                    {
                        page_UserIntegral = dr["UserIntegral"].ToString();
                        page_UserConsumeIntegral = dr["UserConsumeIntegral"].ToString();
                    }
                }
            }

            //列表
            GiftList();

            //最近购买获得积分
            buyProLog();

            //最新兑奖
            exGiftLog();
        }

        //最新购买
        private void buyProLog()
        {
            string sql = "select top 2 op_ID,FK_Pro,op_ProName,UserName,op_UserTotalPrice from Ord_Pro op inner join User_Info ui on op.FK_User=ui.UserSN order by op_AddDate desc";
            DataTable dt = cac.GetDataTable("prolist", sql);
            rpBuyProLog.dt = dt;
            rpBuyProLog.listEvent = list_buyProLog;
        }
        private StringBuilder list_buyProLog(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();

            Dictionary<int, int> fract = new User_FractL().GetFract("buy_1yuan");

            //设置积分
            int integral;
            if (!fract.TryGetValue(0, out integral))
            {
                return sb; //无购买产品送积分服务
            }

            if (integral <= 0)
            {
                return sb;//无购买产品送积分服务
            }
            
            foreach (DataRow drw in dt.Rows)
            {
                string userName = Fn.Left(drw["UserName"].ToString(), 4, " ***");

                // drw["op_UserTotalPrice"]
                sb.Append("<li>");
                sb.Append(userName);
                sb.Append(" 购买了 <a class=\"green\" href=\"" + GetURL.Pro.Info(drw["FK_Pro"]) + "\" target=\"_blank\">" + drw["op_ProName"] + "</a>，获得了" + integral * double.Parse(drw["op_UserTotalPrice"].ToString()) + "积分");
                sb.Append("</li>");
            }
            return sb;
        }

        private void exGiftLog()
        {
            string sql = "select top 4 ExSN,FK_Gift,GiftName,gift_UserName from Gift_ExchangeLog order by AddDate desc";
            DataTable dt = cac.GetDataTable("giftlist_new", sql);
            rpExchange.dt = dt;
            rpExchange.listEvent = list_exGiftLog;
        }
        private StringBuilder list_exGiftLog(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                string userName = Fn.Left(drw["gift_UserName"].ToString(), 4, " ***");

                sb.Append("<span>" + userName + "</span>");
                sb.Append(" 兑换 ");
                sb.Append("<span>" + drw["GiftName"] + "</span>");
                sb.Append("</li>");
            }

            return sb;
        }


        private void GiftList()
        {
            int cur_pageIndex = Fn.IsInt(Req.GetForm("ajax_page"), 1);

            string sqlSelect, sqlFrom, sqlWhere = string.Empty, sqlOrder, pkName;

            sqlSelect = "select GiftSN,GiftName,Integral,PicS";
            sqlFrom = " from Gift_Info";
            sqlOrder = " order by ExchangeN desc";
            pkName = "GiftSN";

            PagingVar pv = new PagingVar();
            pv.SQLCount = "select count(0)" + sqlFrom + sqlWhere;
            pv.SQLRead = "select " + pkName + sqlFrom + sqlWhere + sqlOrder;
            pv.SQL = sqlSelect + sqlFrom + " where " + pkName + " in({0})" + sqlOrder;

            Paging pg = new Paging(pv, new PagingUrlVar(12, cur_pageIndex));
            pg.load();

            DataTable dt = pg.GetDataTable();
            Bind.BGRepeater(dt, this.rpList);
            this.ucPS1.f = pg;
            this.ucPS1.cs = "javascript:ajaxPage('ajax_page_def',{0});";
        }

        private void List_ajaxPage()
        {
            GiftList();
            Response.Write(Fn.GetControlHtml(this.htm_giftlist));
            Response.End();
        }
    }
}
