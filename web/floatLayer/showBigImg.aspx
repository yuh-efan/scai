<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showBigImg.aspx.cs" Inherits="WZ.Web.floatLayer.showBigImg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>无标题页</title>
    <script type="text/javascript" src="/js/base.js"></script>
    <style type="text/css">
    *{ margin:0;padding:0px}
    .wrap{width:800px; height:472px; border:solid 4px #02a318;background:#f1faf2; }

    .left{float:left;overflow-y:scroll;width:138px;height:100%; }
    .left ul li{list-style:none; font-size:0px; line-height:0px; padding:8px; height:80;}
    .left ul li.sel{ background:url(/images/Regframe/bigImgSel.gif) no-repeat 5px -5px}
    .left ul li img{border: solid 1px #ccc}

    .right{float:right; position:relative; font-size:0px; line-height:0px;width:662px;height:100%; overflow:hidden;}
.right .Closure:hover { background-position:-104px -91px;}
    .right img{position:absolute; visibility:hidden}
    
    .right .Closure { width:20px; height:20px; position:absolute; top:10px; right:10px;background:url(/images/Regframe/rehframe.gif) no-repeat -127px -91px;}
    </style>
</head>
<body>
<div class="wrap">
<div class="left">
	<ul id="imgSmall">
	    <asp:Repeater ID="rpPic" runat="server">
	    <ItemTemplate>
	    
        <li><img src="<%#getUrlPic(Container.DataItem,"PicS")%>" width="100" height="80"  rel="<%#getUrlPic(Container.DataItem,"PicB")%>"/></li>
        
	    </ItemTemplate>
	    </asp:Repeater>
	  
    </ul>
</div>

<div class="right"><img id="showP"/><a href="javascript:;" onclick="top.FloatFrame.hidden();" class="Closure"></a></div>

</div>
</body>
<script type="text/javascript">

//var dd=_.get("imgSmall")
//var dddd=document.getElementsByTagName("li")[0];
//alert((dddd.offsetWidth-16)+"   "+(dddd.offsetHeight-16))
function switchImg(obj)
{
	var maxW=662-20,maxH=472-20;
	var objW=obj.offsetWidth,objH=obj.offsetHeight;
	
	with(obj.style)
	{
		width=Math.min(maxW,objW)+"px";
		height=Math.min(maxH,objH)+"px";
		
		left=Math.max((maxW-objW)/2,10)+"px";
top=Math.max((maxH-objH)/2,10)+"px";
		
	}
	obj.style.visibility="visible";
}
_.get("showP").onload=function()
{
	switchImg(this);
}
var selImg={};
function Init()
{
    var imgObj=_.get("imgSmall")
    var selImgStr=_.getUrlParam("selImg");//"/images/Partner_02.gif";
    var arr=_.getTN("img",imgObj);
    for(var i=0;i<arr.length;i++)
    {
        if(_.attr(arr[i],"rel")==selImgStr)
        {
            break;
        }
    }
    if(i!=arr.length)
    {
        _.get("showP").src=selImgStr;
        selImg=arr[i].parentNode;
    }
    
    selImg.className="sel";
    
    var currPosH=(selImg.offsetHeight)*i;
    var offsetH=imgObj.parentNode.offsetHeight;
    
    if(currPosH>=offsetH)
        imgObj.parentNode.scrollTop=currPosH-selImg.offsetHeight;
}
Init();


_.get("imgSmall").onclick=function(e)
{
	e=e||event;
	var obj=e.target||e.srcElement;
	while(obj!=this)
	{
		if(obj.tagName=="IMG")
		{
			if(selImg==obj.parentNode)
			    return;
			var img=document.getElementById("showP");
			img.style.visibility="hidden";
			img.style.width="";
			img.style.height="";
			img.src=obj.getAttribute("rel");
			selImg.className="";
			selImg=obj.parentNode;
			selImg.className="sel";
			
			break;
		}
		obj=obj.parentNode;
	}
}
</script>
</html>