<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="WZ.Web.pro.show" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=d.Eval("ProName")%></title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/Content.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    
    <script type="text/javascript">
		function showPic(pStr)
		{
		    _.get("aShowPic").setAttribute("rel",pStr);
			_.get("imgShowPic").src=pStr;
		}
		
		function ACart()
		{
			AddCart(<%=id%>,_.get('cProN').value);
		}
		
		function showBigImg()
		{
		    var strImg=_.attr(_.get("aShowPic"),"rel");
		    var ff=FloatFrame();
		    ff.src="/floatLayer/showBigImg.aspx?id=<%=id %>&type=pro&selImg="+strImg;
		    ff.width="808";
		    ff.height="480";
		    ff.show();
		}
	</script>
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" /></div>
<div class="main">
  <div class="left">
    <!--商品基本信息-->
    <div class="property">
      <div class="gallery">
        <div class="pic">
         <a id="aShowPic" href="javascript:showBigImg()" rel="<%=GetURL.Pro.Pic(d.Eval("PicB")) %>"><img id="imgShowPic" src="<%=GetURL.Pro.Pic(d.Eval("PicB")) %>" width="379" height="284" alt="<%=d.Eval("ProName") %>" /></a>
        </div>
        <ul class="thumb">
        <asp:Repeater ID="rpPic" runat="server">
          <ItemTemplate>
            <li><a href="javascript:showPic('<%#GetURL.Pro.Pic(Eval("PicB")) %>')" ><img src="<%#GetURL.Pro.Pic(Eval("PicS")) %>" width="46" height="46" /></a></li>
          </ItemTemplate>
        </asp:Repeater>
        </ul>
      </div>
      <div class="wrap">
        <h3><%=d.Eval("ProName")%></h3>
        <p class="goods_number">商品编号：<%=d.Eval("Number")%></p>
        <ul class="Att-box1">
          <%--<li>搜菜价：<span class="red2">￥<%=d.Eval("Price")%></span></li>
          <li>市场价：￥<del><%=d.Eval("PriceMarket")%></del></li>--%>
          <li>搜菜价：<span class="red2">暂无</span></li>
          <li>市场价：￥<del>暂无</del></li>
          <li>销售规格：<%=d.Eval("UnitNum")%><%=d.Eval("Unit")%></li>
          
          <%=pageMS%>
        </ul>
        <div class="Att-box2">
          <ul>
          <%=pageItem%>
          </ul>
        </div>
        <ul class="Purchase">
          <li><strong>会员评价：</strong>
          <span id="curProStar">
            </span>(<a href="javascript:;" class="Green" onclick="getEvaluate()">查看评价</a>)</li>
            <script type="text/javascript">
				document.getElementById('curProStar').innerHTML=GetStar(<%=fraction%>);
			</script>
        </ul>
        <ul class="action">
          <li><strong>购买数量：</strong>
            <input id="cProN" name="cProN" type="text" size="5" class="Qinput" value="1" />
            <%=d.Eval("Unit")%></li>
          <li class="Joined2">
            <input name="" type="button" class="Joinedshop" onclick="ACart()" />
          </li>
          <li class="Joined"><a href="javascript:AddFav(<%=id %>)" class="Bookmark">添加到收藏夹</a></li>
          <li class="Joined" style="position:relative"><a id="shareShow" href="javascript:;" class="Share">分享</a>
          <div id="shareShowDiv">
                  <script type="text/javascript" src="/js/share.js"></script>
                  </div>
          </li>
          <script type="text/javascript">
              var shareT=null;
              _.get("shareShowDiv").onmouseover=_.get("shareShow").onmouseover=function(){if(shareT)clearTimeout(shareT); _.get("shareShowDiv").style.display="block"}
              _.get("shareShowDiv").onmouseout=_.get("shareShow").onmouseout=function(){shareT=setTimeout(function(){_.get("shareShowDiv").style.display="none"},500)}
          </script>
          
        </ul>
        <div class="Recipes"> <a href="#relate" class="Green">不满意? 查看与<strong class="Red"><%=d.Eval("ProName")%></strong>相关的食谱</a></div>
      </div>
      <div class="clear"></div>
    </div>
    <div class="dimPic">图片仅供参考，以商品实物为准。</div>
    <!--商品描述-->
    <%
