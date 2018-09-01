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
using WZ.Data.Layout;

namespace WZ.Web.ascx
{
    public partial class atop_2 : System.Web.UI.UserControl
    {
        private static DbCache cac = new DbCache("/ascx/atop_2.aspx/");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                GetKeywrods();
            }

        }

        //热门关键词列表
        private void GetKeywrods()
        {
            string sSQL = "select KeyWordName,URL from KeyWord where Item&1=1 order by Taxis asc,Num desc";
            DataTable dt = cac.GetDataTable("keywordlist_Item&1=1", sSQL);
            this.rpKeyword.dt = dt;
            this.rpKeyword.listEvent = LinkLay.listKeyword1;
        }
    }
}