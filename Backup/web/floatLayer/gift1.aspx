<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gift1.aspx.cs" Inherits="WZ.Web.floatLayer.gift1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>搜菜网-兑换物品</title>
    <script type="text/javascript" src="/js/base.js"></script>
    <script type="text/javascript" src="/js/ajax.js"></script>
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    <style type="text/css">
    * { margin:0; padding:0;}
    ul,li { list-style:none;}
    .clear { clear:both;}
    .Red3 { color:#cd2a23; font-weight:bold;}
    .Red4 { color:#cd2a23; font-weight:bold; font-size:14px; font-family:Verdana, Geneva, sans-serif;}
    .Closure { background:url(/images/Regframe/rehframe.gif) no-repeat ;}	
    .wrap { width:468px; border:#02a318 solid 4px; padding:25px; background:#f1faf2; font-size:12px; position:relative; overflow:hidden;}
    .Closure { display:block; width:20px; height:20px; position:absolute; top:10px; right:10px; background-position:-127px -91px;}
    .Closure:hover { background-position:-104px -91px;}
    .left { float:left; width:204px; height:171px; border-right:#c9eacd solid 1px;}
    .right { float:left; padding-left:30px; padding-top:10px; height:121px; width:233px;}
    .right li { padding-bottom:15px;}
    .sun { width:100px; height:21px; line-height:21px; text-align:center; background:url(/images/sun2.gif) no-repeat; color:#fff; text-decoration:none; border:0}
    .box2 { border-top:#ddd dashed 1px;}
    .box2 h1 { height:30px; line-height:30px; font-size:14px; font-weight:bold; color:#02a318;}
    .txt { color:#666; width:100%;  height:70px; overflow:auto;}
	.sty_tab1 td{padding:3px;}
	.sty_tab1 th{ font-weight:normal;padding:3px; text-align:right}
    </style>
<script type="text/javascript">
function Exchange()
{
	var param=+'&cInfo='+_.getValue('cInfo')
				+'&cName='+_.getValue('cName')
				+'&cArea='+_.getValue('cArea')
				+'&cAddress='+_.getValue('cAddress')
				+'&cTel='+_.getValue('cTel')
				+'&cFixTel='+_.getValue('cFixTel')
	            +'&cInfo='+_.getValue('cInfo')
    Ajax('/ajax/gift.aspx?t=2&id=<%=id %>&excount=<%=num %>',{
	param:param,
	method:'post',
	fnSuccess:function()
	{
	    eval('var jso='+this.xmlHttp.responseText);
	    switch(jso.type)
		{
		    case 'nologin':
		        window.location.href='login.aspx?furl='+window.location.href;
		        break;
		        
		    case 'success':
				msg_show('兑换成功');
				setTimeout(hhh,1000);
				
				break;
				
		     case 'error':
				switch(jso.info)
				{
				    case 'nogift':
				        msg_show('已不存在此礼品');
				        break;
    				
			        case 'nointegral':
				        msg_show('您的积分不足');
				        break;
					default:
						msg_show(jso.info);
						break;
				}
				break;
				
			default:
				msg_show(jso.info);
				break;
		}
	}
	}).exe();
}

function msg_show(s)
{
    _.get('htm_msg').innerHTML=s;
}
function hhh()
{
    top.floatLayer.hidden();
}
</script>
</head>
<body>
    <div class="wrap">
	<div>
    <div style="font-size:14px; line-height:20px; font-weight:bold">请填写您的配送信息</div>
	<table class="sty_tab1">
	    <tr>
	        <th>所需积分：</th>
	        <td><span style="color:#f00"><%=pageTotalIntegral %></span> （您当前积分：<%=pageUserIntegral %>）</td>
	    </tr>
	    <tr>
	        <th>收货人：</th>
	        <td><input id="cName" name="cName" type="text" maxlength="20" value="<%=pageRealName %>" /></td>
	    </tr>
	    
	    <tr>
	        <th>地区：</th>
	        <td>
            	<script type="text/javascript" src="/js/ClassAjax_Drop.js"></script>
            	<input id="cArea" type="hidden" value="<%=pageArea %>"/>
                  <span id="cArea_htm"></span>
                  <script type="text/javascript">
                  ClassAjax_Drop("cArea","cArea_htm","/ajax/getclass.ashx").exe();
                  </script>
	        </td>
	    </tr>
	    
	    <tr>
	        <th>详细地址：</th>
	        <td><input id="cAddress" name="cAddress" type="text" style="width:330px;" value="<%=pageAddress %>" /></td>
	    </tr>
	    
	    <tr>
	        <th>手机：</th>
	        <td><input id="cTel" name="cTel" type="text" value="<%=pageTel %>" /> <span style="color:#f00">(手机与电话填写一个)</span></td>
	    </tr>
	    
	    <tr>
	        <th>固定电话：</th>
	        <td><input id="cFixTel" name="cFixTel" type="text" value="<%=pageFixTel %>" /></td>
	    </tr>
	    
	    <tr>
	        <th>附加信息：</th>
	        <td><textarea id="cInfo" name="cInfo" style="height: 73px; width: 330px"></textarea></td>
	    </tr>
	</table>
        <li><a  href="javascript:;" onclick="top.FloatFrame.hidden();"  class="Closure"></a></li>
    </div>
    <div style="text-align:center">
    <input type="button" class="sun" onclick="Exchange()" value="立即兑换" />
    <input type="button" class="sun" onclick="history.back();" value="返回" />
    </div>
    <div id="htm_msg" style="color:#f00; line-height:30px; text-align:center">&nbsp;</div>
</div>
</body>

<script type="text/javascript">
FloatFrame.autoLocal();
</script>
</html>
