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

namespace WZ.Web.ascx
{
    public partial class homeOrderProSell : System.Web.UI.UserControl
    {
        private static DbCache cac = new DbCache("/ascx/homeOrderProSell.ascx/");

        protected DataTable dtOrder_SellN1;//销售排行

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sql;
            //销售排行
            sql = "select top 8 ProSN,ProName,PicS,Price,SellN1 from vgPro_Info order by SellN1 desc";
            dtOrder_SellN1 = cac.GetDataTable("prolist_order by SellN1 desc", sql);
        }
    }
}