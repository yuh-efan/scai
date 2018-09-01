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

namespace WZ.Web.user
{
    public partial class account : WZ.Client.Data.General.PageUser
    {
        protected string pageUserCanMoney;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            // 账户余额
            DataTable dt = User_InfoL.GetUserCanMoney(LoginInfo.UserID);
            if (dt.Rows.Count > 0)
                pageUserCanMoney =dt.Rows[0]["UserCanMoney"].ToString();


            Paging pg = Log_SetUserMoneyL.List(LoginInfo.UserID, 10);
            Bind.BGRepeater(pg.GetRead(), this.rpList);
            this.ucPS1.f = pg;
        }
    }
}
