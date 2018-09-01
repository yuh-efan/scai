using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WZ.Common
{
    /// <summary>
    /// Js常用功能
    /// </summary>
    public class Js
    {
        #region Alert 点确定后history.back();
        /// <summary>
        ///  Alert 点确定后history.back();
        /// </summary>
        /// <param name="pStr">显示消息内容</param>
        public static void Alert(string pStr)
        {
            HttpContext.Current.Response.Write(Config.HTML.C_H1);
            HttpContext.Current.Response.Write(Config.HTML.C_J1);
            HttpContext.Current.Response.Write("alert('" + pStr + "');history.back();");
            HttpContext.Current.Response.Write(Config.HTML.C_J2);
            HttpContext.Current.Response.Write(Config.HTML.C_H2);
            HttpContext.Current.Response.End();
        }
        #endregion

        #region Alert 点确定后location.href=''
        /// <summary>
        /// Alert 点确定后location.href=''
        /// </summary>
        /// <param name="pStr">显示消息内容</param>
        /// <param name="pPath">跳转路径</param>
        /// <returns></returns>
        public static void Alert(string pStr, string pPath)
        {
            HttpContext.Current.Response.Write(Config.HTML.C_H1);
            HttpContext.Current.Response.Write(Config.HTML.C_J1);
            HttpContext.Current.Response.Write("alert('" + pStr + "');location.href='" + pPath + "'");
            HttpContext.Current.Response.Write(Config.HTML.C_J2);
            HttpContext.Current.Response.Write(Config.HTML.C_H2);
            HttpContext.Current.Response.End();
        }
        #endregion

        #region Alert 点确定后window.close();
        /// <summary>
        /// Alert 点确定后window.close();
        /// </summary>
        /// <param name="pStr">显示消息内容</param>
        public static void AlertClose(string pStr)
        {
            HttpContext.Current.Response.Write(Config.HTML.C_H1);
            HttpContext.Current.Response.Write(Config.HTML.C_J1);
            HttpContext.Current.Response.Write("alert('" + pStr + "');window.close();");
            HttpContext.Current.Response.Write(Config.HTML.C_J2);
            HttpContext.Current.Response.Write(Config.HTML.C_H2);
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 输出js,执行Response.End()
        /// <summary>
        /// 输出js,执行Response.End()
        /// </summary>
        /// <param name="pStr">js代码</param>
        public static void Write(string pStr)
        {
            HttpContext.Current.Response.Write(Config.HTML.C_H1);
            HttpContext.Current.Response.Write(Config.HTML.C_J1);
            HttpContext.Current.Response.Write(pStr);
            HttpContext.Current.Response.Write(Config.HTML.C_J2);
            HttpContext.Current.Response.Write(Config.HTML.C_H2);
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 输出js,无Response.End()
        /// <summary>
        /// 输出js,无Response.End()
        /// </summary>
        /// <param name="pStr">显示消息内容</param>
        public static void WriteNoEnd(string pStr)
        {
            HttpContext.Current.Response.Write(Config.HTML.C_H1);
            HttpContext.Current.Response.Write(Config.HTML.C_J1);
            HttpContext.Current.Response.Write(pStr);
            HttpContext.Current.Response.Write(Config.HTML.C_J2);
            HttpContext.Current.Response.Write(Config.HTML.C_H2);
        }
        #endregion

        #region 全屏跳转 parent.top.location.href=''
        /// <summary>
        /// 全屏跳转 parent.top.location.href=''
        /// </summary>
        /// <param name="pStr">跳转路径</param>
        /// <returns></returns>
        public static void Parent(string pStr)
        {
            HttpContext.Current.Response.Write(Config.HTML.C_H1);
            HttpContext.Current.Response.Write(Config.HTML.C_J1);
            HttpContext.Current.Response.Write("parent.top.location.href='" + pStr + "';");
            HttpContext.Current.Response.Write(Config.HTML.C_J2);
            HttpContext.Current.Response.Write(Config.HTML.C_H2);
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 是否跳转 Confirm
        /// <summary>
        /// 是否跳转 Confirm
        /// </summary>
        /// <param name="pStr">显示消息内容</param>
        /// <param name="pPathYes">点"是" 跳转路径</param>
        /// <param name="pPathNo">点"否" 跳转路径</param>
        public static void Confirm(string pStr, string pPathYes, string pPathNo)
        {
            HttpContext.Current.Response.Write(Config.HTML.C_H1);
            HttpContext.Current.Response.Write(Config.HTML.C_J1);
            HttpContext.Current.Response.Write("if(confirm('" + pStr + "')){location.href='" + pPathYes + "';}else{location.href='" + pPathNo + "';}");
            HttpContext.Current.Response.Write(Config.HTML.C_J2);
            HttpContext.Current.Response.Write(Config.HTML.C_H2);
            HttpContext.Current.Response.End();
        }
        #endregion
    }
}
