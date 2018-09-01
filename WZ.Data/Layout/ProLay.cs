using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using WZ.Common;

namespace WZ.Data.Layout
{
    /// <summary>
    /// d_:上下
    /// e_:左右
    /// </summary>
    public class ProLay
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
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");

                //sb.Append("<div>市场价格：<del>￥" + drw["PriceMarket"] + "</del></div>");
                //sb.Append("<div>搜菜价：<span class=\"cssPrice\">￥" + drw["Price"] + "</span></div>");
                sb.Append("<div>市场价格：<del>暂无</del></div>");
                sb.Append("<div>搜菜价：<span class=\"cssPrice\">暂无</span></div>");
                sb.Append("</li>");
            }

            return sb;
        }

        public static StringBuilder d_1(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
                sb.Append("<div class=\"d-price\">暂无</div>");
                //sb.Append("<div class=\"d-price\">￥" + drw["Price"] + "</div>");
                sb.Append("</li>");
            }

            return sb;
        }

        public static StringBuilder d_price1_1(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
                //sb.Append("<div class=\"d-price\">￥" + drw["Price1"] + "</div>");
                sb.Append("<div class=\"d-price\">暂无</div>");
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
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<div class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
                //sb.Append("<div><del>市场价：￥" + drw["PriceMarket"] + "</del></div>");
                //sb.Append("<div>搜菜价：<span class=\"d-price\">￥" + drw["Price"] + "</span></div>");

                sb.Append("<div><del>市场价：暂无</del></div>");
                sb.Append("<div>搜菜价：<span class=\"d-price\">暂无</span></div>");
                sb.Append("</li>");
            }

            return sb;
        }

        /// <summary>
        /// 促销
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="li"></param>
        /// <returns></returns>
        public static StringBuilder d_list2(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<p  class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></p>");
                //sb.Append("<p>市场价格：<del>" + drw["PriceMarket"] + "</del></p>");
                //sb.Append("<p>促销价：<span class=\"d-price\">￥" + drw["Price1"] + "</span></p>");

                sb.Append("<p>市场价格：<del>暂无</del></p>");
                sb.Append("<p>促销价：<span class=\"d-price\">暂无</span></p>");
                sb.Append("</li>");
            }

            return sb;
        }

        public static StringBuilder d_list3(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<p class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></p>");
                sb.Append("<p class=\"d-price\">暂无</p>");
                //sb.Append("<p class=\"d-price\">￥" + drw["Price"] + "</p>");
                sb.Append("</li>");
            }
            return sb;
        }

        public static StringBuilder d_list4(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<p class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></p>");
                sb.Append("</li>");
            }
            return sb;
        }

        /// <summary>
        ///　新品+图标
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="li"></param>
        /// <returns></returns>
        public static StringBuilder d_listNew(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<p class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></p>");
                sb.Append("<p>市场价格：<del>暂无</del></p>");
                sb.Append("<p>搜菜价：<span class=\"d-price\">暂无</span></p>");
                //sb.Append("<p>市场价格：<del>" + drw["PriceMarket"] + "</del></p>");
                //sb.Append("<p>搜菜价：<span class=\"d-price\">￥" + drw["Price"] + "</span></p>");
                sb.Append("<p class=\"d-pic-new\"><img src=\"/images/pic-new.gif\" alt=\"新品\" /></p>");
                sb.Append("</li>");
            }

            return sb;
        }

        /// <summary>
        /// 热卖+图标
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="li"></param>
        /// <returns></returns>
        public static StringBuilder d_listHotSale(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<p class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></p>");
                sb.Append("<p>市场价格：<del>暂无</del></p>");
                sb.Append("<p>搜菜价：<span class=\"d-price\">暂无</span></p>");
                //sb.Append("<p>市场价格：<del>" + drw["PriceMarket"] + "</del></p>");
                //sb.Append("<p>搜菜价：<span class=\"d-price\">￥" + drw["Price"] + "</span></p>");
                sb.Append("<p class=\"d-pic-hot\"><img src=\"/images/pic-hotSell.gif\" alt=\"热卖\" /></p>");
                sb.Append("</li>");
            }

            return sb;
        }

        /// <summary>
        /// 促销+图标
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="li"></param>
        /// <returns></returns>
        public static StringBuilder d_listSale(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("<p class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></p>");
                sb.Append("<p>市场价格：<del>暂无</del></p>");
                sb.Append("<p>促销价：<span class=\"d-price\">暂无</span></p>");
                //sb.Append("<p>市场价格：<del>" + drw["PriceMarket"] + "</del></p>");
                //sb.Append("<p>促销价：<span class=\"d-price\">￥" + drw["Price1"] + "</span></p>");
                sb.Append("<p class=\"d-pic-sale\"><img src=\"/images/pic-sale.gif\" alt=\"促销\" /></p>");
                sb.Append("</li>");
            }

            return sb;
        }

        public static StringBuilder e_1(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<div class=\"d-left-img\">");
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("</div>");

                sb.Append("<div class=\"d-left-content\">");
                sb.Append("<div class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></div>");
                sb.Append("<div><del>市场价：暂无</del></div>");
                sb.Append("<div>搜菜价：<span class=\"d-price\">暂无</span></div>");
                //sb.Append("<div><del>市场价：￥" + drw["PriceMarket"] + "</del></div>");
                //sb.Append("<div>搜菜价：<span class=\"d-price\">￥" + drw["Price"] + "</span></div>");
                sb.Append("</div>");
                sb.Append("</li>");
            }
            return sb;
        }

        /// <summary>
        /// e 秒杀
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="li"></param>
        /// <returns></returns>
        public static StringBuilder e_list1(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<div class=\"d-left-img\">");
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("</div>");

                sb.Append("<div class=\"d-left-content\">");
                sb.Append("<p class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></p>");
                sb.Append("<p class=\"d-price\">暂无</p>");
                //sb.Append("<p class=\"d-price\">￥" + drw["Price1"] + "</p>");
                sb.Append("</div>");
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
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("</div>");

                sb.Append("<div class=\"d-left-content\">");
                sb.Append("<p class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></p>");
                sb.Append("<p><del>暂无</del></p>");
                sb.Append("<p class=\"d-price\">暂无</p>");
                //sb.Append("<p><del>" + drw["PriceMarket"] + "</del></p>");
                //sb.Append("<p class=\"d-price\">￥" + drw["Price"] + "</p>");
                sb.Append("</div>");
                sb.Append("</li>");
            }
            return sb;
        }

        public static StringBuilder e_list3(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<div class=\"d-left-img\">");
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("</div>");

                sb.Append("<div class=\"d-left-content\">");
                sb.Append("<p class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></p>");
                sb.Append("<p class=\"d-price\">暂无</p>");
                //sb.Append("<p class=\"d-price\">￥" + drw["Price"] + "</p>");
                sb.Append("</div>");
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
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + "><img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\"  width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("</div>");

                sb.Append("<div class=\"d-des\">");
                sb.Append("<dl>");
                sb.Append("<dt class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></dt>");
                sb.Append("<dd>");
                sb.Append("<div class=\"d-number\">商品编号：<span>" + drw["Number"] + "</span></div>");

                string sUnitNum=drw["UnitNum"].ToString();
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
                sb.Append("<div class=\"d-price\">搜菜价：<span>暂无</span> </div>");
                //sb.Append("<div class=\"d-price\">搜菜价：<span>￥" + drw["Price"] + "</span> </div>");
                sb.Append("<div class=\"d-buttom\">");
                sb.Append("<div class=\"d-buy\"><a href=\"javascript:;\" onclick=\"AddCart(" + drw["ProSN"] + ",1);\"><img src=\"/images/Usercenter/Purchase.gif\" /></a></div>");
                sb.Append("<div class=\"d-favorites\"><a href=\"javascript:;\" onclick=\"AddFav(" + drw["ProSN"] + ");\"><img src=\"/images/Usercenter/Collection.gif\"/></a></div>");
                sb.Append("</div>");

                sb.Append("</div>");


                sb.Append("</li>");
            }
            return sb;
        }

        public static StringBuilder f_sale1(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                sb.Append("<li>");
                sb.Append("<div class=\"d-left\">");
                sb.Append("<div class=\"d-pic\">");
                sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + "><img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\"  width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                sb.Append("</div>");

                sb.Append("<div class=\"d-des\">");
                sb.Append("<dl>");
                sb.Append("<dt class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></dt>");
                sb.Append("<dd>");
                sb.Append("<div class=\"d-number\">商品编号：<span>" + drw["Number"] + "</span></div>");

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
                sb.Append("<div class=\"d-price\">促销价：<span>暂无</span> </div>");
                //sb.Append("<div class=\"d-price\">促销价：<span>￥" + drw["Price1"] + "</span> </div>");
                sb.Append("<div class=\"d-buttom\">");
                sb.Append("<div class=\"d-buy\"><a href=\"javascript:;\" onclick=\"AddCart(" + drw["ProSN"] + ",1);\"><img src=\"/images/Usercenter/Purchase.gif\" /></a></div>");
                sb.Append("<div class=\"d-favorites\"><a href=\"javascript:;\" onclick=\"AddFav(" + drw["ProSN"] + ");\"><img src=\"/images/Usercenter/Collection.gif\"/></a></div>");
                sb.Append("</div>");

                sb.Append("</div>");


                sb.Append("</li>");
            }
            return sb;
        }

        /// <summary>
        /// 购物车ajax动态显示专用
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="li"></param>
        /// <returns></returns>
        public static StringBuilder cart_1(DataTable dt, LayoutInfo li)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow drw in dt.Rows)
            {
                //sb.Append("<li>");
                //sb.Append("<div class=\"d-left-img\">");
                //sb.Append("<a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"d-pic\">");
                //sb.Append("<img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a>");
                //sb.Append("</div>");

                //sb.Append("<div class=\"d-left-content\">");
                //sb.Append("<p class=\"d-name\"><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></p>");
                //sb.Append("<p class=\"d-price\">暂无</p>");
                ////sb.Append("<p class=\"d-price\">￥" + drw["Price"] + "</p>");
                //sb.Append("</div>");
                //sb.Append("</li>");

                sb.Append("<dl>");
                sb.Append("<dt><a href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + " class=\"products-pic2\"><img src=\"" + GetURL.Pro.Pic(drw["PicS"]) + "\" width=\"" + li.width + "\" height=\"" + li.height + "\" alt=\"" + drw["ProName"] + "\" /></a></dt>");
                sb.Append("<dd><span class=\"Price\">￥" + drw["Price"] + "</span><a class=\"products-name\" href=\"" + GetURL.Pro.Info(drw["ProSN"]) + "\" " + li.target + ">" + drw["ProName"] + "</a></dd>");
                sb.Append("</dl>");



                //<dl>
                //                    <dt><a href=\"#\" target=\"_blank\" class=\"products-pic2\"><img src=\"/images/favicon.ico\" width=\"40\" height=\"35\" alt=\"\" /></a></dt>
                //                    <dd><span class=\"Price\">￥235.00元</span><a class=\"products-name\" href=\"#\" target=\"_blank\">优质有机番茄死了都快放假了撒娇发来看减肥拉考四级发</a></dd>
                //                    <dd><span class=\"Del\"><a href=\"#\" class=\"Blue\">[删除]</a></span><span class=\"Quantity\">数量：2</span></dd>
                //                </dl>
            }
            return sb;
        }
    }
}