using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using WZ.Common;

namespace WZ.Data.Layout
{
    public class CaiPuLay
    {
        public static StringBuilder list1(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.CaiPu.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div class=\"d-name\"><a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
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
                sb.Append("<a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.CaiPu.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div><a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
                sb.Append("</li>");
            }
            return sb;
        }

        /// <summary>
        /// list1 + 介绍Detail2
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="li"></param>
        /// <returns></returns>
        public static StringBuilder list3(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.CaiPu.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div class=\"d-name\"><a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
                sb.Append("<div class=\"d-des\">" + Fn.Left(Fn.ReplaceHTML(drw["Detail2"].ToString()), li.detailN, "...") + "</div>");
                sb.Append("</li>");
            }
            return sb;
        }

        //-----------------------------------------------------------------------
        public static StringBuilder d_1(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.CaiPu.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div class=\"d-name\"><a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
                sb.Append("</li>");
            }
            return sb;
        }


        public static StringBuilder d_list1(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.CaiPu.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div class=\"d-name\"><a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
                sb.Append("<div class=\"d-des\">" + Fn.Left(Fn.ReplaceHTML(drw["Detail2"].ToString()), li.detailN, "...") + "</div>");
                sb.Append("</li>");
            }
            return sb;
        }

        public static StringBuilder d_list2(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.CaiPu.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div class=\"d-name\"><a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
                sb.Append("</li>");
            }
            return sb;
        }

        /// <summary>
        /// e
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="li"></param>
        /// <returns></returns>
        public static StringBuilder e_list2(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<div class=\"d-left-img\">");
                sb.Append("<a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.CaiPu.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("</div>");

                sb.Append("<div class=\"d-left-content\">");
                sb.Append("<div class=\"d-name\"><a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
                sb.Append("<div class=\"d-des\">" + Fn.Left(Fn.ReplaceHTML(drw["Detail2"].ToString()), li.detailN, "") + "</div>");
                sb.Append("</div>");
                sb.Append("</li>");
            }
            return sb;
        }

        /// <summary>
        /// 有订购按钮
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="li"></param>
        /// <returns></returns>
        public static StringBuilder d_dingo1(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.CaiPu.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div class=\"d-name\">");
                sb.Append("<span class=\"d-dinggou\"><a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\">订购</a></span>");
                sb.Append("<a class=\"d-name1\" href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
                sb.Append("</li>");
            }
            return sb;
        }

        //f: 列表显示模
        public static StringBuilder f_1(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<div class=\"d-left\">");
                sb.Append("<div class=\"d-pic\">");
                sb.Append("<a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + "><img src=\"" + GetURL.CaiPu.Pic(drw["PicS"]) + "\"  width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("</div>");

                sb.Append("<div class=\"d-des\">");
                sb.Append("<dl>");
                sb.Append("<dt class=\"d-name\"><a href=\"" + GetURL.CaiPu.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></dt>");
                sb.Append("<dd>");
             

                string sUnitNum = drw["UnitNum"].ToString();
                if (Fn.IsDouble(sUnitNum, 0) <= 0)
                {
                    sUnitNum = string.Empty;
                }
                else
                {
                    sUnitNum = "<span>" + sUnitNum + "</span>";
                }

                sb.Append("<div class=\"d-format\">销售规格：" + sUnitNum + " " + drw["Unit"] + "</div>");
                sb.Append("</dd>");
                sb.Append("</dl>");
                sb.Append("</div>");

                sb.Append("</div>");

                sb.Append("<div class=\"d-right\">");
                
                sb.Append("<div class=\"d-buttom\">");
                sb.Append("<div class=\"d-buy\"><a href=\"javascript:;\" onclick=\"AddCart(" + drw["ProSN"] + ",1,1);\"><img src=\"/images/Usercenter/Purchase.gif\" /></a></div>");
                sb.Append("<div class=\"d-favorites\"><a href=\"javascript:;\" onclick=\"AddFav(" + drw["ProSN"] + ",1);\"><img src=\"/images/Usercenter/Collection.gif\"/></a></div>");
                sb.Append("</div>");

                sb.Append("</div>");


                sb.Append("</li>");
            }
            return sb;
        }


    }
}