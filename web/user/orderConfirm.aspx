<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="orderConfirm.aspx.cs" Inherits="WZ.Web.user.orderConfirm" %>
<%@ Import Namespace="WZ.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>确认订单信息</title>
    <w:header id="header1" runat="server"></w:header>
    <link href="/css/shopping.css" rel="stylesheet" type="text/css" />
    <link href="/css/msgCheck.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    <script type="text/javascript" src="/js/msgCheck.js"></script>
    <script type="text/javascript" src="/js/time/WdatePicker.js"></script>
    <script type="text/javascript" src="/js/ClassAjax_Drop.js"></script>
</head>
<body>

<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" > 确认订单信息" /></div>
<form id="form1" runat="server">
	<div class="main">
    <div class="flow-steps-2"></div>
    <div class="cart">
    <h2></h2>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td class="s-pic">商品图片</td>
          <td class="s-title">商品名称</td>
          <td class="s-price">单价</td>
          <td class="s-price">您的价格</td>
          <td class="s-amount">数量</td>
          <td class="s-total">小计</td>
        </tr>
        
<w:Rep id="rpList" runat="server">
<itemtemplate>
        <tr <%#(Container.ItemIndex % 2)==0?"":"class=\"tr-bg\""%>>
          <td class="s-pic"><a href="<%# GetURL.Pro.Info(Eval("FK_All")) %>" target="_blank" class="products-img"><img src="<%# GetURL.Pro.Pic(Eval("PicS")) %>" width="46" height="46" alt="" /></a></td>
          <td class="s-title"><a href="<%# GetURL.Pro.Info(Eval("FK_All")) %>" target="_blank" class="Green"><%# Eval("ProName")%></a>
          
          <span class="Red"><%# User_Cart.GetCartProStatus(Container.DataItem)%></span>
          </td>
          <td class="s-price">￥<%# Eval("Price")%> <%#User_Cart.GetOtherPrice(Container.DataItem)%></td>
          <td class="s-price"><em>￥<%# Eval("dt_UserPrice")%></em></td>
          <td class="s-amount"><%# Eval("Num")%></td>
          <td class="s-total"><em>￥<span id="spanTotalPrice_<%#Eval("FK_ALL") %>"><%# Eval("dt_TotalPrice") %></span></em></td>
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
    <div class="Filling">
      <h2></h2>
<div id="msg">
<%=WZ.Common.Config.HTML.CheckMsg%>
</div>
      <p><em><%=WZ.Client.Data.LoginInfo.UserName%></em>, 您好。请选择或填写以下收货信息，我们将以此为依据配送货品。</p>
      <div class="logintable2">
      <ul class="receiving">
      
<w:Rep id="rpAddress" runat="server">
<itemtemplate>
<li>
<input type="radio" name="cConAdd" id="c<%#Container.ItemIndex %>" value="<%#Eval("ConSN") %>" onclick="fnShowDivAdd(0)" />
<label for="c<%#Container.ItemIndex %>">
<span style="color:#1865b7"><%#GetAreaPath(Eval("FK_Area"))%></span> <%#Eval("Address") %> (收货人:<%#Eval("Name") %>)
</label>
</li>
</itemtemplate>
</w:Rep>
<li>
<input type="radio" name="cConAdd" id="c-1" value="-1" onclick="fnShowDivAdd(1)" />
        <label for="c-1" style="color:#1865b7">新增收货地址</label>
