<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="atop_2.ascx.cs" Inherits="WZ.Web.ascx.atop_2" %>
<!--热搜-->
    <div class="hot-search">
    	<p class="hot-search-l">
        	<span class="green">热搜：</span>
            <w:cycleLink id="rpKeyword" runat="server" target="" />
       	</p>
        <ul class="hot-search-r green">
            <li><a href="/pro/newList.aspx">新品</a></li>
            <li class="gap">|</li>
            <li><a href="/pro/hotList.aspx">热卖</a></li>
            <li class="gap">|</li>
            <li><a href="/pro/salePromotionList.aspx">促销</a></li>
        </ul>
    </div>
<!--热搜End-->