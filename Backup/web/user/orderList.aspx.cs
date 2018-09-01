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

using WZ.Client.Data;
using WZ.Common;
using WZ.Common.Config;
using WZ.Data.DataItem;

namespace WZ.Web.user
{
    public partial class orderList : WZ.Client.Data.General.PageUser
    {
        private string type;

        protected string pageTypeTitle;
        protected ItemHandler kpOrd = new ItemHandler("OrderStatus");
        protected ItemHandler kpOrdPay = new ItemHandler("OrderStatusPay");

        protected void Page_Load(object sender, EventArgs e)
        {
            type = Req.GetQueryString("t");

            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            switch (type)
            {
                case "finish":
                    pageTypeTitle = "完成的交易";
                    break;
                case "ongoing":
                    pageTypeTitle = "正在进行的交易";
                    break;
                default:
                    pageTypeTitle = "所有的交易";
                    break;
            }

            Paging pg = Ord_Info.List(LoginInfo.UserID, type);
            Bind.BGRepeater(pg.GetDataTable(), this.rpList);
            this.ucPS1.f = pg;

            this.ucUL.Text += pageTypeTitle;
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