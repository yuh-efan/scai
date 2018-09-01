<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pwdEdit.aspx.cs" Inherits="WZ.Web.user.pwdEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>修改密码 - 搜菜网</title>
    <w:headerUser id="header1" runat="server"></w:headerUser>
    <link href="/css/msgCheck.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/msgCheck.js"></script>
</head>
<body>
<w:top id="ucTop" runat="server" />
   <w:userLocation id="ucUL" runat="server" Text=" &gt; 个人信息管理 &gt; 修改密码"></w:userLocation>
  <div class="main">
    <div class="left">
      <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
    </div>
    <form id="form1" runat="server">
    <div class="right">
    
      <div class="User-box p-top">   
        <h3><span>修改密码</span></h3>
        <div class="Edit_Info">
        <div id="msg">
<%=WZ.Common.Config.HTML.CheckMsg%>
</div>
          <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td class="lefttd">我的旧密码：</td>
              <td><input id="cOldPwd" name="cOldPwd" type="password" class="text" /></td>
            </tr>            
            <tr>
              <td class="lefttd">请输入新密码：</td>
              <td>
              <input id="cNewPwd" name="cNewPwd" type="password" class="text" />
              </td>
            </tr>
              <tr>
              <td class="lefttd">请再次输入新密码：</td>
              <td>
              <input id="cNewPwdSure" name="cNewPwdSure" type="password" class="text" />
              </td>
              </tr>
          </table>
        </div>
        <div class="btns">
<script type="text/javascript">


function bOK_Click()
{
	var param='hid=1&cmd=save'
			+'&cOldPwd='+_.getValue('cOldPwd')
			+'&cNewPwd='+_.getValue('cNewPwd')
			+'&cNewPwdSure='+_.getValue('cNewPwdSure')
	        ;
	        
	Ajax('pwdEdit.aspx',{
	param:param,
	method:'post',
	fnSuccess:function(){
		cb_ok(this.xmlHttp.responseText);
	}
	}).exe();
	
	return false;
}

function cb_ok(pStr)
{
	eval('var jso='+pStr);
	switch(jso.type)
	{
		case 'error':
			checkPub(function(){
				var msg=jso.info;
				return msg;
			});
			_.get('msg').scrollIntoView();
			break;
		case 'success':
			_.getClass("msgCheck").style.display='none';
			alert(jso.info);
			break;
		default:
			alert(jso.info)
			break;
	}
}
</script>

<input type="button" name="bOK" id="bOK" value="修改" onclick="bOK_Click()" class="anniucss"/>

       <%-- <asp:Button ID="bOK" runat="server" Text="提交" OnClick="bOK_Click" CssClass="anniucss" onclientclick="return bOK_Click()" />--%>
        
        
       </div>
      </div>
      
    </div>
    </form>
    <div class="clear"></div>
  </div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
