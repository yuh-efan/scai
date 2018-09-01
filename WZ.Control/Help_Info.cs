using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common.CacheData;
using WZ.Data;
using System.Collections;
using System.Web;

namespace WZ.Client.Control
{
    public class Help_Info : System.Web.UI.Control
    {
        private static DbCache dbCac;

        public decimal ClassID = 0;
        public int Top = 0;

        static Help_Info()
        {
            dbCac = new DbCache("Help_");
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            const string html = "<li><a href=\"{1}\" target=\"_blank\">{0}</a></li>";
            int classN = ClassID.ToString().Length;
            string sSQL;

            if (ClassID > 0)
            {
                sSQL = string.Format("select Top {2} HelpSN,Title from Help_Info where left(FK_Help_Class,{0})={1} order by Taxis asc,HelpSN desc", classN, ClassID, Top);
            }
            else
            {
                sSQL = string.Format("select Top {0} HelpSN,Title from Help_Info order by Taxis asc,HelpSN desc", Top);
            }

            DataTable dt = dbCac.GetDataTable(ClassID.ToString() + Top, sSQL);
            foreach (DataRow drw in dt.Rows)
            {
                writer.Write(string.Format(html, drw["Title"], GetURL.Help.Info(drw["HelpSN"])));
            }
        }
    }
}