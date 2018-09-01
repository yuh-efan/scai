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
    public partial class ppt3 : System.Web.UI.UserControl
    {
        private static DbCache cac = new DbCache("/ascx/ppt/ppt3.ascx/");

        protected string prefix;
        protected string imgAttr;
        protected string str;
        protected DataTable dtPPT;

        public int top = 0;

        public int Top
        {
            set { this.top = value; }
        }

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
            string sql;
            if (top == 0)
            {
                sql = "select * from PPT where Str=@Str order by Taxis asc";
            }
            else
            {
                sql = "select top " + top + " * from PPT where Str=@Str order by Taxis asc";

            }
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@Str",str),
                                  };

            DbHelpParam param = new DbHelpParam(sql, dp);

            dtPPT = cac.GetDataTable("pptlist_" + str, param);
        }
    }
}