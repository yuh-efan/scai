<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proMsgList.aspx.cs" Inherits="WZ.Web.user.proMsgList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>我的商品提问</title>
    <w:headerUser id="header1" runat="server"></w:headerUser>
    <style type="text/css">
.Reply2 { background:url(images/products_bg.gif) no-repeat;}
.Reply2 { float:left; display:block; width:40px; height:20px; background-position:-110px -102px;}
</style>
</head>
<body>
    <w:top id="ucTop" runat="server" />
   <w:userLocation id="ucUL" runat="server" Text=" > 咨询与评价 > 我的商品提问"></w:userLocation>
    <div class="main">
  <div class="left">
    <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
  </div>
  <div class="right">
    <div class="User-box">
        <h3><span>我的商品提问</span></h3>
        <div class="ordertable">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr bgcolor="#f7f7f7">
            <th>咨询时间</th>
            <th>产品</th>
            <th>咨询内容</th>
            <th>回复</th>
            <th>审核</th>
          </tr>
          
          <w:Item ID="rpList" runat="server">
          <ItemTemplate>
          <tr>
            <td><%# Eval("AddDate")%></td>
            <td><a href="<%#GetURL.Pro.Info(Eval("ProSN")) %>" target="_blank" class="Green"><%#Eval("ProName") %></a></td>
            <td><%# Eval("Detail")%></td>
            <td><%#Eval("ReDetail").ToString().Length > 0 ? Eval("ReDetail").ToString() : "<i>未回复</i>"%></td>
            <td><%#kpAudit.GetDirc(Eval("Purview").ToString())%></td>
          </tr>
          </ItemTemplate>
          </w:Item>
          
        </table>
        
        </div>
        <div class="paging">
      <w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" />
</div>
      </div>
  </div>
  <div class="clear"></div>
</div>
    <w:bottom id="ucBottom" runat="server" />
   
</body>
</html>
