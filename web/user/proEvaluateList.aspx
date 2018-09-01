<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proEvaluateList.aspx.cs" Inherits="WZ.Web.user.proEvaluateList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>我的商品评价 - 搜菜网</title>
    <w:headerUser id="header1" runat="server"></w:headerUser>
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    <style type="text/css">
.Reply2 { background:url(/images/products_bg.gif) no-repeat;}
.Reply2 { float:left; display:block; width:40px; height:20px; background-position:-110px -102px;}
</style>
</head>
<body>
    <w:top id="ucTop" runat="server" />
   <w:userLocation id="ucUL" runat="server" Text=" > 咨询与评价 > 我的商品评价"></w:userLocation>
    <div class="main">
  <div class="left">
    <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
  </div>
  <div class="right">
    <div class="User-box">
        <h3><span>我的商品评价</span></h3>
        <div class="Commentary">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr bgcolor="#f7f7f7">
            <th>产品</th>
            <th>评价内容</th>
            <th>您的评分</th>
            <th>审核</th>
          </tr>
          
          <w:Item ID="rpList" runat="server">
          <ItemTemplate>
          
           <tr>
            <td class="pic">
            <a href="<%#GetURL.Pro.Info(Eval("ProSN")) %>" class="products-pic" target="_blank"><img src="<%#GetURL.Pro.Pic(Eval("PicS")) %>" width="46" height="46" alt="" /></a>
            <span><a href="<%#GetURL.Pro.Info(Eval("ProSN")) %>" target="_blank" class="Green"  target="_blank"><%#Eval("ProName") %></a></span>
            </td>
            <td>
            <%# Eval("Detail")%>
            
            <div class="Explanation" <%#Eval("ReDetail").ToString().Length>0?"":"style=\"display:none\"" %>><span class="Reply2"></span>
             <%# Eval("ReDetail")%>
             </div>
             
            </td>
            <td><div class="com-right">
            <p><%# Eval("AddDate")%></p>
            <p class="star"><%#Eval("Fraction")%></p>
          </div></td>
          
            <td><%#kpAudit.GetDirc(Eval("Purview").ToString())%></td>
          
          </tr>
          
          </ItemTemplate>
          </w:Item>
          
      
          
          
        </table>
<script type="text/javascript">
function setStar()
{
	var obj=_.getClassN('star');
	
	for(var i=0;i<obj.length;i++)
	{
		var o1=obj[i];
		
		obj[i].innerHTML=GetStar(Number(o1.innerHTML))
	}
}
setStar();
</script>
        </div>
        <div class="paging">
      <w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" />
</div>
        
        
      </div>
  </div>
  <div class="clear"></div>
</div>
    <w:bottom id="ucBottom" runat="server" />

</body>
</html>
