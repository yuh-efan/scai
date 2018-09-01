<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderView.aspx.cs" Inherits="WZ.Web.user.orderView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>订单详情 - 我的订单 - 搜菜网</title>
    <w:headerUser id="header1" runat="server"></w:headerUser>
</head>
<body>
<w:top id="ucTop" runat="server" />
	<div class="main">
    	<div class="left">
    <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
    </div>
        <div class="right">
          <div class="User-box">
            <h3><span>订单详情</span></h3>
            <div class="orderdiv">
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
               <caption>用户详情</caption>
               <tbody>
                <tr>
                  <th>用户名</th>
                  <td><%=d.Eval("UserName")%></td>
                  <th>手机</th>
                  <td><%=d.Eval("Tel")%></td>
                </tr>
                <tr>
                  <th>收货人</th>
                  <td><%=d.Eval("RealName")%></td>
                  <th>电话</th>
                  <td><%=d.Eval("FixTel")%></td>
                </tr>
                <tr>
                  <th>地区</th>
                  <td><%=pageAreaPath%></td>
                  <th>&nbsp;</th>
                  <td>&nbsp;</td>
                </tr>
                <tr>
                  <th>详细地址</th>
                  <td colspan="3"><%=d.Eval("Address")%></td>
                 </tr>
                <tr>
                  <th>配送时间</th>
                  <td colspan="3">从 <%=d.Eval("ToMinTime")%> 到 <%=d.Eval("ToMaxTime")%></td>
                </tr>
                </tbody>
              </table>
            </div>
            <div class="orderdiv">
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
               <caption>订单详情</caption>
               <tbody>
                <tr>
                  <th>编号</th>
                  <td><%=d.Eval("OrdNumber")%></td>
                  <th>下单时间</th>
                  <td><%=d.Eval("AddDate")%></td>
                </tr>
                <tr>
                  <th>订单总金额</th>
                  <td>￥<%=d.Eval("TotalPrice")%></td>
                  <th>付款方式</th>
                  <td><%=pagePayName%></td>
                </tr>
                <tr>
                  <th>订单状态</th>
                  <td><%=pageStatusName%></td>
                 
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                 
                 </tr>
                </tbody>
              </table>
            </div>
            <div class="orderdiv"></div>
            <div class="Note">
            <h5>您的附加信息</h5>
            <p><%=d.Eval("Caption")%></p>
            </div>
            
            <%--<div class="Note">
            <h5>网站方备注</h5>
            <p><%=d.Eval("Remark")%></p>
            </div>--%>
            
            <div class="ordertable">
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr bgcolor="#f7f7f7">
                  <th>商品编号</th>
                  <th>商品名称</th>
                  <th>数量</th>
                  <th>单位</th>
                  <th>单价</th>
                  <th>小计</th>
                </tr>
<w:Rep id="rpListProUp" runat="server">
<itemtemplate>
                <tr>
                  <td><%# Eval("op_ProNumber")%></td>
                  <td><a href="<%# GetURL.Pro.Info(Eval("FK_Pro")) %>" target="_blank" class="Green"><%# Eval("op_ProName")%></a></td>
                  <td><%# Eval("op_Num")%></td>
                  <td><%# Eval("op_ProUnit")%></td>
                  <td>￥<%# Eval("op_UserPrice")%></td>
                  <td>￥<%# Eval("op_UserTotalPrice")%></td>
                </tr>
</itemtemplate>
</w:Rep>
              </table>
              <p>
              <%if (pageTicket_1_Number.Length > 0)
                {%>
              （使用购物券 编号：<%=pageTicket_1_Number %> 面值：<span class="red">￥<%=pageTicket_1_Price %></span>）
              <%} %>
              商品总价：<span class="red">￥<%=pageTotalPrice %></span>
              
              </p>
              </div>
          </div>
        </div>
        <div class="clear"></div>
    </div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
