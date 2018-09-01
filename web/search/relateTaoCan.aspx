<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relateTaoCan.aspx.cs" Inherits="WZ.Web.search.relateTaoCan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>相关套餐</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/Category.css" rel="stylesheet" type="text/css" />
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=' > 相关套餐 ' /></div>
<div class="main">
  <div class="left">
    <!--class-->
    <div class="Recently-box">
      <h1></h1>
      <div class="Recently-main">
        <ul>
          <w:caiPuHistory id="CaiPuHistory1" runat="server" width="87" height="76" />
        </ul>
        <div class="clear"></div>
      </div>
    </div>
  </div>
  <div class="right">
   
    <div class="ch-main">
    	<h2></h2>
      <div class="result-count">与<span><%=title %></span>相关的套餐</div>
      
        <ul class="Hot-products">
        <w:cycle id="rpList" runat="server" width="107" height="93" />
        
        </ul>
           <div class="clear"></div>
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
