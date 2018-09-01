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

namespace WZ.Web.user
{
    public partial class exit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginInfo.Exit();

            string url = Req.GetQueryString("url");
            if(url.Length==0)
                url = Req.GetUrlReferrer("/");
            Response.Redirect(url);
        }
    }
}
