<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="regSuccess.aspx.cs" Inherits="WZ.Web.user.regSuccess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>注册成功</title>
    <w:header id="header1" runat="server"></w:header>
    <link href="/css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 注册成功" /></div>
<div class="main">
  <div class="Success">
    <div class="txt"> 恭喜您注册成功<%if (Req.GetQueryString("t") == "1"){%>，我们已发送一封注册信息邮件到您的邮箱中，请注意查收<%} %>。 </div>
    <ul>
      <li>1. <a href="<%=GetURL.Default.Home() %>" class="Green">去购物</a></li>
      <li>2. <a href="/user/center.aspx" class="Green">进入到用户中心</a></li>
      <%if (url.Length > 0)
        {%>
      <li>3. <a href="<%=url %>" class="Green">返回前一个访问的地址</a></li>
      <% }%>
    </ul>
    
    </ul>
  </div>
</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>