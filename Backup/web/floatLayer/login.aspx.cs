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
using WZ.Data.ClientAction;
using WZ.Client.Data;

namespace WZ.Web.floatLayer
{
    public partial class login : WZ.Client.Data.General.FloatPage
    {
        protected string url;//注册连接url
        protected string success_target;//登录成功后打开方式
        protected string isV = "0";
        protected string userName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            success_target = Req.GetQueryString("success_target");
            url = Req.GetUrlReferrer("/");

            if (LoginInfo.banHandler.IsBan())
                isV = "1";

            userName = Req.GetCookies("lastUN");
        }
    }
}
