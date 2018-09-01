<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="WZ.Web.content.propaganda.reg" %>
<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>注册</title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/base.js"></script>
    <script type="text/javascript" src="/js/ajax.js"></script>
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    <script type="text/javascript" src="/js/msgCheck.js"></script>
    <link href="/css/msgCheck.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ClassAjax_Drop.js"></script>
    
<style type="text/css">
        .sty_sex input{border:0px;}
    </style>
</head>

<body>

<uc1:top id="top1" runat="server" T1="reg"></uc1:top>
<div class="main">

  <div id="msg">
<%=WZ.Common.Config.HTML.CheckMsg%>
</div>
  <div class="content">
    <div class="Member">
      <h3></h3>
      <div class="Must">
        <h4></h4>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
           <tr>
            <td class="left">请填写用户名：</td>
            <td class="center"><input id="cname" name="cname" type="text" size="25" maxlength="30" /></td>
            <td>以此作为登录名。</td>
          </tr>
            
          <tr>
            <td class="left">请填写您的Email地址：</td>
            <td class="center"><input id="email" name="email" type="text" size="25" maxlength="30" /></td>
            <td>请填写有效的Email地址，可以通过此Email找回密码。</td>
          </tr>
          <tr>
            <td class="left">请设定密码：</td>
            <td class="center"><input id="pwd" name="pwd" type="password" size="25" /></td>
            <td> 密码请设为5-16位字母或数字。</td>
          </tr>
          <tr>
            <td class="left">请再次输入设定密码：</td>
            <td class="center"><input id="pwd1" name="pwd1" type="password" size="25" /></td>
            <td>&nbsp;</td>
          </tr>
          
          <tr>
            <td class="left">会员卡号：</td>
            <td class="center"><input id="card" name="card" type="text" size="25" maxlength="30" /></td>
            <td>若您有会员卡，请输入会员卡号。</td>
          </tr>
          <tr>
            <td class="left">推广员号码：</td>
            <td class="center"><input id="cPromoter" name="cPromoter" type="text" maxlength="9" style="width:120px" /></td>
            <td>若您有推广员介绍，请输入推广员号码。</td>
          </tr>
          
        </table>
      </div>
      <div class="Select">
        <h4></h4>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td class="left">联系人：</td>
            <td class="center"><input id="realname" name="realname" type="text" size="25" /></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td class="left">性别：</td>
            <td class="sty_sex"><%=pageSex%></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td class="left">地区：</td>
            <td class="center">
            
              <input id="cArea" name="cArea" type="hidden" />
              <span id="cArea_htm"></span>
              <script type="text/javascript">ClassAjax_Drop("cArea","cArea_htm","/ajax/getclass.ashx").exe();</script>

            </td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td class="left">详细地址：</td>
            <td class="center"><input id="address" name="address" type="text" size="35" /></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td class="left">手机：</td>
            <td class="center"><input id="tel" name="tel" type="text" size="25" /></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td class="left">固定电话：</td>
            <td class="center"><input id="telfix" name="telfix" type="text" size="25" /></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td class="left">请输入验证码：</td>
            <td class="center">
<input id="cCode" name="cCode" size="4" maxlength="4" type="text" />
<span id="cCodeHtml"></span><a href="javascript:;" onclick="fnVerify()">刷新验证码</a>
<script type="text/javascript">
function fnVerify()
{
	var oCodeHtml=_.get("cCodeHtml");
	oCodeHtml.innerHTML="<img id='cCodePic' alt='图片验证码,单击刷新' style='width:64px;height:20px;' />";
	var oCode=_.get("cCode");
	oCode.value='';
	_.get('cCodePic').src='/verify.ashx?r='+Math.random();
}
fnVerify();
</script>
            </td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td class="left">&nbsp;</td>
            <td class="center"><input id="cIsAgree" name="cIsAgree" class="Agreement" type="checkbox" value="1" checked="checked" />
              <span class="Agreementspan">已阅读并同意<a href="agreement.aspx" target="_blank"><b>搜菜网用户注册协议</b></a></span></td>
            <td>&nbsp;</td>
          </tr>
        </table>
        
<script type="text/javascript">
function reg()
{
	var oOK=_.get('bReg');
	oOK.style.filter='gray';
	oOK.onclick=function(){alert('正在注册...');return false}
	
	var param='hid=1&cmd=reg'
			+'&email='+_.getValue('email')
			+'&cname='+_.getValue('cname')
			+'&pwd='+_.getValue('pwd')
			+'&pwd1='+_.getValue('pwd1')
			+'&card='+_.getValue('card')
			+'&cPromoter='+_.getValue('cPromoter')
			+'&realname='+_.getValue('realname')
			+'&cSex='+_.getValue('cSex')
			+'&cArea='+_.getValue('cArea')
			+'&address='+_.getValue('address')
			
			+'&tel='+_.getValue('tel')
			+'&telfix='+_.getValue('telfix')
			+'&cCode='+_.getValue('cCode')
			+'&cIsAgree='+_.getValue('cIsAgree')
			;
	
	Ajax('reg.aspx',{
	param:param,
	method:'post',
	fnSuccess:function(){
	
		cb_reg(this.xmlHttp.responseText);
	}
	}).exe();
}

function cb_reg(pStr)
{
	eval('var jso='+pStr);
		switch(jso.type)
		{
			case 'error':
			    if(jso.info=='code.wrong')
			    {
			        jso.info='验证码输入错误';
			    }
			    
			    checkPub(function(){
		            var msg=jso.info;
		            return msg;
	            });
			    window.location.href='#msg';
				break;
			case 'success':
				window.location.href='regs.aspx?t='+jso.info;
				break;
			default:
				alert(pStr)
				break;
		}
		
		var oOK=_.get('bReg');
		oOK.style.filter='';
		oOK.onclick=function(){return reg();}
}

</script>
<a href="javascript:;" onclick="return reg()" class="sun" id="bReg">确定注册</a>
        
        </div>
    </div>
  </div>
</div>
<uc1:bottom id="bo1" runat="server" T1="reg"></uc1:bottom>

</body>
</html>
