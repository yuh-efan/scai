<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="WZ.Web.category.product" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>菜品大全</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/clz.css" rel="stylesheet" type="text/css" />
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 菜品大全" /></div>
<div class="main">
    <div class="Category-box">
      <h3></h3>
      <ul class="Category">
      <%=pageClass.ToString() %>
      </ul>
      <div class="clear"></div>
    </div>
</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
