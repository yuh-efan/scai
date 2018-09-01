using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.Security;
using System.Data;
using System.Net;
using System.IO;
using System.Configuration;

namespace WZ.Common
{
    /// <summary>
    /// 常用功能
    /// </summary>
    public class Fn
    {
        #region 判断是否是Int
        /// <summary>
        /// 判断是否是Int 不是返回 pReturn
        /// </summary>
        /// <param name="pStr">数字字符串</param>
        /// <param name="pReturn">不是Int时返回值</param>
        /// <returns></returns>
        public static int IsInt(string pStr, int pReturn)
        {
            int n;
            if (!int.TryParse(pStr, out n))
                return pReturn;
            return n;
        }

        /// <summary>
        /// 判断是否是Int
        /// </summary>
        /// <param name="pStr">数字字符串</param>
        /// <returns></returns>
        public static bool IsIntBool(string pStr)
        {
            int n;
            return int.TryParse(pStr, out n);

            //Regex r = new Regex(@"^[-]?[0-9]+$");
            //return r.IsMatch(pStr);
        }
        #endregion

        #region 判断是否是byte
        /// <summary>
        /// 判断是否是Int 不是返回 pReturn
        /// </summary>
        /// <param name="pStr">数字字符串</param>
        /// <param name="pReturn">不是Int时返回值</param>
        /// <returns></returns>
        public static byte IsByte(string pStr, byte pReturn)
        {
            byte n;
            if (!byte.TryParse(pStr, out n))
                return pReturn;
            return n;
        }

        /// <summary>
        /// 判断是否是Int
        /// </summary>
        /// <param name="pStr">数字字符串</param>
        /// <returns></returns>
        public static bool IsByteBool(string pStr)
        {
            byte n;
            return byte.TryParse(pStr, out n);

            //Regex r = new Regex(@"^[-]?[0-9]+$");
            //return r.IsMatch(pStr);
        }
        #endregion

        #region 判断是否是Long
        /// <summary>
        /// 判断是否是Long 不是返回 pReturn
        /// </summary>
        /// <param name="pStr">数字字符串</param>
        /// <param name="pReturn">不是Long时返回值</param>
        /// <returns></returns>
        public static long IsLong(string pStr, long pReturn)
        {
            long n;
            if (!long.TryParse(pStr, out n))
                return pReturn;
            return n;
        }

        /// <summary>
        /// 判断是否是Long 不是返回 bool
        /// </summary>
        /// <param name="pStr">数字字符串</param>
        /// <returns></returns>
        public static bool IsLongBool(string pStr)
        {
            long n;
            return long.TryParse(pStr, out n);
        }
        #endregion

        #region 判断是否是Double
        /// <summary>
        /// 判断是否是Double 不是返回 pReturn
        /// </summary>
        /// <param name="pStr">数字字符串</param>
        /// <param name="pReturn">非Double时返回值</param>
        /// <returns></returns>
        public static double IsDouble(string pStr, double pReturn)
        {
            double n;
            if (!double.TryParse(pStr, out n))
                return pReturn;
            return n;
        }

        /// <summary>
        /// 判断是否是Double 不是返回 Bool
        /// </summary>
        /// <param name="pStr">数字字符串</param>
        /// <returns>bool</returns>
        public static bool IsDoubleBool(string pStr)
        {
            double n;
            return double.TryParse(pStr, out n);

            //Regex r = new Regex(@"^[-]?[0-9.]+$");
            //return r.IsMatch(pStr);
        }
        #endregion

        #region 判断是否是DateTime
        /// <summary>
        /// 判断是否是DateTime 不是返回 pReturn
        /// </summary>
        /// <param name="pStr">数字字符串</param>
        /// <param name="pReturn">非DateTime时返回值</param>
        /// <returns></returns>
        public static DateTime IsDate(string pStr, DateTime pReturn)
        {
            DateTime n;
            if (!DateTime.TryParse(pStr, out n))
                return pReturn;
            return n;
        }

        /// <summary>
        /// 判断是否是DateTime 不是返回 bool
        /// </summary>
        /// <param name="pStr">数字字符串</param>
        /// <returns></returns>
        public static bool IsDateBool(string pStr)
        {
            DateTime n;
            return DateTime.TryParse(pStr, out n);
        }

