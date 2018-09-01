<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Default1.aspx.cs" Inherits="WZ.Web._Default1" Trace="false" %>
<%@ Import Namespace="WZ.Data" %>
<%@ Import Namespace="System.Data" %>
<%@ Register src="ascx/Pro_ClassIndex.ascx" tagname="Pro_ClassIndex" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>搜菜网</title>
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/font.css" rel="stylesheet" type="text/css" />
    <link href="css/home.css" rel="stylesheet" type="text/css" />
    <link href="css/header.css" rel="stylesheet" type="text/css" />
</head>
<body>
<w:ShowText ID="stst" runat="server"></w:ShowText>
<w:top id="ucTop" runat="server" /><%--<div id="yuhua"></div><input id="d" /><input id="asd" /> <div tabIndex="-1>sdfsdfsdf</div>--%>
<div class="wrapper">
  <div class="main">
    <div class="box-1">
      <!-- 第一部分 开始-->
      <div class="leftsidebar-wrap">
        <div class="leftsidebar">
          <div class="leftsidebar-border">
            <ul class="sidebar-column">
              <li><a id="sidebar" name="sidebar" href="#"><img src="images/index/leftsidebar_01.gif" width="179" height="29" alt="特价商品" /></a></li>
              <li><a id="sidebar" name="sidebar" href="#"><img src="images/index/leftsidebar_02.gif" width="179" height="29" alt="菜篮子" /></a></li>
            </ul>
            <ul class="sidebar-nav">
            <uc1:Pro_ClassIndex ID="ProClassIndex1" runat="server" />
            </ul>
          </div>
        </div>
        <div class="banner-03">
        
        <w:Adv_Info id="wAdv1" runat="server" Keyword="index_1" Attr="width='191' height='105'" />
        
        </div>
      </div>
      <div class="Module-1right">
        <div class="center">
          <div class="promo">
            <div class="container" id="idTransformView">
              <ul class="slider" id="idSlider">
              
              <w:Rep id="rpPPT" runat="server">
             	<itemtemplate>
                <li><a href="<%# Eval("AdvURL")%>" target="_blank"><img alt="<%# Eval("AdvName")%>" src="<%# GetURL.Adv.Pic(Eval("AdvImg"))%>" /></a></li>
                </itemtemplate>
              </w:Rep>
              </ul>
              
            </div>
            <ul class="num" id="idNum">
                <li>1</li>
                <li>2</li>
                <li>3</li>
              </ul>
          </div>
          <div class="Today-New">
            <h1></h1>
            <ul>
            <w:Pro_ListPic id="rpRecommend" runat="server" AttrPic="width='107' height='89'" />
            
             
            </ul>
          </div>
        </div>
        <div class="M1right-right">
          <div class="help-box">
            <div class="rc-tp"></div>
            <div class="help-guest"> <a href="/user/reg.aspx" class="help_top">免费注册<del>登录品质生活</del></a> <a href="/user/login.aspx" class="help_top">登录<del>开始搜菜之旅</del></a> </div>
            <div class="rc-bt"></div>
          </div>
          <div class="Announcement">
            <ul id="ulAnn" class="Ann-title">
              <li>搜菜公告</li>
              <li>活动通告</li>
            </ul>
            <!--公告-->
            <ul id="ulNotice" name="ulNotice" class="Ann-content">
            <w:Rep id="rpWebNotice" runat="server">
              <itemtemplate>
              <li><a href="#" target="_blank"><%# Eval("Title") %></a></li>
              </itemtemplate>
              </w:Rep>
            </ul>
            
            <!--通告-->
            <ul id="ulNotice" name="ulNotice" class="Ann-content hidden">
            <w:Rep id="rpWebActive" runat="server">
             	<itemtemplate>
              <li><a href="#" target="_blank"><%# Eval("Title") %></a></li>
              </itemtemplate>
              </w:Rep>
            </ul>
            
            <div class="Ann-bt"></div>
          </div>
          <div class="banner-04">
          <w:Adv_Info id="wAdv2" runat="server" Keyword="index_2" Attr="width='210' height='198'" />
          </div>
        </div>
      </div>
    </div>
    <!-- 第一部分 结束-->
    <div class="box-2">
      <!-- 第二部分 开始-->
      <div class="ph-wrap">
        <ul class="ph-h1">
          <li id="liPh" name="liPh"><b>本周热卖</b></li>
          <li id="liPh" name="liPh"><a href="#">今日热卖</a></li>
        </ul>
        <ul id="ulPh" name="ulPh" class="ph-main">
         <!--本周热卖-->
         <%
             int i = 0;
             foreach (DataRow drw in dtHotSell1.Rows)
             {
                 if (i == 0)
                 {
          %>
          <li class="ph-no1"> <a href="<%=GetURL.Pro.Info(drw["ProSN"])%>" target="_blank" class="ph-pic"><img src="<%= GetURL.Pro.Pic(drw["PicS"])%>" width="73" height="61" alt="" /></a> <a href="<%=GetURL.Pro.Info(drw["ProSN"])%>" target="_blank" class="ph-Name"><%=drw["ProName"]%></a> <span>￥<%= drw["Price"]%>元</span>
          </li>
          
           <% }else {%>
           <li><span>￥<%=drw["price"]%>元</span><a href="<%=GetURL.Pro.Info(drw["ProSN"])%>" target="_blank" class="ph-Name2"><%=drw["ProName"]%></a></li>
                 
            <%}
                 i++;
             }
         %>
          
        </ul>
        
        <ul id="ulPh" name="ulPh" class="ph-main hidden">
        <!--今日热卖-->
          <%
             i = 0;
             foreach (DataRow drw in dtHotSell2.Rows)
             {
                 if (i == 0)
                 {
          %>
          <li class="ph-no1"> <a href="<%=GetURL.Pro.Info(drw["ProSN"])%>" target="_blank" class="ph-pic"><img src="<%= GetURL.Pro.Pic(drw["PicS"])%>" width="73" height="61" alt="" /></a> <a href="<%=GetURL.Pro.Info(drw["ProSN"])%>" target="_blank" class="ph-Name"><%=drw["ProName"]%></a> <span>￥<%= drw["Price"]%>元</span>
          </li>
          
           <% }else {%>
           <li><span>￥<%=drw["price"]%>元</span><a href="<%=GetURL.Pro.Info(drw["ProSN"])%>" target="_blank" class="ph-Name2"><%=drw["ProName"]%></a></li>
                 
            <%}
                 i++; 
             }    
         %>
         </ul>
         
      </div>
      <div class="Hot-wrap">
        <h1>热门商品</h1>
        <div class="Hot-main">
          <div class="Hot-left"><a href="#" target="_blank"><img src="images/banner_01.gif" width="144" height="205" alt="广告" /></a></div>
          <div class="Hot-right">
            <ul class="Hot-products">
            
            <w:Pro_ListPic id="rpHot" runat="server" AttrPic="width='107' height='89'" />
            
            
              
              
            </ul>
            <ul class="Writing-box1">
              <li><a href="#" target="_blank">文字内容文字内容文字内容....</a></li>
              <li><a href="#" target="_blank">文字内容文字内容文字内容....</a></li>
              <li><a href="#" target="_blank">文字内容文字内容文字内容....</a></li>
            </ul>
            <ul class="Writing-box1">
              <li><a href="#" target="_blank">文字内容文字内容文字内容....</a></li>
              <li><a href="#" target="_blank">文字内容文字内容文字内容....</a></li>
              <li><a href="#" target="_blank">文字内容文字内容文字内容....</a></li>
            </ul>
          </div>
          <div class="clear"></div>
        </div>
      </div>
      <div class="banner-01">
      <w:Adv_Info id="wAdv6" runat="server" Keyword="index_6" Attr="width='749' height='64'" />
     
      </div>
    </div>
    <!-- 第二部分 结束-->
    <div class="box-3">
      <!-- 大分类 开始-->
      <h1><span><a href="<%=GetURL.Pro.Class(2)%>" target="_blank">更多..</a></span><strong><%=GetClassName(2)%></strong>所属分类：
      <w:Rep id="rpClass1" runat="server">
          <itemtemplate>
      <a href="<%# GetURL.Pro.Class(Eval("ClassSN"))%>" target="_blank" class="Gray"><%# Eval("ClassName")%></a>
       </itemtemplate>
      </w:Rep>
      </h1>
      <div class="class-main">
        <div class="class-left"> 
        <w:Adv_Info id="wAdvLeft1" runat="server" Keyword="index_class_left_1" Attr="width='217' height='298'" />
        </div>
        <ul class="calss-center">
        
        <w:Pro_ListPic id="rpClassPro1" runat="server" AttrPic="width='107' height='89'" />
        
        
          
        </ul>
        <div class="calss-right">
          <ul>
          
          <w:Help_Info id="Help_Info1" runat="server" ClassID="105" Top="8" />
            
          </ul>
          <div class="banner-02">
          <w:Adv_Info id="wAdv3" runat="server" Keyword="index_3" Attr="width='187' height='120'" />
          
          </div>
        </div>
        <div class="clear"></div>
      </div>
    </div>
    <!-- 大分类 结束-->
    <div class="box-3">
      <!-- 大分类 开始-->
      <h1><span><a href="<%=GetURL.Pro.Class(1)%>" target="_blank">更多..</a></span><strong><%=GetClassName(1)%></strong>所属分类：
      <w:Rep id="rpClass2" runat="server">
          <itemtemplate>
      <a href="<%# GetURL.Pro.Class(Eval("ClassSN"))%>" target="_blank" class="Gray"><%# Eval("ClassName")%></a>
       </itemtemplate>
      </w:Rep>
      </h1>
      <div class="class-main">
        <div class="class-left"> 
        <w:Adv_Info id="wAdvLeft2" runat="server" Keyword="index_class_left_2" Attr="width='217' height='298'" />
        </div>
        <ul class="calss-center">
        <w:Pro_ListPic id="rpClassPro2" runat="server" AttrPic="width='107' height='89'" />
          
        </ul>
        <div class="calss-right">
          <ul>
            <w:Help_Info id="Help_Info2" runat="server" ClassID="106" Top="8" />
          </ul>
          <div class="banner-02">
          <w:Adv_Info id="wAdv4" runat="server" Keyword="index_4" Attr="width='187' height='120'" />
          </div>
        </div>
        <div class="clear"></div>
      </div>
    </div>
    <!-- 大分类 结束-->
    <div class="box-3">
      <!-- 大分类 开始-->
      <h1><span><a href="<%=GetURL.Pro.Class(19)%>" target="_blank">更多..</a></span><strong><%=GetClassName(19)%></strong>所属分类：
      <w:Rep id="rpClass3" runat="server">
          <itemtemplate>
      <a href="<%# GetURL.Pro.Class(Eval("ClassSN"))%>" target="_blank" class="Gray"><%# Eval("ClassName")%></a>
       </itemtemplate>
      </w:Rep>
      
      </h1>
      <div class="class-main">
        <div class="class-left"> 
        <w:Adv_Info id="wAdvLeft3" runat="server" Keyword="index_class_left_3" Attr="width='217' height='298'" />
        </div>
        <ul class="calss-center">
        
        <w:Pro_ListPic id="rpClassPro3" runat="server" AttrPic="width='107' height='89'" />
          
        </ul>
        <div class="calss-right">
          <ul>
            <w:Help_Info id="Help_Info3" runat="server" ClassID="107" Top="8" />
          </ul>
          <div class="banner-02">
          <w:Adv_Info id="wAdv5" runat="server" Keyword="index_5" Attr="width='187' height='120'" />
          </div>
        </div>
        <div class="clear"></div>
      </div>
    </div>
    <!-- 大分类 结束-->
    <div class="box-4">
      <!-- 健康快报、论坛热帖 开始-->
      <div class="news-box">
        <h1><span><a href="#" target="_blank">更多...</a></span>健康快报</h1>
        <div class="news-main">
          <div class="news-top">
            <div class="pic"> <a href="#" target="_blank"> <img src="images/index/pic_01.gif" width="153" height="93" alt="" /> <span>11个能减肥的饮食小技巧</span> </a> </div>
            <div class="txt">
              <h3><span class="news-span"></span><a href="#" target="_blank">千万注意!街边的美食却深藏剧毒</a></h3>
              <ul>
                <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行 看哪家辣...</a></li>
                <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行 看哪家辣...</a></li>
                <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行 看哪家辣...</a></li>
                <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行 看哪家辣...</a></li>
              </ul>
            </div>
          </div>
          <ul class="news-bottom">
            <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
            <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
            <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
            <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
          </ul>
        </div>
      </div>
      <div class="bbs-box">
        <h1><span><a href="#" target="_blank">更多...</a></span>论坛热帖</h1>
        <div class="news-main">
          <div class="news-top">
            <div class="pic"> <a href="#" target="_blank"><img src="images/index/pic_01.gif" width="153" height="93" alt="" /><span>11个能减肥的饮食小技巧</span> </a> </div>
            <div class="txt">
              <h3><span class="bbs-span"></span><a href="#" target="_blank">千万注意!街边的美食却深藏剧毒</a></h3>
              <ul>
                <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行 看哪家辣...</a></li>
                <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行 看哪家辣...</a></li>
                <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行 看哪家辣...</a></li>
                <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行 看哪家辣...</a></li>
              </ul>
            </div>
          </div>
          <ul class="news-bottom">
            <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
            <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
            <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
            <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
          </ul>
        </div>
      </div>
    </div>
    <!-- 健康快报、论坛热帖 结束-->
  </div>
  <div class="helpIntro">
    <!-- 帮助介绍 开始-->
    <div class="Tel"></div>
    <div class="help">
      <ul>
      	<w:Help_Info id="wHelp" runat="server" ClassID="100" Top="7" />
      </ul>
      <ul>
        <w:Help_Info id="wHelp1" runat="server" ClassID="101" Top="7" />
      </ul>
      <ul>
       <w:Help_Info id="wHelp2" runat="server" ClassID="102" Top="7" />
      </ul>
      <ul>
        <w:Help_Info id="wHelp3" runat="server" ClassID="103" Top="7" />
      </ul>
      <ul class="helpAbout">
        <w:Help_Info id="wHelp4" runat="server" ClassID="104" Top="7" />
      </ul>
    </div>
    <div class="clear"></div>
  </div>
  <div class="links">
    <h4>友情链接：</h4>
    <ul>
    <w:links ID="ucLinks1" runat="server" />
      <w:links ID="ucLinks2" runat="server" LinksType="0" ShowLocal="1" ShowType="1" />
    </ul>
  </div>
  
