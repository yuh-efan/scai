using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WZ.Data.CenterHandler
{
    public class cs1 : IHttpHandler, IHttpModule
    {

        #region IHttpHandler 成员

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("ddd");
        }

        #endregion

        #region IHttpModule 成员

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {

            context.BeginRequest +=
            (new EventHandler(aaa));


            //context.EndRequest +=
            //    (new EventHandler(this.Application_EndRequest));


            //context.Response.Write("fff");
            //throw new NotImplementedException();
        }

        public void aaa(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            context.Response.Write("fff");

        }

        #endregion
    }
}
