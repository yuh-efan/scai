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
    public partial class WebForm13 : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<div id='str'>"+DateTime.Now.ToString()+"</div>");
            Response.Write("<div id='str2'>"+DateTime.Now.AddSeconds(10)+"</div>");
        }
    }
}
