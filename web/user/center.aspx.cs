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
using WZ.Common.CacheData;
using WZ.Common.Config;
using WZ.Client.Data;
using WZ.Data.Layout;
using WZ.Data.DataItem;

namespace WZ.Web.user
{
    public partial class center : WZ.Client.Data.General.PageUser
    {
        protected string pageUserLevelName;
        protected string pageUserLastTime;
        protected string pageUserLastIP;

        protected string pageOrdCount;
        protected string pageOrdTotalPrice;
        protected ItemHandler kpOrd = new ItemHandler("OrderStatus");
        protected ItemHandler kpOrdPay = new ItemHandler("OrderStatusPay");
        private static DbCache cac = new DbCache("/user/center.ascx/");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            pageUserLevelName = new User_LevelL().GetLevelName(LoginInfo.UserLevel).ToString();
            pageUserLastTime = Req.GetCookies("lastTime");
            pageUserLastIP = Req.GetCookies("lastIP");
            GetOrd();//订单列表
            SellOrder();//近期热卖
            NewsList();//最新新闻
        }

        //订单列表
        private void GetOrd()
        {
            string sSQL = string.Format("select count(0) as cou,sum(TotalPrice) as tol from Ord_Info where FK_User={0} and Status={1}", LoginInfo.UserID, 50);//8:已完成
            using (IDataReader dr = DbHelp.Read(sSQL))
            {
                if (dr.Read())
                {
                    pageOrdCount = dr["cou"].ToString();
                    pageOrdTotalPrice = dr["tol"].ToString();
                    if (pageOrdTotalPrice.Length == 0)
                        pageOrdTotalPrice = "0";
                }
            }

            sSQL = "select top 10 OrdSN,OrdNumber,TotalPrice,Status,StatusPay,AddDate,ToMinTime from Ord_Info where FK_User=" + LoginInfo.UserID + " and AddDate>=(getdate()-30) order by AddDate desc";
            Bind.BGRepeater(DbHelp.GetDataTable(sSQL), this.rpList);
        }

        //近期热卖// where EditDate>DataAdd(dd,-30,getdate())不准
        private void SellOrder()
        {
            string sql = "select top 10 ProSN,ProName,PicS,Price,SellN1 from vgPro_Info order by SellN1 desc";
            DataTable dt = cac.GetDataTable("pro_OrderProSell1", sql);
            this.rpPro.dt = dt;
            this.rpPro.listEvent = new CycleEvent(ProLay.d_list4);
        }

        //最新新闻 
        private void NewsList()
        {
            string sql = "select top 10 NewsSN,UrlType,Url,Title1,Title,EditDate from News_Info order by EditDate desc";
            DataTable dt = cac.GetDataTable("news", sql);
            this.rpNews.dt = dt;
            this.rpNews.listEvent = new CycleEventLink(LinkLay.list2);
        }

        //用户操作
        protected string OP(object obj)
        {
            DataRowView drv = (DataRowView)obj;

            int status = int.Parse(drv["Status"].ToString());

            DateTime.Parse(drv["AddDate"].ToString()).AddDays(1).ToString("yyyy-MM-dd");

            string shtml = string.Empty;
            switch (status)
            {

                case 10://已结算
                    DateTime lc = DateTime.Parse(DateTime.Parse(drv["ToMinTime"].ToString()).ToString("yyyy-MM-dd"));

                    //若是当天0点之前
                    if (DateTime.Now < lc)
                    {
                        shtml = "<input type=\"button\" onclick=\"user_cancel(" + drv["OrdSN"].ToString() + ")\" value=\"申请取消\" />";
                    }
                    break;

                case 30://已发货
                    shtml = "<input type=\"button\" onclick=\"user_confirm(" + drv["OrdSN"].ToString() + ")\" value=\"确认收货\" />";
                    break;
            }

            return shtml;
        }
    }
}
