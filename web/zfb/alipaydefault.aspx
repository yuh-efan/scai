<%@ Page Language="C#" AutoEventWireup="true" Inherits="_alipaydefault" Codebehind="alipaydefault.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>支付宝付款</title>
<style>
	body{font-size:12px;}
	.zfb_1{border:#CCCCCC solid 1px;}
	</style>
</head>
<body>
<form id="form1" runat="server">
  <TABLE cellSpacing=0 cellPadding=0 width=760 align=center border=0>
      <TR>
        <TD vAlign=center align=left width=381><A 
      href="https://www.alipay.com/" target=_blank><IMG height=47 src="Images/logo.gif" 
      width=289 border=0></A></TD>
        <TD style="FONT-SIZE: 12px; COLOR: #000000" vAlign=center align=right 
    width=379 font>来自<a href="<%=GetWebURL%>" target="_blank"><%=GetWebName%></a> 您好，请 <A href="https://lab.alipay.com/user/reg/index.htm" target=_blank>注册</A> 或 
	<A href="https://www.alipay.com/user/login.htm" target=_blank>登录</A> | 
	<A href="http://www.alipay.com/" target=_blank>支付宝首页</A></TD>
      </TR>
  </TABLE>
  <TABLE cellSpacing=0 cellPadding=3 width=760 align=center border=0>
    <TBODY>
      <TR>
        <TD width=8 bgColor=#666666 height=30></TD>
        <TD width=740 bgColor=#ff6600 height=30><FONT 
            style="FONT-SIZE: 14px; COLOR: #ffffff"><B>支付宝快速付款通道 方便 快捷 
          安全</B></FONT></TD>
      </TR>
    </TBODY>
  </TABLE>
  <TABLE height=60 cellSpacing=0 cellPadding=0 width=760 align=center 
      border=0>
    <TBODY>
      <TR>
        <TD width=30>&nbsp;</TD>
        <TD width=730><FONT 
            style="FONT-SIZE: 14px;"><B>填写支付信息</B></FONT>
			<span id="htm01" runat="server">(本站推荐从 <a href="/User/">用户中心</a> -> <a href="/User/MyOrder.aspx">我的订单</a> -> 在相应的订单中点击"<strong>用支付宝支付</strong>")</span>
			</TD>
      </TR>
    </TBODY>
  </TABLE>
  <TABLE height=30 cellSpacing=1 cellPadding=0 width=740 bgColor=#ffcc00 border=0 align="center">
           
              <TR>
                <TD vAlign=top align=middle bgColor=#ffffee><TABLE height=30 cellSpacing=0 cellPadding=0 width=740 align=center border=0>
                  
                      <TR>
                        <TD width=15></TD>
                        <TD width=445 
                        font>请仔细确认金额与其它付款信息</TD>
                        <TD vAlign=center 
                      align=right width=280 font><A 
                        href="http://help.lab.alipay.com/lab/index.htm" 
                        target=_blank>支付宝 - 帮助中心</A> <A 
                        href="http://help.alipay.com/support/index.htm" 
                        target=_blank></A>&nbsp;</TD>
                      </TR>
                   
                  </TABLE></TD>
              </TR>
          
          </TABLE>
 
  <br />
  <table width="500" align="center" cellpadding="5" class="zfb_1">
    <tr>
      <td>订 单 号：</td>
      <td><asp:TextBox ID="TxtOrderno" runat="server" ReadOnly="true"></asp:TextBox></td>
    </tr>
    <tr>
      <td>付款概要：</td>
      <td><asp:TextBox ID="TxtSubject" runat="server"></asp:TextBox>
        <br />
        请填写您在我们<strong><%=GetWebName%></strong>的订单编号</td>
    </tr>
    <tr>
      <td>付款备注：</td>
      <td><asp:TextBox ID="TxtBody" runat="server" Height="100px" TextMode="MultiLine" 
                    Width="270px" Text="联系人：
联系地址：
邮政编码：
联系电话：
手机号码：
符加信息："></asp:TextBox></td>
    </tr>
    <tr>
      <td>付款金额：</td>
      <td><asp:TextBox ID="TxtPrice" runat="server" Width="80"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td></td>
      <td></td>
    </tr>
  </table>
  <table align="center" width="500" bgcolor="#DFDFDF">
    <tr>
      <td width="100"></td>
      <td><asp:Button ID="BtnAlipay" runat="server" OnClick="BtnAlipay_Click" Text="提 交" />
      </td>
    </tr>
  </table>
  <br />
  <div style="text-align:center"> <A 
href="https://lab.alipay.com/user/reg/index.htm" 
target=_blank><IMG src="Images/b.gif" width=668 
border=0></A> </div>
</form>
</body>
</html>
