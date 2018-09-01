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

namespace WZ.Web.cs
{
    public partial class SCNumber_cs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Response.Write(WZ.Common.Fn.SCNumber()+"<br>");
            }
        }
    }
}
