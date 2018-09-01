<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bottom1.ascx.cs" Inherits="WZ.Web.ascx.bottom1" %>

<div class="mod-bot">
	<div class="footer bot-bg">
    	<div class="layout marBot">
        	<div class="left"><a href="#"><img class="block" src="/images/modbot/customerService.gif" width="209" height="140" /></a></div>
            <div class="right bot-help">
            	<div  class="layout">
                	<ul class="bot-help-title white">
                    	<li>新手上路</li>
                        <li>关于支付</li>
                        <li>配送说明</li>
                        <li>用户中心</li>
                        <li class="clearpadd">关于我们</li>
                    </ul>
                </div>
                <div class="bot-help-list layout black2">
            	<ul>
                	<%=GetList("xssl") %>
                </ul>
                
                <ul>
                	<%=GetList("rhfk") %>
                </ul>
                
                <ul>
                	<%=GetList("psfs")%>
                </ul>
                
                <ul>
                	<%=GetList("yhzx") %>
                </ul>
                
                <ul class="clearpadd">
                	<%=GetList("gywm") %>
                </ul>
                </div>
            </div>
        </div>
        <div class="bot-link">
        	<a href="/help/">帮助中心</a><span>|</span><a href="<%=GetURL.Help.Info(25) %>">关于我们</a><span>|</span><a href="<%=GetURL.Help.Info(26) %>"> 隐私申明</a><span>|</span><a href="/pro/team/">团购优惠</a><span>|</span><a class="red" href="#">诚征供应商</a><span>|</span><a href="<%=GetURL.Help.Info(4) %>">联系我们</a><span>|</span><a href="#">投诉与建议</a><span>|</span><a href="#">网站地图</a><span>|</span><a href="#">友情链接</a>
        </div>
    </div>
    <div style="text-align:center"><script src=" http://s17.cnzz.com/stat.php?id=2446247&web_id=2446247&show=pic" language="JavaScript"></script></div>
</div>
