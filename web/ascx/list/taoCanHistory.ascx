<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="taoCanHistory.ascx.cs" Inherits="WZ.Web.ascx.list.taoCanHistory" %>
<w:Rep ID="rpHistory" runat="server">
<ItemTemplate>
<li>
    <a href="<%# GetURL.TaoCan.Info(Eval("ProSN")) %>" target="_blank" class="cssSmall-pic"><img src="<%# GetURL.TaoCan.Pic(Eval("PicS")) %>" width="<%=width %>" height="<%=height %>" alt="<%# Eval("ProName") %>" /></a>
    <div class="cssName"><a href="<%# GetURL.TaoCan.Info(Eval("ProSN")) %>" target="_blank"><%# Eval("ProName") %></a></div>
</li>
</ItemTemplate>
</w:Rep>