<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fav.aspx.cs" Inherits="WZ.Web.user.fav" EnableViewState="true" %>
<%@ Import Namespace="WZ.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>我收藏的<%=tit %> - 搜菜网</title>
    <w:headerUser id="header" runat="server"></w:headerUser>
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    <script type="text/javascript">
        function del(){return confirm('确定删除');}
    </script>
</head>
<body>
<w:top id="ucTop" runat="server" />
   <w:userLocation id="ucUL" runat="server" Text=" &gt; 商品管理 &gt; 我收藏的"></w:userLocation>
  <div class="main">
    <div class="left">
      <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
    </div>
    <div class="right">
    <form id="form01" runat="server">
      <div class="User-box p-top">
        <h3><span>我收藏的<%=tit %></span></h3>
        <p class="Info">关于收藏夹：遇到感兴趣的商品时，如果还没决定立即购买，或者商品暂时缺货，您可以先把它放入收藏夹，以便下次的查找与购买。</p>
        <div class="Commentary center">
        
        
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr bgcolor="#f7f7f7">
            <th>商品</th>
            <th>放入时间</th>
            <%if(t==0){ %><th>单价</th><%} %>
            <th>操作</th>
          </tr>
          <!--商品-->
           <w:Rep ID="rpPro" runat="server" EnableViewState="true">
          <ItemTemplate>
           <tr>
            <td class="pic">
            <a href="<%# GetURL.Pro.Info(Eval("FK_All")) %>" class="products-pic" target="_blank"><img src="<%# GetURL.Pro.Pic(Eval("PicS")) %>" width="46" height="46" alt="" /></a>
            <span><a href="<%# GetURL.Pro.Info(Eval("FK_All")) %>" target="_blank" class="Green"><%# Eval("ProName")%></a></span>
            </td>
            <td>    
            <%# Eval("AddDate")%>
            </td>
            <td>
            <span class="orange">￥<%#Eval("Price")%></span>
            </td>
          <td>
        	<input type="button" class="anniucss" value="购买" onclick="AddCart(<%# Eval("FK_All")%>,1)" />
        	<asp:Button ID="bDelete" runat="server" Text="删除" CommandName='<%#Eval("FavSN") %>' OnClick="bDelete_Click" OnClientClick="return del();" CssClass="anniucss3" />
         
          </td>
          </tr>
          </ItemTemplate>
          </w:Rep>
          
          <!--菜谱-->
          <w:Rep ID="rpCaiPu" runat="server" EnableViewState="true">
          <ItemTemplate>
           <tr>
            <td class="pic">
            <a href="<%# GetURL.CaiPu.Info(Eval("FK_All")) %>" class="products-pic" target="_blank"><img src="<%# GetURL.CaiPu.Pic(Eval("PicS")) %>" width="46" height="46" alt="" /></a>
            <span><a href="<%# GetURL.CaiPu.Info(Eval("FK_All")) %>" target="_blank" class="Green"><%# Eval("ProName")%></a></span>
            </td>
            <td>    
            <%# Eval("AddDate")%>
            </td>
          
          <td>
        	<input type="button" class="anniucss" value="购买" onclick="AddCart(<%# Eval("FK_All")%>,1,1)" />
        	<asp:Button ID="bDelete" runat="server" Text="删除" CommandName='<%#Eval("FavSN") %>' OnClick="bDelete_Click" OnClientClick="return del();" CssClass="anniucss3" />
         
          </td>
          </tr>
          </ItemTemplate>
          </w:Rep>
        </table>
        
        
        
        </div>
      </div>
      </form><div class="paging"><w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" /></div>
    </div>
    <div class="clear"></div>
  </div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
