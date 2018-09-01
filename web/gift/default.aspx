<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WZ.Web.gift._default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>礼品兑换</title>
<w:header id="header" runat="server"></w:header>
<script type="text/javascript" src="/js/ui.floatFrame.js"></script>
<script type="text/javascript" src="/js/pub.js"></script>
<script type="text/javascript" src="/js/ui.ppt.js"></script>

<style type="text/css">
.steps{ height:56px; background:url(../images/gift/steps.gif) no-repeat;margin-bottom:6px}
.steps ul{padding-top:29px; position:relative}
.steps ul li{ float:left; position:absolute;}
.steps ul li.step-one{left:271px}
.steps ul li.step-two{left:500px}
.steps ul li.step-three{left:764px}

.plate{border:solid 1px #ccc; margin-bottom:6px}
	.plate-head{height:31px; line-height:31px; border-bottom:solid 1px #ccc; background-color:#f5f5f5; padding:0 10px}

.gift-main{overflow:hidden; width:100%;margin-bottom:25px}
	.mainContent{float:left; width:738px;}
		/*幻灯片*/
		.ppt{margin-bottom:6px;}
			.ppt-pic ul{height:225px;overflow:hidden;}
			.ppt-trigger{padding-left:2px;background:url(../images/gift/trigger-bg.gif) repeat-x; }
			.ppt-trigger ul{width:100%; overflow:hidden;  }
			.ppt-trigger ul li{ float:left;padding:4px 6px 4px 2px; text-align:center;width:139px; background:url(../images/gift/trigger-gap.gif) no-repeat right 0; height:27px;}
			.ppt-trigger ul li a{display:block;line-height:27px;width:100%}
			.ppt-trigger ul li.sel a{color:#ceeccc;background:url(../images/gift/trigger-bt-bg.gif) no-repeat}

		
		/*兑换奖品*/
		.pro-list ul{width:100%; overflow:hidden;padding-bottom:10px;}
		.pro-list li{background-color:#eef1f6;padding:10px; margin:10px 0 0px 10px; display:inline}
		.pro-list .d-left-img{padding-left:3px}
		.pro-list .d-left-content{padding:5px 0 0 0;width:105px;}
		.pro-list .d-name{font-size:14px; font-weight:bold; height:auto}
		.pro-list .d-price2{padding-top:5px}
		.pro-list .d-price2 span{ font-size:12px; font-weight:bold;}
		
		
		
	/*边栏*/
	.sidebar{float:right; width:235px;}
		/*用户信息*/
		.userInfo{ border:solid 2px #62c711;padding:0 10px; margin-bottom:6px}
			.gift-img-r,.gift-txt,.account-bt-r,.account-txt,.userInfo-help li{background:url(../images/gift/userInfo-main.png) no-repeat;}
		
			.userInfo-main{ border-bottom:solid 1px #ccc;padding:10px}
				.no-login{ padding-top:10px; text-align:center; color:#cc0000}
				.login-bt{ text-align:center;padding:20px 0 4px 0}
				.login-bt a img{ }
			
				.userInfo-name{padding-bottom:5px}
				
				.gift-img{background-color:#0CC;height:25px; background:url(../images/gift/curr-points-bg.gif) repeat-x; margin-top:10px}
					.gift-img-r{ background-position:right -58px;line-height:25px}
						.gift-txt{text-indent:45px}
						.gift-txt span{ font-weight:bold}
					.consume{ background-position:0 -30px}
					
				.userInfo-account{padding:20px 0 10px 15px; }
					.account-bt{width:160px; height:27px; background:url(../images/gift/account-bg.gif) repeat-x;}
						.account-bt-r{background-position:right -124px; line-height:27px;}
							.account-txt{background-position:0 -89px;text-align:center}
			.userInfo-help{padding:3px 0 10px 0}
			.userInfo-help li{line-height:17px; background-position:0 -157px; padding-left:25px; margin-top:7px}
			
			.gift-get{padding:15px 10px 0 10px;}
			.gift-get ul{width:100%; overflow:hidden; border-bottom:dashed 1px #ccc;padding-bottom:10px}
			.gift-get li{width:100px; line-height:2em; height:2em; overflow:hidden; float:left; padding:0 3px;}
			.gift-get li a{color:#1865b7;}
			.gift-get li a:hover{color:#26a61d;}
			
			
			
			.gift-shop{padding:15px 0 15px 16px;}
				.gift-shop-txt{ width:170px; text-align:left; background:url(../images/gift/gift-cart.gif) no-repeat; padding-left:25px}
				
			.gift-buy{background:url(../images/gift/gift-buy.gif) no-repeat;margin:10px; padding-left:45px}
			.gift-buy ul{height:82px; overflow:hidden;}
			.gift-buy ul li{height:3em; width:100%; overflow:hidden;padding-top:5px;}
			
			.new-exchange{padding:5px 0 8px 6px;}
			.new-exchange ul{width:220px; text-align:left}
			.new-exchange ul li{background:url(../images/gift/point-list.gif) no-repeat 0 11px; padding:3px 0 0 10px;}
			.new-exchange ul li span{color:#1865b7}
			
			.adv{width:235px; height:89px; overflow:hidden;}
</style>
<script type="text/javascript">
function Gift(pID)
{
    floatLayer.src="/floatLayer/gift.aspx?id="+pID
    floatLayer.show();
}

function ajaxPage(pCmd,pPageIndex)
{
    Ajax('<%=Request.Url %>',{
	param:'hid=1&cmd='+pCmd+'&ajax_page='+pPageIndex,
	method:'post',
	fnSuccess:function(){
		_.get('htm_giftlist').innerHTML=this.xmlHttp.responseText;
		_.get('anchlr_1').scrollIntoView();
		}
    }).exe();
}
</script>
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 礼品兑换" /></div>

<div class="content">
	<div class="steps">
    	<ul>
        	<li class="step-one">登录搜菜网选购商品</li>
            <li class="step-two">选择商品购买和评论</li>
            <li class="step-three">交易完成获得积分，积分免费换礼品</li>
        </ul>
    </div>
    
    <div class="gift-main">
        <div class="mainContent">
        	<!--幻灯片-->
          <w:ppt3 ID="ucPPT1" runat="server" Str="gift" ImgAttr='width="738" height="225"' Prefix="ppt" />
            <a id="anchlr_1"></a>
            <div class="plate">
            	<div class="plate-head">
                	<div class="left"><img src="../images/gift/gift-exchange.gif" width="73"  height="31" /></div>
                	
                </div>
                <div class="def pro-list" id="htm_giftlist" runat="server">
                	<ul>
                	
<asp:Repeater ID="rpList" runat="server">
<ItemTemplate>
<li>
	<div class="d-left-content">
    	<div class="d-name"><a href="javascript:;" onclick="Gift(<%#Eval("GiftSN") %>)"><%#Eval("GiftName") %></a></div>
        <div class="d-price2">消耗<span><%#Eval("Integral")%></span>积分</div>
    </div>
    <div class="d-left-img">
    	<a class="d-pic" href="javascript:;" onclick="Gift(<%#Eval("GiftSN") %>)"><img width="100" height="75" src="<%#GetURL.Gift.Pic(Eval("PicS"))%>" alt="<%#Eval("GiftName") %>" /></a>
    </div>
</li>
</ItemTemplate>
</asp:Repeater>
                    </ul>
                    <div class="paging">
      <w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" Style="ajax_style_1" />
</div>
                </div>
                
            </div>
        </div>
        
        <div class="sidebar">
        	<!--用户信息-->
        	<div class="userInfo">
            	<div class="userInfo-main" id="login1" runat="server">
                	<div class="userInfo-name"><span class="red">欢迎您，<%=page_UserName%></span></div>
                    
                    <div class="gift-img">
                    	<div class="gift-img-r">
                        	<div class="gift-txt">现有积分：<span><%=page_UserIntegral %></span></div>
                        </div>
                    </div>
                    <div class="gift-img">
                    	<div class="gift-img-r">
                        	<div class="gift-txt consume">已消耗积分：<span><%=page_UserConsumeIntegral %></span></div>
                        </div>
                    </div>
                    
                    <div class="userInfo-account">
                    	<div class="account-bt">
                        	<div class="account-bt-r">
                            	<div class="account-txt"><a href="/user/detailIntegral.aspx">查看我的帐户积分明细</a></div>
                            </div>
                        </div>
                    </div>
                    
                </div>
                
                
                <div class="userInfo-main" id="login2" runat="server">
                	<div class="no-login">欢迎来到兑换中心，您还未登录</div>
                    
                    <div class="login-bt"><a href="javascript:;" onclick="floatLayer.src='/floatLayer/login.aspx?success_target=1';floatLayer.show();"><img src="../images/gift/login-bt.gif" width="152"  height="41"/></a></div>
                    
                    <div class="userInfo-account">
                    	<div class="account-bt">
                        	<div class="account-bt-r">
                            	<div class="account-txt"><a href="/user/reg.aspx">还没有账号？立即注册</a></div>
                            </div>
                        </div>
                    </div>
                    
                </div>
                
                <div class="userInfo-help">
                	<ul>
                    	<li><a href="#">什么是搜菜网帐户积分？</a></li>
                        <li><a href="#">积分有哪些作用？</a></li>
                        <li><a href="#">如何才能获得积分？</a></li>
                    </ul>
                </div>
                
            </div>
            <!--快速挣取积分-->
            <div class="plate">
                <div class="plate-head">
                    <img src="../images/gift/getGift.gif" width="100" height="27"/>
                </div>
                <div class="gift-get">
                    <ul>
                        <li><a href="#">会员推广赚积分</a></li>
                        <li><a href="#">参与活动赚积分</a></li>
                        <li><a href="#">发表评论赚积分</a></li>
                        <li><a href="#">购物订餐返积分</a></li>
                    </ul>
                </div>
                <div class="gift-shop">
                    <div class="gift-shop-txt"><a href="#">实惠购物，轻松赚积分</a></div>
                </div>
            </div>
            <!--积分获得信息-->
            <div class="plate">
                <div class="gift-buy">
                    <ul>
                    <w:cycleText ID="rpBuyProLog" runat="server" />
                    </ul>
                </div>
            </div>
            <!--最新兑换-->
            <div class="plate">
            	<div class="plate-head">
                	<div class="left"><img src="../images/gift/new-exchange.gif" width="73"  height="30" /></div>
                </div>
                <div class="new-exchange">
                	<ul>
                    <w:cycleText ID="rpExchange" runat="server" />
                    </ul>
                </div>
            </div>
            <!--广告-->
            <div class="adv">
            	<w:WebInfo ID="webInfo1" runat="server" Str="gift_home_right_1"></w:WebInfo>
            </div>
        </div>
    </div>
</div>
<w:bottom id="ucBottom" runat="server" />

</body>
</html>
