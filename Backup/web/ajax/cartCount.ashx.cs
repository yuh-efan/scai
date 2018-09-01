using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using WZ.Client.Data;
using WZ.Common;
using System.Web.SessionState;

namespace WZ.Web.ajax
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://souc.cn/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class cartCount : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.CacheControl = "no-cache";

            int userID = Fn.IsInt(Req.GetSession(LoginInfo.C_UserID), 0);
            string cou = "0";
            if (userID > 0)
            {
                cou = User_Cart.GetUserCartN(userID).ToString();
            }

            context.Response.Write(cou);
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
