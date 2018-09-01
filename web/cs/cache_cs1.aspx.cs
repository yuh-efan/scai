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
using MemcachedProviders.Cache;
using Enyim.Caching;

namespace WZ.Web.cs
{
    public partial class cache_cs1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt1 = (DataTable)DbCache.GetInstance.GetCacheData("aaa");

            //foreach (DataRow drw in dt1.Rows)
            //{
            //    Response.Write(drw["className"].ToString() + "<br />");
            //}
            //dt1.Rows[3]["className"] = "ff";

            //dt1.Clear();
            //DbCache.GetInstance.RemoveCache("aaa");

            //DbCache.GetInstance.RemoveCacheAll();

            Response.Write(DistCache.KeySuffix);
            MemcachedClient mc = new MemcachedClient();
            //MemcachedCacheProvider
            //mc.FlushAll();
            //DistCache.Decrement

            if (true)
            {
                object obj = mc.Get("s1");

                //object obj = DistCache.Get("s1");
                

                if (obj != null)
                {
                    DataTable dt1 = (DataTable)obj;
                    foreach (DataRow drw in dt1.Rows)
                    {
                        Response.Write(drw["proname"].ToString() + "<br />");
                    }
                }
                else
                {
                    Response.Write("null");
                }
            }
            else
            {
                object obj = DbCache.GetInstance.GetCacheData("s1");
                if (obj != null)
                {
                    DataTable dt1 = (DataTable)obj;
                    foreach (DataRow drw in dt1.Rows)
                    {
                        Response.Write(drw["className"].ToString() + "<br />");
                    }
                }
                else
                {
                    Response.Write("null");
                }
            }

            //mc.Remove("s1");
        }
    }
}
