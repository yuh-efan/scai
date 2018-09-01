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
    public partial class cycle : System.Web.UI.UserControl
    {
        public int width;
        public int height;
        public string target = "target=\"_blank\"";
        public int detailN = 25;
        public DataTable dt;
        public CycleEvent listEvent;
        public LayoutInfo li;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (listEvent == null)
            {
                listEvent =  ProLay.list1;
            }

            if (li == null)
            {
                li = new LayoutInfo();
                li.width = width;
                li.height = height;
                li.target = target;
                li.detailN = detailN;
            }
        }
    }
}