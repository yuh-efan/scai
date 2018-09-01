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
using WZ.Data;
using WZ.Common;

namespace WZ.Web.taoCan
{
    public partial class _default : WZ.Client.Data.General.BasePage
    {
        protected DataTable dtC;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LL();
            }
        }

        private void LL()
        {
            string sql;
            DataTable dt;

            //一级分类
            dtC = PubData.GetDataTable("TaoCan_Class");
            DataRow[] dr = dtC.Select("ClassLevel=1", "Taxis asc");
            dt = dtC.Clone();
            Fn.DrwToDt(dr, dt);
            Bind.BGRepeater(dt, rpClass1);

            //推荐1
            sql = "select top 2 ProSN,ProName,PicS from vgTaoCan_Info where Item&2=2 order by EditDate desc";
            dt = DbHelp.GetDataTable(sql);
            Bind.BGRepeater(dt, rpTJ1);

            //推荐2
            sql = "select top 4 ProSN,ProName,PicS from vgTaoCan_Info where Item&4=4 order by EditDate desc";
            dt = DbHelp.GetDataTable(sql);
            Bind.BGRepeater(dt, rpTJ2);

            //精品
            sql = "select top 12 ProSN,ProName,PicS from vgTaoCan_Info where Item&1=1 order by EditDate desc";
            dt = DbHelp.GetDataTable(sql);
            Bind.BGRepeater(dt, rpJP);
        }

        protected void rpClass1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int ID = Convert.ToInt32(((Label)e.Item.FindControl("ClassID")).Text);
            Repeater r = (Repeater)e.Item.FindControl("rpClass2");

            DataTable dt1;
            dt1=dtC.Clone();
            DataRow[] dr = dtC.Select("PClassSN=" + ID, "Taxis asc");
            Fn.DrwToDt(dr, dt1);

            r.DataSource = dt1;
            r.DataBind();

        }
    }
}
