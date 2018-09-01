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
using System.Collections.Generic;

namespace WZ.Web.cs
{
    public partial class get_webcache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (System.Collections.DictionaryEntry c in HttpContext.Current.Cache)
            {
                i++;
                Response.Write(i + ". " + c.Key);
                Response.Write("<br>");
            }

            List<int> aaa = new List<int>();

            
        }
    }
}
