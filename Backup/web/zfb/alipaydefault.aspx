<%@ Page Language="C#" AutoEventWireup="true" Inherits="_alipaydefault" Codebehind="alipaydefault.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>֧��������</title>
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
    width=379 font>����<a href="<%=GetWebURL%>" target="_blank"><%=GetWebName%></a> ���ã��� <A href="https://lab.alipay.com/user/reg/index.htm" target=_blank>ע��</A> �� 
	<A href="https://www.alipay.com/user/login.htm" target=_blank>��¼</A> | 
	<A href="http://www.alipay.com/" target=_blank>֧������ҳ</A></TD>
      </TR>
  </TABLE>
  <TABLE cellSpacing=0 cellPadding=3 width=760 align=center border=0>
    <TBODY>
      <TR>
        <TD width=8 bgColor=#666666 height=30></TD>
        <TD width=740 bgColor=#ff6600 height=30><FONT 
            style="FONT-SIZE: 14px; COLOR: #ffffff"><B>֧�������ٸ���ͨ�� ���� ��� 
          ��ȫ</B></FONT></TD>
      </TR>
    </TBODY>
  </TABLE>
  <TABLE height=60 cellSpacing=0 cellPadding=0 width=760 align=center 
      border=0>
    <TBODY>
      <TR>
        <TD width=30>&nbsp;</TD>
        <TD width=730><FONT 
            style="FONT-SIZE: 14px;"><B>��д֧����Ϣ</B></FONT>
			<span id="htm01" runat="server">(��վ�Ƽ��� <a href="/User/">�û�����</a> -> <a href="/User/MyOrder.aspx">�ҵĶ���</a> -> ����Ӧ�Ķ����е��"<strong>��֧����֧��</strong>")</span>
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
                        font>����ϸȷ�Ͻ��������������Ϣ</TD>
                        <TD vAlign=center 
                      align=right width=280 font><A 
                        href="http://help.lab.alipay.com/lab/index.htm" 
                        target=_blank>֧���� - ��������</A> <A 
                        href="http://help.alipay.com/support/index.htm" 
                        target=_blank></A>&nbsp;</TD>
                      </TR>
                   
                  </TABLE></TD>
              </TR>
          
          </TABLE>
 
  <br />
  <table width="500" align="center" cellpadding="5" class="zfb_1">
    <tr>
      <td>�� �� �ţ�</td>
      <td><asp:TextBox ID="TxtOrderno" runat="server" ReadOnly="true"></asp:TextBox></td>
    </tr>
    <tr>
      <td>�����Ҫ��</td>
      <td><asp:TextBox ID="TxtSubject" runat="server"></asp:TextBox>
        <br />
        ����д��������<strong><%=GetWebName%></strong>�Ķ������</td>
    </tr>
    <tr>
      <td>���ע��</td>
      <td><asp:TextBox ID="TxtBody" runat="server" Height="100px" TextMode="MultiLine" 
                    Width="270px" Text="��ϵ�ˣ�
��ϵ��ַ��
�������룺
��ϵ�绰��
�ֻ����룺
������Ϣ��"></asp:TextBox></td>
    </tr>
    <tr>
      <td>�����</td>
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
      <td><asp:Button ID="BtnAlipay" runat="server" OnClick="BtnAlipay_Click" Text="�� ��" />
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