        /// <summary>
        /// 判断时间是否当天范围
        /// </summary>
        /// <param name="time"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static bool IsDateDayArea(DateTime time, TimeSpan startTime, TimeSpan endTime)
        {
            DateTime dayMinTime = DateTime.Parse(time.ToString("yyyy-MM-dd"));
            if ((time < dayMinTime.Add(startTime)) || (time > dayMinTime.Add(endTime)))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 正则验证
        public enum EnumRegex
        {
            //数字,
            用户名,
            电子邮件
        }

        //public static readonly string[] S_ArrRegex = {
        //                                           @"^[-]?[0-9]+$",
        //                                           @"^([a-zA-Z]|[\u4e00-\u9fa5]){1}([\w]|[\u4e00-\u9fa5])+$",//5-18位 (中文 大小英文)开头  数字  _   
        //                                           @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
        //                                           };

        public static readonly Regex[] ArrCheckRegex = {
                                                       //new Regex(@"^[-]?[0-9]+$"),
                                                       new Regex(@"^([0-9a-zA-Z]|[\u4e00-\u9fa5]){1}([\w]|[\u4e00-\u9fa5])+$"),//5-18位 (中文 大小英文)开头  数字  _   
                                                       new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"),
                                                       };

        public static bool IsRegex(string pStr, EnumRegex pEnum)
        {
            return ArrCheckRegex[(int)pEnum].IsMatch(pStr);
        }
        #endregion

        #region Md5加密两次
        /// <summary>
        /// Md5加1密两次
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static string MD5(string pStr)
        {
            string s = FormsAuthentication.HashPasswordForStoringInConfigFile(pStr, "md5");
            s = FormsAuthentication.HashPasswordForStoringInConfigFile(s, "md5");
            return s;
        }
        #endregion

        #region 位 是否有此位
        /// <summary>
        /// 位 是否有此位
        /// </summary>
        /// <returns></returns>
        public static bool IsHasBit(int pEditValue, int pValue)
        {
            return (pEditValue & pValue) >= pValue;
        }
        #endregion

        #region 长度 一个汉字两个字符
        /// <summary>
        /// 字符串长度 一个汉字两个字符
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static int HanZiLen(string pStr)
        {
            return Encoding.Default.GetBytes(pStr).Length;
        }
        #endregion

        #region 载取左字符
        /// <summary>
        /// 载取左字符
        /// </summary>
        /// <param name="pStr">字符串内容</param>
        /// <param name="pLen">数据个数</param>
        /// <param name="pReturn">超出时后边要加的返回的内容</param>
        /// <returns></returns>
        public static string Left(string pStr, int pLen, string pReturn)
        {
            if (pStr == null)
            {
                return string.Empty;
            }

            int n = pStr.Length;
            if (n == 0)
            {
                return string.Empty;
            }

            if (n >= pLen)
            {
                return pStr.Substring(0, pLen) + pReturn;
            }
            else
            {
                return pStr;
            }
        }
        #endregion
        
        #region 过滤字符串的非int字符 逗号隔开
        /// <summary>
        /// 过滤字符串的非int字符 逗号隔开
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static string IsIntArr(string pStr)
        {
            string sStr = string.Empty;
            string[] ArrStr = pStr.Split(',');

            for (int i = 0; i < ArrStr.Length; i++)
            {
                string lsStr = ArrStr[i];

                if (Fn.IsIntBool(lsStr))
                    sStr += lsStr + ',';
                else
                    continue;
            }

            if (sStr.Length > 0)
                sStr = sStr.TrimEnd(',');

            return sStr;
        }
        #endregion

        #region 过滤字符串的非int字符
        /// <summary>
        /// 过滤字符串的非int字符
        /// </summary>
        /// <param name="pStr"></param>
        /// <param name="pSplit">分隔符</param>
        /// <returns></returns>
        public static string IsIntArr(string pStr, char pSplit)
        {
            string sStr = string.Empty;
            string[] ArrStr = pStr.Split(pSplit);

            for (int i = 0; i < ArrStr.Length; i++)
            {
                string lsStr = ArrStr[i];

                if (Fn.IsIntBool(lsStr))
                    sStr += lsStr + pSplit;
                else
                    continue;
            }

            if (sStr.Length > 0)
                sStr = sStr.TrimEnd(pSplit);

            return sStr;
        }
        #endregion

        #region 字符串是否可以 转 int[] 是:true 否:false
        /// <summary>
        /// 字符串是否可以 转 int[] 是:true 否:false
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static bool IsIntArrBool(string pStr)
        {
            string[] ArrStr = pStr.Split(',');
            bool b = true;

            for (int i = 0; i < ArrStr.Length; i++)
            {
                if (!Fn.IsIntBool(ArrStr[i]))
                {
                    b = false;
                    break;
                }
            }

            return b;
        }
        #endregion

        #region 判断验证码是否正确
        /// <summary>
        /// 判断验证码是否正确 true:正确 false:错误 删除session
        /// </summary>
        /// <returns></returns>
        public static bool IsVerifyCode(string pTxtName, string pSessionCodeName)
        {
            bool b = true;
            string strCode = Req.GetForm(pTxtName).Trim();
            string strCode1 = Req.GetSession(pSessionCodeName).Trim();

            if (strCode.Length == 0 || (string.Compare(strCode, strCode1, true) != 0))
            {
                b = false;
            }
            HttpContext.Current.Session.Remove(pSessionCodeName);
            return b;
        }

        /// <summary>
        /// 判断验证码是否正确 true:正确 false:错误 不删除session
        /// </summary>
        /// <param name="pTxtName"></param>
        /// <param name="pSessionCodeName"></param>
        /// <returns></returns>
        public static bool IsVerifyCode1(string pTxtName, string pSessionCodeName)
        {
            bool b = true;
            string strCode = Req.GetForm(pTxtName).Trim();
            string strCode1 = Req.GetSession(pSessionCodeName).Trim();

            if (strCode.Length == 0 || (string.Compare(strCode, strCode1, true) != 0))
            {
                b = false;
            }
            return b;
        }
        #endregion

        #region 生成编号
        private static Random S_Rand = new Random();
        /// <summary>
        /// 生成编号
        /// </summary>
        /// <returns></returns>
        public static string SCNumber()
        {
            System.Threading.Thread.Sleep(new TimeSpan(1));
            return DateTime.Now.ToString("yyyyMMddhhmmss") + DateTime.Now.Millisecond;//需要要优化
        }

        /// <summary>
        /// 20位guid
        /// </summary>
        /// <returns></returns>
        public static string GetGuid20()
        {
            string s = Guid.NewGuid().ToString();
            return s.Substring(0, 8) + s.Substring(24, 12);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCount"></param>
        /// <param name="pNum"></param>
        public static Dictionary<string, string> SCNumber(int pCount, int pNum)
        {
            if (pCount.ToString().Length > pNum)
            {
                throw new Exception("位数值必须大于数量位数");
            }

            Dictionary<string, string> list = new Dictionary<string, string>();
            StringBuilder sb = new StringBuilder();
            int n = 0;
            for (int i = 0; i < pCount; i++)
            {
                n++;
                for (int j = 0; j < pNum; j++)
                {
                    sb.Append(S_Rand.Next(0, 10));
                }

                try
                {
                    list.Add(sb.ToString(), "");
                }
                catch
                {
                    i--;
                }

                sb.Remove(0, sb.Length);
            }
            return list;
        }

        #endregion

        #region IList<int> 所有值相或
        /// <summary>
        /// 将一个数组 所有值相或
        /// </summary>
        /// <returns></returns>
        public static int IntArrToBit(int[] pList)
        {
            int n = 0;
            foreach (int i in pList)
            {
                n = n | i;
            }
            return n;
        }
        #endregion

        #region string转int[]
        /// <summary>
        /// string转int[]
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static int[] StrToIntArr(string pStr)
        {
            string[] ArrStr = pStr.Split(',');
            int[] iStr = new int[ArrStr.Length];

            for (int i = 0; i < ArrStr.Length; i++)
                iStr[i] =int.Parse(ArrStr[i]);
            return iStr;
        }
        #endregion

        #region DataTable转Dictionary
        /// <summary>
        /// DataTable转Dictionary
        /// </summary>
        /// <param name="pDt"></param>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public static Dictionary<string, string> DtToDic(DataTable pDt, string pKey, string pValue)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataRow drw in pDt.Rows)
            {
                dic.Add(drw[pKey].ToString(), drw[pValue].ToString());
            }

            return dic;
        }
        #endregion

        #region DataRow转DataTable

        public static void DrwToDt(DataRow[] pArrDrw, DataTable pDt)
        {
            if (pArrDrw == null)
                return;
            for (int i = 0; i <= pArrDrw.Length - 1; i++)
                pDt.ImportRow(pArrDrw[i]);
        }

        public static void DrwToDt(IList<DataRow> pList, DataTable pDt)
        {
            foreach (DataRow drw in pList)
                pDt.ImportRow(drw);
        }
        #endregion

        #region 设置DataTable 主键
        /// <summary>
        /// 设置DataTable 主键
        /// </summary>
        public static void SetDataTablePrimary(DataTable pDt)
        {
            DataColumn[] dc = new DataColumn[1];
            dc[0] = pDt.Columns[0];
            pDt.PrimaryKey = dc;
        }
        #endregion

        #region 获取DataTable 主键的对应记录的指定字段值
        /// <summary>
        /// 获取Key的Name值
        /// 不会返回null
        /// </summary>
        /// <param name="pDt"></param>
        /// <param name="pKeyValue"></param>
        /// <param name="pFieldName"></param>
        /// <returns></returns>
        public static object GetDataTableFind(DataTable pDt, object pKeyValue, string pFieldName)
        {
            if (pDt == null || pDt.Rows.Count == 0)
                return string.Empty;

            //Find方法找不到记录时返回null,而不是一个实例化后的空对象
            DataRow drw = pDt.Rows.Find(pKeyValue);
            if (drw == null)
                return string.Empty;

            return drw[pFieldName];
        }

        
        #endregion

        #region 获取DataTable 第一行的指定字段值(根据检索结果)
        /// <summary>
        /// 获取DataTable 第一行的指定字段值(根据检索结果)
        /// </summary>
        /// <param name="pDt"></param>
        /// <param name="pWhere"></param>
        /// <param name="pFieldName"></param>
        /// <returns></returns>
        public static object GetDataTableValue(DataTable pDt, string pWhere, string pFieldName)
        {
            if (pDt == null || pDt.Rows.Count == 0)
                return string.Empty;

            DataRow[] arrDrw = pDt.Select(pWhere);
            if (arrDrw.Length > 0)
                return arrDrw[0][pFieldName];
            else
                return string.Empty;
        }
        #endregion

        #region 获取DataTable 第一行的指定字段值
        /// <summary>
        /// 获取DataTable 第一行的指定字段值
        /// </summary>
        /// <param name="pDt"></param>
        /// <param name="pFieldName"></param>
        /// <returns></returns>
        public static object GetDataTableFirst(DataTable pDt, string pFieldName)
        {
            if (pDt == null || pDt.Rows.Count == 0)
                return string.Empty;

            return pDt.Rows[0][pFieldName];
        }
        #endregion

        #region 刷新自身页面
        /// <summary>
        /// 刷新自身页面
        /// </summary>
        public static void RefreshSelf()
        {
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }
        #endregion

        #region 获取按钮控件CommandName
        /// <summary>
        /// 获取按钮控件CommandName
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static string GetCommandName(object sender)
        {
            return ((IButtonControl)sender).CommandName.ToString();
        }
        #endregion

        #region Html过滤
        /// <summary>
        /// Html过滤
        /// </summary>
        /// <param name="pHtml"></param>
        /// <returns></returns>
        public static string ReplaceHTML(string pHtml)
        {
            return TestReplace.ReplaceHtmlTag(pHtml).Replace(" ", string.Empty).Replace("　", string.Empty);
        }

        public class TestReplace
        {
            private TestReplace() { }

            private static string sNR = "\r\n";
            private static string sXiaoYu = "<";
            private static string sDaYu = ">";
            private static IList<Regex> iList = new List<Regex>();

            private static string[] aReplace = new string[]
            {
                "","","","","","","","\"","&","<",">","","\xa1","\xa2","\xa3","\xa9",""
            };

            static TestReplace()
            {
                string[] aPattern = new string[]
                                    {
                                        @"<script.*?</script>",
                                        @"<style.*?</style>",
                                        @"<.*?>",
                                        @"<(.[^>]*)>",
                                        @"([\r\n])[\s]+",
                                        @"-->",
                                        @"<!--.*",
                                        @"&(quot|#34);",
                                        @"&(amp|#38);",
                                        @"&(lt|#60);",
                                        @"&(gt|#62);",
                                        @"&(nbsp|#160);",
                                        @"&(iexcl|#161);",
                                        @"&(cent|#162);",
                                        @"&(pound|#163);",
                                        @"&(copy|#169);",
                                        @"&#(\d+);"
                                    };

                for (int i = 0; i < aPattern.Length; i++)
                {
                    iList.Add(new Regex(aPattern[i]));
                }
            }

            /// <summary>
            /// 去除HTML标记
            /// </summary>
            /// <param name="Htmlstring">包括HTML的源码 </param>
            /// <returns>已经去除后的文字</returns>
            public static string ReplaceHtmlTag(string Htmlstring)
            {
                Htmlstring = Htmlstring.Replace(sNR, string.Empty);

                Regex r;
                for (int i = 0; i < iList.Count; i++)
                {
                    r = iList[i];
                    if (r != null)
                        Htmlstring = r.Replace(Htmlstring, aReplace[i], -1, 0);
                }

                Htmlstring = Htmlstring.Replace(sXiaoYu, string.Empty);
                Htmlstring = Htmlstring.Replace(sDaYu, string.Empty);
                Htmlstring = Htmlstring.Replace(sNR, string.Empty);
                return Htmlstring;
            }
        }
        #endregion

        #region 获取页面html
        public static string GetPageHtml(string pURL)
        {
            string s = string.Empty;
            WebRequest wRequest = WebRequest.Create(pURL);
            using (WebResponse wResponse = wRequest.GetResponse())
            {
                using (StreamReader sr = new StreamReader(wResponse.GetResponseStream(), Encoding.UTF8))
                {
                    s = sr.ReadToEnd();
                }
            }
            return s;
        }

        /// <summary>
        /// post
        /// </summary>
        /// <param name="pUrl"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string GetHttpWebResponse(string pUrl, string postData)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(pUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.Timeout = 20000;

            HttpWebResponse response = null;

            try
            {
                StreamWriter swRequestWriter = new StreamWriter(request.GetRequestStream());
                swRequestWriter.Write(postData);
                if (swRequestWriter != null)
                    swRequestWriter.Close();

                response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
        }

        #endregion

        #region 获取 服务器控件生成的html
        /// <summary>
        /// 获取 服务器控件生成的html
        /// </summary>
        /// <param name="pCtrl"></param>
        /// <returns></returns>
        public static string GetControlHtml(System.Web.UI.Control pCtrl)
        {
            string strHtml = string.Empty;
            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw))
                {
                    pCtrl.RenderControl(htw);
                    strHtml = sw.ToString();
                }
            }



