<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="links.ascx.cs" Inherits="WZ.Web.ascx.links" %>
<w:Rep ID="rpText" runat="server">
<ItemTemplate>
<li><a href="<%#Eval("WebURL") %>" target="_blank"><%#Eval("LinksName") %></a></li><li>|</li>
</ItemTemplate>
</w:Rep>

<w:Rep ID="rpPic" runat="server">
<ItemTemplate>
<li><a href="<%#Eval("WebURL") %>" target="_blank"><img alt="<%#Eval("LinksName") %>" src="<%# GetURL.Links.Pic(Eval("PicS")) %>" width="100" height="35" /></a></li>
</ItemTemplate>
</w:Rep>