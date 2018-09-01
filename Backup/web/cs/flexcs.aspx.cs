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
using WZ.Client.Data;

namespace WZ.Web.cs
{
    public partial class flexcs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (User_Info.IsUserName(un))
            //{
            //    context.Response.Write('1');
            //}
            //else
            //{
            //    context.Response.Write('0');
            //}

            Response.Write("<abc>");
            Response.Write("sd");
            Response.Write("</abc>");
            Response.End();
        }
    }
}