</div>
<w:bottom id="ucBottom" runat="server" />

</body>
<script type="text/javascript" src="js/Ajax.js"></script>
<script type="text/javascript" src="js/DataAjax.js"></script>

<script type="text/javascript" src="js/ui.FloatDivPos.js"></script>

<script type="text/javascript" src="js/ui.tab.js"></script>
<script type="text/javascript" src="js/ui.tabMove.js"></script>
<script type="text/javascript">

//document.getElementById("asd").onblur=function(e){

//document.getElementById("yuhua").innerHTML+="2";

////    if(e.explicitOriginalTarget)
////        document.getElementById("yuhua").innerHTML=e.explicitOriginalTarget.parentNode.tagName;
////    if(document.activeElement)
//        document.getElementById("yuhua").innerHTML=document.activeElement.tagName;

//    //document.getElementById("yuhua").innerHTML=document.activeElement.innerHTML
////    alert(e.explicitOriginalTarget.parentNode.tagName)
////    if(e)   document.getElementById("yuhua").innerHTML=e.explicitOriginalTarget.innerHTML

//}




window.onload=function()
{
    //PPT幻灯片
    var aTag=document.getElementById("idNum").getElementsByTagName("li");
    var aDiv=document.getElementById("idSlider").getElementsByTagName("li");
    var view=document.getElementById("idTransformView");
    var objMove=new TabMove({a:aTag,div:aDiv,display:view,overCss:"on"});
    objMove.exe();
    
    //公告   通知
    var oAnn=document.getElementById("ulAnn");
    var aAnn=oAnn.getElementsByTagName("li");
    var ulNotice=document.getElementsByName("ulNotice");
    aAnn[0].onmouseover=function()
    {
        oAnn.style.backgroundPosition="";
        ulNotice[0].style.display="block";
        ulNotice[1].style.display="none";
    }
    aAnn[1].onmouseover=function()
    {
        oAnn.style.backgroundPosition="0px -23px";
        ulNotice[0].style.display="none";
        ulNotice[1].style.display="block";
    }
    //本周热卖 今日热卖
    var aLiPh=document.getElementsByName("liPh");
    var aUlPh=document.getElementsByName("ulPh");
    var tabPh=new Tab({a:aLiPh,div:aUlPh,overCss:"over",outCss:"out"});
    tabPh.exe();
    
    //特价商品  菜篮子
    var aSidebar=document.getElementsByName("sidebar");
    var aUrl=["/control/default1.aspx","/control/default1.aspx"];//路径  和aSidebar  对应
    
    var floatDivPos=new FloatDivPos({obj:aSidebar[0],width:100,height:100,diffX:200,diffY:0});
    
    floatDivPos.div.onmouseover=function(){this.style.display="block"}
    floatDivPos.div.onmouseout=function(){this.style.display="none"}
    
    var dataAjax=new DataAjax();
    
    for(var i=0;i<aSidebar.length;i++)
    {
	    aSidebar[i].onmouseover=function(i)
	    {
	        return function()
	        {
	            dataAjax.url=aUrl[i];
		        dataAjax.fn=function()
		        {
		            floatDivPos.content=arguments[0];
			        floatDivPos.show();
		        };
		        dataAjax.getData(i);
	        }
	    }(i);
	    aSidebar[i].onmouseout=function()
	    {
		    floatDivPos.hidden();
	    }
    }
}
</script>
</html>
