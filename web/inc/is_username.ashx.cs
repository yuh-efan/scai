using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using WZ.Common;
using WZ.Client.Data;

namespace WZ.Web.inc
{
    public class has_username1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string un = Req.GetQueryString("un").TrimEnd();

            if (User_Info.IsUserName(un))
            {
                context.Response.Write('1');
            }
            else
            {
                context.Response.Write('0');
            }
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
