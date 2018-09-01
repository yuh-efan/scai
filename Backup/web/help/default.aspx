<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WZ.Web.help._default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>帮助中心</title>
    <link href="/css/help.css" rel="stylesheet" type="text/css" />
    <w:header id="header" runat="server"></w:header>
</head>
<body>
    <w:top id="ucTop" runat="server" />
    <div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 帮助中心 " /></div>
    <div class="main">
  <div class="left">
    <h1></h1>
    <div class="leftmain">
        <asp:Repeater ID="rpClass" runat="server" onitemdatabound="rpClass_ItemDataBound">
        <ItemTemplate>
            <div class="leftbox">
            <asp:Label ID="ClassID" runat="server" Text='<%#Eval("ClassSN") %>' Visible="false"></asp:Label>
            <h2><%#Eval("ClassName") %></h2>
            <ul>
            <asp:Repeater ID="rpList" runat="server">
            <ItemTemplate>
                <%#Eval("HelpSN").ToString() != d.Eval("HelpSN").ToString() ? string.Format("<li><a href='" + GetURL.Help.Info(Eval("HelpSN")) + "'>{1}</a></li>", Eval("HelpSN"), Eval("Title")) : string.Format("<li class='leftcurrent'>{0}</li>", Eval("Title"))%>
            </ItemTemplate>
            </asp:Repeater>
            </ul>
        </div>
        </ItemTemplate>
        </asp:Repeater>
    </div>
  </div>
  <div class="right">
  	<h1><%=d.Eval("Title")%></h1>
    <div class="help-content">
    <%=d.Eval("Detail")%>
    </div>
  </div>
  <div class="clear"></div>
</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
