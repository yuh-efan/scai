using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WZ.Common.CacheData;
using System.Web;
using WZ.Data.DataItem;

namespace WZ.Common
{
    public class Bind
    {
        #region 绑定 repeater
        /// <summary>
        /// 绑定Repeater
        /// </summary>
        /// <param name="pSql">sql 语句</param>
        /// <param name="pList">Repeater</param>
        public static void BGRepeater(string pSql, Repeater pList)
        {
            using (IDataReader dr = DbHelp.Read(pSql))
            {
                pList.DataSource = dr;
                pList.DataBind();
            }
        }

        /// <summary>
        /// 绑定Repeater
        /// </summary>
        /// <param name="pDr">IDataReader</param>
        /// <param name="pList">Repeater</param>
        public static void BGRepeater(IDataReader pDr, Repeater pList)
        {
            using (pDr)
            {
                pList.DataSource = pDr;
                pList.DataBind();
            }
        }

        /// <summary>
        /// 绑定Repeater 清空DataTable
        /// </summary>
        /// <param name="pDt">DataTable</param>
        /// <param name="pList">Repeater</param>
        public static void BGRepeater(DataTable pDt, Repeater pList)
        {
            if (pDt == null || pDt.Rows.Count == 0)
                return;
            pList.DataSource = pDt;
            pList.DataBind();
        }

        /// <summary>
        /// 绑定Repeater
        /// </summary>
        /// <param name="pDt">DataTable</param>
        /// <param name="pList">Repeater</param>
        /// <param name="pB">是否清空DataTable true:是,false:否</param>
        public static void BGRepeater(DataTable pDt, Repeater pList, bool pB)
        {
            if (pDt == null || pDt.Rows.Count == 0)
                return;
            pList.DataSource = pDt;
            pList.DataBind();
            if (pB)
            {
                pDt.Clear();
                pDt.Dispose();
            }
        }

        /// <summary>
        /// 绑定Repeater
        /// </summary>
        /// <param name="pDw">DataRow[]</param>
        /// <param name="pList">Repeater</param>
        public static void BGRepeater(DataRow[] pDw, Repeater pList)
        {
            if (pDw != null && pDw.Length > 0)
            {
                pList.DataSource = pDw;
                pList.DataBind();
            }
        }
        #endregion

        #region 服务器端自带控件

        public static void BGListControl(IList<ItemInfo> list, ListControl pList, string pEditValue)
        {
            BGListControl(list, pList, pEditValue, string.Empty, string.Empty);
        }

        public static void BGListControl(IList<ItemInfo> list, ListControl pList, string pEditValue, string pFirstValue, string pFirstText)
        {
            if (pFirstText.Length > 0)
            {
                ListItem drlist = new ListItem();
                drlist.Text = pFirstText;
                drlist.Value = pFirstValue;

                if (pEditValue == pFirstValue)
                    drlist.Selected = true;

                pList.Items.Add(drlist);
            }

            foreach (ItemInfo info in list)
            {
                ListItem drlist = new ListItem();
                drlist.Text = info.name;
                drlist.Value = info.id;

                if (pEditValue == info.id)
                    drlist.Selected = true;

                pList.Items.Add(drlist);
            }
        }
        #endregion

        #region 复选框 返回字符串

        #region 用位来判断

        public static string GetHtmlCheckBox(IList<ItemInfo> pInfolist, string pControlName, int pEditValue)
        {
            return GetHtml_Bit(pInfolist, pControlName, pEditValue, "checkbox").ToString();
        }

        //public static string GetHtmlRadio(IList<ItemInfo> pInfolist, string pControlName, int pEditValue)
        //{
        //    return GetHtml_Bit(pInfolist, pControlName, pEditValue, "radio").ToString();
        //}

        public static StringBuilder GetHtml_Bit(IList<ItemInfo> pInfolist, string pControlName, int pEditValue, string pInputType)
        {
            string checkBox = "<input id=\"{0}\" type=\"" + pInputType + "\" name=\"{1}\" value=\"{2}\" {4}/><label for=\"{0}\">{3}</label>&nbsp;";

            StringBuilder sbStr = new StringBuilder();
            int i = 0;
            foreach (ItemInfo info in pInfolist)
            {
                int iKey = int.Parse(info.id);
                if ((iKey & pEditValue) == iKey)
                    sbStr.Append(string.Format(checkBox, pControlName + i, pControlName, info.id, info.name, "checked=\"checked\""));
                else
                    sbStr.Append(string.Format(checkBox, pControlName + i, pControlName, info.id, info.name, string.Empty));
                i++;
            }

            return sbStr;
        }
        #endregion

