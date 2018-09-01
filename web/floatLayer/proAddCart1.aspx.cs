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
using WZ.Data;
using System.Collections.Generic;

namespace WZ.Web.floatLayer
{
    public partial class proAddCart1 : WZ.Client.Data.General.FloatPage
    {
        protected string msg;

        protected void Page_Load(object sender, EventArgs e)
        {
            msg = Req.GetQueryString("msg");
        }
    }
}