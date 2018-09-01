<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="orderList.aspx.cs" Inherits="WZ.Web.user.orderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=pageTypeTitle %> - 搜菜网</title>
    <w:headerUser id="header1" runat="server"></w:headerUser>
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
<w:userLocation id="ucUL" runat="server" Text=" &gt; "></w:userLocation>

   	<div class="main">
    	<div class="left">
    <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
    </div>
        <div class="right">
          <div class="User-box p-top">
            <h3><span><%=pageTypeTitle %></span></h3>
            <div class="ordertable">
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr bgcolor="#f7f7f7">
            <th>订单号</th>
            <th>订单详细</th>
            <th>下单时间</th>
            <th>总价</th>
            <th>付款状态</th>
            <th>状态</th>
          </tr> 
          <w:Rep ID="rpList" runat="server">
          <ItemTemplate>
          <tr>
            <td><%#Eval("OrdNumber") %></td>
            <td><a href="orderView.aspx?id=<%#Eval("OrdSN")%>" target="_blank" class="Green">查看详情</a></td>
            <td><%#Eval("AddDate")%></td>
            <td><span class="orange weight"><%#Eval("TotalPrice")%></span></td>
            <td><%#kpOrdPay.GetDirc(Eval("StatusPay").ToString())%></td>
            
            <td>
            <%#kpOrd.GetDirc(Eval("Status").ToString())%>
            <%#OP(Container.DataItem) %>
            </td>
            
          </tr>
          </ItemTemplate>
          </w:Rep>
        </table>
            </div>
            <!-- 翻页 -->
            <div class="paging"><w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" /></div>
          </div>
        </div>
    	<div class="clear"></div>
    </div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
