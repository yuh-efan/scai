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
using System.Threading;

namespace WZ.Web.cs
{
    public partial class trans_cs : System.Web.UI.Page
    {
        DbHelpParam p = new DbHelpParam();
        protected void Page_Load(object sender, EventArgs e)
        {
            DbHelp.ExecuteTrans(p, new DbHelp.ExecuteTransHandler(ss) , null);
        }

        private int ss(IDbHelp thelp, object obj)
        {
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@aaa","121111111111")
                                  };
            thelp.Update("insert into cs1(CsName) values(@aaa)", dp);

            IDataParameter[] dp1 = { 
                                  DbHelp.Def.AddParam("@aaa1","45555555555555555")
                                  };
            thelp.Update("insert into cs1(CsName) values(@aaa1)", dp1);

            //TransHelp th=(TransHelp)thelp;
            //foreach (IDataParameter d in th.cmd.Parameters)
            //{
            //    Response.Write(d.ParameterName+"<br>");
            //}


            DataTable dt = thelp.GetDataTable("select * from cs1");
            foreach (DataRow drw in dt.Rows)
            {
                Response.Write(drw["csname"] + "<br>");

            }

            return 1;
        }
    }
}
