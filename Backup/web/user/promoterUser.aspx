<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promoterUser.aspx.cs" Inherits="WZ.Web.user.promoterUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>我推广的用户 - 搜菜网</title>
    <w:headerUser id="header" runat="server"></w:headerUser>
</head>
<body>
   <w:top id="ucTop" runat="server" />
   <w:userLocation id="ucUL" runat="server" Text=" &gt; 推广信息 &gt; 我推广的用户"></w:userLocation>
   	<div class="main">
    	<div class="left">
    <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
    </div>
    	<div class="right">
      <div class="User-box">
        <h3><span>我推广的用户</span></h3>
        <div class="ordertable">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr bgcolor="#f7f7f7">
            <th>用户名</th>
            <th>注册时间</th>
          </tr>
<w:Rep ID="rpList" runat="server">
<ItemTemplate>
           <tr>
            <td><%# Eval("UserName") %></td>
            <td><%#Eval("UserAddDate") %></td>
          </tr>
</ItemTemplate>
</w:Rep>
          
        </table>
        <div class="pagination">
        <!-- 翻页 -->
            <div class="paging"><w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" /></div>
        </div>
        </div>
        <div class="Sufficient" style="display:none"><a href="#"><img src="/images/Usercenter/Sufficient.gif" width="108" height="28" alt="" /></a></div>
      </div>
    </div>
    </div>
    <w:bottom id="ucBottom" runat="server" />
</body>
</html>
