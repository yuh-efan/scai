<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default1.aspx.cs" Inherits="WZ.Web.taoCan._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>烹饪课堂</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/columns.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ui.ppt.js"></script>
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 营养套餐" /></div>
   <div class="main">
  <div class="box-1">
    <div class="box-left">
      <div class="promo">
            <div class="container" id="idTransformView">
          <w:ppt1 ID="ucPPT1" runat="server" Str="taocan" ImgAttr='width="680" height="275"' Prefix="ppt1_" />
              
            </div>
          </div>
    </div>
    <div class="box-right">
      <h2></h2>
      <div class="box-main">
        <ul>
<w:Rep ID="rpTeJja" runat="server">
<ItemTemplate>
<li> <a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" class="Quite-pic" target="_blank"><img src="<%#GetURL.TaoCan.Pic(Eval("PicS")) %>" width="110" height="96" alt="<%#Eval("ProName")%>" /></a>
<p><a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" class="Blue" target="_blank"><b><%#Eval("ProName")%></b></a></p>
</li>
</ItemTemplate>
</w:Rep>
        </ul>
      </div>
      <div class="box-bootom"></div>
    </div>
  </div>
  <div class="left">
    <div class="Category-box">
      <h2></h2>
      <ul class="Category">
      <%=pageClass.ToString()%>
      </ul>
      <div class="clear"></div>
    </div>
    <div class="Recently-box">
      <h1></h1>
      <div class="Recently-main">
        <ul>
        <w:taoCanHistory id="ucHistory" runat="server" width="87" height="76" />
        </ul>
        <div class="clear"></div>
      </div>
    </div>
  </div>
  <div class="right">
    <div class="Hot-main">
      <h1></h1>
      <ul class="calss-center2">
<w:Rep ID="rpTJ" runat="server">
<ItemTemplate>
<li> <a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" class="products-pic" target="_blank"><img src="<%#GetURL.TaoCan.Pic(Eval("PicS")) %>" width="230" height="150" alt="<%#Eval("ProName")%>" /></a>
<p><a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" target="_blank" class="Blue"><b><%#Eval("ProName")%></b></a></p>
<p><%#Eval("Detail3") %></p>
</li>
</ItemTemplate>
</w:Rep>
      </ul>
      <div class="clear"></div>
    </div>
    <div class="Hot-main">
      <h2></h2>
      <ul class="calss-center2">


<w:Rep ID="rpJingPin" runat="server">
<ItemTemplate>
<li> <a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" class="products-pic" target="_blank"><img src="<%#GetURL.TaoCan.Pic(Eval("PicS")) %>" width="230" height="150" alt="<%#Eval("ProName")%>" /></a>
<p><a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" target="_blank" class="Blue"><b><%#Eval("ProName")%></b></a></p>
<p><%#Eval("Detail3") %></p>
</li>
</ItemTemplate>
</w:Rep>
        
      </ul>
      <div class="clear"></div>
    </div>
  </div>
</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
