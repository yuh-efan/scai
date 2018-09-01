using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Reflection;
using System.Net;
using System.IO;

namespace WZ.Common
{
    public class Req
    {
        #region 获取Session
        /// <summary>
        /// 获取Session
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static string GetSession(string pStr)
        {
            object o = HttpContext.Current.Session[pStr];
            return o == null ? string.Empty : o.ToString();
        }
        #endregion

        #region 得到Request.QueryString
        /// <summary>
        /// 得到Request.QueryString
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static string GetQueryString(string pStr)
        {
            string s = HttpContext.Current.Request.QueryString[pStr];
            return s == null ? string.Empty : s;
        }
        #endregion

        #region 得到Request.Form
        /// <summary>
        /// 得到Request.Form
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static string GetForm(string pStr)
        {
            string s = HttpContext.Current.Request.Form[pStr];
            return s == null ? string.Empty : s;
        }
        #endregion

        #region 得到Request.Cookies
        /// <summary>
        /// 得到Request.Cookies
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static string GetCookies(string pStr)
        {
            HttpCookie hc = HttpContext.Current.Request.Cookies[pStr];
            return hc == null ? string.Empty : HttpUtility.UrlDecode(hc.Value);
        }
        #endregion

        #region 得到 Request 的全部
        /// <summary>
        /// 得到 Request 的全部
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static string GetRequest(string pStr)
        {
            string s = HttpContext.Current.Request[pStr];
            return s == null ? string.Empty : s;
        }
        #endregion

        #region 获取上一页URL
        /// <summary>
        /// 获取上一页URL
        /// </summary>
        /// <param name="pNoReturn">获取不到时返回值</param>
        /// <returns></returns>
        public static string GetUrlReferrer(string pNoReturn)
        {
            string s;
            try
            {
                s = HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch
            {
                s = pNoReturn;
            }
            return s;
        }
        #endregion

        #region 获得当前页面的名称
        /// <summary>
        /// 获得当前页面的名称
        /// </summary>
        /// <returns></returns>
        public static string PageName()
        {
            string[] aStr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return aStr[aStr.Length - 1].ToLower();
        }
        #endregion

        #region 返回表单或Url参数的总个数(即Form+QueryString的参数总个数)
        /// <summary>
        /// 返回表单或Url参数的总个数(即Form+QueryString的参数总个数)
        /// </summary>
        /// <returns></returns>
        public static int ParamCount()
        {
            return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
        }
        #endregion

        #region 获取id
        /// <summary>
        /// 常用 获取ID 默认获取URL id参数 不是数值时返回值为0
        /// </summary>
        /// <returns></returns>
        public static int GetID()
        {
            return Fn.IsInt(GetQueryString("id"), 0);
        }

        /// <summary>
        /// 常用 获取ID 不是数值时返回值为0
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static int GetID(string pStr)
        {
            return Fn.IsInt(GetQueryString(pStr), 0);
        }

        /// <summary>
        /// 常用 获取ID
        /// </summary>
        /// <param name="pStr"></param>
        /// <param name="pReturn">不是数值时返回值</param>
        /// <returns></returns>
        public static int GetID(string pStr, int pReturn)
        {
            return Fn.IsInt(GetQueryString(pStr), pReturn);
        }
        #endregion

       
        

        //public static class GetRequestToObject//<T> where T : new()
        //{
        //    /// <summary>
        //    /// 为Model赋值
        //    /// </summary>
        //    /// <typeparam name="T">Model</typeparam>
        //    /// <param name="t">model</param>
        //    /// <param name="form">Request</param>
        //    /// <returns></returns>
        //    public static int GetPost<T>(T t, System.Collections.Specialized.NameValueCollection form)
        //    {
        //        int va = 0;
        //        Type type = t.GetType();//获取类型
        //        PropertyInfo[] pi = type.GetProperties();//获取属性集合
        //        foreach (PropertyInfo p in pi)
        //        {
        //            HttpContext.Current.Response.Write(p.Name+"<br>");

        //            if (form[p.Name] != null)
        //            {
        //                try
        //                {
        //                    p.SetValue(t, Convert.ChangeType(form[p.Name], p.PropertyType), null);//为属性赋值，并转换键值的类型为该属性的类型
        //                    va++;//记录赋值成功的属性数
        //                }
        //                catch(Exception e)
        //                {
        //                    throw new Exception("系统异常提示:" + p.Name+" "+e.Message);
        //                }
        //            }
        //        }
        //        return va;
        //    }
        //}


    }
}