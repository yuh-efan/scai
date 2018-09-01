using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WZ.Common
{
    /// <summary>
    /// URL参数处理
    /// </summary>
    public class URLPara
    {
        public Dictionary<string, string> d = new Dictionary<string, string>();

        public URLPara() { }

        public void QueryStringToURLPara()
        {
            foreach (string s in HttpContext.Current.Request.QueryString)
            {
                if (s == null)
                    continue;
                d.Add(s, Req.GetQueryString(s));
            }
        }

        /// <summary>
        /// 单个参数修改
        /// </summary>
        /// <param name="pKey">参数名</param>
        /// <param name="pValue">参数值</param>
        /// <returns>string</returns>
        public string ToString(string pKey, string pValue)
        {
            if (!d.ContainsKey(pKey))
                d.Add(pKey, pValue);
            return HttpContext.Current.Request.Url.AbsolutePath + "?" + GetURL(pKey, pValue);
        }

        /// <summary>
        /// 多个参数修改
        /// </summary>
        /// <param name="pD">Dictionary string, string</param>
        /// <returns>string</returns>
        public string ToString(Dictionary<string, string> pD)
        {
            foreach (string s in pD.Keys)
            {
                if (d.ContainsKey(s))
                    d[s] = pD[s];
                else
                    d.Add(s, pD[s]);
            }
            return HttpContext.Current.Request.Url.AbsolutePath + "?" + GetURL(string.Empty, string.Empty);
        }

        public void DeleteKey(string pStr)
        {
            if (d.ContainsKey(pStr))
            {
                d.Remove(pStr);
            }
        }

        private string GetURL(string pKey, string pValue)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string s in d.Keys)
            {
                string strKey;
                string strValue;

                if (s == pKey)
                {
                    strKey = pKey;
                    strValue = pValue;
                }
                else
                {
                    strKey = s;
                    strValue = d[s];
                }

                if (strValue.Length > 0)
                {
                    sb.Append('&');
                    sb.Append(strKey);
                    sb.Append('=');
                    sb.Append(strValue);
                }
            }
            return sb.ToString().TrimStart('&');
        }
    }
}
