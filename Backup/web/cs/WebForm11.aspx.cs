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

namespace WZ.Web.cs
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            Response.Write("123");
            Response.Write("<br>" + Request.QueryString["aa"]);

            if (Req.GetForm("hid")=="1")
            {
                Response.Write("456");
                Response.Write(Request.Form["aa"]);
               
            }
        }
    }
}
