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
using System.Web.Caching;
using System.Collections.Generic;

namespace WZ.Web.cs
{
    public partial class getallcache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cache webCache = HttpRuntime.Cache;
            webCache.Insert("aa", "ww", null, DateTime.Now.AddSeconds((double)12), Cache.NoSlidingExpiration, CacheItemPriority.High, null);

            foreach (System.Collections.DictionaryEntry c in webCache)
            {
                Response.Write(c.Key+"<br>");
                //pub.WebCacher.cacher.ClearCacher(c.Key.ToString());
            }

            //Dictionary<string, string> d = new Dictionary<string, string>();
            //foreach()
        }
    }
}
