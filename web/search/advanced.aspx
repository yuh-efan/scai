<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="advanced.aspx.cs" Inherits="WZ.Web.search.advanced" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>高级搜索</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/search.css" rel="stylesheet" type="text/css" />
</head>
<body>
<w:top id="ucTop" runat="server" NavIndex="1" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=' > 高级搜索 ' /></div>
<div class="main">
  <div class="search-wrap">
  
  	<ul id="menuItem" class="search-title">
    	<li><a href="javascript:;" onclick="TT.showItem('')">搜索食谱</a></li>
        <li><a href="javascript:;" onclick="TT.showItem('2')">搜索食品</a></li>
    </ul>
    <div class="search-left"></div>
    <div class="search-main">
    	<div>
        	<div class="left">关键字：</div>
            <div class="right"><input id="keyword" name="keyword" type="text" size="30" />
            </div>
        </div>
       	
        <ul id="htm_">
            <%=sbCaiPu.ToString() %>
        </ul>
       	
       	<ul id="htm_2" style="display:none">
       	    商品分类
       	</ul>
       	
<script type="text/javascript">
var TT={
	attr:[],
	currAttr:"caiPu",
	ele:_.get("htm_"),
	showItem:function(pStr)
	{
       	    var arr=['htm_','htm_2'];
			TT.attr=["caiPu","pro"];
			
			TT.currAttr=TT.attr[Number(pStr)?Number(pStr)-1:0];
			
            for(var i=0;i<arr.length;i++)
            {
                document.getElementById(arr[i]).style.display='none';
            }
            TT.ele=document.getElementById('htm_'+pStr);
            TT.ele.style.display='';
            document.getElementById('menuItem').className='search-title'+pStr;
	},
	submit:function()
	{
		var arr=[];
		var allInp=_.getTN("input",TT.ele);
		for(var i=0; i<allInp.length;i++)
		{
			if(allInp[i].checked)
				arr.push(allInp[i].id.split("_")[2]);
		}
		location.href="/search/{0}.aspx?s=-----{1}-{2}".format(TT.currAttr,encodeURIComponent(_.get("keyword").value).trim(),arr.toString());
	}
}
</script>
       	
        <li>
        	<div class="left">&nbsp;</div>
            <div class="right">
            <input onclick="TT.submit()" type="button" class="sunbg" value="搜索" />
            <input type="hidden" name="selType" id="selType" />
            </div>
        </li>
    </div>
    <div class="clear"></div>
  </div>
</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>