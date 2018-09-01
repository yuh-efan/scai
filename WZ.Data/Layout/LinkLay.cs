using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using WZ.Common;

namespace WZ.Data.Layout
{
    public class LinkLay
    {
        public static StringBuilder list1(DataTable dt, LayoutInfoLink li)
        {
            StringBuilder sb = new StringBuilder();
            return sb;
        }

        /// <summary>
        /// 新闻列表 需要 UrlType,Url,Title1,Title,NewsSN,EditDate
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="li"></param>
        /// <returns></returns>
        public static StringBuilder list2(DataTable dt, LayoutInfoLink li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.News.Info(drw) + "\" " + li.target + " title=\"" + drw["Title"] + "\">" + FnData.GetNewsTitle(drw) + "</a> <span class=\"newsdate\">" + Fn.IsDate( drw["EditDate"].ToString(),DateTime.Now).ToString("yyyy-MM-dd") + "</span>");
                sb.Append("</li>");
            }
            return sb;
        }

        /// <summary>
        /// 新闻列表 需要 UrlType,Url,Title1,Title,NewsSN
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="li"></param>
        /// <returns></returns>
        public static StringBuilder list3(DataTable dt, LayoutInfoLink li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.News.Info(drw) + "\" " + li.target + " title=\"" + drw["Title"] + "\">" + FnData.GetNewsTitle(drw) + "</a>");
                sb.Append("</li>");
            }
            return sb;
        }



        /// <summary>
        /// 公告 首页
        /// </summary>
        public static StringBuilder listNotice1(DataTable dt, LayoutInfoLink li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.News.Info(drw) + "\" " + li.target + " title=\"" + drw["Title"] + "\">" + FnData.GetNewsTitle(drw) + "</a>");
                //sb.Append("<img src=\"/images/index/Notice_0" + FnData.GetNewsImg(drw) + ".gif\" />");
                //sb.Append("<span><a href=\"" + GetURL.News.Info(drw) + "\" " + li.target + " title=\"" + drw["Title"] + "\">" + FnData.GetNewsTitle(drw) + "</a></span>");
                sb.Append("</li>");
            }
            return sb;
        }

        /// <summary>
        /// 关键词
        /// </summary>
        public static StringBuilder listKeyword1(DataTable dt, LayoutInfoLink li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<a href=\"" + drw["URL"] + "\" " + li.target + ">" + drw["KeyWordName"] + "</a>");
            }
            return sb;
        }
    }
}