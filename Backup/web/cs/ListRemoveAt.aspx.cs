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
using System.Collections.Generic;

namespace WZ.Web.cs
{
    public partial class ListRemoveAt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<reat> list = new List<reat>();



            list.Add(new reat("aaa"));
            list.Add(new reat("bbb"));
            list.Add(new reat("ccc"));
            list.Add(new reat("ddd"));
            list.Add(new reat("eee"));
            list.Add(new reat("fff"));
            list.Add(new reat("ggg"));


            reat re = list[2];


            list.RemoveAt(2);

            Response.Write(re.s);

            Response.Write("-------<br>");
            foreach (reat reat in list)
            {
                Response.Write(reat.s + "<br>");
            }
        }
    }

    public class reat
    {
        public string s;

        public reat(string pS)
        {
            this.s = pS;
        }
    }
}
