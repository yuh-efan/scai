<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="WZ.Web.taoCan.show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=d.Eval("ProName") %></title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/Content.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    <script type="text/javascript" src="/js/ui.ppt3.js"></script>
    
    <script type="text/javascript">
		function showPic(pStr)
		{
			document.getElementById("aShowPic").href=pStr;
			document.getElementById("imgShowPic").src=pStr
		}
		
		function ACart()
		{
			AddCart(<%=id%>,document.getElementById('cProN').value,2);
		}
		
	</script>
	<style type="text/css">
.Attribute { border-bottom:#ddd solid 1px; border-top:#ddd solid 1px; padding:10px; margin-top:10px; min-height:35px; height:auto !important; height:35px; }
.Attribute li { float:left; width:180px; height:30px; line-height:30px;}
.Attribute span { background:#ff6600; padding:3px 6px; color:#fff; margin-right:5px;}
</style>
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
        <a id="aShowPic" href="<%=GetURL.TaoCan.Pic(d.Eval("PicB")) %>" target="_blank"><img id="imgShowPic" src="<%=GetURL.TaoCan.Pic(d.Eval("PicB")) %>" width="379" height="284" alt="<%=d.Eval("ProName") %>" /></a>
        </div>
        <ul class="thumb">
        <asp:Repeater ID="rpPic" runat="server">
          <ItemTemplate>
            <li><a href="javascript:showPic('<%#GetURL.TaoCan.Pic(Eval("PicB")) %>')" ><img src="<%#GetURL.TaoCan.Pic(Eval("PicS")) %>" width="46" height="46" /></a></li>
          </ItemTemplate>
        </asp:Repeater>
        </ul>
      </div>
      <div class="wrap">
        <h3><%=d.Eval("ProName") %></h3>
        <p class="goods_number">商品编号：<%=d.Eval("Number") %></p>
        <ul class="Att-box1">
          <li>销售规格：<%=d.Eval("UnitNum") %><%=d.Eval("Unit") %></li>
          <li>库存数量：<%=d.Eval("StockN") %><%=d.Eval("Unit") %></li>
        </ul>
        <div class="Att-box2">
          <ul>
          <li id="liAttr1" runat="server" visible="false"><img src="/images/item_detail/Label_01.gif" width="43" height="17" alt="菜篮子" /></li>
          <li id="liAttr2" runat="server" visible="false"><img src="/images/item_detail/Label_02.gif" width="43" height="17" alt="无公害" /></li>
          </ul>
        </div>
        <ul class="Purchase">
          <li><strong>会员评价：</strong>
          <span id="curProStar">
            </span>(<a href="#eval" class="Green">查看评价</a>)</li>
            <script type="text/javascript">
				document.getElementById('curProStar').innerHTML=GetStar(<%=fraction%>);
			</script>
        </ul>
        <ul class="action">
          <li><strong>购买数量：</strong>
            <input id="cProN" name="cProN" type="text" size="5" class="Qinput" value="1" />
            <%=d.Eval("UnitNum") %><%=d.Eval("Unit") %></li>
          <li class="Joined2">
            <input name="" type="button" class="Joinedshop" onclick="ACart()" />
          </li>
          <li class="Joined"><a href="javascript:AddFav(<%=id %>,2)" class="Bookmark">添加到收藏夹</a></li>
          <li class="Joined"><a href="#" class="Share">分享给好友</a></li>
        </ul>
        <div class="Recipes"> <a href="#relate" class="Green">不会做? 查看与<strong class="Red"><%=d.Eval("ProName") %></strong>相关的套餐</a> </div>
      </div>
      <div class="clear"></div>
    </div>
    <ul class="Attribute"><%=pageClassAttr.ToString() %></ul>
    
    <div class="Including">
      	<div class="Including-text">您可以选择购买单个或多个食谱</div>
        <div class="Including-main">
           <div class="Including-left">
           		<div class="Including-Button"><img style="cursor:pointer" id="pathLower" src="/images/content_left.gif" /></div>
                <ul id="cPPT" style="overflow:hidden">
                
<w:Item ID="rpChild" runat="server">
    <ItemTemplate>
        <li><span><input name="cPro" type="checkbox" value="<%#Eval("ProSN") %>" /></span><a href="<%#GetURL.CaiPu.Info(Eval("ProSN")) %>" target="_blank" class="products-pic"><img src="<%#GetURL.CaiPu.Pic(Eval("PicS")) %>" width="74" height="65" alt="<%#Eval("ProName")%>" /></a><span><a href="<%#GetURL.CaiPu.Info(Eval("ProSN")) %>" target="_blank" class="Blue"><%#Eval("ProName")%></a></span></li>
    </ItemTemplate>
</w:Item>
                </ul>
                <div class="Including-Button"><img style="cursor:pointer" id="pathAdd" src="/images/content_right.gif" /></div>
           </div>
<div class="Including-right">
<br />
<br />
<p>
<script type="text/javascript">
	PPT3("cPPT",{path:1,b1:"pathAdd",b2:"pathLower"}).exe();
	function ljgm()
	{
		var sid='';
		var oPros=document.getElementsByName('cPro');
		for(var i=0;i<oPros.length;i++)
		{
			if(oPros[i].checked)
			{
				sid+=oPros[i].value+',';
			}
		}
		AddCart(sid,1,1);
	}
</script>
<input name="cljgm" type="button" class="sun" onclick="ljgm()" />
</p>
           </div>
        </div>
    </div>
    
<div class="Including">
      	<div class="Including-text1">您可以选择购买单个或多个菜品</div>
        <div class="Including-main">
           <div class="Including-left">
           		<div class="Including-Button"><img style="cursor:pointer" id="pathLower1" src="/images/content_left.gif" /></div>
                <ul id="cPPT1" style="overflow:hidden">
                
<w:Item ID="rpChild1" runat="server">
    <ItemTemplate>
        <li><span><input name="cPro1" type="checkbox" value="<%#Eval("ProSN") %>" /></span><a href="<%#GetURL.Pro.Info(Eval("ProSN")) %>" target="_blank" class="products-pic"><img src="<%#GetURL.Pro.Pic(Eval("PicS")) %>" width="74" height="65" alt="<%#Eval("ProName")%>" /></a><span><a href="<%#GetURL.CaiPu.Info(Eval("ProSN")) %>" target="_blank" class="Blue"><%#Eval("ProName")%></a></span><p class="Red2">￥<%#Eval("Price")%></p></li>
    </ItemTemplate>
</w:Item>
                </ul>
                <div class="Including-Button"><img style="cursor:pointer" id="pathAdd1" src="/images/content_right.gif" /></div>
           </div>
<div class="Including-right">
<br />
<br />
<p>
<script type="text/javascript">
	PPT3("cPPT1",{path:1,b1:"pathAdd1",b2:"pathLower1"}).exe();
	function ljgm1()
	{
		var sid='';
		var oPros=document.getElementsByName('cPro1');
		for(var i=0;i<oPros.length;i++)
		{
			if(oPros[i].checked)
			{
				sid+=oPros[i].value+',';
			}
		}
		AddCart(sid,1);
	}
</script>
<input name="cljgm" type="button" class="sun" onclick="ljgm1()" />
</p>
           </div>
        </div>
    </div>
    
    <!--商品描述-->
    <div class="description">
      <h1></h1>
      <div class="Hot-main"><%=d.Eval("Detail1") %></div>
    </div>
    <!--营养价值-->
    <div class="description">
      <h2></h2>
      <div class="Hot-main"><%=d.Eval("Detail2") %></div>
    </div>
    <a name="relate"></a>
    <!--  相关套餐-->
    <div class="ch-main">
      <h2><a href="/search/relateTaoCan.aspx?id=<%=id %>&t=2" target="_blank">更多...</a></h2>
      <div class="list">
        <ul class="Hot-products">
        
<w:cycle id="rpRelateTaoCan" runat="server" width="107" height="93" />
        
        
          <w:Item ID="rpRelateTaoCan1" runat="server">
        <ItemTemplate>
        <li>
            <a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" target="_blank" class="products-pic">
            <img src="<%#GetURL.TaoCan.Pic(Eval("PicS")) %>" width="107" height="93" alt="<%#Eval("ProName") %>" /></a>
            <p><a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" target="_blank"><%#Eval("ProName")%></a></p>
        </li>
        </ItemTemplate>
        </w:Item>
        </ul>
        <div class="clear"></div>
      </div>
    </div>
    
    <!--评价、咨询-->
    <div class="reviews">
      <div class="reviews-title"> <span><a href="/taoCan/evaluateList.aspx?id=<%=id%>" target="_blank">查看更多评价</a></span>
        
<script type="text/javascript">
function getEvaluate()
{
		Ajax("/ajax/taoCanEvaluate.aspx?id=<%=id%>",{
			fnSuccess:function(){
				document.getElementById('comment').innerHTML=this.xmlHttp.responseText;
				
				document.getElementById('commentMenu').className='Appraisal';
				setStar();
				}
		}).exe();
}

</script>
<a name="eval"></a>
        <ul id="commentMenu" class="ship-Appraisal">
          <li><a href="javascript:;">用户评价</a></li>
         
        </ul>
      </div>
      <h3>关于商品价格、网站活动的留言回复是有时效的，仅对回复后的一段时间内有效，有可能改变，之前的回复仅供参考。</h3>

      <div id="comment">
      <w:Item ID="rpEvaluate" runat="server">
      <ItemTemplate>
      <div class="comment">
        <div class="com-left">
          <p><%# Eval("FK_User").ToString() == "0" ? "匿名：" : Eval("UserName").ToString() + " 说："%></p>
          <p class="com-txt"><%# Eval("Detail")%></p>
          <p class="com-Reply" <%#Eval("ReDetail").ToString().Length>0?"":"style=\"display:none\"" %>><span class="Reply"></span><%# Eval("ReDetail")%></p>
        </div>
        <div class="com-right">
          <p>评价时间</p>
          <p><%# Eval("AddDate")%></p>
          <p>评分：</p>
          <p class="star"><%#Eval("Fraction")%></p>
        </div>
        <div class="clear"></div>
      </div>
      </ItemTemplate>
      </w:Item>
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
</script>
    </div>
    <div class="ship-twLeft">
      <div class="h4">
          <div id="selStar" style="width:80px; height:13px;background:url('/images/star.gif');position:relative;">
            <div style="width:48px; height:100%;background:url('/images/star1.gif')"></div>
            <input type="hidden" id="starHidden" value="3" />
          </div>
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
				//stars.cObj.style.width=stars.temp*16+"px";
			};
			//stars.obj.onmouseout=function(){
			//	stars.cObj.style.width=stars.N*16+"px";
			//};
			stars.obj.onclick=function(){
				stars.N=stars.temp;
				_.get('starHidden').value=stars.N;
				//新加
				stars.cObj.style.width=stars.N*16+"px";
			}
		}
	}
})();
stars.init();
</script>
    </div>
      <div class="txaAddText">
        <textarea id="content" name="content" cols="" rows="">欢迎您对该产品提问咨询。同时，我们不欢迎任何违反国家法律法规和攻击他人的言论，并有权随时删除。</textarea>
      </div>
      <div class="Sub-box">
        <div class="Sub">
        <input name="content" type="button" class="Subinput" onclick="msgSubmit()" />
        <script type="text/javascript">
			var std=new setTextDef('content');
			
			function msgSubmit()
			{
				var obj=document.getElementById('content');
				if((!obj.value) || std.old==obj.value)
				{
					alert('请输入内容');
					return ;
				}
				
				Ajax("/ajax/taoCanEvaluate.aspx?id=<%=id%>&t=1&star="+_.get('starHidden').value,{
					param:'content='+obj.innerHTML,
					method:'post',
					fnSuccess:function(){
						eval('var jso='+this.xmlHttp.responseText)
						if(jso.info)
						{
							switch(jso.info)
							{
								case 'nologin':
									flogin();
									break;
								case 'above':
									alert('不能超出600字');
									break;
								case 'success':
									getEvaluate();
									alert('提交成功');
									obj.innerHTML='';
									obj.focus();
									break;
							}
						}
						else 
						{
							alert(this.xmlHttp.responseText);
							alert('非法操作')
						}
						}
				}).exe();
			}
		</script>
        </div>
      </div>
    </div>
  </div>
  <div class="right">
    <div class="content-box">
      <h1></h1>
      <ul class="content">
      
<w:cycle id="rpSameClass" runat="server" width="122" height="90" />

<!--同类商品-->
<asp:Repeater ID="rpSameClass1" runat="server">
<ItemTemplate>
<li><a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" class="Similar"><img src="<%#GetURL.TaoCan.Pic(Eval("PicS")) %>" width="122" height="106" alt="<%#Eval("ProName")%>" /></a>
<p><a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" class="Blue"><%#Eval("ProName")%></a></p>
</li>
</ItemTemplate>
</asp:Repeater>
      </ul>
      <div class="clear"></div>
    </div>
    <div class="Recently-box">
      <h1></h1>
      <div class="Attention">
        <ul>
<w:cycle id="rpGZ" runat="server" width="60" height="39" />
        </ul>
        <div class="clear"></div>
      </div>
    </div>
  </div>
</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>