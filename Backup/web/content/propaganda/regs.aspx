<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="regs.aspx.cs" Inherits="WZ.Web.content.propaganda.regs" %>
<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>注册成功</title>
<link href="css/css.css" rel="stylesheet" type="text/css" />
</head>

<body>
<div class="header">
  <div class="logo"><a href="#"><img src="images/logo.gif" width="230" height="105" alt="logo" /></a></div>
  <div class="Tel"><img src="images/Tel.gif" width="246" height="105" alt="孙经理：18957066373  王 总：13059614998" /></div>
</div>
<div class="main">
  <div class="nav-wrap">
    <div class="nav-left"></div>
    <ul class="nav">
      <li><a href="default.aspx">首页</a></li>
      <li><a href="default.aspx#fzzl">发展战略</a></li>
      <li><a href="default.aspx#scxj">市场前景</a></li>
      <li><a href="default.aspx#rzsj">入驻商家</a></li>
      <li><a href="reg.aspx" class="current">会员注册</a></li>
    </ul>
    <div class="shop"><img src="images/shop.gif" width="10" height="7" alt="" /><span><a href="/default.aspx">立即入驻搜菜网</a></span></div>
    <div class="nav-right"></div>
  </div>
  <div class="content">
    <div class="Success">
      <h4></h4>
      <div class="txt"> 恭喜您注册成功<%if (Req.GetQueryString("t") == "1")
                                 { %>，我们已发送一封注册信息邮件到您的邮箱中，请注意查收。<%} %> </div>
      <ul>
        <li>1. <a href="/default.aspx" class="Green">访问搜菜网</a></li>
        <li>2. <a href="/user/center.aspx" class="Green">进入到用户中心</a></li>
      </ul>
      </ul>
    </div>
  </div>
</div>
<div class="footer">
  <div class="footer-nav"> <a href="#" target="_blank">关于我们</a> | <a href="#" target="_blank">联系我们</a> | <a href="#" target="_blank">About Us</a> | <a href="#" target="_blank">Contact Us</a></div>
  <div class="copyright">Copyright (c)2010 搜菜网 All Rights Reserved. 浙ICP备00000068号</div>
</div>
</body>
</html>
