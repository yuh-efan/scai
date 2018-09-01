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

namespace WZ.Web.ascx.list
{
    public partial class proHistory : System.Web.UI.UserControl
    {
        public int ProID = 0;
        public int Max = 5;

        protected int width = 87;
        protected int height = 76;
        protected DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            HistoryData hd = new HistoryData("proHistory", Max);

            string sID = hd.Add(ProID);
            if (sID.Length > 0)
            {
                dt = DbHelp.GetDataTable("select ProSN,ProName,PicS,Price from vgPro_Info where ProSN in(" + sID + ")  order by EditDate desc");

                this.rpList.width = width;
                this.rpList.height = height;
                this.rpList.dt = dt;
                this.rpList.listEvent = WZ.Data.Layout.ProLay.e_list3;
            }
        }

        #region 属性
        /// <summary>
        /// 图片宽度
        /// </summary>
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// 图片高度
        /// </summary>
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        #endregion
    }
}