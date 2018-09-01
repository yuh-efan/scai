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
using System.Text;

namespace WZ.Web.ascx.list
{
    public partial class cycleText : System.Web.UI.UserControl
    {
        public DataTable dt;
        public CycleEventText listEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (listEvent == null)
            {
                listEvent = new CycleEventText(dtNull);
            }
        }

        private StringBuilder dtNull(DataTable dt) 
        {
            return new StringBuilder();
        }
    }
}