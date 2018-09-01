<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default1.aspx.cs" Inherits="WZ.Web.gift._default1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>搜菜网-礼品兑换</title>
    <w:header id="header" runat="server"></w:header>
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/ui.ppt.js"></script>
    <link  href="/css/point.css"  rel="Stylesheet"/>
</head>
<body>
    <w:top id="ucTop" runat="server" />
    <div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 礼品兑换" /></div>
    <div class="main">
  <div class="box-wrap">
    <div class="left">
      <div class="Ranking">
        <h1></h1>
        <div class="Ranking-main">
        <script type="text/javascript">
        //gift  积分兑换
        var floatLayer=FloatFrame();
        
        function Gift(pID)
        {
            floatLayer.src="/floatLayer/gift.aspx?id="+pID
	        floatLayer.show();
        }
        </script>
        <asp:Repeater ID="rpRank" runat="server">
        <ItemTemplate>
        <dl>
            <dt> <span><%#Container.ItemIndex+1%></span> <a href="javascript:;" onclick="Gift(<%#Eval("GiftSN") %>)" class="Blue"><%#Eval("GiftName")%></a></dt>
            <dd>所需积分<span class="Red3"><%#Eval("Integral")%></span>积分</dd>
          </dl>
        </ItemTemplate>
        </asp:Repeater>
          
          
          <div class="clear"></div>
        </div>
        <div class="Ranking-bottom"></div>
      </div>
    </div>
    <div class="right">
    <div class="box1">
      <div class="banner">
        <div class="promo">
        
        <div class="container" id="idTransformView">
          <w:ppt1 ID="ucPPT1" runat="server" Str="gift" ImgAttr='width="546" height="274"' Prefix="ppt1_" />
              
            </div>
          <%--<div id="idTransformView" class="container">
            <ul id="ppt1_img" class="ppt1_img">
              <div style="width: 1092px;">
                <li><a target="_blank" href="3"><img width="546" height="274" src="/pf/info/1007/100707094947453.gif" alt="1"></a></li>
                <li><a target="_blank" href="2"><img width="546" height="274" src="/pf/info/1007/100708065848781.jpg" alt="1"></a></li>
              </div>
            </ul>
            <ul id="ppt1_num" class="ppt1_num">
              <li class="over">1</li>
              <li class="">2</li>
            </ul>
            <script type="text/javascript">
PPT("ppt1_img","ppt1_num",{path:1}).exe();
</script>
          </div>--%>
          
          
        </div>
      </div>
      <div class="box-content">
      <h1></h1>
        
        <ul class="news-bottom">
          <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
          <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
          <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
          <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
          <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
          <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
          <li><a href="#" target="_blank">网友推荐最正宗川菜馆综合指数排行...</a></li>
        </ul>
    </div>
    </div>
    <div class="Hot-main">
      <h1></h1>
      <ul class="Hot-products">
      <asp:Repeater ID="rpAdv" runat="server">
        <ItemTemplate>
        <li> <a href="javascript:;" onclick="Gift(<%#Eval("GiftSN") %>)" class="products-pic"><img src="<%#GetURL.Gift.Pic(Eval("PicS")) %>" width="130" height="113" alt="<%#Eval("GiftName")%>" /></a>
          <p><a href="javascript:;" onclick="Gift(<%#Eval("GiftSN") %>)" class="Blue"><%#Eval("GiftName")%></a></p>
          <span>所需积分：<strong class="Red3"><%#Eval("Integral")%></strong>分</span>
        </li>
        </ItemTemplate>
        </asp:Repeater>
        
        
        
        
      </ul>
      <div class="clear"></div>
    </div>
    </div>
    <div class="clear"></div>
  </div>
  <div class="Hot-main2">
      <h2 id="locate">
      <%=id == 0 ? "<span>所有</span>" : "<a href='/gift/#locate'>所有</a>"%>
      
      <asp:Repeater ID="rpClass" runat="server">
      <ItemTemplate>
      <%#Convert.ToInt32(Eval("ClassSN")) == id ? string.Format("<span>{0}</span>", Eval("ClassName")) : string.Format("<a href='?s={0}#locate'>{1}</a>", Eval("ClassSN"), Eval("ClassName"))%>
      </ItemTemplate>
      </asp:Repeater>
      </h2>
  <ul class="Hot-products2">
  
        <asp:Repeater ID="rpList" runat="server">
        <ItemTemplate>
        <li> <a href="javascript:;" onclick="Gift(<%#Eval("GiftSN") %>)" class="products-pic"><img src="<%#GetURL.Gift.Pic(Eval("PicS"))%>" width="140" height="122" alt="<%#Eval("GiftName") %>" /></a>
          <p><a href="javascript:;" onclick="Gift(<%#Eval("GiftSN") %>)" class="Blue"><%#Eval("GiftName") %></a></p>
          <span>所需积分：<strong class="Red3"><%#Eval("Integral")%></strong>分</span>
        </li>
        </ItemTemplate>
        </asp:Repeater>
      </ul>
      <div class="clear"></div>
       <!-- 翻页 -->
      <div class="paging">
      <w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" />
</div>
  </div>
</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
