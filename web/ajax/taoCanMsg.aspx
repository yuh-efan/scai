<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="taoCanMsg.aspx.cs" Inherits="WZ.Web.ajax.taoCanMsg" %>
<w:Item ID="rpMsg" runat="server">
<ItemTemplate>
  <div class="comment">
   <div class="com-left">
    <p><%# Eval("UserName")%> 问：</p>
    <p class="com-txt"><%# Eval("Detail")%></p>
    <p class="com-Reply" <%#Eval("ReDetail").ToString().Length>0?"":"style=\"display:none\"" %>><span class="Reply"></span><%# Eval("ReDetail")%></p>
   </div>
   <div class="com-right">
    <p>咨询时间</p>
    <p><%# Eval("AddDate")%></p>
   </div>
   <div class="clear"></div>
 </div>
 </ItemTemplate>
</w:Item>