        #region 普通
        public static string GetHtmlCheckBox(IList<ItemInfo> pInfolist, string pControlName, string pEditValue)
        {
            return GetHtml_General(pInfolist, pControlName, pEditValue, "checkbox", string.Empty, string.Empty).ToString();
        }

        public static string GetHtmlRadio(IList<ItemInfo> pInfolist, string pControlName, string pEditValue)
        {
            return GetHtml_General(pInfolist, pControlName, pEditValue, "radio", string.Empty, string.Empty).ToString();
        }

        public static string GetHtmlCheckBox(IList<ItemInfo> pInfolist, string pControlName, string pEditValue, string first_value, string first_text)
        {
            return GetHtml_General(pInfolist, pControlName, pEditValue, "checkbox", first_value, first_text).ToString();
        }

        public static string GetHtmlRadio(IList<ItemInfo> pInfolist, string pControlName, string pEditValue, string first_value, string first_text)
        {
            return GetHtml_General(pInfolist, pControlName, pEditValue, "radio", first_value, first_text).ToString();
        }

        public static StringBuilder GetHtml_General(IList<ItemInfo> pInfolist, string pControlName, string pEditValue, string pInputType, string first_value, string first_text)
        {
            string checkBox = "<input id=\"{0}\" type=\"" + pInputType + "\" name=\"{1}\" value=\"{2}\" {4}/><label for=\"{0}\">{3}</label>&nbsp;";

            StringBuilder sbStr = new StringBuilder();
            int i = 0;

            if (first_text.Length > 0)
            {
                i++;
                if (first_value == pEditValue)
                    sbStr.Append(string.Format(checkBox, pControlName + i, pControlName, first_value, first_text, "checked=\"checked\""));
                else
                    sbStr.Append(string.Format(checkBox, pControlName + i, pControlName, first_value, first_text, string.Empty));

            }

            foreach (ItemInfo info in pInfolist)
            {
                if (info.id == pEditValue)
                    sbStr.Append(string.Format(checkBox, pControlName + i, pControlName, info.id, info.name, "checked=\"checked\""));
                else
                    sbStr.Append(string.Format(checkBox, pControlName + i, pControlName, info.id, info.name, string.Empty));
                i++;
            }

            return sbStr;
        }
        #endregion

        #endregion

