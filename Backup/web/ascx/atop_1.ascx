<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="atop_1.ascx.cs" Inherits="WZ.Web.ascx.atop_1" %>
	<!--site-nav-->
    <div class="site-nav">
            <p class="login-info">
             
            <span id="divNoLogin" runat="server">
            您好，欢迎使用搜菜网！
            <a class="red" href="/user/login.aspx">请登录</a> <a class="red" href="/user/reg.aspx">免费注册</a>
            </span>
            
            <span id="divLogin" runat="server">
            <a href="/user/center.aspx" class="red"><%=pageUserName %></a> 您好，欢迎回来！ 
            <%=noReadLetter%>
            <a href="/user/exit.aspx">退出</a>
            </span>
            </p>
            
            <ul class="quick-menu" >
                <li id="myBasket" class="myBasket">
                	<a class="green" href="/user/center.aspx">我的菜篮子</a>
                    <div id="myBasketDropDown" class="myBasket-dropDown">
                        <a href="/user/fav.aspx?t=0">我收藏的商品</a>
                        <a href="/user/orderList.aspx?t=ongoing">进行中的交易</a>
                    </div>
                </li>
                <li>
                	<a class="black" href="/user/cart.aspx">购物车</a>
                	<a class="black" href="/user/fav.aspx">收藏夹</a>
                </li>
                <li class="site-help">
                	<a class="black" href="/help/">帮助中心</a>
                </li>
            </ul>
            <script type="text/javascript">
				var T2=null;
            	_.get("myBasket").onmouseover=function(){clearTimeout(T2);this.className="myBasket sel";_.get("myBasketDropDown").style.display="block"}
				_.get("myBasket").onmouseout=function(){T2=setTimeout(_.bind(this,function(){this.className="myBasket";_.get("myBasketDropDown").style.display="none"}),500);}
            </script>
    </div>

	<!--logo search-->
    <div class="search-content">
    	<div class="logo"><a href="<%=GetURL.Default.Home() %>"><img src="/images/logo.gif" alt="欢迎访问搜菜网" /></a></div>
        <div class="search-wrap">
        	<p class="search-category" id="searchTab">
            	<a href="javascript:;"><span>商品</span></a>
                <a href="javascript:;"><span>食谱</span></a>
                <a href="javascript:;"><span>资讯</span></a>
            </p>
            <div>
            	<ul class="search-text">
                	<li class="search-bg search-bg-l"></li>
                    <li class="search-bg search-bg-m" >
                    
                            <input type="text" class="search-inp" name="kw" id="kw" maxlength="30" value="请输入商品名称" />
                            <div id="kwList" class="kwList"></div>
                            <input  type="button" class="search-bt" value="" id="btSearch" />
                    
                    </li>
                    <li class="search-bg search-bg-r"></li>
                </ul>
                <%--<p class="search-advanced"><a href="/search/advanced.aspx">高级搜索</a></p>--%>
            </div>
        </div>
        
    </div>
    <!--logo search End-->


	<!--导航-->
	<div class="channel" id="webMenu">
        <p class="channel-l"></p>
        <p class="channel-r"></p>
        
         <ul class="channel-content">
        	<li><a class="forum" href="/index.aspx">首页</a></li>
            <li id="proOrder">
            	<a class="forum" href="<%=GetURL.Default.Home() %>">菜品订购</a>
                <div class="channel-float">
                	<ul>
                    	<li class="channel-float-pro channel-float-pro-class"><a class="green">特别关注</a></li>
                        <li class="channel-float-pro channel-float-pro-activity"><a href="/pro/newList.aspx">新品上市</a></li>
                        <li class="channel-float-pro channel-float-pro-activity"><a href="/pro/salePromotionList.aspx">特价促销</a></li>
                        <li class="channel-float-pro channel-float-pro-activity"><a href="/pro/hotList.aspx">热卖商品</a></li>
                    </ul>
                    <ul>
                   		<li class="channel-float-pro"><a href="/category/product.aspx">菜品大全</a></li>
                        <li class="channel-float-pro"><a href="/basket/">菜篮子专区</a></li>
                        <li class="channel-float-pro"><a href="/caipu/">烹饪学堂</a></li>
                        <li class="channel-float-pro"><a href="/pro/team/">企业专区</a></li>
                    </ul>
                </div>
            </li>
            <li><a class="forum" href="javascript:void(0)">在线订餐</a></li>
            <li><a class="forum" href="javascript:void(0)">家宴预定</a></li>
            <li><a class="forum" href="javascript:void(0)">活动中心</a></li>
            <li><a class="forum" href="/news/1/">健康快报</a></li>
            <li><a class="forum" href="javascript:void(0)">论坛</a></li>
        </ul>
        <script type="text/javascript">
		var proOrder=_.get("proOrder");
        proOrder.onmouseover=function(){this.className="sel";_.getChild(this,1).style.display="block";}
		proOrder.onmouseout=function(){this.className="";_.getChild(this,1).style.display="none";}
        </script>        
      
            <ul class="channel-cart">
                <li class="channel-cart-l"></li>
                <li class="channel-cart-m" >
                    <ul>
                        <li class="cart-pic"></li>
                        <li id="showCart" class="cart-txt">
                        
                        <a href="/user/cart.aspx" class="cart-link">购物车有<span class="shop-N green" id="cartUserCount"></span>件商品</a>
                        
                        	<div id="cartMain" class="shop-main">
                                
                                <%--<dl>
                                    <dt><a href="#" target="_blank" class="products-pic2"><img src="/images/favicon.ico" width="40" height="35" alt="" /></a></dt>
                                    <dd><span class="Price">￥235.00元</span><a class="products-name" href="#" target="_blank">优质有机番茄死了都快放假了撒娇发来看减肥拉考四级发</a></dd>
                                    <dd><span class="Del"><a href="#" class="Blue">[删除]</a></span><span class="Quantity">数量：2</span></dd>
                                </dl>
                                <dl>
                                    <dt><a href="#" target="_blank" class="products-pic2"><img src="/images/favicon.ico" width="40" height="35" alt="" /></a></dt>
                                    <dd><span class="Price">￥235.00元</span><a href="#" target="_blank">优质有机番茄</a></dd>
                                    <dd><span class="Del"><a href="#" class="Blue">[删除]</a></span><span class="Quantity">数量：2</span></dd>
                                </dl>
                                <div class="Total">共<strong>1</strong>件商品   金额总计：<strong>￥1090.00</strong></div>
                                <a href="#" class="Exashop">去购物车并结算</a> --%>
                            </div>
                            
                        </li>
                        <li class="gap">|</li>
                        <li class="goBuy"><a href="/user/orderConfirm.aspx">去结算</a></li>
                    </ul>
                    <script type="text/javascript">
					var T=null;
                    _.get("showCart").onmouseover=function(){
                        clearTimeout(T);
                        _.get("cartMain").style.display="block";
                    }
					_.get("showCart").onmouseout=function(){T=setTimeout(function(){_.get("cartMain").style.display="none"},500);}
                    </script>
                   </li>
                <li class="channel-cart-r"></li>
            </ul>
    </div>
    <script type="text/javascript">
	function RealtimeUserCartInfo_Count(pCount)
	{
		if(pCount && (!isNaN(pCount)))
		{
			_.get('cartUserCount').innerHTML=pCount;
			return;
		}
		
		Ajax("/ajax/cartCount.ashx",{
		fnSuccess:function()
		{
			_.get('cartUserCount').innerHTML=this.xmlHttp.responseText;
		}
		}).exe();
	}
	
	function RealtimeUserCartInfo()
	{
	    Ajax("/ajax/cart.aspx",{
		fnSuccess:function()
		{
		    eval('var jso_cart='+this.xmlHttp.responseText);
		    if(jso_cart.cou)
		    {
		        RealtimeUserCartInfo_Count(jso_cart.cou);
		    }
		        
		    if(jso_cart.html)
		    {
		        _.get('cartMain').innerHTML=jso_cart.html;
		    }
		}
		}).exe();
	}
	RealtimeUserCartInfo();
    //setTimeout(RealtimeUserCartInfo,500);
    </script>
    <!--导航 End-->
  
<script type="text/javascript">var navIndex=<%=navIndex %></script>
<script type="text/javascript" src="/js/search.js"></script>

<script type="text/javascript">
W.init({pro:'<%=keyPro %>',caipu:'<%=keyCaiPu %>',news:'<%=keyNews %>'});
</script>