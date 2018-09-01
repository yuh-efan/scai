<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="top.ascx.cs" Inherits="WZ.Web.content.propaganda.top" %>
<div class="header">
  <div class="logo"><a href="/"><img src="images/logo.gif" width="230" height="105" alt="logo" /></a></div>
  <div class="Tel"><img src="images/Tel.gif" width="246" height="105" alt="孙经理：18957066373  王 总：13059614998" /></div>
</div>
<div class="main">
<div class="nav-wrap">
    <div class="nav-left"></div>
    <ul class="nav">
      <li><a href="default.aspx" <%=GetDirc("home") %>>首页</a></li>
      <li><a href="#fzzl" <%=GetDirc("zl") %>>发展战略</a></li>
      <li><a href="#scxj" <%=GetDirc("mark") %>>市场前景</a></li>
      <li><a href="#rzsj" <%=GetDirc("join") %>>入驻商家</a></li>
      <li><a href="reg.aspx" <%=GetDirc("reg") %>>会员注册</a></li>
    </ul>
    <div class="shop"><img src="images/shop.gif" width="10" height="7" alt="" /><span><a href="/default.aspx">立即入驻搜菜网</a></span></div>
    <div class="nav-right"></div>
  </div>
  </div>