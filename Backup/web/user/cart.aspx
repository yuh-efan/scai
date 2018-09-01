<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="cart.aspx.cs" Inherits="WZ.Web.user.cart" %>
<%@ Import Namespace="WZ.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>购物车</title>
    <w:header id="header1" runat="server"></w:header>
    <link href="/css/shopping.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    
    <script type="text/javascript">
    function edit1(pID)
    {
        var n=Number(_.get('cNum_'+pID).value)+1;
        editNum({ID:pID,num:n});
    }

    function edit_1(pID)
    {
        var n=Number(_.get('cNum_'+pID).value)-1;
        editNum({ID:pID,num:n});
    }

    function editNumBlur(pID)
    {
        var n=_.get('cNum_'+pID).value;
        editNum({ID:pID,num:n});
    }

    function editNum(pJso)
    {
        Ajax(location.href,{
            method:"post",
            param:'hid=1&cmd=editNum&id='+pJso.ID+'&num='+pJso.num,
		    fnSuccess:function(){
		        eval('var jso='+this.xmlHttp.responseText)
			    switch(jso.type)
                {
	                case 'success':
		                _.get('htm_cart').innerHTML=jso.html;
		                break;
			        case 'nologin':
				        flogin();
				        break;
        			
	                default:
		                alert(jso.info);
		                break;
                }
		    }
	    }).exe();
    }
    
    function del(pID)
    {
        if(!confirm('确定删除吗？'))
            return;
        
        Ajax(location.href,{
            method:"post",
            param:'hid=1&cmd=del&id='+pID,
		    fnSuccess:function(){
		        eval('var jso='+this.xmlHttp.responseText)
			    switch(jso.type)
                {
	                case 'success':
		                _.get('htm_cart').innerHTML=jso.html;
		                RealtimeUserCartInfo(jso.cartCount);
		                break;
			        case 'nologin':
				        flogin();
				        break;
        			
	                default:
		                alert(jso.info);
		                break;
                }
		    }
	    }).exe();
    }
    
    function delAll()
    {
        if(!confirm('确定清空购物车？'))
            return;
        
        Ajax(location.href,{
            method:"post",
            param:'hid=1&cmd=clearAll',
		    fnSuccess:function(){
		        eval('var jso='+this.xmlHttp.responseText)
			    switch(jso.type)
                {
	                case 'success':
		                _.get('htm_cart').innerHTML=jso.html;
		                RealtimeUserCartInfo(jso.cartCount);
		                break;
			        case 'nologin':
				        flogin();
				        break;
        			
	                default:
		                alert(jso.info);
		                break;
                }
		    }
	    }).exe();
    }
    </script>
</head> 
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" > 购物车" /></div>
<div class="main">
<div class="flow-steps"></div>
<div class="cart">
  <h2></h2>
  
<div id="htm_cart" runat="server">
  <table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="s-pic">商品图片</td>
      <td class="s-title">商品名称</td>
      <td class="s-price">单价</td>
      <td class="s-price">您的价格</td>
      <td class="s-amount">数量</td>
      <td class="s-total">小计</td>
      <td class="s-del">操作</td>
    </tr>
    
<w:Rep id="rpList" runat="server">
<itemtemplate>
    <tr <%#(Container.ItemIndex % 2)==0?"":"class=\"tr-bg\""%> id="tr_<%#Eval("CartSN") %>">
      <td class="s-pic"><a href="<%# GetURL.Pro.Info(Eval("FK_All")) %>" target="_blank" class="products-img"><img src="<%# GetURL.Pro.Pic(Eval("PicS")) %>" width="46" height="46" alt="" /></a></td>
      <td class="s-title">
      <a href="<%# GetURL.Pro.Info(Eval("FK_All")) %>" target="_blank" class="Green"><%# Eval("ProName")%></a>
     
      
      <span class="Red"><%# User_Cart.GetCartProStatus(Container.DataItem)%></span>
      </td>
      <td class="s-price">￥<%# Eval("Price")%> <%#User_Cart.GetOtherPrice(Container.DataItem)%></td>
      <td class="s-price"><em>￥<%# Eval("dt_UserPrice")%></em></td>
      <td class="s-amount"><a href="javascript:;"><img src="/images/shopping/jian.gif" width="9" height="9" alt="减 1" onclick="edit_1(<%#Eval("FK_All") %>)" /></a>
        <input id="cNum_<%#Eval("FK_ALL") %>" type="text" maxlength="9" class="text-amount" value="<%# Eval("Num")%>" onchange="editNumBlur(<%#Eval("FK_All") %>)" />
        <a  href="javascript:;"><img src="/images/shopping/jia.gif" width="9" height="9" alt="加 1" onclick="edit1(<%#Eval("FK_All") %>)" /></a></td>
      <td class="s-total"><em>￥<span id="spanTotalPrice_<%#Eval("FK_ALL") %>"><%# Eval("dt_TotalPrice") %></span></em></td>
      <td class="s-del"><a href="javascript:;" class="Green" onclick="del(<%#Eval("CartSN") %>)">删除</a></td>
    </tr>
    
</itemtemplate>
</w:Rep>

  </table>
  <div class="charge-info">
   <p>产品数量总计：<em><span id="spanProN"><w:ShowText ID="txtProN" runat="server"></w:ShowText></span>件</em></p>
     <p style="display:none">赠送积分总计：<em>394分</em></p>
     <p>商品金额总计：<strong>￥<span id="spanTotalPriceALL"><w:ShowText ID="txtTotalPriceAll" runat="server"></w:ShowText></span></strong></p>
  </div>
</div>
  
  <div class="clearfix">
  
   <a id="go" class="go" href="orderConfirm.aspx"><img src="/images/shopping/Paying.gif" alt="去结算" /></a>

   <a href="javascript:window.history.back()"><img src="/images/shopping/shopping_01.gif" width="81" height="21" alt="继续购物" /></a>
   
   
   
   <a href="javascript:;" onclick="delAll()"><img src="/images/shopping/shopping_02.gif" alt="清空购物车" /></a>

  </div>
  
 
  
  <div class="note">您在购物过程中有任何疑问，请查阅 <a href="#" target="_blank" class="Green">帮助中心</a> 或 <a href="#" target="_blank" class="Green">联系客服</a></div>
</div>

<div class="msg">
  <h5>关于“我的购物车”</h5>
  <p>·在商品保留在购物车内期间，您所选择商品的价格、优惠政策、库存、配送时间等信息可能会有所变化，请以网页最新信息为准。</p>
</div>

</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>