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
using System.Xml;
using WZ.Common;

namespace WZ.Web.cs
{
    public partial class area : System.Web.UI.Page
    {
        private XmlDocument doc = new XmlDocument();
        private int i = 0;
        private DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            doc.Load(Request.MapPath("/js/area.xml"));
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("id"));
            dt.Columns.Add(new DataColumn("name"));

            
            Get1();
            Response.Write(i + "</br>");

            Response.Write(dt.Rows.Count + "<br>");


            string sSQL = "insert into Pub_Area(AreaID,AreaName) values(@AreaID,@AreaName)";
            foreach (DataRow drw in dt.Rows)
            {
                IDataParameter[] dp = { 
                                      DbHelp.Def.AddParam("@AreaID",drw["id"]),
                                      DbHelp.Def.AddParam("@AreaName",drw["name"])
                                      };
                DbHelp.Update(sSQL, dp);

                
            }
        }

        private void AddRow(string pID,string pName)
        { 
            DataRow drw = dt.NewRow();
            drw["id"] = pID;
            drw["name"] = pName;
            dt.Rows.Add(drw);
        }

        private void Get1()
        {
            var ii = 100;
            foreach (XmlNode xn in doc.ChildNodes[1].ChildNodes)
            {
                i++;

                string id = ii.ToString();

                AddRow(id, xn.Attributes[2].Value);

                Response.Write(id + " " + xn.Attributes[2].Value + "<br>");
                Get2(xn.ChildNodes, id);
                ii++;
            }
        }

        private void Get2(XmlNodeList pXn, string pII)
        {
            var ii = 100;
            foreach (XmlNode xn in pXn)
            {
                i++;
                string id = pII.ToString() + ii.ToString();
                
                AddRow(id, xn.Attributes[1].Value);
                Response.Write("&nbsp;&nbsp;" + id + " " + xn.Attributes[1].Value + "<br>");
                Get3(xn.ChildNodes, id);
                ii++;
            }
        }

        private void Get3(XmlNodeList pXn, string pII)
        {
            var ii = 100;
            foreach (XmlNode xn in pXn)
            {
                i++;
                string id = pII.ToString() + ii.ToString();

                AddRow(id, xn.Attributes[1].Value);
                Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + id + " " + xn.Attributes[1].Value + "<br>");
                Get4(xn.ChildNodes, id);
                ii++;
            }
        }

        private void Get4(XmlNodeList pXn, string pII)
        {
            var ii = 100;
            foreach (XmlNode xn in pXn)
            {
                i++;
                string id = pII.ToString() + ii.ToString();
                AddRow(id, xn.Attributes[1].Value);
                Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;----" + id + " " + xn.Attributes[0].Value + " " + xn.Attributes[1].Value + "<br>");
                ii++;
                
            }
        }
    }
}
