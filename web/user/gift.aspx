<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gift.aspx.cs" Inherits="WZ.Web.user.gift" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>用户中心-礼品兑换记录</title>
    <w:headerUser id="header" runat="server"></w:headerUser>
    <style type="text/css">
	.sty_tr1 td{border-bottom:#CCC dashed 1px;}
	</style>
    
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
   <script type="text/javascript">
   var ffObj= FloatFrame();
   ffObj.width=526;
   ffObj.height=355;
   function Info(i)
   {
   ffObj.src="/floatLayer/gift_log.aspx?id="+i;
    ffObj.show();
   }
   </script>
</head>
<body>
    <w:top id="ucTop" runat="server" />
   <w:userLocation id="ucUL" runat="server" Text=" &gt; 礼品兑换记录"></w:userLocation>
   <div class="main">
    <div class="left">
      <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
    </div>
    <div class="right">
      <div class="User-box">
        <h3><span>礼品兑换记录</span></h3>
        <p class="Info">您共有 <span class="ce00"><w:ShowText ID="countN" runat="server"></w:ShowText></span> 条兑换记录，您当前的积分：<span class="ce00"><w:ShowText ID="cUserIntegral" runat="server"></w:ShowText>
        </span><a href="/gift/" target="_blank"><strong>马上去兑换积分&gt;&gt;</strong></a></p>
        <div class="ordertable">
          <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr bgcolor="#f7f7f7">
              <th>图片</th>
              <th>礼品名称</th>
              <th>兑换时间</th>
              <th>花费积分</th>
              <th>数量</th>
            </tr>
            
            <asp:Repeater ID="rpList" runat="server">
            <ItemTemplate>
            <tr >
            <td>
            <a href="javascript:;" onclick="Info(<%#Eval("ExSN") %>)" class="Green">
            <img  src="<%#GetURL.Gift.Pic(Eval("PicS")) %>" width="50" height="43" alt="<%#Eval("GiftName") %>" /></a></td>
            <td><a href="javascript:;" onclick="Info(<%#Eval("ExSN") %>)" class="Green"><%#Eval("GiftName")%></a></td>
            <td><%#Eval("AddDate")%></td>
            <td><%#Eval("ExIntegral")%></td>
            <td><span class="Red3"><%#Eval("Num")%></span></td>
          </tr>
            </ItemTemplate>
            </asp:Repeater>
            
          </table>
        </div>
        <div class="paging"><w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" /></div>
      </div>
    </div>
    <div class="clear"></div>
  </div>
   
   <w:bottom id="ucBottom" runat="server" />
</body>
</html>
