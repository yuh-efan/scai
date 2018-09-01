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

namespace WZ.Web.cs
{
    public partial class RowsFindIsNull : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = PubData.GetDataTable("pro_class");

            DataRow drw = dt.Rows.Find(555);
            
            Response.Write(drw==null);
        }
    }
}
