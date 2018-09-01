function checkIn()
{
	this.oName=_.get("cName");
	this.oEmail=_.get("cEmail");
	this.oPwd=_.get("cPwd");
	this.oPwdSure=_.get("cPwdSure");
	this.oCard=_.get("cCard");
	this.oPromoter=_.get("cPromoter");
	this.oCode=_.get("cCode");
	
	this.oNameText=_.get(this.oName.id+"Text");
	this.oEmailText=_.get(this.oEmail.id+"Text");
	this.oPwdText=_.get(this.oPwd.id+"Text");
	this.oPwdSureText=_.get(this.oPwdSure.id+"Text");
	this.oCardText=_.get(this.oCard.id+"Text");
	this.oPromoterText=_.get(this.oPromoter.id+"Text");
	this.oCodeText=_.get(this.oCode.id+"Text");
	
	this.msgObj={};
	this.msgObj.name=this.oNameText;
	this.msgObj.email=this.oEmailText;
	this.msgObj.pwd=this.oPwdText;
	this.msgObj.pwd1=this.oPwdSureText;
	this.msgObj.card=this.oCardText;
	this.msgObj.promoter=this.oPromoterText;
	this.msgObj.code=this.oCodeText;
	
	this.msg={};
	
	this.msg.name={}
	this.msg.name.init='用户名5-30个字符，可以包含英文、数字和下划线。';
	this.oNameText.innerHTML=this.msg.name.init;
	this.msg.name.input='请输入用户名，用户名5-30个字符，英文、数字和下划线。';
	this.msg.name.above='用户名5-30个字符，可以包含英文、数字和下划线。';
	this.msg.name.format='用户名有非法字符。';
	this.msg.name.has='该用户名已被注册';
	
	this.msg.email={}
	this.msg.email.init='邮箱名5-30个字符，可以包含英文、数字和下划线。';
	this.oEmailText.innerHTML=this.msg.email.init;
	this.msg.email.input='请输入邮箱，邮箱名5-30个字符，英文、数字和下划线。';
	this.msg.email.above='邮箱名5-30个字符，可以包含英文、数字和下划线。';
	this.msg.email.format='您的邮箱格式不正确，请输入有效的E-mail地址，如：chen1987@163.com。';
	this.msg.email.has='该邮箱名已被注册';
	
	this.msg.pwd={};
	this.oPwdText.innerHTML='密码至少5位，区分大小写。';
	this.msg.pwd.input='请输入密码。';
	this.msg.pwd.above='密码必须在5-30位数之间。';
	
	this.msg.pwd1={};
	this.msg.pwd1.init='请重复输入一次相同的登录密码。';
	this.oPwdSureText.innerHTML=this.msg.pwd1.init;
	this.msg.pwd1.input='请输入确认密码。';
	this.msg.pwd1.notEqual='两次密码输入不一致。';
	
	this.msg.card={}
	this.msg.card.init='若您有会员卡，请输入会员卡号。';
	this.oCardText.innerHTML=this.msg.card.init;
	this.msg.card.wrong='会员卡错误或不存在此卡号。';
	this.msg.card.clo='会员卡活动已关闭。';
	
	this.msg.promoter={}
	this.msg.promoter.init='若您有推广员介绍，请输入推广员号码。';
	this.oPromoterText.innerHTML=this.msg.promoter.init;
	this.msg.promoter.wrong='推广员号码错误或不存在此推广员。';
	this.msg.promoter.clo='注册推广员活动已关闭。';
	
	this.msg.code={};
	this.msg.code.init='请输入左边图片的数字。';
	this.oCodeText.innerHTML=this.msg.code.init;
	this.msg.code.input='请输入验证码。';
	this.msg.code.wrong='验证码输入错误。';
	
	this.msgObj.code.className="error";
	
	var pThis=this;
	//--username
	this.oName.onfocus=function()
	{
		pThis.onFocus(this);
		pThis.oNameText.innerHTML=pThis.msg.name.init;
	}
	
	this.oNameB=function(pArg)
	{
		pThis.onBlur(pThis.oName);
		
		var oRow=pThis.oName.parentNode.parentNode
		
		var errGeShi=pThis.msg.name.format;
		var sValue=pThis.oName.value.trim();
		
		if(sValue.length==0)
		{
			pThis.oNameText.innerHTML=pThis.msg.name.input;
			oRow.className="error";
			return false;
		}
		else if(sValue.length<5||sValue.length>30)
		{
		    pThis.oNameText.innerHTML=pThis.msg.name.above;
			oRow.className="error";
			return false;
		}
		else if(sValue.search(/^([0-9a-zA-Z]|[\u4e00-\u9fa5]){1}([\w]|[\u4e00-\u9fa5])+$/)==-1)
		{
			pThis.oNameText.innerHTML=errGeShi;
			oRow.className="error";
			return false;
		}
		else if(pArg!=1)
		{
			Ajax('/ajax/checkInfo.aspx?s='+encodeURIComponent(sValue),{
				fnSuccess:function(){
					switch(this.xmlHttp.responseText)
				{
					case '0':
						pThis.oNameText.innerHTML='';
						oRow.className="success";
						return true;
						break;
						
					case '1':
						pThis.oNameText.innerHTML=pThis.msg.name.has;
						oRow.className="error";
						return false;
						break;
						
					case '2':
						pThis.oNameText.innerHTML=errGeShi;
						oRow.className="error";
						return false;
						break;
				}
				}
			}).exe();
		}
		else
			return true
	}
	this.oName.onblur=this.oNameB;
	//--end username
	
	//--email
	this.oEmail.onfocus=function()
	{
		pThis.onFocus(this);
		pThis.oEmailText.innerHTML=pThis.msg.email.init;
	}
	
	this.oEmailB=function(pArg)
	{
		
		pThis.onBlur(pThis.oEmail);
		
		var oRow=pThis.oEmail.parentNode.parentNode
		
		var errGeShi=pThis.msg.email.format;
		var sValue=pThis.oEmail.value.trim();
		
		if(sValue.length==0)
		{
			pThis.oEmailText.innerHTML=pThis.msg.email.input;
			oRow.className="error";
			return false;
		}
		else if(sValue.length<5||sValue.length>30)
		{
		    pThis.oEmailText.innerHTML=pThis.msg.email.above;
			oRow.className="error";
			return false;
		}
		else if(sValue.search(/^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/)==-1)
		{
			pThis.oEmailText.innerHTML=errGeShi;
			oRow.className="error";
			return false;
		}
		else if(pArg!=1)
		{
			Ajax('/ajax/checkInfo.aspx?s='+sValue+'&t=1',{
				fnSuccess:function(){
					switch(this.xmlHttp.responseText)
				{
					case '0':
						pThis.oEmailText.innerHTML='';
						oRow.className="success";
						return true;
						break;
						
					case '1':
						pThis.oEmailText.innerHTML=pThis.msg.email.has;
						oRow.className="error";
						return false;
						break;
						
					case '2':
					
						pThis.oEmailText.innerHTML=errGeShi;
						oRow.className="error";
						return false;
						break;
				}
				}
			}).exe();
		}
		else
			return true
	}
	this.oEmail.onblur=this.oEmailB;
	//--end email
	
	//--pwd 
	this.oPwd.onfocus=function()
	{
		pThis.onFocus(this);
		
		pThis.oPwdText.innerHTML="密码至少5位，区分大小写。<table id='pwdTable' class='pwdTab' cellpadding='0' cellspacing='0' border='0'><tr><td><div style='width:100px; border:solid 1px #42BF26; padding:1px'><div id='safePwd' style='height:5px; font-size:0px;background:#42BF26;width:0px'></div></div></span></td><td><span id='Level'></span></td></tr></table>";
		fnSetPwdSafe(this.value);
	}
	
	this.oPwdB=function()
	{
		pThis.onBlur(pThis.oPwd);
		var oRow=pThis.oPwd.parentNode.parentNode;
		oRow.style.backgroundColor='';
		var sValue=pThis.oPwd.value;
		
		if(sValue.length==0)
		{
			oRow.className="error";
			pThis.oPwdText.innerHTML=pThis.msg.pwd.input;
			return false;
		}
		else if(sValue.length<5 || sValue.length>30)
		{
			oRow.className="error";
			pThis.oPwdText.innerHTML=pThis.msg.pwd.above;
			return false;
		}
		else
		{
		
			if(!pThis.oPwdSure.value)
			{
				oRow.className="success";
			    pThis.oPwdText.innerHTML="";
			    return true;
			}
			else if( pThis.oPwdSure.value!=pThis.oPwd.value)
			{
			
			    oRow.className="success";
				pThis.oPwdText.innerHTML='';
			
			    var rowPwdSureO=_.get('rowPwdSure');
				rowPwdSureO.className="error";
				pThis.oPwdSureText.innerHTML=pThis.msg.pwd.notEqual;
				return false;
			}
			else
			{
				var rowPwdSureO=_.get('rowPwdSure');
				rowPwdSureO.className="success";
				pThis.oPwdSureText.innerHTML="";
				
				oRow.className="success";
				pThis.oPwdText.innerHTML='';
				return true;
			}
		}
	}
	this.oPwd.onblur=this.oPwdB;
	//-- end pwd
	
	this.oPwd.onkeyup=function()
	{
		fnSetPwdSafe(this.value)
	}
	
	//--pwdSure
	this.oPwdSure.onfocus=function()
	{
		pThis.onFocus(this);
		pThis.oPwdSureText.innerHTML=pThis.msg.pwd1.init;
	}
	
	this.oPwdSureB=function()
	{
		pThis.onBlur(pThis.oPwdSure);
		var oRow=pThis.oPwdSure.parentNode.parentNode
		oRow.style.backgroundColor='';
		var sValue=pThis.oPwdSure.value;
		
		if(sValue.length==0)
		{
			oRow.className="error";
			pThis.oPwdSureText.innerHTML=pThis.msg.pwd1.input;
			return false;
		}
		else if(sValue!=pThis.oPwd.value)
		{
			oRow.className="error";
			pThis.oPwdSureText.innerHTML=pThis.msg.pwd1.notEqual;
			return false;
		}
		else
		{
			oRow.className="success";
			pThis.oPwdSureText.innerHTML='';
			return true;
		}
	}
	this.oPwdSure.onblur=this.oPwdSureB;
	//-- end pwdSure
	
	//--card
	this.oCard.onfocus=function()
	{
		pThis.onFocus(this);
		pThis.oCardText.innerHTML=pThis.msg.card.init;
	}
	
	this.oCardB=function(pArg)
	{
		pThis.onBlur(pThis.oCard);
		
		var oRow=pThis.oCard.parentNode.parentNode
		//oRow.className="success";
		pThis.oCardText.innerHTML=pThis.msg.card.init;
		return true;
	}
	this.oCard.onblur=this.oCardB;
	//--end card
	
	//--card
	this.oPromoter.onfocus=function()
	{
		pThis.onFocus(this);
		pThis.oPromoterText.innerHTML=pThis.msg.promoter.init;
	}
	
	this.oPromoterB=function(pArg)
	{
		pThis.onBlur(pThis.oPromoter);
		
		var oRow=pThis.oPromoter.parentNode.parentNode
		//oRow.className="success";
		pThis.oPromoterText.innerHTML=pThis.msg.promoter.init;
		return true;
	}
	this.oPromoter.onblur=this.oPromoterB;
	//--end card
	
	//--code
	this.oCode.onfocus=function()
	{
		pThis.onFocus(this);
		pThis.oCodeText.innerHTML=pThis.msg.code.init;;
	}
	
	this.oCodeB=function(pArg)
	{
		pThis.onBlur(pThis.oCode);
		var oRow=pThis.oCode.parentNode.parentNode;
		oRow.style.backgroundColor='';
		var sValue=pThis.oCode.value;
		
		if(sValue.length==0)
		{
			oRow.className="error";
			pThis.oCodeText.innerHTML=pThis.msg.code.input;
			return false;
		}
		else if(pArg!=1)
		{
			var objAjax=Ajax('/ajax/checkInfo.aspx?t=2&s='+sValue);
			objAjax.fnSuccess=function()
			{
				switch(this.xmlHttp.responseText)
				{
					case '0':
						pThis.oCodeText.innerHTML=pThis.msg.code.wrong;
						oRow.className="error";
						return false;
						break;
						
					case '1':
						pThis.oCodeText.innerHTML='';
						oRow.className="success";
						return true;
						break;
				}
			}
			objAjax.exe();
		}
		else
			return true;
	}
	this.oCode.onblur=this.oCodeB;
	//-- end code
}

