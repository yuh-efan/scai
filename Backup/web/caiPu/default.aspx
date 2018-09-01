<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WZ.Web.caiPu._defaul1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>烹饪课堂</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/columns.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="/js/ui.ppt.js"></script>
    <style type="text/css">
	.border{border:solid 1px #ddd; padding-left:8px}
    .cur-list-1 li{width:127px; float:none}
    .cur-list-1 { width:113px; text-align:center; }
    .cur-list-2{width:100%; overflow:hidden; padding:10px 0;}
    .cur-list-2 li { float:left; width:224px; padding:10px 8px;}
			.cur-list-2 .d-name { display:block; width:214px; height:35px; line-height:35px; background:#eee; font-size:14px; font-weight:bold; padding-left:10px; padding-top:0px}
			.cur-list-2 .d-dinggou { float:right; text-align:center; display:block; width:80px; background:#aaa;font-size:16px;}
				.cur-list-2 .d-dinggou a { color:#fff; }
				.cur-list-2 .d-name1{color:#315f80}
    </style>
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 烹饪课堂" /></div>
  <div class="main">
    <div class="box-tc">
      <div class="box-tcbox">
          <div class="tc-Category">
            <%=pageClass.ToString()%>
          </div>
          
          <script type="text/javascript">
function setChildOver(str,pThis)
{
    _.get('childHome'+str).style.display='block';
    
    pThis.style.zIndex="62";
    _.getChild(pThis,0).className='loc';
}

function setChildOut(str,pThis)
{
    _.get('childHome'+str).style.display='none';
    //_.get('classDD'+str).className='';
    pThis.style.zIndex="61";
     _.getChild(pThis,0).className='';
}
</script>
          <div class="promo">
            <div class="container">
            <w:ppt1 ID="ucPPT1" runat="server" Str="caipu" ImgAttr='width="580" height="273"' Prefix="pptCaiPu_" />
            </div>
          </div>
        <div class="clear"></div>
      </div>
      <div class="box1-right">
        <div class="Seckill">
          <h1></h1>
          <div class="Seckill-main">
          
            <ul class="def cur-list-1">
           <w:cycle id="rpTeJja" runat="server" width="123" height="80" detailN="32" />
            </ul>
            
          </div>
          <div class="Seckill-bottom"></div>
        </div>
      </div>
    </div>
    <div class="tc-main">
      <h1><a href="/search/caipu.aspx?s=--------2" target="_blank">更多..</a></h1>
      
      <div class="border">
      <ul class="def cur-list-2">
      <w:cycle id="rpTJ" runat="server" width="220" height="150" />
      </ul>
      </div>
      
    </div>
    <div class="Hot-main">
      <h3><a href="/search/caipu.aspx?s=--------1" target="_blank">更多..</a></h3>
      <div class="border">
      <ul class="def cur-list-2">
      <w:cycle id="rpJingPin" runat="server" width="220" height="150" />
      </ul>
      </div>
      
    </div>
  </div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
