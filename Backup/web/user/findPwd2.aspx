<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="findPwd2.aspx.cs" Inherits="WZ.Web.user.findPwd2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <w:header id="header1" runat="server"></w:header>
    <title>找回密码 - 填写新密码</title>
    <link href="/css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
<w:top id="ucTop" runat="server" />
    <div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 找回密码- 填写新密码" /></div>
    <script type="text/javascript">
    function val()
    {
        var p1=_.get("cPwd").value;
        var p2= _.get("cPwdSure").value;
        var f1=_.get("fontcPwd");
        var f2=_.get("fontcPwdSure");
        
        if(p1.length==0)
		{
			f1.innerHTML="请输入密码。";
		}
		else if(p1.length<5)
		{
			f1.innerHTML="密码长度不能小于5位。";
		}
		else
		{
		    f1.innerHTML="";
		}
		if(p2.length==0)
		{
		    f2.innerHTML="请输入确认密码。";
		}
		else if(p1!=p2)
		{
		    f2.innerHTML="两次密码输入不一致。";
		}
		else
		{
		    f2.innerHTML="";
		}
        if(f1.innerHTML||f2.innerHTML)
        {
            return false;
        }
        f1.innerHTML="";
        f2.innerHTML="";
        return true;
    }
    
   
    </script>
    
    
    <div class="main">
    <w:ShowText ID="stmsg" runat="server"></w:ShowText>
    <form id="form1" runat="server" onsubmit="return val();" >
    <div class="Login">
      <div class="Logintable">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
        
          <tr>
            <td class="txt-left">请设定新密码：</td>
            <td class="center"><input id="cPwd" name="cPwd" type="password" /></td>
            <td><font id="fontcPwd" color="red"></font><%--密码请设为6-16位字母或数字--%> </td>
          </tr>
          <tr>
            <td class="txt-left">请再次输入新密码：</td>
            <td class="center"><input id="cPwdSure" name="cPwdSure" type="password"  /></td>
           <td><font id="fontcPwdSure" color="red"></font></td>
          </tr>
          
        </table>
        <div class="sun4">
            <asp:Button id="bOK" runat="server" OnClick="bOK_Click" CssClass="sun04" Text="确认密码" />
           
        </div>
      </div>
    </div>
    </form>
  </div>
  
    <w:bottom id="ucBottom" runat="server" />
</body>
</html>
