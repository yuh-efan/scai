<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WZ.Web._default" Trace="false" %>
<%@ Register src="~/ascx/homeProClass.ascx" tagname="homeProClass" tagprefix="uc1" %>
<%@ Register src="~/ascx/homeOrderProSell.ascx" tagname="homeOrderProSell" tagprefix="uc1" %>
<%@ Register src="~/ascx/top1.ascx" tagname="top1" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>搜菜网</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/style/index.css" rel="stylesheet" type="text/css" />
    <link href="/style/modBot.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="/images/favicon.ico" />
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    
    <script type="text/javascript" src="js/ui.ppt100.js"></script>
    <script type="text/javascript" src="/js/ui.marquee2.js"></script>
    <script type="text/javascript" src="/js/xcookie.js"></script>
</head>
<body>
<uc1:top1 id="ucTop" runat="server" />

<div class="content">
    
	<div class="content-one">
    	<!--分类-->
    	<div class="category">
            <div class="category-c">
            	<p class="category-t"><a href="#"><img src="images/category-title.gif"/></a></p>
                <ul id="categoryList">
                	<uc1:homeProClass ID="HomeProClass1" runat="server" />
                </ul>
                <script type="text/javascript">
                var swap={
					list:"categoryList",
					oldObj:null,
					//timeover:null,
					timeout:null,
					show:function(obj){
						obj.className="sel";
						_.getChild(obj,1).style.display="block";
					},
					hidden:function(obj){
						obj.className="";
						_.getChild(obj,1).style.display="none";

					},
					init:function(){
						var arr=_.getChild(swap.list);
						
						for(var i=0;i<arr.length;i++){
							arr[i].onmouseover=function(){
								swap.show(this);
							};
							arr[i].onmouseout=function(){
								swap.hidden(this);
							};
						}
						
					}
					/*init:function(){
						var arr=_.getChild(swap.list);
						
						for(var i=0;i<arr.length;i++){
							arr[i].onmouseover=function(){
								if(swap.timeout)
								{
									clearTimeout(swap.timeout);
									if(swap.oldObj)
										swap.hidden(swap.oldObj);
								}
								swap.oldObj=this;
								swap.show(this);
							};
							arr[i].onmouseout=function(){
								swap.timeout=setTimeout(_.bind(this,function(){swap.hidden(this)}),500)
							};
						}
						
					}*/
					
				}
				swap.init();
                </script>
                
            </div>
            <div class="category-pos"></div>
        </div>        
        <div class="content-one-c">
        	<div class="content-one-main">
            	<!--幻灯片-->
            	<div class="content-one-slide">
            	<w:ppt2 ID="ucPPT1" runat="server" Str="home" ImgAttr='width="550" height="330"' Prefix="ppt1_" Top="4" />
            	</div>
                
                <!--秒杀-->
                <div class="today-spike">
                	<p class="today-spike-title"></p>
                    <ul class="def-list today-spike-pro">
                    <w:cycleText id="rpProMS" runat="server" />
<script type="text/javascript">
var TO={
    loop:null,
    startN:0,
    endN:0,
    startTime:null,
    endTime:null,
    showObj:{d:"d",h:"h",m:"m",s:"s"},
    fnSuccess:function(){},
    init:function(startS,endS,obj)
    {
        TO.startN=Date.parse(startS.replace(/-/g,"/"));
        TO.endN=Date.parse(endS.replace(/-/g,"/"));
        
        TO.startTime=new Date(TO.startN);
        TO.endTime=new Date(TO.endN);
        if (obj)
            TO.showObj=obj;           
    },
    handle:function()
    {
        TO.startN+=1000;
        TO.show();
    },
    show:function()
    {
        TO.startTime=new Date(TO.startN);
        var nMS=TO.endTime-TO.startTime;
        if(nMS<0)
        {
            clearInterval(TO.loop);
            //时间到处理程序
            TO.fnSuccess();
            return;
        }
        var tt={
            d:Math.floor(nMS/(1000 * 60 * 60 * 24)),
            h:Math.floor(nMS/(1000 * 60 * 60)) % 24,
            m:Math.floor(nMS/(1000*60)) % 60,
            s:Math.floor(nMS/1000) % 60
        }
        if(!_.get(TO.showObj.d))
        {
            tt.h=tt.h+(24*tt.d)
        }
        for(var obj in TO.showObj)
        {
            var o=_.get(TO.showObj[obj]);
            if(o)
                o.innerHTML=tt[obj];
        }
    },
    exe:function()
    {
		TO.handle();
        TO.loop=setInterval(TO.handle,1000);
    }
}

