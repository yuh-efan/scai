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
using WZ.Common.CacheData;
using WZ.Data;
using WZ.Common;
using System.Text;

namespace WZ.Web.ascx
{
    public partial class bottom_help : System.Web.UI.UserControl
    {
        private DataTable dtHelpClass;
        private DataTable dtHelp;
        private static DbCache cac = new DbCache("/ascx/bottom_help.ascx/");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                dtHelpClass = PubData.GetDataTable("help_class");

                string sql = "select * from Help_Info order by Taxis asc";
                dtHelp = cac.GetDataTable("helplist_all", sql);
            }
        }

        private StringBuilder sb = new StringBuilder();
        protected StringBuilder GetList(string pStr)
        {
            sb.Remove(0, sb.Length);

            if (dtHelp == null || dtHelpClass == null)
                return sb;

            int classID = Fn.IsInt(Fn.GetDataTableValue(dtHelpClass, "Str='" + pStr + "'", "ClassSN").ToString(), 0);
            if (classID == 0)
                return sb;

            DataRow[] arrDrw = dtHelp.Select("FK_Help_Class=" + classID, "Taxis asc");
            for (int i = 0; i < arrDrw.Length; i++)
            {
                DataRow drw = arrDrw[i];
                if (i > 4)
                    break;
                sb.Append(string.Format("<li><a href=\"{0}\" target=\"_blank\">{1}</a></li>", GetURL.Help.Info(drw["HelpSN"]), drw["Title"]));
            }
            return sb;
        }
    }
}