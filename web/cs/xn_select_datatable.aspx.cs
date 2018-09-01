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

namespace WZ.Web.cs
{
    //datatable select 查询性能测试
    public partial class xn_select_datatable : System.Web.UI.Page
    {
        private DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            dt = PubData.GetDataTable("pub_area");
            
            //LL1();
            Response.Write("----------------------<br>");
            LL2();
        }

        //返回一行用Find最快
        private void LL1()
        {
            DateTime dtime1 = DateTime.Now;

            for (int i = 0; i < 100000; i++)
            {
                //string s = Fn.GetDataTableKeyName(dt, "115110105", "AreaID", "Name");
                //string s = Fn.GetDataTableKeyName1(dt, "115110105", "AreaID", "Name");
                Fn.GetDataTableFind(dt, "115110105", "Name");

            }
            

            DateTime dtime2 = DateTime.Now;

            TimeSpan ts = dtime2 - dtime1;

            Response.Write(ts.TotalSeconds + " 秒<br>");
            Response.Write(ts.TotalMilliseconds + " 毫秒<br>");
        }

        //用主键的select查询更快
        private void LL2()
        {
            DateTime dtime1 = DateTime.Now;

            for (int i = 0; i < 100; i++)
            {
                //HandleClassDataTable.GetClassNext(dt, 115110105);
                //HandleClassDataTable.GetClassNext1(dt, 115110105);

                //ClassDataTable.NextList(dt, 115110105, "AreaID", "Taxis asc");

            }


            DateTime dtime2 = DateTime.Now;

            TimeSpan ts = dtime2 - dtime1;

            Response.Write(ts.TotalSeconds + " 秒<br>");
            Response.Write(ts.TotalMilliseconds + " 毫秒<br>");
        }

        private void LL3()
        {
            DateTime dtime1 = DateTime.Now;

            for (int i = 0; i < 100; i++)
            {
                dt.Select("Name like '北京'");
            }

            DateTime dtime2 = DateTime.Now;

            TimeSpan ts = dtime2 - dtime1;

            Response.Write(ts.TotalSeconds + " 秒<br>");
            Response.Write(ts.TotalMilliseconds + " 毫秒<br>");
        }

        
    }
}
