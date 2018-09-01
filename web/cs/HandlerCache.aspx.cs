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

namespace WZ.Web.cs
{
    public partial class HandlerCache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CacheDependency dependencies = new CacheDependency(null, new string[] { "Key3" }, DateTime.Now);


            if (Cache["Key2"] == null)
                Cache.Insert("Key2", DateTime.Now.ToString(), dependencies, DateTime.Now.AddMinutes(50), Cache.NoSlidingExpiration);


            if (Cache["Key2"] != null)
                HttpContext.Current.Response.Write(Cache["Key2"].ToString());

            //DefaultCacheStrategy();

            //HttpContext.Current.Response.Write("<br>" + TimeZone.CurrentTimeZone.ToUniversalTime(DateTime.MaxValue) + "<br>" + TimeSpan.Zero);
            //Cache.Remove("Key3");
            //HttpContext.Current.Response.Write("<br>"+Cache.Get("Key3")+"fffffffffff");

        }

        public static bool itemRemoved = false;
        public static CacheItemRemovedReason reason;
        CacheItemRemovedCallback onRemove = null;

        public void RemovedCallback(String k, Object v, CacheItemRemovedReason r)
        {
            itemRemoved = true;
            reason = r;
            HttpContext.Current.Response.Write("事件已删除");
        }

        public void AddItemToCache(Object sender, EventArgs e)
        {
            itemRemoved = false;

            onRemove = new CacheItemRemovedCallback(this.RemovedCallback);

            if (Cache["Key1"] == null)
                Cache.Add("Key1", "Value 1", null, DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration, CacheItemPriority.High, onRemove);
        }

        public void RemoveItemFromCache(Object sender, EventArgs e)
        {
            if (Cache["Key1"] != null)
                Cache.Remove("Key1");
        }

    }



}
