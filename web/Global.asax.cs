using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            
        }

        //DateTime dt;
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //dt = DateTime.Now;
        }

        protected void Application_EndRequest(Object sender, EventArgs E)
        {
            //DateTime dt2 = DateTime.Now;
            //TimeSpan ts = dt2 - dt;
            //Response.Write(ts.ToString());
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}