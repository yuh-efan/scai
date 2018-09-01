using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using WZ.Common.CacheData;
using WZ.Common;

namespace WZ.Web.service
{
    ///// <summary>
    ///// $codebehindclassname$ 的摘要说明
    ///// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class cachehandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string t;
            string key;

            t = Req.GetForm("t");
            key = Req.GetForm("key");

            switch (t)
            {
                case "remove_all":
                    DbCache.GetInstance.RemoveCacheAll();
                    context.Response.Write("remove_all");
                    break;

                case "remove_regex":
                    DbCache.GetInstance.RemoveCacheRegex(key);
                    context.Response.Write("remove_regex");
                    break;

                case "remove":
                    DbCache.GetInstance.RemoveCache(key);
                    context.Response.Write("remove");
                    break;
                default:
                    context.Response.Write("no");
                    break;
            }

            context.Response.Write("end");
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
