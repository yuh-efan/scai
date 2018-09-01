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
using WZ.Common.CacheData;
using System.Collections.Generic;
using WZ.Data;

namespace WZ.Web.cs
{
    public partial class HandlerCache1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cache["Key3"] = DateTime.Now.ToString();
            DataTable dt = PubData.GetDataTable("join_info");

            //Response.Write((int)SCWCache.CacheKey.Join_Info);

            foreach (DataRow drw in dt.Rows)
            {
                Response.Write(drw[1].ToString()+"<br>");
            }
        }
    }

    public interface ics_fx<TKey, TValue>
    {
        void add(TKey a,TValue b);
    }

    //public class cs_fx<TKey, TValue> : ics_fx<TKey, TValue>
    //{
    //    //private Entry<TKey, TValue> entr;
    //    //private struct Entry
    //    //{
    //    //    public int hashCode;
    //    //    public int next;
    //    //    public TKey key;
    //    //    public TValue value;
    //    //}

    //    public void aaa()
    //    { 
            
    //    }
    //}
}
