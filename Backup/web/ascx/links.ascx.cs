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
using WZ.Common;

namespace WZ.Web.ascx
{
    public partial class links : System.Web.UI.UserControl
    {
        private static DbCache dbCac;

        public int LinksType = 0;//友情链接,合作伙伴
        public int ShowLocal = 0;//是否显示在首页
        public int ShowType = 0;//是否图片链接

        static links()
        {
            dbCac = new DbCache("Links_");
        }

        private void LL()
        {
            string sSQL = "select * from Links where LinksType=" + LinksType + " and ShowLocal=" + ShowLocal + " and ShowType=" + ShowType + " order by Taxis desc,LinksSN desc";



            //string sSQL = string.Format("select * from Links where LinksType={0} and Item={1}{2} order by Taxis asc", LinksType, Item, "{0}");
            //if (IsPic)
            //{
            //    sSQL = string.Format(sSQL, " and len(LinksImg)>0");
            //}
            //else
            //{
            //    sSQL = string.Format(sSQL, " and len(LinksImg)=0");
            //}

            DataTable dt = dbCac.GetDataTable(LinksType.ToString() + ShowLocal.ToString() + ShowType.ToString(), sSQL);

            if (ShowType==1)
            {
                Bind.BGRepeater(dt, this.rpPic, false);
                this.rpText.Visible = false;
            }
            else
            {
                Bind.BGRepeater(dt, this.rpText, false);
                this.rpPic.Visible = false;
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }
    }
}