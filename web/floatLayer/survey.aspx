<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="survey.aspx.cs" Inherits="WZ.Web.floatLayer.survey" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>问卷调查</title>
<script type="text/javascript" src="/js/base.js"></script>
<script type="text/javascript" src="/js/ajax.js"></script>
<script type="text/javascript" src="/js/ui.floatFrame.js"></script>
<script type="text/javascript" src="/js/xcookie.js"></script>

<style type="text/css">
* { margin:0; padding:0;}
ul,li { list-style:none;}
.Closure { background:url(/images/Regframe/rehframe.gif) no-repeat ;}	
.wrap { width:468px; border:#02a318 solid 4px; padding:10px 15px 25px 15px; background:#f1faf2; font-size:12px; position:relative; overflow:hidden;}
.title { height:49px; padding-bottom:2px; background:url(/images/Survey_01.gif) repeat-x 0 bottom;}
.Closure { display:block; width:20px; height:20px; position:absolute; top:10px; right:10px; background-position:-127px -91px;}
.Closure:hover { background-position:-104px -91px;}
.Inve-main { padding:10px;}
		.Inve-main h3 { height:30px; line-height:30px; font-weight:bold; font-size:12px;}
		.Inve-main ul { padding:5px 0; border-bottom:#ddd dashed 1px; margin-bottom:10px;}
			.Inve-main li { height:30px;}
				.Inve-main li input { vertical-align:middle; margin-right:6px; margin-top:-4px;}
		.Inve-main .suntj { width:80px; height:22px; background:url(/images/index/box3.gif) no-repeat; background-position:0 -96px; border:0; font-size:12px; font-weight:bold;}
.content { padding-bottom:10px;}
.content textarea { width:98%; height:80px; padding:1%;}
</style>
</head>
<body>
<div class="wrap">
	<div class="title"><img src="/images/Survey_02.gif" width="247" height="49" alt="说说您对搜菜网的感受" /></div>
<div class="Inve-main">
    <h3><%=QuName%></h3>
    <ul>
        <w:cycleText id="rpVote" runat="server" />
    </ul>
    <h3>将您对搜菜网的任何意见或想法告诉我们吧，我们将随时倾听您的感受。</h3>
    <div class="content"><textarea id="content" name="content"></textarea></div>
    <div>
   
    <input name="cVoteOK" type="button" class="suntj" onclick="voteSubmit()" value="提交" /> &nbsp; 
    <input name="cVoteInfo" type="button" class="suntj" onclick="window.open('/questionnaire/');" value="查看" />
  <span id="msgsuc" style="color:#f00;display:none"></span>
    </div>
</div>
<a href="javascript:;" onclick="top.floatLayer.hidden();" class="Closure"></a>

</div>
<script type="text/javascript">

function voteSubmit()
{
	var param='cVote='+_.getValue('cVote')
			+'&content='+_.get('content').value
	
	Ajax("/ajax/vote.aspx?id=<%=QuSN%>",{
		param:param,
		method:'post',
		fnSuccess:function(){
			eval('var jso='+this.xmlHttp.responseText)
			
			switch(jso.type)
			{
				case 'success':
					_.get('msgsuc').style.display='';
					_.get('msgsuc').innerHTML='投票成功，感谢您的参与。';
					break;
				
				default:
					_.get('msgsuc').style.display='';
					_.get('msgsuc').innerHTML=jso.info;
					break;
			}
		}
	}).exe();
}
</script>

<script type="text/javascript">
window.onload=function(){FloatFrame.autoLocal();}
</script>
</body>
</html>