checkIn.prototype=
{
	onFocus:function(pThis)
	{
		var oRow=pThis.parentNode.parentNode
		oRow.style.backgroundColor="#F4FCFE";
		oRow.className="init";
	},
	
	onBlur:function(pThis)
	{
		var oRow=pThis.parentNode.parentNode
		oRow.style.backgroundColor="";
	}
}

var ck=new checkIn();

  
function fnSetPwdSafe(password)
{
    if(password.length==0)
        _.get("pwdTable").style.display="none";
    else
        _.get("pwdTable").style.display="block";

    var _score=0;
    if(password.length<=4)
        _score+=5
    else if(password.length>=5&&password.length<=7)
        _score+=10
    else if(password.length>=8)
        _score+=25
    
    var _UpperCount=(password.match(/[A-Z]/g)||[]).length;
    var _LowerCount=(password.match(/[a-z]/g)||[]).length;
    var _LowerUpperCount=_UpperCount+_LowerCount;
    if(_UpperCount&&_LowerCount)
        _score+=20
    else if(_UpperCount||_LowerCount)
        _score+=10
    
    var _NumberCount=(password.match(/[\d]/g,"")||[]).length;
    if(_NumberCount>0&&_NumberCount<=2)
        _score+=10
    else if(_NumberCount>=3)
        _score+=20
    
    var _CharacterCount=(password.match(/[!@#$%^&*?_\.\-~]/g)||[]).length;
    if(_CharacterCount==1)
        _score+=10
    else if(_CharacterCount>1)
        _score+=25
    
    if(_NumberCount&&_LowerUpperCount)
        _score+=2
    if(_NumberCount&&_LowerUpperCount&&_CharacterCount)
        _score+=3
    if(_NumberCount&&(_UpperCount&&_LowerCount)&&_CharacterCount)
        _score+=5
    
    if(_score>100)
        _score=100;
    
    _.get("Level").innerHTML=getResultDesp(_score);
    _.get("safePwd").style.width=_score+"px";
    
}
function getResultDesp(score)
{
    if(score<=5)
        return"\u592a\u77ed"
    else if(score>5&&score<=20)
        return"\u5f31"
    else if(score>20&&score<60)
        return"\u4e2d"
    else if(score>=60)
        return"\u5f3a"
    else
        return"";
}

function checkall()
{
	var objReg=_.get('btSubmit');
	objReg.style.filter='gray';
	objReg.onclick=function(){alert('正在提交...');return false}
		
	var param='hid=1&cmd=reg'
		+'&cCode='+_.getValue('cCode')
		+'&cName='+_.get('cName').value
		+'&cEmail='+_.get('cEmail').value
		+'&cPwd='+_.get('cPwd').value
		+'&cPwdSure='+_.get('cPwdSure').value
		+'&cCard='+_.get('cCard').value
		+'&cPromoter='+_.get('cPromoter').value
		
	Ajax("reg.aspx",{
		param:param,
		method:'post',
		fnSuccess:function(){
			
			eval('var jso='+this.xmlHttp.responseText)
			
			switch(jso.type)
			{
				case 'success':
					var rurl=_.get('rurl').value;
					var jumpurl='regSuccess.aspx?t='+jso.info;
					if(rurl)
						jumpurl+='&url='+rurl
					window.location.href=jumpurl;
					break;
				
				case 'error':
					if(jso.info=='0')
					{
						alert('注册失败');
						break;
					}
					
					var arr=jso.info.split(';');
					try
					{
						for(var i=0;i<arr.length;i++)
						{
							var arr1=arr[i].split('.');
							ck.msgObj[arr1[0]].innerHTML=ck.msg[arr1[0]][arr1[1]];
							ck.msgObj[arr1[0]].parentNode.parentNode.className='error';
						}
					}
					catch(e)
					{
						alert(jso.info)
					}
					
					break;
				
				default:
					alert(jso.info)
					break;
			}
			
			objReg.style.filter='';
			objReg.onclick=checkall;
		}
	}).exe();
}