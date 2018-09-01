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
using System.Data.SqlClient;
using WZ.Data;
using System.Collections.Generic;
using System.Text;
using WZ.Client.Data;
using WZ.Common.Config;
using WZ.Data.DataItem;

namespace WZ.Web.cs
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> d = Fn.SCNumber(100, 9);
            foreach (string s in d.Keys)
            {
                Response.Write("<br>" + s);
            }
            Response.Write("<br>");
        }
    }
}
