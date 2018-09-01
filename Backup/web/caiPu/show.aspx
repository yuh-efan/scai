<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="WZ.Web.caiPu.show"%>
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
		    _.get("aShowPic").setAttribute("rel",pStr);
			_.get("imgShowPic").src=pStr;
		}
		
		function ACart()
		{
			AddCart(<%=id%>,document.getElementById('cProN').value,1);
		}
		
		function showBigImg()
		{
		    var strImg=_.attr(_.get("aShowPic"),"rel");
		    var ff=FloatFrame();
		    ff.src="/floatLayer/showBigImg.aspx?id=<%=id %>&type=caipu&selImg="+strImg;
		    ff.width="808";
		    ff.height="480";
		    ff.show();
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
        <a id="aShowPic" href="javascript:showBigImg()" rel="<%=GetURL.CaiPu.Pic(d.Eval("PicB")) %>"><img id="imgShowPic" src="<%=GetURL.CaiPu.Pic(d.Eval("PicB")) %>" width="379" height="284" alt="<%=d.Eval("ProName") %>" /></a>
        </div>
        <ul class="thumb">
        <asp:Repeater ID="rpPic" runat="server">
          <ItemTemplate>
            <li><a href="javascript:showPic('<%#GetURL.CaiPu.Pic(Eval("PicB")) %>')" ><img src="<%#GetURL.CaiPu.Pic(Eval("PicS")) %>" width="46" height="46" /></a></li>
          </ItemTemplate>
        </asp:Repeater>
        </ul>
      </div>
      <div class="wrap">
        <h3><%=d.Eval("ProName") %></h3>
       
        <ul class="Att-box1">
          <li>销售规格：<%=d.Eval("UnitNum").ToString() == "0.00" ? "" : d.Eval("UnitNum")%><%=d.Eval("Unit") %></li>
          <%--<li>库存数量：<%=d.Eval("StockN") %><%=d.Eval("Unit") %></li>--%>
        </ul>
        <div class="Att-box2">
          <ul>
          <li id="liAttr1" runat="server" visible="false"><img src="/images/item_detail/Label_01.gif" width="43" height="17" alt="菜篮子" /></li>
          <li id="liAttr2" runat="server" visible="false"><img src="/images/item_detail/Label_02.gif" width="43" height="17" alt="无公害" /></li>
          </ul>
        </div>
        
        <ul class="action">
          <li><strong>购买数量：</strong>
            <input id="cProN" name="cProN" type="text" size="5" class="Qinput" value="1" />
            <%=d.Eval("Unit") %></li>
          <li class="Joined2">
            <input name="" type="button" class="Joinedshop" onclick="ACart()" />
          </li>
          <li class="Joined"><a href="javascript:AddFav(<%=id %>,1)" class="Bookmark">添加到收藏夹</a></li>
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
        <div class="Recipes"> <a href="#relate" class="Green">不满意? 查看与<strong class="Red"><%=d.Eval("ProName") %></strong>相关的食谱</a> </div>
      </div>
      <div class="clear"></div>
    </div>
    <div class="dimPic">图片仅供参考，以商品实物为准。</div>
    <ul class="Attribute">
    <%=pageClassAttr.ToString() %>
    </ul>
    <div class="Including">
      	<div class="Including-text1">您可以选择购买单个或多个菜品</div>
        <div class="Including-main">
           <div class="def d_list4">
           		<div class="Including-Button"><span id="pathLower"></span></div>
                <ul id="cPPT" style="overflow:hidden;padding-top:10px">
                
<w:Item ID="rpChild" runat="server">
    <ItemTemplate>
        <li>
        <p style="padding-bottom:10px"><input name="cPro" type="checkbox" value="<%#Eval("ProSN") %>" /></p>
        <a href="<%#GetURL.Pro.Info(Eval("ProSN")) %>" target="_blank" class="d_img">
        <img src="<%#GetURL.Pro.Pic(Eval("PicS")) %>" width="74" height="65" alt="<%#Eval("ProName")%>" /></a>
        <p class="d_name"><a href="<%#GetURL.Pro.Info(Eval("ProSN")) %>" target="_blank"><%#Eval("ProName")%></a></p>
        <p class="d_price">￥63.00</p>
        </li>
    </ItemTemplate>
</w:Item>
                </ul>
                <div class="Including-Button"><span id="pathAdd"></span></div>
           </div>
           <div class="Including-right">
           		<br />
                <br />
                <p>
<script type="text/javascript">
	PPT3("cPPT",{path:1,b1:"pathAdd",b2:"pathLower",c1:["yes2","no2"],c2:["yes1","no1"]}).exe();
	
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
		
		if(sid.length>0)
		{
		    _.get('htm_msgAddCart').innerHTML='';
		    AddCart(sid,1,0);
		}
		else
		{
		    _.get('htm_msgAddCart').innerHTML='请选择菜品';
		}
	}
