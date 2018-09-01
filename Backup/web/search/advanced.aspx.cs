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
using System.Text;
using WZ.Data;

/*
 * 高级搜索
 * 
 * */
namespace WZ.Web.search
{
    public partial class advanced : WZ.Client.Data.General.BasePage
    {
        protected StringBuilder sbCaiPu = new StringBuilder();
        //protected StringBuilder sbTaoCan = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            GetCaiPu();
            //GetTaoCan();
        }

        protected void GetCaiPu()
        {
            DataTable dt = PubData.GetDataTable("caipu_classattr");
            DataRow[] arrDrw = dt.Select("ClassLevel=1", "Taxis asc");
            foreach (DataRow drw in arrDrw)
            {
                sbCaiPu.Append("<li>");
                sbCaiPu.Append("<div class=\"left\">" + drw["ClassName"] + "：</div>");
                sbCaiPu.Append("<div class=\"right\">");
                DataRow[] arrDrw1 = dt.Select("PClassSN=" + drw["ClassSN"], "Taxis asc");
                foreach (DataRow drw1 in arrDrw1)
                {
                    sbCaiPu.Append(string.Format("<p><input id=\"attrCaiPu_{0}_{1}\" name=\"attrCaiPu_{0}\" type=\"radio\" value=\"{1}\" /><label for=\"attrCaiPu_{0}_{1}\">{2}</label></p>", drw["ClassSN"], drw1["ClassSN"], drw1["ClassName"]));

                }
                sbCaiPu.Append("</div>");
                sbCaiPu.Append("</li>");
            }
        }

        //protected void GetTaoCan()
        //{
        //    DataTable dt = PubData.GetDataTable("TaoCan_ClassAttr");
        //    DataRow[] arrDrw = dt.Select("ClassLevel=1", "Taxis asc");
        //    foreach (DataRow drw in arrDrw)
        //    {
        //        sbTaoCan.Append("<li>");
        //        sbTaoCan.Append("<div class=\"left\">" + drw["ClassName"] + "：</div>");
        //        sbTaoCan.Append("<div class=\"right\">");
        //        DataRow[] arrDrw1 = dt.Select("PClassSN=" + drw["ClassSN"], "Taxis asc");
        //        foreach (DataRow drw1 in arrDrw1)
        //        {
        //            sbTaoCan.Append(string.Format("<p><input id=\"attrTaoCan_{0}_{1}\" name=\"attrTaoCan_{0}\" type=\"radio\" value=\"{1}\" /><label for=\"attrTaoCan_{0}_{1}\">{2}</label></p>", drw["ClassSN"], drw1["ClassSN"], drw1["ClassName"]));

        //        }
        //        sbTaoCan.Append("</div>");
        //        sbTaoCan.Append("</li>");
        //    }
        //}
    }
}
