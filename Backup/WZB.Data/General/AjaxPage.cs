using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Web;

namespace WZ.Client.Data.General
{
    public class AjaxPage : System.Web.UI.Page
    {
        protected JavaScriptObject jso = new JavaScriptObject();

        public AjaxPage()
        {
            HttpContext.Current.Response.CacheControl = "no-cache";
            this.EnableViewState = false;
        }

        public void WriteEndJso()
        {
            HttpContext.Current.Response.Write(JavaScriptConvert.SerializeObject(jso));
            HttpContext.Current.Response.End();
        }
    }
}
