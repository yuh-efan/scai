<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WZ.Web.pro.team._default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<w:header id="header" runat="server"></w:header>

<title>企业快速订购</title>
<script type="text/javascript" src="/js/ui.floatFrame.js"></script>
<script type="text/javascript" src="/js/pub.js"></script>
<style type="text/css">
a.blue{color:#1865b7;text-decoration:none}
a.blue:hover{color:#1865b7;text-decoration:underline}
.gap3{padding-left:20px;} 
.gap2{padding-top:5px}

.category{border:solid 4px #62c711;padding:20px 0 20px 20px; line-height:2em;margin-bottom:6px}
.category span{color:#333333;font-weight:bold}
.category a{display:inline-block;margin-right:15px}

.border{border:solid 4px #eaeaea;}
.list,.list li dl dd{width:100%; overflow:hidden}
.list{ padding-bottom:18px; min-height:440px;height:auto !important;height:440px;}
.list li dl dd{padding-top:5px; }
.list li{ float:left;border:solid 1px #eed97c; padding:12px;width:195px;margin:18px 0 0 17px; display:inline}
.list li dt a{font-size:14px; font-weight:bold}

.list li dl .left input{ border:solid 1px #ccc;width:35px; text-align:center;padding-right:1px;}

.buy-bt,.buy-bt span{ background:url(/images/groupBuy/groupbuy-bt.gif) no-repeat;}
.buy-bt{display:inline-block;padding-left:18px;height:20px;}
.buy-bt span{background-position:right;padding-right:18px;display:block;padding-top:2px}

</style>
<script type="text/javascript">
function page_AddCart(pID)
{
    AddCart(pID,_.get('p_'+pID).value,0,1);
}
</script>
</head>

<body>
<w:top id="ucTop" runat="server" />
    <div class="content">
    	<!--类别-->
    	<div class="category">
        	<span>分类：</span>
        	<a href="?" class="blue" <%=0 == classID?"style=\"color:#f00\"":""%>>全部</a>
        	<asp:Repeater ID="rpClass" runat="server">
                <ItemTemplate>
                <a href="?classID=<%#Eval("ClassSN") %>" class="blue" <%#Eval("ClassSN").ToString() == classID.ToString()?"style=\"color:#f00\"":""%>><%#Eval("ClassName") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!--列表-->
        <div class="border">
        	<ul class="list" id="sdf">
        	
        	<asp:Repeater ID="rpPro" runat="server">
        	<ItemTemplate>
        	    <li>
                	<dl>
                    	<dt><a href="<%#GetURL.Pro.Info(Eval("ProSN")) %>" class="blue" target="_blank"><%#Eval("ProName") %></a></dt>
                        <dd>
                        	<div class="left">
                            	<div>规格：<%#Eval("UnitNum")%><%#Eval("Unit")%></div>
                                <div class="gap2">数量：<input id="p_<%#Eval("ProSN") %>" name="p_<%#Eval("ProSN") %>" type="text" value="1" maxlength="9" /></div>
                            </div>
                            <div class="left gap3">
                            	<div>价格：<span class="red">￥<%#Eval("Price2") %></span></div>
                                <div class="gap2"><a class="buy-bt white" href="javascript:;" onclick="page_AddCart(<%#Eval("ProSN") %>)"><span>订购</span></a></div>
                            </div>
                        </dd>
                    </dl>
                </li>
        	</ItemTemplate>
        	</asp:Repeater>
            </ul>
        </div>
        <!--翻页-->
        <div class="paging"><w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" /></div>
    </div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
