<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="seckillList.aspx.cs" Inherits="WZ.Web.pro.seckillList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>秒杀 SECKILL</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/Category.css" rel="stylesheet" type="text/css" />
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 秒杀 SECKILL" /></div>
<div class="main">
  <div class="left">
    <div class="Category-box">
      <h1></h1>
      <ul class="Category">
      <%=pageClass.ToString()%>
      </ul>
       <div class="clear"></div>
    </div>
    <div class="Recently-box">
      <h1></h1>
      <div class="Recently-main">
        <ul>
        <w:prohistory id="ucHistory" runat="server" width="87" height="76" Style_price="Red2" />
        </ul>
        <div class="clear"></div>
      </div>
    </div>
  </div>
  <div class="right">
    
    <div class="ch-main">
      <div class="Toolbar">
        <ul class="mode">
<li><a href="<%=string.Format(modelJumpUrl,0) %>" class="humb-mode<%=stypeModel%>">图片显示</a></li>
<li><a href="<%=string.Format(modelJumpUrl,1) %>" class="thumb-mode<%=stypeModel%>">列表显示</a></li>
<li class="order">排序方式：</li>
<li class="select">
<%=pageOrder%>
<script type="text/javascript">_.get('cOrder').onchange=function(){location.href='<%=orderJumpUrl %>'.format(this.value)};</script>
</li>
        </ul>
      </div>
      <div class="list">
        <ul class="calss-center" id="showList" runat="server">
        <!--  列表显示-->
          
<w:Item ID="rpList" runat="server">
<ItemTemplate>
<li> <a href="<%#GetURL.Pro.Info(Eval("ProSN")) %>" class="products-pic2" target="_blank"><img src="<%#GetURL.Pro.Pic(Eval("PicS")) %>" width="107" height="80" alt="<%#Eval("ProName")%>" /></a>
            <div class="calss-left">
              <h5><a href="<%#GetURL.Pro.Info(Eval("ProSN")) %>" class="Blue" target="_blank"><%#Eval("ProName")%></a></h5>
              <ul class="left-txt">
                <li>商品编号：<%#Eval("Number")%></li>
                <li>销售规格：<%#Eval("UnitNum")%> <%#Eval("Unit")%></li>
                <li>商品库存：<%#Eval("StockN")%> <%#Eval("Unit")%></li>
              </ul>
            </div>
            <div class="calss-right">
              <ul class="right-box2">
                <li class="Price">网购单价：<span class="Red4"><%#Eval("Price1")%></span>元</li>
              </ul>
              <ul class="right-box">
                <li><a href="#"><img src="../images/Usercenter/Purchase.gif" width="59" height="21" alt="" /></a></li>
                <li><a href="#"><img src="../images/Usercenter/Collection.gif" width="59" height="21" alt="" /></a></li>
              </ul>
            </div>
          </li>
</ItemTemplate>
</w:Item>
        </ul>
        
        <ul class="calss-center2" id="showPic" runat="server">
<w:cycle id="rpPic" runat="server" width="165" height="124" />
        </ul>
        <div class="clear"></div>
           
           
      </div>
      <!-- 翻页 -->
      <div class="paging">
      <w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" />
</div>
    </div>
  </div>
</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