if(_.get("str"))
{
var str=_.get("str").innerHTML;
var str2=_.get("str2").innerHTML;

TO.init(str,str2);
TO.exe();
TO.fnSuccess=function(){}
}
</script>
                    </ul>
                </div>
            </div>
        
            <!--公告-->
            <div class="content-bulletin">
                <ul class="white" id="webgg">
                    <w:cycleLink id="rpNotice" runat="server" />
                </ul>
            <script type="text/javascript">
                Marquee2("webgg",{path:"up",outSpeed:3500}).exe();
            </script>
            
                <p class="white"><a href="/search/news.aspx?s=--8">全部公告</a></p>
            </div>
            <!--招商-->
            <div class="merchants">
            <w:WebInfo ID="webInfo4" runat="server" Str="home_5"></w:WebInfo>
            </div>
        
        </div>
    </div>
    
    <div class="content-pro">
    	<div class="content-pro-col">
        	
        	<div class="content-pro-one">
                <!--新品推荐-->
            	<div class="left pro-one-c">
                	<div class="pro-new-title"></div>
                    <div class="pro-one-main">
                    	<div class="left" >
                    	<w:WebInfo ID="webInfo" runat="server" Str="home_1"></w:WebInfo>
                    	</div>

                        <ul class="def-list pro-one-list" >
                        
                        <w:cycle id="rpZuiXinTJ" runat="server" width="103" height="72" />
                        
                            
                            
                        </ul>
                    </div>
                </div>
                <!--促销抢购-->
            	<div class="right pro-one-c">
                	<div class="pro-promotions-title"></div>
                    <div class="pro-one-main">
                    	<div class="left" >
                    	<w:WebInfo ID="webInfo1" runat="server" Str="home_2"></w:WebInfo>
                    	</div>

                        <ul class="def-list pro-one-list" >
                        <w:cycle id="rpProCX" runat="server" width="103" height="72" />
                        </ul>
                    </div>
                </div>
        	</div>
            <!--食全食美-->
            <div class="content-food">
        		<div class="food-title">
                	<div class="food-category">
                    	<span class="red">分类：</span>
                        <w:cycleText id="rpCaiPuClass" runat="server" />
                       
                    </div>
                    <div class="food-more"><a href="/caiPu/">更多..</a></div>
                </div>
                <div class="food-main">
                	<div class="left" >
                	<w:WebInfo ID="webInfo2" runat="server" Str="home_3"></w:WebInfo>
                	
                	</div>
                    <ul class="def-list food-list" >
                    	<w:cycle id="rpCaiPuHome" runat="server" width="154" height="104" />
                    </ul>
                </div>
        	</div>
             <!--生鲜食品-->
            <div class="content-food food-fresh">
        		<div class="food-title">
                	<div class="food-category">
                    	<span class="red">分类：</span>
                        <w:cycleText id="rpProClass" runat="server" />
                    </div>
                    <div class="food-more"><a href="/basket/">更多..</a></div>
                </div>
                <div class="food-main">
                	<div class="left">
                	<w:WebInfo ID="webInfo3" runat="server" Str="home_4"></w:WebInfo>
                	</div>
                    <ul class="def-list fresh-list">
                    	<w:cycle id="rpProHome" runat="server" width="154" height="104" />
                    	
                    </ul>
                </div>
                
        	</div>
            
        </div>
        <!--右边栏-->
        <div class="content-sidebar">
        	<!--热卖排行榜-->
        	<div class="hot-rank">
            	<ul class="def-list hot-rank-list">
            	
            	<w:cycle id="rpHotSell" runat="server" width="76" height="50" />
                  
                </ul>
            </div>
            <!--广告-->
            <div class="sidebar-adv">
            <w:WebInfo ID="webInfo5" runat="server" Str="home_right_1"></w:WebInfo>
            
            </div>
            
            <div class="sidebar-ASN">
            </div>
            <!--发货通知-->
            
            <ul id="userNewBuy" class="ASN-list">
            <w:cycleText id="cyRealTimeBuy" runat="server" />
            </ul>
            <script type="text/javascript">
                Marquee2("userNewBuy",{path:"up",outSpeed:3500}).exe();
            </script>
           
           <!--广告-->
            <div class="sidebar-adv-two">
            <w:WebInfo ID="webInfo6" runat="server" Str="home_right_2"></w:WebInfo>
            </div>
            
            <!--健康快报-->
			<div class="plate">
            	<div class="plate-head health">
                    <div class="plate-more"><a href="/news/1/">更多</a></div>
                </div>
                <div class="plate-c">
                	<div class="plate-c-m">
                	
                	<w:cycleText ID="rpNewsPic" runat="server" />
                	
                    	
                        
                    </div>
                    <div class="plate-c-list">
                    	<ul>
                    	<w:cycleLink ID="rpNewsTJ" runat="server" />
                        </ul>
                    </div>
                </div>
            </div>
            
            
            <!--论坛热帖-->
			<div class="plate">
            	<div class="plate-head forum">
                    <div class="plate-more"><a href="#">更多</a></div>
                </div>
                <div class="plate-c">
                	<div class="plate-c-m">
                    	<div class="left">
                        	<a href=""><img width="81" height="79" src="images/sidebar-head.png"/></a>
                        </div>
                        <div class="right">
                        	<dl class="plate-top">
                            	<dt><a class="red" href="#">街边的美思科京东方科技斯蒂芬可接受的克里夫食</a></dt>
                                <dd>6.1但莫非是的疯狂反斯蒂芬士思科家乐福大夫士大夫实弹发射斯蒂芬师傅</dd>
                            </dl>
                        </div>
                    </div>
                    <div class="plate-c-list">
                    	<ul>
                        	<li><a href="#">网友推荐最正宗川菜馆网友推荐最正宗川菜馆</a></li>
                            <li><a href="#">网友推荐最正宗川菜馆网友推荐最正宗川菜馆</a></li>
                            <li><a href="#">网友推荐最正宗川菜馆网友推荐最正宗川菜馆</a></li>
                        </ul>
                    </div>
                </div>
            </div>       
            
            
            
        </div>
    </div>
</div>




<w:bottom1 id="bottom1" runat="server" />
<script type="text/javascript" src="/js/ui.floatDivMove.js"></script>

<script type="text/javascript">
new FloatDivMove({width:35,height:180,content:"<a href=\"javascript:floatLayer.src='/floatLayer/survey.aspx';floatLayer.show();\"><img src='/images/survey/survey_01.gif' /></a><a href='#'><img src='/images/survey/survey_02.gif' /></a>"}).show();</script>
</body>
</html>
