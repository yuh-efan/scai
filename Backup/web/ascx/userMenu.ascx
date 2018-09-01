<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="userMenu.ascx.cs" Inherits="WZ.Web.ascx.userMenu" %>
<div class="grmes">
    	<h1></h1>
      	<ul class="grmes-main"> 
        <li>您好 <a href="center.aspx" title="会员中心首页"><span style="color:#f00"><%=WZ.Client.Data.LoginInfo.UserName %></span></a></li>
        <li>注册时间：<span style="font-weight:bold"><%=pageAddDate %></span></li>
        
        <li>帐户余额：<span class="ce00">￥<%=pageUserCanMoney %></span></li>
        <li>当前等级：<span class="ce00"><%=pageUserLevelName %></span></li>
        <%--<li>您的积分：<span class="ce00"><%=pageUserIntegral%></span></li>--%>
        <%--<li>您的经验：<span class="ce00"><%=pageUserExp%></span></li>--%>
        </ul>
        <div class="grmes-bootom"></div>
    </div>
    <div class="sidebar-box">

        <div class="box-left" id="leftList">
          <h2><img src="/images/User_02.gif" /><span>帐户管理</span></h2>
          <ul class="navlist">
            <li><a href="account.aspx">我的账户明细</a></li>
            <li><a href="orderList.aspx?t=ongoing">正在进行的交易</a></li>
            <li><a href="orderList.aspx?t=finish">完成的交易</a></li>
            <li class="no"><a href="orderList.aspx?t=all">所有的交易</a></li>
          </ul>
          <%if (LoginInfo.IsUserPromoter())
            { %>
          <h2><img src="/images/User_02.gif" /><span>推广信息</span></h2>
          <ul class="navlist">
            <li class="no"><a href="promoterUser.aspx">我推广的用户</a></li>
          </ul>
          <%} %>
          <h2><img src="/images/User_02.gif" /><span>个人信息</span></h2>
          <ul class="navlist">
            <li><a href="userInfoEdit.aspx">编辑个人信息</a></li>
            <li><a href="pwdEdit.aspx">修改密码</a></li>
            <li class="no"><a href="contact.aspx">设置收货地址</a></li>
          </ul>
          
          <h2><img src="/images/User_02.gif" /><span>积分查询</span></h2>
          <ul class="navlist">
            <li><a href="detailIntegral.aspx">我的积分明细</a></li>
            <li><a href="/gift/" target="_blank">我要礼品兑换</a></li>
            <li class="no"><a href="gift.aspx">礼品兑换记录</a></li>
          </ul>
          
          <h2><img src="/images/User_02.gif" /><span>评价收藏</span></h2>
          <ul class="navlist">
            <li><a href="fav.aspx?t=0">我收藏的商品</a></li>
            <li><a href="fav.aspx?t=1">我收藏的食谱</a></li>
            <li><a href="proEvaluateList.aspx">我的商品评价</a></li>
            <li class="no"><a href="buyProList.aspx">已购买商品评价</a></li>
          </ul>
          
          <h2><img src="/images/User_02.gif" /><span>我的站内信</span></h2>
          <ul class="navlist">
          <li class="no"><a href="letterList.aspx">收到的信</a></li>
          </ul>
      </div>
    </div>
    
<script type="text/javascript">
function navSel(sArr,sNav)
{
    var arr=_.getTN("li",_.get(sArr));
    
    var text=[];
    for(var i=0;i<arr.length;i++)
        text[i]=_.firstChild(arr[i]).innerHTML.trim();

    var navL=_.get(sNav);
    
    if(navL)
    {
        var len=text.length;
        var inner=navL.innerHTML;
        for(var i=len-1;i>=0;i--)
        {
            if(inner.indexOf(text[i])>-1)
            {
                arr[i].className="sel";
                break;
            }
        }
    }
}
navSel("leftList","webLocation");
</script>