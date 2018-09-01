<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proAddCart1.aspx.cs" Inherits="WZ.Web.floatLayer.proAddCart1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script type="text/javascript" src="/js/base.js"></script>
<script type="text/javascript" src="/js/ajax.js"></script>
<script type="text/javascript" src="/js/ui.floatFrame.js"></script>
<style type="text/css">

body { margin:0; padding:0; font-size:12px;}
ul,li { list-style:none; margin:0px; }
.wrap .tou,.sun,.sun2,.Closure { background:url(/images/Regframe/rehframe.gif) no-repeat ;}
.wrap { width:380px; border:#02a318 solid 4px; padding:25px 25px 0px 25px; background:#f1faf2;  position:relative;}
.wrap .tou { height:30px; background-position:-20px -155px; border-bottom:#c9eacd solid 1px;font-size:0px;}
.Closure { display:block; width:20px; height:20px; position:absolute; top:10px; right:10px; background-position:-127px -91px;}
.Closure:hover { background-position:-104px -91px;}
.main {  line-height:30px; text-align:center;  height:158px; overflow:auto; padding:5px 0px;}
.main span img { vertical-align:middle;}
.msg{font-size:14px; font-weight:bold; color:#f00}
.msg a{color:#900}
.msg a:hover{color:#f00}
</style>
</head>
<body>
<div class="wrap">
	<div class="tou"></div>
	<a href="javascript:;" onclick="top.floatLayer.hidden();" class="Closure"></a>
	<div class="main">
	<div class="msg"><%=msg %></div>
    </div>
</div>

</body>

<script type="text/javascript">
window.onload=function(){FloatFrame.autoLocal();}
</script>
</html>
