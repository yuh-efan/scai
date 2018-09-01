<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="findPwd1.aspx.cs" Inherits="WZ.Web.user.findPwd1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <w:header id="header1" runat="server"></w:header>
    <link href="/css/login.css" rel="stylesheet" type="text/css" />
    <title>找回密码-填写邮箱</title>
</head>
<body>
    <w:top id="ucTop" runat="server" />
    <div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 找回密码" /></div>
    <script type="text/javascript">
    function val()
    {
        var sName=_.get("cName").value.trim();
        var sMail=_.get("cMail").value.trim();
        
        var msgName=_.get("htm_msgName");
        var msgMail=_.get("htm_msgMail");
        msgName.className='red';
        msgMail.className='red';
        
        if(!sName)
        {
            msgName.innerHTML="请输入您的用户名";
            return false;
        }
        else
        {
            if(sName.search(/^([a-zA-Z]|[\u4e00-\u9fa5]){1}([\w]|[\u4e00-\u9fa5])+$/)==-1)
            {
                msgName.innerHTML="用户名中有非法字符";
                return false;
            }
        }
        msgName.innerHTML='';
        
        if(!sMail)
        {
            msgMail.innerHTML="请输入您的邮箱";
            return false;
        }
        else
        {
            if(sMail.search(/^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/)==-1)
            {
                msgMail.innerHTML="邮箱格式不正确";
                return false;
            }
        }
        
        msgMail.innerHTML='';
        return true;
    }
    
    </script>
    <form id="form1" runat="server" >
    <div class="main">
    <div class="Login">
      <div class="Logintable">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
            <td class="txt-left">用户名：</td>
              
            <td class="center"><input  id="cName" name="cName" type="text"/></td>
            <td><span id="htm_msgName">请输入您的用户名</span></td>
          </tr>
        
          <tr>
            <td class="txt-left">注册邮箱：</td>
              
            <td class="center"><input  id="cMail" name="cMail" type="text"/></td>
            <td><span id="htm_msgMail">请输入您的邮箱</span></td>
          </tr>
          
          
        </table>
        <div class="sun4">
        <asp:Button ID="bOK" runat="server" OnClick="bOK_Click" Text="确认发送" CssClass="sun04" OnClientClick="return val()"/>
        </div>
        
      </div>
    </div>
  </div>
  </form>
    <w:bottom id="ucBottom" runat="server" />
</body>
</html>
