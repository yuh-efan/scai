<%@ WebHandler Language="C#" Class="Handler" %>
using System;
using System.Web;
using System.Web.SessionState;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using WZ.Common;

public class Handler : IHttpHandler, IRequiresSessionState 
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/gif";
        context.Response.CacheControl = "no-cache";

        VerifyHandler vh = new VerifyHandler(64, 20, "uverify");
        

        vh.BackGroundColor = Color.FromArgb(193, 223, 237);

        Bitmap basemap = vh.GetImg();

        basemap.Save(context.Response.OutputStream, ImageFormat.Gif);
        context.Response.End();
    }
 
    public bool IsReusable 
    {
        get 
        {
            return false;
        }
    }
}