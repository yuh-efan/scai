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
using System.Collections.Generic;

namespace WZ.Web.cs
{
    public partial class datatable_cs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sSQL = "select * from vgPro_Info";
            DataTable dt = DbHelp.GetDataTable(sSQL);
            //Fn.SetDataTablePrimary(dt);

            DateTime dtime = DateTime.Now;
            DataTable dt1 = dt.Clone();
            DataTable dt2;

            DataRow[] aDrw = dt.Select();

            for (int i = 0; i < 10000; i++)
            {
               //dt2= Fn.DrwToDt(aDrw);
               //dt2.Clear();
                
            }


            //List<DataRow> l = new List<DataRow>();
            
            //foreach (DataRow drw in dt.Rows)
            //{
            //    if (((Config.PubEnum.ProItem)(drw["item"]) & Config.PubEnum.ProItem.热销) == Config.PubEnum.ProItem.热销)
            //    {
            //        l.Add(drw);
            //        //dt1.Rows.Add(drw);
            //    }
            //}

            //this.rpList.DataSource = l;
            //this.rpList.DataBind();


            
            Response.Write("-------------");


            //foreach (DataRow drw in dt.Rows)
            //{
            //    Response.Write("<br>");
            //    Response.Write(Config.KeyPair.GetAttrList(Convert.ToInt32(drw["item"])));
               
            //}

            DateTime dtime1 = DateTime.Now;

            TimeSpan ts = dtime1 - dtime;

            Response.Write(ts.TotalSeconds + "秒<br>");

        }

        public static DataTable DrwToDt(DataRow[] pArrDrw)
        {
            DataTable pDt = new DataTable();
            for (int i = 0; i <= pArrDrw.Length - 1; i++)
                pDt.ImportRow(pArrDrw[i]);
            return pDt;
        }
    }
}