string detail1 = d.Eval("Detail1").ToString();
if (detail1.Length > 0)
{
   %>
    <div class="description">
      <h1></h1>
      <div class="border">
      	<div class="Hot-main"><%=detail1%></div>
      </div>
    </div>
    <%} %>
    
    <!--营养价值-->
    <%
        string detail2 = d.Eval("Detail2").ToString();
        if (detail2.Length > 0)
{
   %>
    <div class="description">
      <h2></h2>
      <div class="border">
      <div class="Hot-main"><%=detail2%></div>
      </div>
    </div>
    <%} %>
    
    <a name="relate"></a>
    <!--  相关食谱-->
    <%if (relateDt == null || relateDt.Rows.Count > 0)
      { %>
    <div class="ch-main">
      <h1><a href="/search/relateCaiPu.aspx?id=<%=id %>" target="_blank">更多...</a></h1>
      <div class="border">
          <div class="list">
            <ul class="def d_list3">
    <w:cycle id="rpRelateCaiPu" runat="server" width="123" height="80" />
    
            </ul>
            
          </div>
      </div>
    </div>
    <%} %>
    <!--评价、咨询-->
    <div class="reviews">
      <div class="reviews-title"> 
      <span><a href="/pro/evaluateList.aspx?id=<%=id%>" target="_blank">查看更多评价</a></span>
<a id="eval"></a>
<ul id="commentMenu" class="Appraisal">
  <li><a href="javascript:;" onclick="getEvaluate()">用户评价</a></li>
  
</ul>
  </div>
  <h3>用户的评价仅针对其所订购的订单，商品价格与网站活动都为即时更新，请用户结合实际情况作参考。</h3>
<!--评价列表-->
<div id="comment" runat="server">
  <w:Item ID="rpEvaluate" runat="server">
  <ItemTemplate>
  <div class="comment">
    <div class="com-left">
      <p><%# Eval("UserName")%>：</p>
      <p class="com-txt"><%# Eval("Detail")%></p>
      <p class="com-Reply" <%#Eval("ReDetail").ToString().Length>0?"":"style=\"display:none\"" %>><span class="Reply"></span><%# Eval("ReDetail")%></p>
    </div>
    <div class="com-right">
      <p class="star"><%#Eval("Fraction")%></p>
      <p><%# Eval("AddDate")%></p>
    </div>
    <div class="clear"></div>
  </div>
  </ItemTemplate>
  </w:Item>
  
</div>
<!--end 评价列表-->

<!--评论列表-->
<div id="comment1" runat="server">
<w:Item ID="rpMsg" runat="server">
<ItemTemplate>
  <div class="comment">
   <div class="com-left">
    <p><%# Eval("UserName")%>：</p>
    <p class="com-txt"><%# Eval("Detail")%></p>
    <p class="com-Reply" <%#Eval("ReDetail").ToString().Length>0?"":"style=\"display:none\"" %>><span class="Reply"></span><%# Eval("ReDetail")%></p>
   </div>
   <div class="com-right">
    <p>咨询时间</p>
    <p><%# Eval("AddDate")%></p>
   </div>
   <div class="clear"></div>
 </div>
 </ItemTemplate>
</w:Item>
</div>
<!-- end 评论列表-->
</div>

<script type="text/javascript">
function setStar()
{
	var obj=_.getClassN('star');
	
	for(var i=0;i<obj.length;i++)
	{
		var o1=obj[i];
		
		obj[i].innerHTML=GetStar(Number(o1.innerHTML))
	}
}
setStar();

function ajaxPage(pCmd,pPageIndex)
{
    Ajax('<%=GetURL.Pro.Info(id) %>',{
	param:'hid=1&cmd='+pCmd+'&ajax_page='+pPageIndex,
	method:'post',
	fnSuccess:function(){
		_.get('comment').innerHTML=this.xmlHttp.responseText;
		setStar();
		_.get('eval').scrollIntoView();
		}
    }).exe();
}

