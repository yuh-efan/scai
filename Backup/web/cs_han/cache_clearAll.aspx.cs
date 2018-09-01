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

namespace WZ.Web.cs_han
{
    public partial class cache_clearAll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new DefaultCacheStrategy().RemoveCacheAll();
        }
    }
}
