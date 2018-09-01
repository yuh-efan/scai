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

namespace WZ.Web.ascx.ppt
{
    public partial class ppt1 : System.Web.UI.UserControl
    {
        private static DbCache cac = new DbCache("/ascx/ppt/ppt1.ascx/");

        protected string prefix;
        protected string imgAttr;
        protected string str;
        protected DataTable dtPPT;

        public string Prefix
        {
            set { this.prefix = value; }
        }

        public string ImgAttr
        {
            set { this.imgAttr = value; }
        }

        public string Str
        {
            set { this.str = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sSql = "select * from PPT where Str=@Str order by Taxis asc";
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@Str",str),
                                  };

            DbHelpParam param = new DbHelpParam(sSql, dp);

            dtPPT = cac.GetDataTable("pptlist_" + str, param);
        }
    }
}