</li>
</ul>
<w:InputText ID="cIsDivAdd" runat="server" Type="hidden" />
        <div id="divAdd" style="display:none">
        <table width="600">
                    <tr>
                        <td class="loginleft">收货人：</td>
                        <td class="loginright"><input id="cName" name="cName" type="text" maxlength="20" value="<%=pageRealName %>" /></td>
                    </tr>
                    <tr>
                      <td class="loginleft">地区：</td>
                      <td class="loginright">
                      <input id="cArea" name="cArea" type="hidden" value="<%=pageArea %>"/>
                      <span id="cArea_htm"></span>
                      <script type="text/javascript">
					  ClassAjax_Drop("cArea","cArea_htm","/ajax/getclass.ashx").exe();
					  </script>
                      </td>
                    </tr>
                    
                    <tr>
                        <td class="loginleft">详细地址：</td>
                        <td class="loginright"><input id="cAddress" name="cAddress" type="text" style="width:330px;" value="<%=pageAddress %>" /></td>
                    </tr>
                    
                    <tr>
                        <td class="loginleft">手机：</td>
                        <td class="loginright"><input id="cTel" name="cTel" type="text" value="<%=pageTel %>" /> <span class="Red2">(手机与电话填写一个)</span></td>
                    </tr>
                    
                    <tr>
                        <td class="loginleft">固定电话：</td>
                        <td class="loginright"><input id="cFixTel" name="cFixTel" type="text" value="<%=pageFixTel %>" /></td>
                    </tr>
                    
                    
                    <tr>
                      <td class="loginleft">是否保存此收货地址：</td>
                      <td class="loginright">
                      <input id="cSaveContact1" type="radio" name="cSaveContact" value="1" checked="checked" /><label for="cSaveContact1">是</label>
                      <input id="cSaveContact2" type="radio" name="cSaveContact" value="0" /><label for="cSaveContact2">否</label>
                      </td>
                    </tr>
                </table>
  </div>
<table width="100%">
<tr>
<td class="loginleft">要求送到时间：</td>
<td>
<input class="Wdate" type="text" id="cAreaDate" name="cAreaDate" onFocus="WdatePicker({isShowClear:false,readOnly:true,skin:'whyGreen',dateFmt:'yyyy-MM-dd',maxDate:'%y-%M-{%d+7}',minDate:'<%=DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")%>'})" value="<%=DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")%>" />

<%=pageOrdAreaTime %>

<span style="display:none">
从：<input id="startTime" name="startTime" type="text" value="<%=sTime1%>" />
到：<input id="endTime" name="endTime" type="text" value="<%=sTime2%>" />
</span>
<div class="Red2" style="display:none">配送时间范围必须在订购当天后的 09：00—19：00，最迟不超过一个星期，间隔不能小于30分钟。<br />（时间格式：如 <%=sTime1 %> 到 <%=sTime2%>）</div>
</td>
</tr>
<tr>
<td class="loginleft">附加信息：</td>
<td><textarea id="cInfo" name="cInfo" style="height: 73px; width: 330px"></textarea>
<script type="text/javascript">
_.get("cInfo").onkeypress=function(){if(this.value.length>=600) return false;}
</script>
</td>
</tr>
</table>
      </div>
      <h3></h3>
      <p>请选择或填写以下付款方式，目前您有预存款可用金额 <b><%=pageUserMoney%></b>元。</p>
      <div class="paylist">
      	<ul>
        
        <w:Rep ID="rpPay" runat="server">
        <ItemTemplate>
          <li>
                <div class="left">
                    <input name="pay" id="pay_<%#Container.ItemIndex %>" value="<%#Eval("PaySN")%>" type="radio" class="rad"/><label for="pay_<%#Container.ItemIndex %>"><%#Eval("PayName")%></label>
                </div>
                <div class="right">
               
                <%#GetPayAttr(Eval("PaySN"), Eval("PayType"))%>
                <%#Eval("Detail")%>
                </div>
            </li>
          </ItemTemplate>
          </w:Rep>
        </ul>
      </div>
      
      <div>
      抵金券：<input id="cActNumber_1" name="cActNumber_1" type="text" />
      </div>
      
      <div class="logintable2 Paymenttable" style="display:none">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <w:Rep ID="rpPay1" runat="server">
        <ItemTemplate>
          <tr>
            <td class="Payment loginright" width="50">
            <input name="pay" type="radio" value="<%#Eval("PaySN")%>" />
            </td>
            <td class="Payment loginright"><%#Eval("PayName")%></td>
            <td>
            <%#Eval("Detail")%>
            <%#GetPayAttr(Eval("PaySN"), Eval("PayType"))%>
            </td>
          </tr>
          </ItemTemplate>
          </w:Rep>
        </table> 
      </div>
      <h4 style="display:none"></h4>
      <ul class="Coupon" style="display:none">
      <li>你有可用积分 34点，本次消费最多可用 0点（抵用现金0.00元）。我要使用
        <input type="text" size="5" />
        点</li>
      <li>请输入抵用券号码：<input name="textfield" type="text" id="textfield" size="50" /></li>
      <li><img src="/images/shopping/Use.gif" width="81" height="21" alt="" /></li>
      </ul>
      <div class="sun2">
      <p style="display:none">共节省 <em>0.00</em>元   只需付款： <em>0.00</em>(货款) + <em>8.00</em>(运费)- <em>0.00</em>(积分抵扣)- <em>0.00</em>(抵用券)- <em>0.00</em>(现金券)=￥<span>8.00</span>元</p>

