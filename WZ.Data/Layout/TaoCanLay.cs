using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using WZ.Common;

namespace WZ.Data.Layout
{
    public class TaoCanLay
    {
        /// <summary>
        /// 列表页结构
        /// </summary>
        public static StringBuilder list1(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.TaoCan.Info(drw["ProSN"]) + "\" " + li.target + " class=\"cssSmall-pic\">");
                sb.Append("<img src=\"" + GetURL.TaoCan.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div class=\"cssName\"><a href=\"" + GetURL.TaoCan.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
                sb.Append("</li>");
            }

            return sb;
        }

        /// <summary>
        /// 关注排行
        /// </summary>
        public static StringBuilder list2(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.TaoCan.Info(drw["ProSN"]) + "\" " + li.target + " class=\"cssSmall-pic\">");
                sb.Append("<img src=\"" + GetURL.TaoCan.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<p><a href=\"" + GetURL.TaoCan.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></p>");
                sb.Append("</li>");
            }
            return sb;
        }

        /// <summary>
        /// list1 + 介绍Detail2
        /// </summary>
        public static StringBuilder list3(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.TaoCan.Info(drw["ProSN"]) + "\" " + li.target + " class=\"cssSmall-pic\">");
                sb.Append("<img src=\"" + GetURL.TaoCan.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div class=\"cssName\"><a href=\"" + GetURL.TaoCan.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
                sb.Append("<div class=\"cssDetail\">" + Fn.Left(Fn.ReplaceHTML(drw["Detail2"].ToString()), li.detailN, "...") + "</div>");
                sb.Append("</li>");
            }
            return sb;
        }

    }
}