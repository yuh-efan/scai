using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WZ.Data
{
    public class GetURL
    {
        public const string noPic_s = "/images/nopic_s.gif";
        public const string noPic = "/images/nopic.gif";

        public class Default
        {
            /// <summary>
            /// 首页
            /// </summary>
            /// <returns></returns>
            public static string Home()
            {
                return "/default.aspx";
            }
        }

        public class News
        {
            public static string Info(object pObj)
            {
                string str = string.Empty;
                DataRowView drv = (DataRowView)pObj;
                string urlType = drv["UrlType"].ToString();
                if (urlType == "2")
                    str = drv["Url"].ToString();
                else
                    str = Info(drv["NewsSN"].ToString());

                return str;
            }

            public static string Info(DataRow drw)
            {
                string str = string.Empty;
                string urlType = drw["UrlType"].ToString();
                if (urlType == "2")
                    str = drw["Url"].ToString();
                else
                    str = Info(drw["NewsSN"].ToString());

                return str;
            }

            public static string Info(string pStr)
            {
                return "/news/1/article/" + pStr + ".html";
            }

            public static string Class(object pObj)
            {
                return "/news/1/class/" + pObj + ".html";
            }

            public static string Pic(object pName)
            {
                return "/pf/news/" + pName;
            }

            public static string Msg(object pObj)
            {
                return "/news/1/msg.aspx?s=" + pObj;
            }
        }

        /// <summary>
        /// 产品
        /// </summary>
        public class Pro
        {
            public const string picPath = "/pf/pro/";
            public static string Info(object pObj)
            {
                return "/product/show/" + pObj + ".html";
            }

            public static string Class(object pObj)
            {
                return "/product/category/" + pObj + ".html";
            }

            public static string Pic(object pName)
            {
                string s = pName.ToString();
                if (s.Length == 0)
                    return noPic;
                return picPath + s;
            }
        }

        /// <summary>
        /// 菜谱
        /// </summary>
        public class CaiPu
        {
            public const string picPath = "/pf/caipu/";

            public static string Info(object pObj)
            {
                return "/caipu/show/" + pObj + ".html";
            }

            public static string Class(object pObj)
            {
                return "/caipu/category/" + pObj + ".html";
            }

            public static string Pic(object pName)
            {
                string s = pName.ToString();
                if (s.Length == 0)
                    return noPic;
                return picPath + s;
            }

            public static string Default()
            {
                return "/caiPu/";
            }
        }

        /// <summary>
        /// 套餐
        /// </summary>
        public class TaoCan
        {
            public static string Info(object pObj)
            {
                return "/taocan/show/" + pObj + ".html";
            }

            public static string Class(object pObj)
            {
                return "/taocan/category/" + pObj + ".html";
            }

            public static string Pic(object pName)
            {
                string s = pName.ToString();
                if (s.Length == 0)
                    return noPic;
                return "/pf/taocan/" + s;
            }

            public static string Default()
            {
                return "/taoCan/";
            }
        }

        //public class Pro_Class
        //{
        //    public static string Info(object pID)
        //    {
        //        return "/product/pro_class_list.aspx?id=" + pID;
        //    }
        //}

        /// <summary>
        /// 帮助
        /// </summary>
        public class Help
        {
            public static string Info(object pID)
            {
                return "/help/?id=" + pID;
            }

            public static string Class(object pID)
            {
                return "/help/class.aspx?id=" + pID;
            }
        }

        /// <summary>
        /// 友情链接
        /// </summary>
        public class Links
        {
            public static string Pic(object pName)
            {
                return "/pf/links/" + pName;
            }
        }

        /// <summary>
        /// 广告 宣传
        /// </summary>
        public class Adv
        {
            public static string Pic(object pName)
            {
                return "/pf/adv/" + pName;
            }
        }

        /// <summary>
        /// 幻灯片
        /// </summary>
        public class PPT
        {
            public static string Pic(object pName)
            {
                return "/pf/info/" + pName;
            }
        }

        /// <summary>
        /// 礼品兑换
        /// </summary>
        public class Gift
        {
            public static string Pic(object pName)
            {
                return "/pf/Gift/" + pName;
            }

            public static string Info(object pID)
            {
                return "/floatLayer/gift.aspx?id=" + pID;
            }

        }
    }
}
