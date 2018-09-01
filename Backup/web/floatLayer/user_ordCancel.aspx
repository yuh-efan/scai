<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_ordCancel.aspx.cs" Inherits="WZ.Web.floatLayer.user_ordCancel" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script type="text/javascript" src="/js/base.js"></script>
<script type="text/javascript" src="/js/ajax.js"></script>
<script type="text/javascript" src="/js/ui.floatFrame.js"></script>
<style type="text/css">
body { margin:0; padding:0; font-size:12px;}
ul,li { list-style:none;}
.wrap,.sun,.sun2,.Closure { background:url(/images/Regframe/rehframe.gif) no-repeat ;}
.wrap { width:380px; border:#02a318 solid 4px; padding:25px; background:#f1faf2;  position:relative;}
.Closure { display:block; width:20px; height:20px; position:absolute; top:10px; right:10px; background-position:-127px -91px;}
.Closure:hover { background-position:-104px -91px;}
.main {  line-height:30px;  height:148px; overflow:auto; padding:5px 0px;}
.main span img { vertical-align:middle;}
.sun-wrap { height:30px; padding-top:15px;}
.sun-wrap li { float:left; width:50%;  text-align:center;}
.sun { width:85px; height:21px; border:0; background-position:-154px -91px;}
.sun2 { width:110px; height:21px; border:0; background-position:0 -113px;}
.sun04 { border:0; color:#fff; width:100px; height:21px; line-height:21px; background:url(/images/sun2.gif) no-repeat; text-align:center; text-decoration:none; font-size:12px;}
.sun04:hover { color:#f9fc01; text-decoration:none;}
</style>
</head>
<body>
<div class="wrap">
	 <span style="font-size:14px; font-weight:bold">取消订单</span>
	<a href="javascript:;" onclick="top.floatLayer.hidden();" class="Closure"></a>
	<div class="main">
    请输入取消原因<br />
    <textarea id="qxtext" name="qxtext" style="width:350px; height:100px;"></textarea>
    </div>
  <ul class="sun-wrap">
<script type="text/javascript">
function click_ok()
{
	var aj=new Ajax(location.href);
	aj.method='post';
	aj.param='hid=1&content='+_.get('qxtext').value;

	aj.fnSuccess=function()
	{
		eval('var jso='+this.xmlHttp.responseText);
		
		switch(jso.type)
		{
			case 'success':
				alert('提交成功，请等待,我们会尽快处理');
				top.floatLayer.hidden();
				top.location.href=top.location.href;
				break;
			
			default:
				alert(jso.info);
				break;
		}
	}
	
	aj.exe();
}

</script>
        <li><input name="ok" type="button" value="提交" onclick="click_ok()" class="sun04" /></li>
        <li><input name="close" onclick="top.floatLayer.hidden();" type="button" value="取消" class="sun04" /></li>
  </ul>
</div>

</body>

<script type="text/javascript">
window.onload=function(){FloatFrame.autoLocal();}
</script>
</html>