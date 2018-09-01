using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Web;

namespace WZ.Client.Data.General
{
    public class FloatPage : System.Web.UI.Page
    {
        public FloatPage()
        {
            HttpContext.Current.Response.CacheControl = "no-cache";
            this.EnableViewState = false;
        }
    }
}
