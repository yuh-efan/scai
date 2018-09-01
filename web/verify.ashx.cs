using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Drawing;
using WZ.Common;
using System.Drawing.Imaging;
using System.Web.SessionState;

namespace WZ.Web
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://souc.cn/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class verify : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/gif";
            context.Response.CacheControl = "no-cache";

            VerifyHandler vh = new VerifyHandler(64, 20, "uverify");


            vh.BackGroundColor = Color.FromArgb(193, 223, 237);

            Bitmap basemap = vh.GetImg();

            basemap.Save(context.Response.OutputStream, ImageFormat.Gif);
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
