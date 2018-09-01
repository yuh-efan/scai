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

namespace WZ.Web.content.propaganda
{
    public partial class top : System.Web.UI.UserControl
    {
        private string t1 = "";
        private Dictionary<string, string> dict = new Dictionary<string, string>();

        public string T1
        {
            set { this.t1 = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            dict.Add(t1,"class=\"current\"");
        }

        protected string GetDirc(string pStr)
        {
            string style = string.Empty;
            if (dict.TryGetValue(pStr, out style))
            { 
                
            }

            return style;
        }
    }
}