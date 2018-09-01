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
using WZ.Common.CacheData;
using WZ.Data.DataItem;
using System.Collections.Generic;

namespace WZ.Web.cs
{
    public partial class xml_cs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ItemHandler ih = new ItemHandler("Trades");
            Response.Write(ih.GetDirc("1"));
            Response.Write("<br>");

            //ItemHandler ih1 = new ItemHandler("ProItem");
            //Response.Write(ih1.GetDircBit(55));

            IList<ItemInfo> l = new List<ItemInfo>();
            l.Add(new ItemInfo("1", "aaa"));
            l.Add(new ItemInfo("2", "bbb"));
            Response.Write(ItemHandler.GetDirc(l, "2"));



            //Response.Write(ih.GetDirc("2").name);


            //DbCache.

            //XmlDocument xdoc = new XmlDocument();
            //xdoc.Load(Request.MapPath("/App_Data/item.xml"));

            //XmlNodeList xNodeList = xdoc.GetElementsByTagName("infolist");

            //Dictionary<string, IList<ItemInfo>> dict = new Dictionary<string, IList<ItemInfo>>();
            //foreach (XmlNode xn in xNodeList)
            //{
            //    XmlNodeList xnlist = xn.ChildNodes;
            //    IList<ItemInfo> list = new List<ItemInfo>();
            //    foreach (XmlNode xn1 in xnlist)
            //    {
            //        ItemInfo ii = new ItemInfo();
            //        #region
            //        XmlNodeList xnlist1 = xn1.ChildNodes;
            //        foreach (XmlNode xn2 in xnlist1)
            //        {
            //            string sValue = xn2.InnerText;
            //            switch (xn2.Name)
            //            {
            //                case "id":
            //                    ii.id = sValue;
            //                    break;

            //                case "name":
            //                    ii.name = sValue;
            //                    break;

            //                case "detail":
            //                    ii.detail = sValue;
            //                    break;

            //                default:
            //                    throw new Exception("xml格式错误");
            //                    break;
            //            }
            //        }
            //        #endregion
            //        list.Add(ii);
            //    }

            //    dict.Add(xn.Attributes["name"].Value, list);
            //}




            //foreach (string s in dict.Keys)
            //{
            //    Response.Write(s+"<br>");

            //    foreach (ItemInfo info in dict[s])
            //    {
            //        Response.Write(info.id + "<br>");
            //        Response.Write(info.name + "<br>");
            //        Response.Write(info.detail + "<br>");
            //    }
            //}



            //Response.Write(xn.Attributes["name"].Value + "<br>");

            //XmlNodeReader xReader = new XmlNodeReader(xdoc);

            //while (xReader.Read())
            //{
            //    if (xReader.Name == "infolist")
            //    {
            //        ItemInfo ii = new ItemInfo();
            //        ii.id = xReader.GetAttribute("id");
            //        ii.id = xReader.GetAttribute("name");
            //        ii.id = xReader.GetAttribute("detail");
            //    }

            //    Response.Write(xReader.NodeType + " = " + xReader.Name + " = " + xReader.Value + "<br>");
            //}
        }

        //ItemInfo
    }
}