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
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<br>Cookies的所有值:<br>");
            for (int i = 0; i < HttpContext.Current.Request.Cookies.Count; i++)
            {
                Response.Write(HttpContext.Current.Request.Cookies.Keys[i] + "：  " + HttpContext.Current.Request.Cookies[i].Value.ToString() + "<br>");
            }

            Response.Write("<br>Session的所有值:<br>");
            foreach (string key in Session.Contents)
            {
                Response.Write(key.ToString() + "：  " + Session[key].ToString() + "<br>");
            }

            Response.Write(WZ.Common.Config.cs.s + "<br>");
            Response.Write(Application["SessionTable"] + "<br>");


            //for (int i = 0; i < 10000; i++)
            //{
            //    DESEncrypt.Encrypt("suger" + i.ToString());
            //}


            Response.Write(DESEncrypt.Encrypt("suger") + "<br>");
            Response.Write(DESEncrypt.Decrypt("E763A41422949096") + "<br>");
            //Response.Write(DESEncrypt.Decrypt(""););


            
        }
    }
}
