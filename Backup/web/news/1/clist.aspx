<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clist.aspx.cs" Inherits="WZ.Web.news._1.clist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/news.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/base.js"></script>
    <title><%=className %> 健康快报</title>
</head>

<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; <a href='/news/1'>健康快报</a> &gt; {0}" /></div>


<div class="main">
  <div class="box-2">
        <div class="tab_main2">
          <div class="shell2">
                <ul>
                <asp:Repeater ID="rpNewsList" runat="server">
                <ItemTemplate>
                  <li><a href="<%#GetURL.News.Info(Container.DataItem) %>" target="_blank" class="news-title"><%#Eval("Source").ToString().Length>0?"["+Eval("Source")+"]":""%><%#Eval("Title")%></a> <span><%#Eval("EditDate")%></span>
                    <p><%# Fn.Left(Fn.ReplaceHTML(Eval("Detail").ToString()),130,"...")%>
                    <a href="<%#GetURL.News.Info(Container.DataItem) %>" target="_blank" class="Detailed">[查看详情]</a>
                    </p>
                    </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="paging">
                <w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" />
            </div>
          </div>
        </div>
    <div class="clear"></div>
  </div>
</div>


<w:bottom id="ucBottom" runat="server" />
</body>
</html>
