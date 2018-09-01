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
using WZ.Data.Layout;

namespace WZ.Web.ascx.list
{
    public partial class cycleLink : System.Web.UI.UserControl
    {
        public string target = "target=\"_blank\"";
        public DataTable dt;
        public CycleEventLink listEvent;
        public LayoutInfoLink li;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (listEvent == null)
            {
                listEvent = new CycleEventLink(LinkLay.list1);
            }

            if (li == null)
            {
                li = new LayoutInfoLink();
                li.target = target;
            }
        }
    }
}