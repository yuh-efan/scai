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
using WZ.Common.CacheData;
using System.Collections.Generic;

namespace WZ.Web.cs
{
    public partial class regex_cs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<string> l = DbCache.GetInstance.SearchCacheRegex(Request.QueryString["r"]);
            foreach (string s in l)
            {
                Response.Write(s+"<br />");
            }
        }
    }
}
