using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Data;
using WZ.Common;

namespace WZ.Client.Control
{
    public class WebInfo : System.Web.UI.Control
    {
        private string str;
        private string attr = "";
        
        public string Str
        {
            get { return this.str; }
            set { this.str = value; }
        }

        public string Attr
        {
            get { return this.attr; }
            set { this.attr = value; }
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            DataTable dt = PubData.GetDataTable("webinfo");

            DataRow[] arrDrw = dt.Select("Str='" + str + "'");
            if (arrDrw.Length > 0)
            {
                writer.Write("<div " + attr + ">");
                writer.Write(arrDrw[0]["Detail"].ToString());
                writer.Write("</div>");
            }
        }
    }
}
