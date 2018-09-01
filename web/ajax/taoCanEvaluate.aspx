<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="taoCanEvaluate.aspx.cs" Inherits="WZ.Web.ajax.taoCanEvaluate" %>
<w:Item ID="rpEvaluate" runat="server">
<ItemTemplate>
<div class="comment">
<div class="com-left">
  <p><%# Eval("FK_User").ToString() == "0" ? "匿名：" : Eval("UserName").ToString() + " 说："%></p>
  <p class="com-txt"><%# Eval("Detail")%></p>
  <p class="com-Reply" <%#Eval("ReDetail").ToString().Length>0?"":"style=\"display:none\"" %>><span class="Reply"></span><%# Eval("ReDetail")%></p>
</div>
<div class="com-right">
  <p>评价时间</p>
  <p><%# Eval("AddDate")%></p>
  <p>评分：</p>
  <p class="star"><%#Eval("Fraction")%></p>
 
</div>
<div class="clear"></div>
</div>
</ItemTemplate>
</w:Item>