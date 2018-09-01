<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderComplete.aspx.cs" Inherits="WZ.Web.user.orderComplete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>提交订单完成 - 搜菜网</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/shopping.css" rel="stylesheet" type="text/css" />
</head>
<body>
<w:top id="ucTop" runat="server" />
	<div class="main">
    <div class="flow-steps-3"></div>
    <div class="Filling">
      <div class="Completion">
        <p class="gx"><img src="/images/shopping/gx.gif" width="322" height="50" alt="恭喜，您的订单已提交完成！" /></p>
        <p class="Co-txt">恭喜！您的订单<a href="orderView.aspx?id=<%=sOrdSN %>" class="orange"><%=sOrdNumber%></a>已经提交成功，应付金额：<span class="orange"><%=sTotalPrice%></span>元，支付方式：<span class="orange"><%=sPayName %></span>。</p>
        <p class="Co-txt">配送人员会在您的规定时间内将订单送达，请注意...</p>
        <p style="padding-top:10px"><a href="orderView.aspx?id=<%=sOrdSN %>"><img src="/images/shopping/order.gif" width="108" height="28" alt="查看订单" /></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/"><img src="/images/shopping/Co.gif" width="108" height="28" alt="继续购物" /></a></p>
      </div>
      <div class="note">您在购物过程中有任何疑问，请查阅 <a href="#" target="_blank" class="Green">帮助中心</a> 或 <a href="#" target="_blank" class="Green">联系客服</a></div>
    </div>
  </div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
