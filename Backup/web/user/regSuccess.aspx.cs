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

namespace WZ.Web.user
{
    public partial class regSuccess : System.Web.UI.Page
    {
        protected string url;
        protected void Page_Load(object sender, EventArgs e)
        {
            url = Req.GetQueryString("url");

        }
    }
}
