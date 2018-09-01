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
using System.Web.SessionState;
using WZ.Common;
using WZ.Data;

namespace WZ.Web.cs
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s1 = DESEncrypt_DbHelp.Encrypt("cgq");
            s1 = DESEncrypt_DbHelp.Encrypt(s1);
            string s2 = DESEncrypt_DbHelp.Decrypt(s1);
            s2 = DESEncrypt_DbHelp.Decrypt(s2);
            Response.Write(s1 + "<br>");
            Response.Write(s2 + "<br>");

            Response.Write(Convert.ToInt32( 0.9));

            Response.Write("<br>"+DateTime.Now.Millisecond);



        }
        protected void ff(object sender, EventArgs e)
        {
            string text = "Ming";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "sdfsdf", "SetText('" + text + "')", true);  
        
        }
    }
}
