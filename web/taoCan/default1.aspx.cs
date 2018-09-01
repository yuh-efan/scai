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
using System.Text;
using WZ.Client.Data;
using WZ.Common.Config;
using WZ.Common;

namespace WZ.Web.taoCan
{
    public partial class _default : WZ.Client.Data.General.BasePage
    {
        private static DbCache cac = new DbCache("/taoCan/default.aspx/");
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
            dtClass = PubData.GetDataTable("TaoCan_Class");

            ListTaoCan("taoCan_TJ", 3, PubEnum.TaoCanItem.推荐, this.rpTJ);
            ListTaoCan("taoCan_JP", 9, PubEnum.TaoCanItem.精品食谱, this.rpJingPin);
            ListTaoCan("taoCan_TeiJia", 2, PubEnum.TaoCanItem.特价, this.rpTeJja);


            PathList();//分类列表
        }

        private void ListTaoCan(string cacheName, int topN, PubEnum.TaoCanItem type,Repeater rep)
        {
            int iItem = (int)type;
            string sSQL = string.Format("select top " + topN + " ProSN,ProName,PicS,Detail3,Item from vgTaoCan_Info where Item&{0}={0} order by EditDate desc", iItem);

            DataTable dt = cac.GetDataTable(cacheName, sSQL);
            Bind.BGRepeater(dt, rep, false);
        }
       

        //分类列表
        private void PathList()
        {
            DataRow[] arrDrw1 = dtClass.Select("ClassLevel=1", "Taxis asc");
            foreach (DataRow drw1 in arrDrw1)
            {
                pageClass.Append("<li>");
                pageClass.Append("<span><a href=\"" + GetURL.TaoCan.Class(drw1["ClassSN"]) + "\">" + drw1["ClassName"] + "</a></span>");

                DataRow[] arrDrw2 = dtClass.Select("PClassSN=" + drw1["ClassSN"], "Taxis asc");
                foreach (DataRow drw2 in arrDrw2)
                {
                    pageClass.Append("<a href=\"" + GetURL.TaoCan.Class(drw2["ClassSN"]) + "\">" + drw2["ClassName"] + "</a>");
                }
                pageClass.Append("</li>");
            }
        }
    }
}
