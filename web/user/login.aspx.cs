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
using WZ.Data.ClientAction;
using WZ.Data;

namespace WZ.Web.user
{
    public partial class login : WZ.Client.Data.General.BasePage
    {
        protected string url;
        protected string isV = "0";
        protected string userName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            url = Req.GetQueryString("url");

            if (url.Length == 0)
                url = Req.GetUrlReferrer("/");

            if ((url == Request.Url.ToString()) || url.IndexOf("reg.aspx") >= 0)
            {
                url = "/user/center.aspx";
            }

            //判断是否用户需要输入验证码
            if (LoginInfo.banHandler.IsBan())
                isV = "1";

            userName = Req.GetCookies("lastUN");
        }
    }
}
