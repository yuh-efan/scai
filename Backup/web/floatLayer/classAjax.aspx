<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="classAjax.aspx.cs" Inherits="WZ.Web.floatLayer.classAjax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<style type="text/css">
* { margin:0; padding:0;}
ul,li { list-style:none;}
.clear { clear:both;}
.Closure { background:url(/images/Regframe/rehframe.gif) no-repeat ;}	
.wrap { width:600px; border:#02a318 solid 4px; padding:25px; background:#f1faf2; font-size:12px; position:relative;}
.wrap h1 { height:30px; border-bottom:#c9eacd solid 1px; text-align:center;}
.Closure { display:block; width:20px; height:20px; position:absolute; top:10px; right:10px; background-position:-127px -91px;}
.Closure:hover { background-position:-104px -91px;}
.main { padding:20px 0; line-height:30px; }
.main a { display:block; font-size:12px; font-weight:bold; text-decoration:none; padding-left:10px; color:#333; cursor:pointer}
.main div { float:left; width:200px; height:300px; overflow:auto}
.selected { background:#ddd;}
.hasList { color:#02a318!important;}
.sun-wrap { height:30px; padding-top:15px;}
.sun-wrap li { float:left; width:50%;  text-align:center;}
.sun { width:59px; height:21px; line-height:21px; border:0; background:url(/images/sun.gif) no-repeat; color:#fff; font-size:12px; text-align:center;}

</style>
<script src="/js/base.js" type="text/javascript" ></script>
<script src="/js/Ajax.js" type="text/javascript" ></script>
<script src="/js/ClassAjax.js" type="text/javascript" ></script>
</head>
<body>
<div class="wrap">
	<h1><img src="/images/Area.gif" width="82" height="23" alt="选择地区" /></h1>
	<a id="cClose" href="#" class="Closure"></a>
	<div class="main" id="showList">
    	
    </div>
    <div class="clear"></div>
    <ul class="sun-wrap">
        <li><input type="button" class="sun" value="确定" id="cSrue" /></li>
        <li><input name="" type="button" class="sun" value="取消" id="cCancel" /></li>
    </ul>
</div>
<input type="hidden" id="cClassId" />

<script type="text/javascript">

var input=document.getElementById("cClassId");
var appToElement=document.getElementById("showList");

var sParam=fnGetParameter("id");

if(sParam)
	input.value=sParam;
	
appToElement.style.visibility="hidden";//未加载先隐藏div

var classId=fnGetParameter("classId");//"area"=默认地区   "pro"=产品  "news"=新闻中心   "help"=帮助中心   "pack"=营养套餐

var classObj=new ClassAjax({url:"/ajax/getclass.ashx",classId:classId,input:input,appToElement:appToElement})
classObj.exe();


appToElement.style.visibility="visible";//加载好后显示div 
document.getElementById("cSrue").onclick=fnSure;//确定按钮
document.getElementById("cCancel").onclick=fnCancel;//取消按钮
document.getElementById("cClose").onclick=fnCancel;

//获取地址栏参数或锚点值 fnGetParameter("name")
function fnGetParameter(sName){
    var rg = new RegExp("(\\?|#|&)"+sName+"=([^&#]*)(&|#|$)","i")
    var a = location.href.match(rg);
    if (!a) a= top.location.href.match(rg);
    return (!a?null:a[2]);
}

function fnSure()//确定按钮
{
	var i=document.getElementById("cClassId").value;
	var o=top.frames["mainFrame"]||top;
	var arr=classObj.nav();
	o.fnCallSure({id:i,name:arr});//i==0时  表示无限
}
function fnCancel()//取消按钮
{
	var o=top.frames["mainFrame"]||top
	o.fnCallCancel();
}
</script>
</body>
</html>
