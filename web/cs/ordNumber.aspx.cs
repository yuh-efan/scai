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
using WZ.Data;
using WZ.Common;
using WZ.Client.Data;

namespace WZ.Web.cs
{
    public partial class ordNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageAjaxC msgAjax = new MessageAjaxC();
            string s = "sdfdsf";
            msgAjax.WriteMessage(string.Empty, ref s, string.Empty, "nologin");

            Response.Write(msgAjax.ReturnMessage);

            Pub_Number oh = new Pub_Number("ord");
            Response.Write(oh.GenerateNumber());

            
        }
    }
}
