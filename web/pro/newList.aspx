<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="newList.aspx.cs" Inherits="WZ.Web.pro.newList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>新品 NEW</title>
    <w:header id="header" runat="server"></w:header>
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    <link href="/css/Category.css" rel="stylesheet" type="text/css" />
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 新品 NEW" /></div>
<div class="main">
  <div class="left">
    <%--<div class="Category-box">
      <h1></h1>
      <ul class="Category">
      <%=pageClass.ToString()%>
      </ul>
       <div class="clear"></div>
    </div>--%>
    <div class="Recently-box margin0" >
      <h1 ></h1>
      <div class="def d_listHistory">
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
        <ul class="def1 f_list1" id="showList" runat="server">
        <!--  列表显示-->
          
<w:cycle id="rpList" runat="server" width="107" height="80" />
        </ul>
        
        <ul class="def d_list2 d_list_new" id="showPic" runat="server">
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