</script>
<input name="cljgm" type="button" class="sun" onclick="ljgm()" />
<div style="color:#f00" id="htm_msgAddCart"></div>

</p>
           </div>
        </div>
    </div>
    
    <!--教程-->
        <%
string detail1 = d.Eval("Detail1").ToString();
if (detail1.Length > 0)
{
   %>
    <div class="description">
      <h3></h3>
      <div class="border">
      <div class="Hot-main"><%=detail1%></div>
      </div>
    </div>
    <%} %>
    <!--特色-->
            <%
string detail2 = d.Eval("Detail2").ToString();
if (detail2.Length > 0)
{
   %>
    <div class="description">
      <h4></h4>
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
      <h1><a href="/search/relateCaiPu.aspx?id=<%=id %>&t=1" target="_blank">更多...</a></h1>
      <div class="border">
          <div class="list">
            <ul class="def d_list3">
    <w:cycle id="rpRelateCaiPu" runat="server" width="123" height="93" />
           
            </ul>
            <div class="clear"></div>
          </div>
      </div>
    </div>
    <%} %>

    <!--评价、咨询-->
    <div class="reviews">
      <div class="reviews-title"> <span><a href="/caiPu/msgList.aspx?id=<%=id%>" target="_blank">查看更多评论</a></span>
<a name="eval"></a>
        <ul id="commentMenu" class="ship-Appraisal" >
          <li><a href="javascript:;">用户评论</a></li>
          
        </ul>
      </div>
      <h3>用户的评价仅针对其所订购的订单，商品价格与网站活动都为即时更新，请用户结合实际情况作参考。</h3>

      <!--评论列表-->
<div id="comment" runat="server">
<w:Item ID="rpMsg" runat="server">
<ItemTemplate>
  <div class="comment">
   <div class="com-left">
    <p><%# Eval("UserName").ToString().Length == 0 ? "匿名" : Eval("UserName")%>：</p>
    <p class="com-txt"><%# Eval("Detail")%></p>
    <p class="com-Reply" <%#Eval("ReDetail").ToString().Length>0?"":"style=\"display:none\"" %>><span class="Reply"></span><%# Eval("ReDetail")%></p>
   </div>
   <div class="com-right">
    <p><%# Eval("AddDate")%></p>
   </div>
   <div class="clear"></div>
 </div>
 </ItemTemplate>
</w:Item>
</div>
<!-- end 评论列表-->

    </div>
    <div class="ship-twLeft">
      <div class="h4"></div>
      <div class="txaAddText">
        <textarea id="content" name="content" cols="" rows="">请输入内容。</textarea>
      </div>
      <div class="Sub-box">
        <div class="Sub">
        <span style="color:#f00; display:none" id="htm_evalMsg"></span>
        <input name="content" type="button" class="Subinput" onclick="evalSubmit()" />
<script type="text/javascript">
function ajaxPage(pCmd,pPageIndex)
{
    Ajax('<%=GetURL.CaiPu.Info(id) %>',{
	param:'hid=1&cmd='+pCmd+'&ajax_page='+pPageIndex,
	method:'post',
	fnSuccess:function(){
		_.get('comment').innerHTML=this.xmlHttp.responseText;
		
		_.get('eval').scrollIntoView();
		}
    }).exe();
}


function getMsg()
{
    ajaxPage('ajax_page_msg',1);
   
}

function msg_show(pName,pMsg)
{
    _.get(pName).style.display='';
    _.get(pName).innerHTML=pMsg;
}

var evalText=new setTextDef('content');

function evalSubmit()
{
	var obj=_.get('content');
	if((!obj.value) || evalText.old==obj.value)
	{
		msg_show('htm_evalMsg','请输入内容。');
		return ;
	}
	
	Ajax("/ajax/caiPuMsg.aspx?id=<%=id%>&t=1",{
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
					getMsg();
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
      </div>
    </div>
  </div>
  <div class="right">
    <div class="content-box">
      <h1></h1>
      <ul class="def d_list1">
<w:cycle id="rpSameClass" runat="server" width="147" height="100" target="" />

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