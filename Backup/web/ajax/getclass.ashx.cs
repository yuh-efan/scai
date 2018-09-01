using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using WZ.Common;
using WZ.Data;

namespace WZ.Web.ajax
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://v/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class getclass1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.CacheControl = "no-cache";

            string tableName = string.Empty;
            switch (Req.GetQueryString("t"))
            {
                //case "news":
                //    tableName = "News_Class";
                //    break;

                case "pro":
                    tableName = "pro_class";
                    break;

                case "help":
                    tableName = "help_class";
                    break;

                //case "pack":
                //    tableName = "Pack_Class";
                //    break;

                case "area":
                    tableName = "pub_area";
                    break;

                default:
                    tableName = "pub_area";
                    break;
            }

            DataTable dt = PubData.GetDataTable(tableName);

            WZ.Data.AjaxHandle.PubClass pc = new WZ.Data.AjaxHandle.PubClass(dt);
            pc.Run();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
