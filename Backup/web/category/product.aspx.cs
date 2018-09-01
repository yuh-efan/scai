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
using System.Text;

namespace WZ.Web.category
{
    public partial class product : WZ.Client.Data.General.BasePage
    {
        private DataTable dtClass;
        protected StringBuilder pageClass = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            dtClass = PubData.GetDataTable("pro_class");

            PathList();
        }

        //分类列表
        private void PathList()
        {
            DataRow[] arrDrw1 = dtClass.Select("ClassLevel=1", "Taxis asc");
            foreach (DataRow drw1 in arrDrw1)
            {
                pageClass.Append("<li>");
                pageClass.Append("<span><a href=\"" + GetURL.Pro.Class(drw1["ClassSN"]) + "\">" + drw1["ClassName"] + "</a></span>");

                DataRow[] arrDrw2 = dtClass.Select("PClassSN=" + drw1["ClassSN"], "Taxis asc");
                foreach (DataRow drw2 in arrDrw2)
                {
                    pageClass.Append("<a href=\"" + GetURL.Pro.Class(drw2["ClassSN"]) + "\">" + drw2["ClassName"] + "</a>");
                }
                pageClass.Append("</li>");
            }
        }
    }
}