//评价列表
function getEvaluate()
{
    ajaxPage('ajax_page_eval',1);
    _.get('commentMenu').className='Appraisal';
	setStar();
	_.get('postEval').style.display='';
}

function msg_show(pName,pMsg)
{
    _.get(pName).style.display='';
    _.get(pName).innerHTML=pMsg;
}
</script>
    
<!--发表评价-->
<div class="ship-twLeft" id="postEval">
    <div class="h4">
        <div id="selStar" style="width:80px; height:13px;background:url('/images/star.gif');position:relative;float:left; font-size:0px; line-height:0px;cursor:pointer">
            <div style="width:48px; height:100%;background:url('/images/star1.gif')"></div>
            <input type="hidden" id="starHidden" value="3" />
        </div>
        <p style=" float:left; color:Red; padding-left:10px"><span id="starNumber">3</span>星</p>
    </div>
    <div class="txaAddText"><textarea id="evalContent" name="evalContent">请输入内容。</textarea></div>
    <div class="Sub-box">
        <div class="Sub">
            <span style="color:#f00; display:none" id="htm_evalMsg"></span>
            <input name="evalOK" type="button" class="Subinput" onclick="evalSubmit()" />
        </div>
    </div>
</div>
<!--end 发表评价-->
<script type="text/javascript">
(function(){
	window.stars={
		objS:"selStar",
		init:function()
		{
			stars.obj=_.get(stars.objS)
			stars.N=3;//初始化时3颗星
			stars.cObj=_.firstChild(stars.obj);
			
			stars.obj.onmousemove=function(e){
				e=e||event;
				var x=e.layerX||e.offsetX;
				stars.temp=Math.ceil(x/16);
			};
			stars.obj.onclick=function(){
				stars.N=stars.temp;
				_.get('starHidden').value=stars.N;
				_.get('starNumber').innerHTML=stars.N
				stars.cObj.style.width=stars.N*16+"px";
			}
		}
	}
})();
stars.init();

//发表评价
var evalText=new setTextDef('evalContent');

function evalSubmit()
{
	var obj=_.get('evalContent');
	
	if((!obj.value) || evalText.old==obj.value)
	{
        msg_show('htm_evalMsg','请输入内容。');
		return;
	}
	
	Ajax("/ajax/proEvaluate.aspx?id=<%=id%>&t=1&star="+_.get('starHidden').value,{
		param:'content='+obj.value,
		method:'post',
		fnSuccess:function(){
			eval('var jso='+this.xmlHttp.responseText)
			
			switch(jso.type)
			{
				case 'nologin':
					flogin();
					break;
				case 'error':
				    switch(jso.info)
				    {
				        case 'above':
				            msg_show('htm_evalMsg','不能超出600字。');
				            break;
				        case 'ban':
				            msg_show('htm_evalMsg','您的提交太过频繁，隔几秒再试！');
				            break;
				        case 'has':
				            msg_show('htm_evalMsg','您已对此产品评价。');
				            break;
			            case 'nobuy':
				            msg_show('htm_evalMsg','您还未订购此商品，不能评价。');
				            break;
				        default:
				            msg_show('htm_evalMsg',jso.info);
				            break;
				    }
					
					break;
				case 'success':
					//getEvaluate();
                    msg_show('htm_evalMsg','提交成功。');
					obj.value='';
					obj.focus();
					break;
			}
		}
	}).exe();
}
</script>
  </div>
  <div class="right">
    <div class="content-box">
      <h1></h1>
      <ul class="def d_list1">
<!--同类商品-->
<w:cycle id="rpProSameClass" runat="server" width="147" height="100" target="" />
      </ul>
      <div class="clear"></div>
    </div>
    <div class="Recently-box">
      <h1></h1>
      <div class="def d_list2">
        <ul>
<w:cycle id="rpGZ" runat="server" width="72" height="44" target="" />

        </ul>
        <div class="clear"></div>
      </div>
    </div>
  </div>
</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>