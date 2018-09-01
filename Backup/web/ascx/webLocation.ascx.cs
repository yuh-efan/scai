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
using WZ.Data;

namespace WZ.Web.ascx
{
    public partial class webLocation : System.Web.UI.UserControl
    {
        private static readonly string currentHome = "您当前所在位置：<a href=\"" + GetURL.Default.Home() + "\">首页</a>";

        protected string text;
        protected string first = null;

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        public string First
        {
            get { return this.first; }
            set { this.first = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (first == null)
                first = currentHome;
        }
    }
}