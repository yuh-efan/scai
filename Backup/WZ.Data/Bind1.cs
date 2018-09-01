using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Data.DataItem;

/*
 * 
 * 与ajax绑定等 相关
 * 
 * */
namespace WZ.Common
{
    public class Bind1
    {
        #region 复选 位
        public class CheckboxBit
        {
            /// <summary>
            /// 属性字段名称
            /// </summary>
            public string fieldName;

            /// <summary>
            /// 主键名称
            /// </summary>
            public string fieldSN;

            /// <summary>
            /// 当前修改的属性值
            /// </summary>
            public int curValue;

            /// <summary>
            /// js的方法名
            /// </summary>
            public string jsClickName = "setSel";

            public CheckboxBit(string pFieldName, string pFieldSN, int pCurValue)
            {
                this.fieldName = pFieldName;
                this.fieldSN = pFieldSN;
                this.curValue = pCurValue;
            }

            public string GetHTML(object pObj)
            {
                DataRowView drv = (DataRowView)pObj;

                const string str = "<input id=\"checkbox_{0}_{1}_{3}\" name=\"checkbox_{0}_{1}_{3}\" onclick=\"{5}({1},'{0}','{3}');\" value=\"{4}\" type=\"checkbox\" {2} />";
                const string str1 = "checked=\"checked\"";

                return string.Format(str, fieldName, drv.Row[fieldSN], IsSel(int.Parse(drv.Row[fieldName].ToString())) ? str1 : string.Empty, curValue, drv.Row[fieldName], jsClickName);
            }

            public bool IsSel(int editValue)
            {
                return ((editValue & curValue) == curValue);
            }
        }
        #endregion

        #region 复选 普通
        public class CheckboxSingle
        {
            /// <summary>
            /// 属性字段名称
            /// </summary>
            public string fieldName;

            /// <summary>
            /// 主键名称
            /// </summary>
            public string fieldSN;

            /// <summary>
            /// js的方法名
            /// </summary>
            public string jsClickName = "setSel";

            public CheckboxSingle(string pFieldName, string pFieldSN)
            {
                this.fieldName = pFieldName;
                this.fieldSN = pFieldSN;
            }

            public string GetHTML(object pObj)
            {
                DataRowView drv = (DataRowView)pObj;

                bool isSel = drv[fieldName].ToString() == "1";

                const string str = "<input id=\"checkbox_{0}_{1}\" name=\"checkbox_{0}_{1}\" onclick=\"{4}({1},'{0}');\" value=\"{3}\" type=\"checkbox\" {2} />";
                const string str1 = "checked=\"checked\"";

                return string.Format(str, fieldName, drv.Row[fieldSN], isSel ? str1 : string.Empty, drv.Row[fieldName], jsClickName);
            }
        }
        #endregion

        #region 单选
        public class RadioMore
        { 
             /// <summary>
            /// 属性字段名称
            /// </summary>
            public string fieldName;

            /// <summary>
            /// 主键名称
            /// </summary>
            public string fieldSN;

            public IList<ItemInfo> infoList;

            /// <summary>
            /// js的方法名
            /// </summary>
            public string jsClickName = "setRadio";

            public RadioMore(string pFieldName, string pFieldSN, IList<ItemInfo> pInfoList)
            {
                this.fieldName = pFieldName;
                this.fieldSN = pFieldSN;
                this.infoList = pInfoList;
            }

            public string GetHTML(object pObj)
            {
                DataRowView drv = (DataRowView)pObj;
                StringBuilder sb = new StringBuilder();

                const string sRadio = "<input id=\"radio_{0}_{1}_{4}\" name=\"radio_{0}_{1}\" onclick=\"{5}({1},{4},'{0}');\" value=\"{4}\" type=\"radio\" {2} /><label for=\"radio_{0}_{1}_{4}\">{3}</label> ";
                const string str1 = "checked=\"checked\"";

                string s1 = drv.Row[fieldSN].ToString();//id值
                string s2 = drv.Row[fieldName].ToString();//字段值

                foreach (ItemInfo info in infoList)
                {
                    sb.Append(string.Format(sRadio, fieldName, s1, info.id == s2 ? str1 : string.Empty, info.name, info.id, jsClickName));
                }

                return sb.ToString();
            }
        }
        #endregion

        #region 文本框
        public class InputText
        {
            /// <summary>
            /// 属性字段名称
            /// </summary>
            public string fieldName;

            /// <summary>
            /// 主键名称
            /// </summary>
            public string fieldSN;

            /// <summary>
            /// 事件触发的方法名
            /// </summary>
            public string jsClickName = "setText";

            /// <summary>
            /// 事件触发类型
            /// </summary>
            public string ClickType = "onchange";

            public string InputID_Prefix = "text_";

            public InputText(string pFieldName, string pFieldSN)
            {
                this.fieldName = pFieldName;
                this.fieldSN = pFieldSN;
            }

            public string GetHTML(object pObj)
            {
                DataRowView drv = (DataRowView)pObj;
                string sVal = drv[fieldName].ToString();
                const string str = "<input id=\"{5}{0}_{1}\" name=\"{5}{0}_{1}\" {4}=\"{3}({1},'{0}');\" type=\"text\" value=\"{2}\" />";
                return string.Format(str, fieldName, drv.Row[fieldSN], sVal, jsClickName, ClickType, InputID_Prefix);
            }
        }
        #endregion
    }
}