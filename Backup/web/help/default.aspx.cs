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

namespace WZ.Web.help
{
    public partial class _default : System.Web.UI.Page
    {
        private DataTable dtL;
        
        private int id;
        protected SqlDataSelect d;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Req.GetID();
            if (!Page.IsPostBack)
                LL();
        }

        private void LL()
        {
            string sql;
            DataTable dt;

            //分类下 文章
            sql = "select HelpSN,FK_Help_Class,Taxis,Title from Help_Info";
            dtL = DbHelp.GetDataTable(sql);

            //内容
            if (id == 0)
                sql = "select top 1 HelpSN,Title,Detail from Help_Info order by Taxis asc";
            else
                sql = "select HelpSN,Title,Detail from Help_Info where HelpSN=" + id;
            d = new SqlDataSelect(sql);


            //分类
            dt = PubData.GetDataTable("help_class");
            Bind.BGRepeater(dt, rpClass, false);

        }

        protected void rpClass_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int ID = Convert.ToInt32(((Label)e.Item.FindControl("ClassID")).Text);
            Repeater r = (Repeater)e.Item.FindControl("rpList");

            DataTable dt1 = dtL.Clone();
            DataRow[] dr = dtL.Select("FK_Help_Class=" + ID, "Taxis asc");
            Fn.DrwToDt(dr, dt1);

            r.DataSource = dt1;
            r.DataBind();

        }
    }
}