<script type="text/javascript">
	function bOK_Click()
	{
		var objBuy=_.get('bBuy');
		objBuy.style.filter='gray';
		objBuy.onclick=function(){alert('正在提交,请稍后...');return false}
		
		var param='hid='+_.getValue('hid')
				+'&cConAdd='+_.getValue('cConAdd')
				+'&cAreaDate='+_.getValue('cAreaDate')
				+'&cAreaTime='+_.getValue('cAreaTime')
				+'&startTime='+_.getValue('startTime')
				+'&endTime='+_.getValue('endTime')
				+'&cInfo='+_.getValue('cInfo')
				+'&pay='+_.getValue('pay')
				
				+'&cName='+_.getValue('cName')
				+'&cArea='+_.getValue('cArea')
				+'&cAddress='+_.getValue('cAddress')
				+'&cTel='+_.getValue('cTel')
				+'&cFixTel='+_.getValue('cFixTel')
				+'&cSaveContact='+_.getValue('cSaveContact')
				+'&cActNumber_1='+_.getValue('cActNumber_1')
		;
		
		Ajax('orderConfirm.aspx',{
		param:param,
		method:'post',
		fnSuccess:function(){
			cb_ok(this.xmlHttp.responseText);
		}
		}).exe();
		
		return false;
	}
	
	function cb_ok(pStr)
	{
		eval('var jso='+pStr);
		switch(jso.type)
		{
			case 'error':
			    checkPub(function(){
		            var msg=jso.info;
		            return msg;
	            });
			    window.location.href='#msg';
				break;
			case 'success':
				window.location.href=jso.jumpurl;
				break;
			default:
				alert(pStr)
				break;
		}
		
		var objBuy=document.getElementById('bBuy');
		objBuy.style.filter='';
		objBuy.onclick=function(){return bOK_Click();}
	}

</script>

<input type="hidden" name="hid" value="1" />

<input id="bBuy" type="image" src="/images/shopping/Confirmation.gif" onclick="return bOK_Click()" />

      </div>
      <div class="note">您在购物过程中有任何疑问，请查阅 <a href="#" target="_blank" class="Green">帮助中心</a> 或 <a href="#" target="_blank" class="Green">联系客服</a></div>
    </div>
  </div>
</form>
<w:bottom id="ucBottom" runat="server" />
</body>
<script type="text/javascript">
function fnShowDivAdd(pStr)
{
    _.get("cIsDivAdd").value=pStr;
    
    var obj=_.get("divAdd");
    if(pStr==1)
    {
        obj.style.display="";
    }
    else
    {
        obj.style.display="none";
    }
}

window.onload=function()
{
	var objAddList=_.getN('cConAdd')[0];
	
	objAddList.checked="checked";
	fnShowDivAdd(_.get("cIsDivAdd").value);
	
	var objPay=_.getN('pay')[0];
	if(objPay)
		objPay.checked="checked";
}

</script>
</html>