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
using WZ.Common;
using WZ.Common.CacheData;
using WZ.Common.Config;
using WZ.Data;

namespace WZ.Web.ascx
{
    public partial class homeProClass : System.Web.UI.UserControl
    {
        protected static DbCache cac = new DbCache("/ascx/homeProClass.ascx/");
        protected DataTable dtProClassHome;
        protected DataTable dtProClass;
        protected WZ.Data.Layout.LayoutInfo lay1 = new WZ.Data.Layout.LayoutInfo() { width = 62, height = 44 };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            dtProClass = PubData.GetDataTable("pro_class");
            string sSQL = "select ClassSN,ClassName,PClassSN,Taxis from vgPro_Class where Item&1=1 order by Taxis desc";
            dtProClassHome = cac.GetDataTable("pro_class_Item&1=1", sSQL);

            //DataRow[] aDrw = dtProClassHome.Select("PClassSN=0", "Taxis asc");
            //foreach (DataRow drw in aDrw)
            //{
            //    DataRow[] aDrw1 = dtProClassHome.Select("PClassSN=" + drw["ClassSN"], "Taxis asc");
            //    int j = 0;
            //    foreach (DataRow drw1 in aDrw)
            //    {
            //        j++;
            //        if (j >= 3)
            //            break;


            //    }
            //}
        }
    }
}