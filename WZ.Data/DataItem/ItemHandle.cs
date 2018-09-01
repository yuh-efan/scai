using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;
using WZ.Common.CacheData;
using WZ.Common;
using System.Configuration;
using System.Data;

namespace WZ.Data.DataItem
{
    public class ItemHandler
    {
        //private static Dictionary<string, IList<ItemInfo>> _dict;
        private IList<ItemInfo> itemInfoList;
        private static string xmlPath;
        private static string[] arrXmlPath;

        private string infoName;

        static ItemHandler()
        {
            //_dict = new Dictionary<string, IList<ItemInfo>>();
            xmlPath = HttpContext.Current.Request.MapPath(ConfigurationManager.AppSettings["xml_item"]);
            arrXmlPath = new string[] { xmlPath };
        }

        public ItemHandler(string pName)
        {
            this.infoName = pName;

            if (!dict.TryGetValue(infoName, out itemInfoList))
            {
                itemInfoList = new List<ItemInfo>();
            }
        }

        public ItemHandler(IList<ItemInfo> pList)
        {
            this.itemInfoList = pList;
        }

        private static Dictionary<string, IList<ItemInfo>> dict
        {
            get
            {
                string skey = "xml_item";

                object o = DbCache.GetInstance.GetCacheData(skey);

                if (o == null)
                {
                    o = GetItem();
                    DbCache.GetInstance.AddFileDepend(skey, o, 360000, arrXmlPath);
                }

                return (Dictionary<string, IList<ItemInfo>>)o;
            }
        }

        /// <summary>
        /// 获取当前指定属性集
        /// </summary>
        /// <returns></returns>
        public IList<ItemInfo> GetItemList()
        {
            return this.itemInfoList;
        }

        /// <summary>
        /// 获取指定属性
        /// </summary>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public ItemInfo GetDirc(string pKey)
        {
            ItemInfo s = new ItemInfo();
            if (pKey.Length == 0)
                return s;

            foreach (ItemInfo info in this.itemInfoList)
            {
                if (info.id == pKey)
                {
                    s = info;
                    break;
                }
            }
            return s;
        }

        /// <summary>
        /// 获取批定属性 位
        /// </summary>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public string GetDircBit(int pKey)
        {
            string s = string.Empty;

            foreach (ItemInfo info in this.itemInfoList)
            {
                int iKey = int.Parse(info.id);

                if ((iKey & pKey) == iKey)
                    s += info.name + ",";
            }

            if (s.Length > 0)
                s = s.TrimEnd(',');

            return s;
        }

        #region
        /// <summary>
        /// 获取当前指定属性集
        /// </summary>
        /// <param name="pInfoName"></param>
        /// <returns></returns>
        public static IList<ItemInfo> GetItemList(string pInfoName)
        {
            IList<ItemInfo> l;
            if (!dict.TryGetValue(pInfoName, out l))
                return new List<ItemInfo>();

            return l;
        }

        /// <summary>
        /// 获取批定属性
        /// </summary>
        /// <param name="l"></param>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public static ItemInfo GetDirc(IList<ItemInfo> l, string pKey)
        {
            ItemInfo s = new ItemInfo();
            if (pKey.Length == 0)
                return s;

            foreach (ItemInfo info in l)
            {
                if (info.id == pKey)
                {
                    s = info;
                    break;
                }
            }
            return s;
        }

        /// <summary>
        /// 获取批定属性 位
        /// </summary>
        /// <param name="l"></param>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public static string GetDircBit(IList<ItemInfo> l, int pKey)
        {
            string s = string.Empty;
            foreach (ItemInfo info in l)
            {
                int iKey = int.Parse(info.id);

                if ((iKey & pKey) == iKey)
                    s += info.name + ",";
            }

            if (s.Length > 0)
                s = s.TrimEnd(',');

            return s;
        }
        #endregion

        /// <summary>
        /// 获取xml文件内容
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, IList<ItemInfo>> GetItem()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(xmlPath);

            XmlNodeList xNodeList = xdoc.GetElementsByTagName("infolist");

            Dictionary<string, IList<ItemInfo>> dict = new Dictionary<string, IList<ItemInfo>>();
            foreach (XmlNode xn in xNodeList)//infolist
            {
                XmlNodeList xnlist = xn.ChildNodes;
                IList<ItemInfo> list = new List<ItemInfo>();
                foreach (XmlNode xn1 in xnlist)//info
                {
                    if (xn1.Name != "info")
                        continue;

                    ItemInfo ii = new ItemInfo();

                    ii.id = xn1.Attributes["id"].Value;
                    ii.name = xn1.Attributes["name"].Value;
                    ii.detail = xn1.InnerText;

                    #region
                    //XmlNodeList xnlist1 = xn1.ChildNodes;
                    //foreach (XmlNode xn2 in xnlist1)
                    //{
                    //    string sValue = xn2.InnerText;
                    //    switch (xn2.Name)
                    //    {
                    //        case "id":
                    //            ii.id = sValue;
                    //            break;

                    //        case "name":
                    //            ii.name = sValue;
                    //            break;

                    //        case "detail":
                    //            ii.detail = sValue;
                    //            break;

                    //        default:
                    //            throw new Exception("xml格式错误");
                    //            break;
                    //    }
                    //}
                    #endregion
                    list.Add(ii);
                }

                dict.Add(xn.Attributes["name"].Value, list);
            }
            return dict;
        }

        public static IList<ItemInfo> DataTableToItemInfo(DataTable dt)
        {
            IList<ItemInfo> itemInfo = new List<ItemInfo>();
            foreach (DataRow drw in dt.Rows)
            {
                itemInfo.Add(new ItemInfo() { id = drw[0].ToString(), name = drw[1].ToString() });
            }

            return itemInfo;
        }

        public static IList<ItemInfo> DataTableToItemInfo(DataTable dt, string fieldID, string fieldValue)
        {
            IList<ItemInfo> itemInfo = new List<ItemInfo>();
            foreach (DataRow drw in dt.Rows)
            {
                itemInfo.Add(new ItemInfo() { id = drw[fieldID].ToString(), name = drw[fieldValue].ToString() });
            }

            return itemInfo;
        }
    }
}
