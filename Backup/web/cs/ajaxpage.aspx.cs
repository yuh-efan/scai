using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Caching;
using WZ.Data;
using WZ.Common.CacheData;
using System.Collections.Generic;

namespace WZ.Web.cs
{
    public partial class ajaxpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            IList<string> l= DbCache.GetInstance.SearchCacheRegex(Request.QueryString["a"]);
            foreach (string s in l)
            {
                Response.Write(s+"<br>");
            }


            //Cache c = HttpRuntime.Cache;
            //if (c["a1"] == null)
            //{
            //    c["a1"] = DateTime.Now.Ticks;
            //}

            ////if (c["a2"] == null)
            ////{
            ////    c["a2"] = DateTime.Now.Ticks;
            ////}

            //DataTable dt = PubData.PubCache.GetDataTable_CacheDepend("ddd", "select * from Pro_Class", new string[] { "a1", "a2" });
            //foreach (DataRow drw in dt.Rows)
            //{
            //    Response.Write(drw["ClassName"].ToString() + "<br>");
            //}


        }
    }
}
