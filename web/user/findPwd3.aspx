<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="findPwd3.aspx.cs" Inherits="WZ.Web.user.findPwd3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <w:header id="header1" runat="server"></w:header>
    <link href="/css/login.css" rel="stylesheet" type="text/css" />
    <title>找回密码-完成</title>
</head>
<body>
    <w:top id="ucTop" runat="server" />
    <div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 找回密码- 完成" /></div>
    <div class="main">
  <div class="Success2">
    <div class="Password"></div>
    <div class="txt"> 恭喜您成功找回了密码，您可以在下次登录时使用新密码。 </div>
    <ul>
      <li>1. <a href="<%=GetURL.Default.Home() %>" class="Green">去购物</a></li>
      <li>2. <a href="/user/center.aspx" class="Green">进入到用户中心</a></li>
    </ul>
  </div>
</div>
    <w:bottom id="ucBottom" runat="server" />
</body>
</html>
