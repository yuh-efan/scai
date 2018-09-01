<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="login.aspx.cs" Inherits="WZ.Web.user.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>用户登录</title>
    <w:header id="header1" runat="server"></w:header>
    <link href="/css/login.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
var sto;
function login()
{
    clearTimeout(sto);
    sto=setTimeout(function(){objInfo.innerHTML='';},2000);
    
    var objInfo=_.get('info');
    if(!_.get('cName').value)
    {
        objInfo.innerHTML='请输入用户名';sto;
        return false;
    }
    
    if(!_.get('cPwd').value)
    {
        objInfo.innerHTML='请输入密码';sto;
        return false;
    }
	
	var sParam;
	if(_.get('isV').value=='1')
	{
		if(!_.get('cCode').value)
		{
			objInfo.innerHTML='请输入验证码';sto;
        	return false;
		}
		
		sParam='cName='+_.get('cName').value+'&cPwd='+_.get('cPwd').value+'&cCode='+_.get('cCode').value;
	}
	else
	{
		sParam='cName='+_.get('cName').value+'&cPwd='+_.get('cPwd').value;
	}
	//alert(0);
	//return false;
    Ajax("/ajax/login.aspx",{
			param:sParam,
			method:'post',
			fnSuccess:function(){
				
				eval('jso='+this.xmlHttp.responseText);
				if(jso.err)
				{
					objInfo.innerHTML=jso.err;sto;
				}
				else if(jso.success)
				{
					window.location.href='<%=url %>';
				}
				
				if(jso.v)
				{
					if(_.get('isV').value!='1')
					{
						_.get('htmV').style.display='';
						_.get('isV').value=1;
					}
					fnVerify();
				}
			}
	}).exe();
	//alert(1)
	return false;
}
</script>
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 登录 注册" /></div>
  
    <form id="form1" name="form1">
    <div class="main">
    <div class="Login">
    	 <div class="box">
      <div class="login">
        <h2><img src="/images/login/login_03.gif" width="105" height="28" alt="登录搜菜网" /></h2>
        <p>已注册用户请从这里登录</p>
        <div class="logintable2">
          <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td class="loginleft">用户名：</td>
              <td class="logincenter" >
                  <div  class="full">
                      <input id="cName" name="cName" type="text" value="<%=userName %>"  />
                  </div>
              </td>
              <td></td>
            </tr>
            <tr>
              <td class="loginleft">密码：</td>
              <td class="logincenter"><input id="cPwd" name="cPwd" type="password"   /></td>
              <td><a href="findPwd1.aspx"  target="_blank">忘记密码？</a></td>
            </tr>
            <tr id="htmV" style="display:none">
              <td class="loginleft">验证码：</td>
              <td class="logincenter">
<input id="cCode" name="cCode" size="4" maxlength="4" style="width:40px;" type="text"  />
<input id="isV" name="isV" type="hidden" value="<%=isV %>" />
<span id="cCodeHtml"></span><a href="javascript:;" onclick="fnVerify()">刷新验证码</a>
<script type="text/javascript">
function fnVerify()
{
	var oCodeHtml=_.get("cCodeHtml");
	oCodeHtml.innerHTML="<img id='cCodePic' alt='图片验证码,单击刷新' onclick='fnVerify()' style='cursor:pointer;width:64px;height:20px;' />";
	var oCode=_.get("cCode");
	oCode.value='';
	_.get('cCodePic').src='/verify.ashx?r='+Math.random();
}

(function page_init()
{
    if(_.get('isV').value=='1')
    {
        _.get('htmV').style.display='';
        fnVerify();
    }

    if(_.get('cName').value)
        _.get('cPwd').focus();
    else
        _.get('cName').focus();
})();
    
</script>
              </td>
              <td>
              </td>
            </tr>
          </table>
          
          <div class="sun2">
          <input name="cLogin" type="submit" class="sun03" onclick="return login();" value=""  />
          <span id="info">&nbsp;</span>
          </div>
          <div class="login-note">有任何疑问请点击 <a href="/help/" target="_blank" class="Green">帮助中心</a> 或 <a href="#" target="_blank" class="Green">联系客服</a></div>
        </div>
      </div>
      <div class="Regtable">
          <h3></h3>
          <ul>
            <li><span>绿色无公害！</span>正规渠道货源保证食品安全</li>
            <li><span>安全交易！</span>支持货到付款更安全</li>
            <li><span>优质服务！</span>爱上小二的幽默回答</li>
            <li><span>社区互动！</span>轻松玩转美食生活</li>
            <li><span>每日登录可领取10积分！</span><a href="#" target="_blank">什么是欧酷积分？</a></li>
          </ul>
          <div class="reg"><a href="reg.aspx"><img src="/images/login/sun_02.gif" width="153" height="28" alt="立即注册" /></a></div>
        </div>
        </div>
      <div class="clear"></div>
      
    </div>
  </div>
    </form>
    <w:bottom id="ucBottom" runat="server" />
    
</body>

</html>
