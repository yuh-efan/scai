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
using WZ.Data;

namespace WZ.Web.floatLayer
{
    public partial class showBigImg : WZ.Client.Data.General.FloatPage
    {
        private int id;
        private string type;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Req.GetID();
            type = Req.GetQueryString("type");
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            if (type == "pro")
                proPicList();
            else if (type == "caipu")
                caipuPicList();

        }


        private void proPicList()
        {
            string sSql = "select PicS,PicB from Pro_Pic where FK_Pro=" + id;
            DataTable dtPic = DbHelp.GetDataTable(sSql);
            Bind.BGRepeater(dtPic, this.rpPic);
        }

        private void caipuPicList()
        {
            string sSql = "select PicS,PicB from CaiPu_Pic where FK_Pro=" + id;
            DataTable dtPic = DbHelp.GetDataTable(sSql);
            Bind.BGRepeater(dtPic, this.rpPic);
        }

        
        protected string getUrlPic(object pDataRow,string pField)
        {
            DataRowView dr = (DataRowView)pDataRow;
            string url = "";
            if (type == "pro")
                url=GetURL.Pro.Pic(dr[pField]);
            else if (type == "caipu")
                url=GetURL.CaiPu.Pic(dr[pField]);
            return url;
        }
    }
}