            return strHtml;
        }
        #endregion

        #region Html编码
        /// <summary>
        /// Html编码
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static string EncodeHtml(string pStr)
        {
            return HttpContext.Current.Server.HtmlEncode(pStr);
        }
        #endregion

        #region Response.CacheControl = "no-cache"
        /// <summary>
        /// Response.CacheControl = "no-cache"
        /// </summary>
        public static void ResponseNoCache()
        {
            HttpContext.Current.Response.CacheControl = "no-cache";
        }
        #endregion

        #region 获取或设置Cookie
        public static void SetCookie(string pName, string pValue, DateTime pTime)
        {
            HttpCookie hc = new HttpCookie(pName, HttpUtility.UrlEncode(pValue));
            if (pTime > DateTime.Now)
                hc.Expires = pTime;
            HttpContext.Current.Response.Cookies.Add(hc);
        }

        public static void RemoveCookie(string pName)
        {
            HttpCookie hc = HttpContext.Current.Request.Cookies[pName];
            if (hc == null)
                return;
            hc.Expires = DateTime.Now.AddMinutes(-1);
            HttpContext.Current.Response.Cookies.Add(hc);
        }
        #endregion

        #region 获取配置文件AppSettings
        public static string GetAppSettings(string pName)
        {
            return ConfigurationManager.AppSettings[pName];
        }
        #endregion

    }
}