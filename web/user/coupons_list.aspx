<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="coupons_list.aspx.cs" Inherits="WZ.Web.user.coupons_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>我的优惠券 - 搜菜网</title>
<link href="/css/layout.css" rel="stylesheet" type="text/css" />
<link href="/css/header.css" rel="stylesheet" type="text/css" />
<link href="/css/master.css" rel="stylesheet" type="text/css" />
<link href="/css/font.css" rel="stylesheet" type="text/css" />
<link href="/css/Usercenter.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
     <w:top id="ucTop" runat="server" />
   	<div class="main">
    <div class="left">
    <w:user_menu ID="ucMenu" runat="server"></w:user_menu>
    </div>
    <div class="right">
      <div class="current">当前位置：<a href="center.aspx" class="Green">会员中心</a> &gt; 优惠券与积分管理 &gt; 我的优惠券</div>
      <div class="User-box p-top">
        <h3><span>我的优惠券</span><cite> 所有的 | 
          <a href="#" class="User-title">未使用</a> | 
          <a href="#" class="User-title">已使用</a>| 
          <a href="#" class="User-title">已过期</a></cite></h3>
        <div class="ordertable">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr bgcolor="#f7f7f7">
            <th>优惠卷号码</th>
            <th>优惠卷类型</th>
            <th>使用截止日期</th>
            <th>备注</th>
            <th>状态</th>
          </tr>
          
          
          <w:Rep ID="rpList" runat="server">
          <ItemTemplate>
              <tr>
                <td><%#Eval("CodeNumber") %></td>
                <td><span class="Red"><%#getItem(Eval("Item"))%></span></td>
                <td><%#Eval("EndTime") %></td>
                <td><%#Eval("Remark")%></td>
                <td><span class="Green"><%#getState(Container.DataItem)%></span></td>
              </tr>
          </ItemTemplate>
          </w:Rep>
          
          
          
          
          <%--<tr>
            <td>LDF942254749441</td>
            <td><span class="Red">30元</span></td>
            <td>2010-6-15</td>
            <td>5.1火爆优惠促销活动</td>
            <td><span class="Green">可以使用</span></td>
          </tr>
          <tr>
            <td>LDF9426584294312</td>
            <td><span class="Red">10元</span></td>
            <td>2010-3-15</td>
            <td>系统赠送</td>
            <td><span class="Gray2">已使用</span></td>
          </tr>
          <tr>
            <td>LDF9426584294312</td>
            <td><span class="Red">50元</span></td>
            <td>2010-3-15</td>
            <td>春节礼包</td>
            <td><span class="Gray2">已过期</span></td>
          </tr>--%>
        </table>
        <%--<div class="pagination">共8条记录 每页:10条 共1页 页次:1/1   分页:<span class="Red">1</span></div>--%>
        </div>
        
        <!-- 翻页 -->
            <div class="paging"><w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" /></div>
        
        <div class="msg">
        <h6>提示信息</h6>
1. 一个订单只能使用一张现金消费券<br />
2. 每张现金消费券只能使用一次，如您使用后抵用券后又取消了订单，则该消费券也会随之作废。如您再次下单购买，您可以联系搜菜网
客服重新获得一张等价值抵用券。<br />
3. 现金消费券无法与其他优惠促销活动同时使用<br />
        </div>
      </div>
    </div>
    <div class="clear"></div>
  	</div>
   <w:bottom id="ucBottom" runat="server" />
</body>
</html>