        #region 绑定下拉列表 从数据库中读取
        /// <summary>
        /// 绑定下拉列表 sql 语句
        /// </summary>
        /// <param name="pSql">sql 语句</param>
        /// <param name="pHtmlSelect">HtmlSelect</param>
        /// <param name="pEditValue">修改时值</param>
        /// <param name="pFieldValue">值字段 如:ProID</param>
        /// <param name="pFieldText">内容字段 如:ProName</param>
        /// <param name="pFirstValue">第一项的值</param>
        /// <param name="pFirstText">第一项的内容</param>
        public static void BGHtmlSelect(string pSql, HtmlSelect pDropList, string pEditValue, string pFieldValue, string pFieldText, string pFirstValue, string pFirstText)
        {
            if (pFirstText.Length > 0)
                pDropList.Items.Add(new ListItem(pFirstText, pFirstValue));

            using (DataTable dt = DbHelp.GetDataTable(pSql))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    System.Web.UI.WebControls.ListItem drlist = new ListItem();
                    drlist.Text = dr[pFieldText].ToString();
                    drlist.Value = dr[pFieldValue].ToString();

                    if (pEditValue == drlist.Value)
                        drlist.Selected = true;

                    pDropList.Items.Add(drlist);

                }
                dt.Clear();
            }
        }

        /// <summary>
        /// 绑定下拉列表 DataTable
        /// </summary>
        /// <param name="pDt">DataTable</param>
        /// <param name="pDropList">HtmlSelect</param>
        /// <param name="pEditValue">修改时值</param>
        /// <param name="pFieldValue">值字段 如:ProID</param>
        /// <param name="pFieldText">内容字段 如:ProName</param>
        /// <param name="pFirstValue">第一项的值</param>
        /// <param name="pFirstText">第一项的内容</param>
        public static void BGHtmlSelect(DataTable pDt, HtmlSelect pDropList, string pEditValue, string pFieldValue, string pFieldText, string pFirstValue, string pFirstText)
        {
            if (pFirstText.Length > 0)
                pDropList.Items.Add(new ListItem(pFirstText, pFirstValue));

            foreach (DataRow dr in pDt.Rows)
            {
                ListItem drlist = new ListItem();
                drlist.Text = dr[pFieldText].ToString();
                drlist.Value = dr[pFieldValue].ToString();

                if (pEditValue == drlist.Value)
                    drlist.Selected = true;

                pDropList.Items.Add(drlist);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDt"></param>
        /// <param name="pDropList"></param>
        /// <param name="pEditValue"></param>
        /// <param name="pFirstValue"></param>
        /// <param name="pFirstText"></param>
        public static void BGHtmlSelect(DataTable pDt, HtmlSelect pDropList, string pEditValue, string pFirstValue, string pFirstText)
        {
            if (pFirstText.Length > 0)
                pDropList.Items.Add(new ListItem(pFirstText, pFirstValue));

            foreach (DataRow dr in pDt.Rows)
            {
                ListItem drlist = new ListItem();
                drlist.Text = dr[1].ToString();
                drlist.Value = dr[0].ToString();

                if (pEditValue == drlist.Value)
                    drlist.Selected = true;

                pDropList.Items.Add(drlist);
            }
        }

        /// <summary>
        /// 绑定下拉列表 Dictionary<string, string>
        /// </summary>
        /// <param name="pDict"></param>
        /// <param name="pDropList"></param>
        public static void BGHtmlSelect(IList<ItemInfo> pInfolist, HtmlSelect pDropList)
        {
            foreach (ItemInfo info in pInfolist)
            {
                ListItem drlist = new ListItem();
                drlist.Text = info.name;
                drlist.Value = info.id;
                pDropList.Items.Add(drlist);
            }
        }

        /// <summary>
        /// 绑定下拉列表 Dictionary<string, string>
        /// </summary>
        /// <param name="pDict">Dictionary<string, string></param>
        /// <param name="pDropList">HtmlSelect</param>
        /// <param name="pEditValue">修改时值</param>
        public static void BGHtmlSelect(IList<ItemInfo> pInfolist, HtmlSelect pDropList, string pEditValue)
        {
            foreach (ItemInfo info in pInfolist)
            {
                ListItem drlist = new ListItem();
                drlist.Text = info.name;
                drlist.Value = info.id;
                if (pEditValue == info.id)
                    drlist.Selected = true;
                pDropList.Items.Add(drlist);
            }
        }
        #endregion

        #region 下拉列表,返回字符串
        public static string BGHtmlSelect(IList<ItemInfo> pInfolist, string edit_value, string first_value, string first_text)
        {
            StringBuilder sbStr = new StringBuilder();
            if (first_text.Length > 0)
            {
                sbStr.Append("<option value=\"");
                sbStr.Append(first_value);
                sbStr.Append("\">");
                sbStr.Append(first_text);
                sbStr.Append("</option>");
            }

            foreach (ItemInfo info in pInfolist)
            {
                sbStr.Append("<option value=\"");
                sbStr.Append(info.id);
                sbStr.Append("\"");
                if (edit_value == info.id)
                {
                    sbStr.Append(" selected=\"selected\"");
                }
                sbStr.Append(">");
                sbStr.Append(info.name);
                sbStr.Append("</option>");
            }

            return sbStr.ToString();
        }

        public static string GetHtmlSelect(DataTable pDt, string pControlName, string pEditValue, string pFieldValue, string pFieldText, string pFirstValue, string pFirstText)
        {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<select id=\"" + pControlName + "\" name=\"" + pControlName + "\">");
            if (pFirstText.Length > 0)
            {
                sbStr.Append("<option value=\"");
                sbStr.Append(pFirstValue);
                sbStr.Append("\"");

                if (pFirstValue == pEditValue)
                {
                    sbStr.Append(" selected=\"selected\"");
                }

                sbStr.Append(">");

                sbStr.Append(pFirstText);
                sbStr.Append("</option>");
            }

            string lsValue, lsText;
            foreach (DataRow drw in pDt.Rows)
            {
                lsValue = drw[pFieldValue].ToString();
                lsText = drw[pFieldText].ToString();

                sbStr.Append("<option value=\"");
                sbStr.Append(lsValue);
                sbStr.Append("\"");
                if (lsValue == pEditValue)
                {
                    sbStr.Append(" selected=\"selected\"");
                }
                sbStr.Append(">");
                sbStr.Append(lsText);
                sbStr.Append("</option>");
            }
            sbStr.Append("</select>");
            return sbStr.ToString();
        }

        /// <summary>
        /// 树形结构的下拉列表
        /// </summary>
        /// <param name="pDt"></param>
        /// <param name="pControlName"></param>
        /// <param name="pEditValue"></param>
        /// <param name="pFieldValue"></param>
        /// <param name="pFieldText"></param>
        /// <param name="pFieldLevel"></param>
        /// <param name="pFirstValue"></param>
        /// <param name="pFirstText"></param>
        /// <returns></returns>
        public static string GetHtmlSelectTree(DataTable pDt, string pControlName, string pEditValue, string pFieldValue, string pFieldText, string pFieldLevel, string pFirstValue, string pFirstText)
        {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<select id=\"" + pControlName + "\" name=\"" + pControlName + "\">");
            if (pFirstText.Length > 0)
            {
                sbStr.Append("<option value=\"");
                sbStr.Append(pFirstValue);
                sbStr.Append("\"");

                if (pFirstValue == pEditValue)
                {
                    sbStr.Append(" selected=\"selected\"");
                }

                sbStr.Append(">");

                sbStr.Append(pFirstText);
                sbStr.Append("</option>");
            }

            string lsValue, lsText;
            foreach (DataRow drw in pDt.Rows)
            {
                lsValue = drw[pFieldValue].ToString();
                lsText = drw[pFieldText].ToString();

                sbStr.Append("<option value=\"");
                sbStr.Append(lsValue);
                sbStr.Append("\"");
                if (lsValue == pEditValue)
                {
                    sbStr.Append(" selected=\"selected\"");
                }
                sbStr.Append(">");

                int lsLevelN = Fn.IsInt(drw[pFieldLevel].ToString(), 0);

                for (int i = 1; i < lsLevelN; i++)
                    sbStr.Append("&nbsp;&nbsp;&nbsp;&nbsp;");

                if (lsLevelN > 1)
                    sbStr.Append("∟&nbsp;");

                sbStr.Append(lsText);

                sbStr.Append("</option>");
            }
            sbStr.Append("</select>");
            return sbStr.ToString();
        }

        public static string GetHtmlSelect(IList<ItemInfo> pInfolist, string pControlName, string pEditValue, string pFirstValue, string pFirstText)
        {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<select id=\"" + pControlName + "\" name=\"" + pControlName + "\">");
            if (pFirstText.Length > 0)
            {
                sbStr.Append("<option value=\"");
                sbStr.Append(pFirstValue);
                sbStr.Append("\"");

                if (pFirstValue == pEditValue)
                {
                    sbStr.Append(" selected=\"selected\"");
                }

                sbStr.Append(">");

                sbStr.Append(pFirstText);
                sbStr.Append("</option>");
            }

            foreach (ItemInfo info in pInfolist)
            {
                sbStr.Append("<option value=\"");
                sbStr.Append(info.id);
                sbStr.Append("\"");
                if (pEditValue == info.id)
                {
                    sbStr.Append(" selected=\"selected\"");
                }
                sbStr.Append(">");
                sbStr.Append(info.name);
                sbStr.Append("</option>");
            }
            sbStr.Append("</select>");
            return sbStr.ToString();
        }

        public static string GetHtmlSelectOptgroup(IList<ItemInfo> pInfolist, string pControlName, string pEditValue, string pFirstValue, string pFirstText)
        {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("<select id=\"" + pControlName + "\" name=\"" + pControlName + "\">");
            if (pFirstText.Length > 0)
            {
                sbStr.Append("<option value=\"");
                sbStr.Append(pFirstValue);
                sbStr.Append("\"");

                if (pFirstValue == pEditValue)
                {
                    sbStr.Append(" selected=\"selected\"");
                }

                sbStr.Append(">");

                sbStr.Append(pFirstText);
                sbStr.Append("</option>");
            }

            foreach (ItemInfo info in pInfolist)
            {
                if (info.id == "_c_html")
                {
                    sbStr.Append(HttpContext.Current.Server.HtmlDecode(info.name));
                }
                else
                {
                    sbStr.Append("<option value=\"");
                    sbStr.Append(info.id);
                    sbStr.Append("\"");
                    if (pEditValue == info.id)
                    {
                        sbStr.Append(" selected=\"selected\"");
                    }
                    sbStr.Append(">");
                    sbStr.Append(info.name);
                    sbStr.Append("</option>");
                }

            }
            sbStr.Append("</select>");
            return sbStr.ToString();
        }
        #endregion
    }
}
