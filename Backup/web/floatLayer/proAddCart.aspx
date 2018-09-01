<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proAddCart.aspx.cs" Inherits="WZ.Web.floatLayer.proAddCart" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script type="text/javascript" src="/js/base.js"></script>
<script type="text/javascript" src="/js/ajax.js"></script>
<script type="text/javascript" src="/js/ui.floatFrame.js"></script>
<style type="text/css">
body { margin:0; padding:0; font-size:12px;}
ul,li { list-style:none; margin:0px; }
.wrap .tou,.sun,.sun2,.Closure { background:url(/images/Regframe/rehframe.gif) no-repeat ;}
.wrap { width:380px; border:#02a318 solid 4px; padding:25px 25px 0px 25px; background:#f1faf2;  position:relative;}
.wrap .tou { height:30px; background-position:-20px -155px; border-bottom:#c9eacd solid 1px;font-size:0px;}
.Closure { display:block; width:20px; height:20px; position:absolute; top:10px; right:10px; background-position:-127px -91px;}
.Closure:hover { background-position:-104px -91px;}
.main {  line-height:30px; text-align:center;  height:158px; overflow:auto; padding:5px 0px;}
.main span img { vertical-align:middle;}
.sun-wrap {padding-top:15px 0 0 0; height:20px;}
.sun-wrap li { float:left; width:50%; text-align:center}
.sun { width:85px; height:21px; border:0; background-position:-154px -91px;}
.sun2 { width:110px; height:21px; border:0; background-position:0 -113px;}
.Red3 { color:#cd2a23; font-weight:bold;}
.Red2 { color:#cd2a23;}
.sun04 { border:0; color:#fff; width:100px; height:21px; line-height:21px; background:url(/images/sun2.gif) no-repeat; text-align:center; text-decoration:none; font-size:12px;}
.sun04:hover { color:#f9fc01; text-decoration:none;}
</style>
</head>
<body>
<div class="wrap">
	<div class="tou"></div>
	
	<a href="javascript:;" onclick="top.floatLayer.hidden();" class="Closure"></a>
	<div class="main">
	
	<table width="100%">
	<tr>
	    <td width="30"></td>
	    <td>名称</td>
	    <td>数量</td>
	    <td>价格</td>
	    <td>小计</td>
	</tr>
	<w:Item ID="rpList" runat="server">
	<ItemTemplate>
	<tr>
	    <%--<td><img src="/images/Regframe/zq.gif" id="i_s_<%#Eval("ProSN") %>" /><span class="Red2" id="s_<%#Eval("ProSN") %>"><%#User_Cart.GetCartProStatus(Container.DataItem)%></span></td>--%>
	    <td><img src="/images/Regframe/zq.gif" /></td>
	    <td><%#Eval("ProName") %> </td>
	    <td><%#Eval("Num")%></td>
	    <td><span class="Red3">￥<%#Eval("dt_UserPrice")%></span></td>
	    <td><span class="Red2">￥<%#Eval("dt_TotalPrice")%></span></td>
	</tr>
	</ItemTemplate>
	</w:Item>
	</table>
    </div>

    <input id="cID" name="cID" type="hidden" value="<%=ids %>"  />
    <input id="cT" name="cT" type="hidden" value="<%=type %>"  />
    <input id="cN" name="cN" type="hidden" value="<%=num %>"  />

    <ul class="sun-wrap">
    <script type="text/javascript">
    function AC(pID,pN,t)
    {
	    var url='/ajax/cartAdd.aspx?id='+pID+'&n='+pN+'&t='+t;
	    var aj=new Ajax(url);
    	
	    var url='/ajax/cartAdd.aspx?id='+pID+'&n='+pN+'&t='+t;
	     Ajax(url,{
			    fnSuccess:function(){
    				
				    eval('jso='+this.xmlHttp.responseText);
    				
				    switch(jso.type)
		            {
			            case 'nologin':
				            window.location.href='<%=furl %>';
				            break;
            			
			            case 'success':
        				    msg_show('放入购物车成功','#26a61d');
				            setTimeout(hhh,1000);
				            break;
    				        
				        case 'error':
        				    msg_show(jso.info,'#cc0000');
		            }
			    }
	    }).exe();
    }

    function msg_show(s,c)
    {
        _.get('htm_addSuccess').innerHTML=s;
        _.get('htm_addSuccess').style.display='';
        _.get('htm_addSuccess').style.color=c;
    }

    function hhh()
    {
        top.RealtimeUserCartInfo();
	    top.floatLayer.hidden();
    }

    function okAC()
    {
        AC(_.get('cID').value,_.get('cN').value,_.get('cT').value);
    }
    </script>
    <li><input name="ok" type="button" value="确定放入购物车" onclick="okAC()" class="sun04" /></li>
    <li><input name="close" onclick="top.floatLayer.hidden();" type="button" value="取消" class="sun04" /></li>
    </ul>
    <div style="text-align:center; font-weight:bold; height:18px;">
    <span style="display:none" id="htm_addSuccess"></span>
    </div>
    
</div>

</body>

<script type="text/javascript">
window.onload=function(){FloatFrame.autoLocal();}
</script>
</html>
