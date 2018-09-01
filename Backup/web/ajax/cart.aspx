<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="WZ.Web.ajax.cart1" %>
<div id="cCart" runat="server">

<%
    if (dtPro != null)
    {
        foreach (DataRow drw in dtPro.Rows)
        {
 %>
<dl>
    <dt><a href="<%=GetURL.Pro.Info(drw["ProSN"]) %>" target="_blank" class="products-pic2"><img src="<%=GetURL.Pro.Pic(drw["PicS"]) %>" width="40" height="35" alt="" /></a></dt>
    <dd><span class="Price">￥<%=drw["dt_UserPrice"] %></span><a class="products-name" href="<%=GetURL.Pro.Info(drw["ProSN"]) %>" target="_blank"><%=drw["ProName"] %></a></dd>
    <dd><span class="Del" style="display:none"><a href="#" class="Blue">[删除]</a></span><span class="Quantity">数量：<%=drw["Num"] %></span></dd>
</dl>
<%}
    } %>

    <div class="Total">共<strong><%=cou %></strong>件商品   金额总计：<strong>￥<%=totalPrice %></strong></div>
    <a href="/user/cart.aspx" class="Exashop">去购物车并结算</a> 
</div>