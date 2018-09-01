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

namespace WZ.Web.ascx
{
    public partial class top1 : System.Web.UI.UserControl
    {
        private int navIndex = 0;

        public int NavIndex
        {
            set { this.navIndex = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.t1.NavIndex = navIndex;
        }
    }
}