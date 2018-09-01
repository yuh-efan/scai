<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buyProList.aspx.cs" Inherits="WZ.Web.user.buyProList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>已购买的商品 - 搜菜网</title>
    <w:headerUser id="header1" runat="server"></w:headerUser>
</head>
<body>
    <w:top id="ucTop" runat="server" />
   <w:userLocation id="ucUL" runat="server" Text=" > 咨询与评价 > 已购买商品评价"></w:userLocation>
    <div class="main">
  <div class="left">
    <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
  </div>
  <div class="right">
    <div class="User-box">
      <h3><span>已购买商品评价</span></h3>
      <p class="Info">你可对已成功购买的<span class="Red3"><%=buyCout %></span>件商品，可以对购买的商品进行评价，和大家说说你的切身感受。</p>
      <div class="Commentary2">
        
        <w:Item ID="rpPro" runat="server">
        <ItemTemplate>
            <div class="Comment-box">
              <div class="Comment-main"> <a href="<%#GetURL.Pro.Info(Eval("FK_Pro")) %>" target="_blank" class="products-pic2"><img src="<%#GetURL.Pro.Pic(Eval("PicS")) %>" width="46" height="40" alt="<%#Eval("op_ProName") %>" /></a>
                <p> <span><a href="<%#GetURL.Pro.Info(Eval("FK_Pro")) %>" target="_blank" class="Green"><%#Eval("op_ProName") %></a></span> <em><%#Eval("op_AddDate") %>购买</em> <a href="<%#GetURL.Pro.Info(Eval("FK_Pro")) %>#eval" target="_blank" class="Comment-pic"><img src="/images/Usercenter/Comment.gif" width="85" height="21" /></a> </p>
              </div>
            </div>
        </ItemTemplate>
        </w:Item>
        
        <div class="clear"></div>
      </div>
      <div class="Sufficient">
        <div class="paging"><w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" /></div>
      </div>
    </div>
  </div>
  <div class="clear"></div>
</div>
    <w:bottom id="ucBottom" runat="server" />

</body>
</html>
