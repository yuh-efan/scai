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
using System.Threading;
using WZ.Common;
using MemcachedProviders.Cache;
using Enyim.Caching;

namespace WZ.Web.cs
{
    public partial class cache_cs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sKey = "s1";
            DataTable cacheValue = DbHelp.GetDataTable("select top 500 * from vgPro_Info");
            MemcachedClient mc = new MemcachedClient();
            //DistCache.Add(,,
            if (true)
            {
                //// 寫入快取資料 (預設過期時間)
                //DistCache.Add(sKey, cacheValue);
                //// 快取 60 秒
                //DistCache.Add(sKey, cacheValue, 5 * 1000);
                mc.Store(Enyim.Caching.Memcached.StoreMode.Add,"s1",cacheValue,DateTime.Now.AddHours(5d));

                //// 快取至今天結束
                //DistCache.Add(sKey, cacheValue, DateTime.Today.AddDays(1) - DateTime.Now);
            }
            else
            {
                //DefaultCacheStrategy dcs = new DefaultCacheStrategy();
                //dcs.TimeOut = 5;

                //dcs.Add(sKey, cacheValue);
            }

            int j = 0;
            foreach (string s in DbCache.GetInstance.GetCacheKeys())
            {
                j++;
                Response.Write(j + " " + s + "<br />");
            }

            Response.Write("<br><br><br>----------<br><br>");

            //j = 0;
            //foreach (string s in DbCache.CacheKeys)
            //{
            //    j++;
            //    Response.Write(j + " " + s + "<br />");
            //}
        }

        public string newsKey(string v)
        {
            return "news_" + v;
        }

        public T sss<T>(string aa)
        {
            return default(T);
        }

        public DataTable sss1()
        {
            return default(DataTable);
        }
    }
}
