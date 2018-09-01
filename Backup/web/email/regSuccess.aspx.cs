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

namespace WZ.Web.email
{
    public partial class regSuccess : Page
    {
        protected string userName;

        protected void Page_Load(object sender, EventArgs e)
        {
            userName = Req.GetQueryString("un");
        }
    }
}