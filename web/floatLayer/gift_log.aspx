<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gift_log.aspx.cs" Inherits="WZ.Web.floatLayer.gift_log" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>搜菜网-兑换记录</title>
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
    .sun { display:block; width:100px; height:21px; line-height:21px; text-align:center; background:url(/images/sun2.gif) no-repeat; color:#fff; text-decoration:none;}
    .box2 { border-top:#ddd dashed 1px;}
    .box2 h1 { height:30px; line-height:30px; font-size:14px; font-weight:bold; color:#02a318;}
    .txt { color:#666; width:100%;  height:70px; overflow:auto;}
    </style>
</head>
<body>
    
    <%if (d.Count > 0)
      {%>

<div class="wrap">
	<div class="box1">
	<div class="left">
    	<img src="<%=GetURL.Gift.Pic(d.Eval("PicB")) %>" width="180" height="156" alt="<%=d.Eval("GiftName")%>" />
    </div>
    <ul class="right">
    	<li><span class="Red4"><%=d.Eval("GiftName")%></span></li>
        <li>兑换积分：<strong class="Red3"><%=d.Eval("ExIntegral")%></strong>分</li>
    	<li>数量：<%=d.Eval("Num")%></li>
        <li>总花费积分：<%=d.Eval("ExTotalIntegral")%></li>
       <li><a  href="javascript:;" onclick="top.FloatFrame.hidden();"  class="Closure"></a></li>
    </ul>
    <div class="clear"></div>
    </div>
    <div class="box2">
    	<h1>详细信息</h1>
        <div class="txt"><%=d.Eval("Detail")%></div>
    </div>
</div>


    <%}
      else if(!LoginInfo.IsLogin())
      {
          %>
      <script type="text/javascript">
        flogin();
      </script>
    <%} %>
    
</body>

</html>
