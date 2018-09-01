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
    public partial class trans_cs1 : System.Web.UI.Page
    {
        DbHelpParam p = new DbHelpParam();
        protected void Page_Load(object sender, EventArgs e)
        {

            //DbHelp.ExecuteTrans(p, (cmd) => ss(cmd));


        }

        //private int ss(IDbCommand command)
        //{
        //    //command.CommandText = "insert into cs1(CsName) values('tttttttttttttttt')";
        //    //command.ExecuteNonQuery();

        //    //Thread.Sleep(10000);

        //    command.CommandText = "select * from cs1";
        //    DataTable dt = DbHelp.GetDataTable_Cmd(p, command);
        //    foreach (DataRow drw in dt.Rows)
        //    {
        //        Response.Write(drw["csname"]+"<br>");
                
        //    }

        //    return 0;
        //}
    }
}
