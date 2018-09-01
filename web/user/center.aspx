<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="center.aspx.cs" Inherits="WZ.Web.user.center" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>用户中心 - 搜菜网</title>
    <w:headerUser id="header" runat="server"></w:headerUser>
       <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>

	<script type="text/javascript">
	function user_cancel(id)
	{
		floatLayer.src='/floatLayer/user_ordCancel.aspx?id='+id;
		floatLayer.show();
	}
	
	function user_confirm(id)
	{
		floatLayer.src='/floatLayer/user_confirmAccept.aspx?id='+id;
		floatLayer.show();
	}
	</script>
</head>
<body>
   <w:top id="ucTop" runat="server" />
   <w:userLocation id="ucUL" runat="server"></w:userLocation>
   <div class="main">
    <div class="left">
    <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
    </div>
    <div class="right">
    <h1></h1>
      <p class="Info"> 您的上一次登录时间<%=pageUserLastTime %> <br />
        截至 <%=DateTime.Now.ToString("yyyy年MM月dd日") %>，您共有 <span class="Red3"><%=pageOrdCount %></span> 张订单完成交易，累计消费 <span class="Red3"><%=pageOrdTotalPrice %></span> 元。 </p>
      <div class="User-box">
        <h3><span>您的最近订单</span></h3>
        <div class="ordertable">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr bgcolor="#f7f7f7">
            <th>订单号</th>
            <th>订单时间</th>
            <th>总价</th>
            <th>订单详细</th>
            <th>付款状态</th>
            <th>订单状态</th>
          </tr>
          <w:Rep ID="rpList" runat="server">
          <ItemTemplate>
          <tr>
            <td><%#Eval("OrdNumber") %></td>
            <td><%#Eval("AddDate")%></td>
            <td><span class="orange weight"><%#Eval("TotalPrice")%></span></td>
            <td><a href="orderView.aspx?id=<%#Eval("OrdSN")%>" target="_blank" class="Green">查看详情</a></td>
            <td><%#kpOrdPay.GetDirc(Eval("StatusPay").ToString())%></td>
            <td><%#kpOrd.GetDirc(Eval("Status").ToString())%>
            <%#OP(Container.DataItem) %>
            </td>
          </tr>
          </ItemTemplate>
          </w:Rep>
         
        </table>
        </div>
      </div>
      <div class="Sale">
        	<h3><span>近期热卖</span></h3>
            <ul class="def d_list1">
          <w:cycle ID="rpPro" runat="server" Width="123" Height="80" />
        </ul>
        <div class="clear"></div>
        </div>
      <div class="User-box">
        <h3><span>最新资讯</span></h3>
        <ul class="FAQ">
        
          <w:cycleLink ID="rpNews" runat="server" />
        </ul>
        <div class="clear"></div>
        </div>
       	
    </div>
    <div class="clear"></div>
  	</div>
   <w:bottom id="ucBottom" runat="server" />
</body>
</html>
