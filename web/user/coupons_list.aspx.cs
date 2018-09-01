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

using WZB.Data; 
using WZ.Common;

namespace WZ.Web.user
{
    public partial class coupons_list : WZB.Data.General.PageUser
    {
        private string type;
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
            Paging pg = Coupons_Info.List(GetSess.UserID, type);
            Bind.BGRepeater(pg.GetRead(), this.rpList);
            this.ucPS1.f = pg;
        }


        protected string getItem(object obj)
        {
            string sMsg = Config.Empty;
            switch (Convert.ToByte(obj))
            {
                case 1://折扣卷
                    sMsg = "折扣卷";
                    break;
                case 2://抵价卷
                    sMsg = "抵价卷";
                    break;
                //case 3://送优惠卷
                //    break;
                case 4://赠品卷
                    sMsg = "赠品卷";
                    break;
            }
            return sMsg;
        }

        private DateTime cutTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        protected string getState(object obj)
        {
            DataRowView drv = (DataRowView)obj;
            DateTime endTime = (DateTime)drv["EndTime"];
            DateTime startTime = (DateTime)drv["startTime"];

            byte status = Convert.ToByte(drv["Status"]);
            string sMsg = Config.Empty;
            switch (status)
            {
                case 0://未使用
                    if (cutTime <= endTime && cutTime>=startTime)
                        sMsg = "可以使用";
                    else
                        sMsg = "过期";
                    break;
                case 1://已使用
                    sMsg = "已使用";
                    break;
                default:
                    break;
            }
            return sMsg;
        }
    }
}
