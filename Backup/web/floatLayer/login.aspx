<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WZ.Web.floatLayer.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>登录</title>
<script type="text/javascript" src="/js/base.js"></script>
<script type="text/javascript" src="/js/ajax.js"></script>

<style type="text/css">
* { margin:0; padding:0;}
ul,li { list-style:none;}
.left h1,.sun,.input1,.input2,.Closure { background:url(/images/Regframe/rehframe.gif) no-repeat ;}	
.wrap { display:block; width:468px; height:171px; border:#02a318 solid 4px; padding:25px; background:#f1faf2; font-size:12px; position:relative; overflow:hidden}
.Closure { width:20px; height:20px; position:absolute; top:10px; right:10px; background-position:-127px -91px;}
.Closure:hover { background-position:-104px -91px;}
.left { float:left; width:294px; height:171px; border-right:#c9eacd solid 1px;}
.left h1 { height:22px; overflow:hidden;}
.left ul { padding-top:20px;}
.left li { margin-bottom:15px; height:22px;}
.left li input { width:165px; height:19px; line-height:19px; border:0; color:#333; font-size:12px;}
.left li span { color:#f00}
.input1,.input2 { width:166px; border:0; padding-left:70px; overflow:hidden; padding-top:1px;}
.input1 { background-position:0 -39px;}
.input2 { background-position:0 -66px;}
.sun { width:85px!important; height:21px!important; border:0; background-position:0 -91px;}
.right { float:left; padding-left:50px; padding-top:50px; height:121px; width:123px;}
.right li { padding-bottom:15px;}
.right li a { color:#02a318; text-decoration:underline;}
.right li a:visited,.right li a:link { color:#02a318;}
.right li a:hover { color:#cd2a23; text-decoration:underline;}


.left li input.input3{ border:solid 1px #999; border-bottom-color:#ccc; border-right-color:#ccc;width:40px;}
</style>

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
				    var furl='<%=Req.GetQueryString("furl") %>';
				    var success_target='<%=success_target%>';
					if(furl)
					{
					    if(success_target==1)
					    {
					        top.window.location.href=furl;
					    }
					    else
					    {
					        window.location.href=furl;
					    }
					}
					else
					{
					    if(success_target==1)
					    {
					        top.window.location.href=top.window.location.href;
					    }
					    else
					    {
					        top.floatLayer.hidden();
					    }
					    
					}
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
	return false;
}
</script>
</head>
<body>
<form id="form1" name="form1">
<div class="wrap">
	<div class="left">
    	<h1></h1>
        <ul>
        	<li class="input1">
        	<div  class="full">
        	    <input id="cName" name="cName" type="text" maxlength="30" value="<%=userName %>" tabindex="1" />
        	    
            </div>
        	
        	</li>
            <li class="input2"><input id="cPwd" name="cPwd" type="password" maxlength="30" tabindex="2" /></li>
            <li style="position:relative; z-index:99; display:none" id="htmV">验证码：
			<input class="input3" id="cCode" name="cCode" size="4" maxlength="4" type="text" tabindex="3" />
<input id="isV" name="isV" type="hidden" value="<%=isV %>" />
<span id="cCodeHtml"></span><a href="javascript:;" onclick="fnVerify()" style="margin-left: 70px; color:#C00">刷新验证码</a>
<script type="text/javascript">
function fnVerify()
{
	var oCodeHtml=_.get("cCodeHtml");
	oCodeHtml.innerHTML="<img id='cCodePic' alt='图片验证码,单击刷新' align='top' onclick='fnVerify()' style='cursor:pointer;width:64px;height:20px;position:absolute;top:0px;' />";
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
            </li>
            
            <li>
            <input name="cLogin" type="submit" class="sun" onclick="return login();" value="" tabindex="4" />
            <span id="info">&nbsp;</span>
            </li>
            
           
            
        </ul>
    </div>
    
    <ul class="right">
    	<li>没有帐号？ <a href="/user/reg.aspx?url=<%=url %>" target="_blank">注册</a></li>
    	<li><a href="/user/findPwd1.aspx" target="_blank">找回密码</a></li>
        <li><a href="javascript:;" onclick="top.FloatFrame.hidden();" class="Closure"></a></li>
    </ul>
</div>
</form>
</body>

<script type="text/javascript" src="/js/ui.floatFrame.js"></script>
<script type="text/javascript">
    window.onload=function(){FloatFrame.autoLocal();}
</script>
</html>