<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="WZ.Web.user.contact" EnableViewState="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>添加/修改 收货地址 - 搜菜网</title>
    <w:headerUser id="header" runat="server"></w:headerUser>
    <link href="/css/msgCheck.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    <script type="text/javascript" src="/js/ClassAjax_Drop.js"></script>
    <script type="text/javascript" src="/js/msgCheck.js"></script>
</head>
<body>
<w:top id="ucTop" runat="server" />
   <w:userLocation id="ucUL" runat="server" Text=" &gt; 个人信息管理 &gt; 设置收货地址"></w:userLocation>
   	<div class="main">
    	<div class="left">
    <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
    </div>
        <div class="right">
        <form id="form1" runat="server">
          <div class="User-box p-top">
            <h3><span>我的收货地址簿</span></h3>
<div id="clist" runat="server">
<w:Rep ID="rpList" runat="server">
<ItemTemplate>
            <div class="address">
              <ul>
             
               <li><%#Container.ItemIndex+1 %> 收货人：<%# Eval("Name")%></li>
               <li>收货地址：<span class="blue"><%#GetAreaPath(Eval("FK_Area"))%></span> <%# Eval("Address")%></li>
               <li>手机：<%# Eval("Tel")%> 固定电话：<%# Eval("FixTel")%></li>
              </ul>
              <ul class="Operation">
              
                <li>
                <input type="button" id="bEdit" name="bEdit" value="修改" onclick="location.href='?id=<%#Eval("ConSN") %>#e'" Class="anniucss3" />
                </li>
                <li>
                <input type="button" name="cDel" onclick="del(<%#Eval("ConSN") %>)" value="删除" class="anniucss3" />
               <%-- <asp:Button ID="bDelete" runat="server" Text="删除" CommandName='' OnClick="bDelete_Click" OnClientClick="return del(<%#Eval("ConSN") %>)" CssClass="anniucss3" />--%>
                </li>
              </ul>
              <div class="clear"></div>
            </div>
</ItemTemplate>
</w:Rep>
</div>
            <h3 id="e"><span>添加或修改 收货地址</span> <a href="contact.aspx?#msg">添加</a></h3>
            <div class="Edit_Info">
            <div id="msg">
<%=WZ.Common.Config.HTML.CheckMsg%>
</div>
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td class="lefttd">收货人姓名：</td>
                  <td><w:InputText ID="cName" runat="server" Attr='size="30"'></w:InputText></td>
                </tr>            
                
                <tr>
                  <td class="lefttd">所在区域：</td>
                  <td>
                  <w:InputText ID="cArea" runat="server" Type="hidden"></w:InputText>
                  <span id="cArea_htm"></span>
                  <script type="text/javascript">ClassAjax_Drop("cArea","cArea_htm","/ajax/getclass.ashx").exe();</script>
              
                  </td>
                </tr>  
                <tr>
                  <td class="lefttd">详细地址：</td>
                  <td>
                  <w:InputText ID="cAddress" runat="server" Attr='size="50"'></w:InputText>
                  </td>
                </tr>
                 
                  <tr>
                  <td class="lefttd">固定电话：</td>
                  <td>
                  <w:InputText ID="cFixTel" runat="server" Attr='size="30"'></w:InputText>
                  
                  </td>
                </tr>
                  <tr>
                  <td class="lefttd">手机：</td>
                  <td>
                  <w:InputText ID="cTel" runat="server" Attr='size="30"'></w:InputText>
                  </td>
                </tr>
              </table>
              
            </div>
          </div>
          
          <div class="btns"> 
<script type="text/javascript">
function del(pID)
{
    if(!confirm("确定删除"))
        return;
    
    bOK_Click('del',pID);
}

function bOK_Click(cmd,pID)
{
    if(!cmd) cmd='save';
    
	var param='hid=1&cmd='+cmd
			+'&cName='+_.getValue('cName')
			+'&cAddress='+_.getValue('cAddress')
			+'&cFixTel='+_.getValue('cFixTel')
			+'&cTel='+_.getValue('cTel')
			+'&cArea='+_.getValue('cArea')
	        ;
	        
	if(cmd=='del')
	{
	    param+='&delid='+pID;
	}
	
	Ajax('contact.aspx?id=<%=id %>',{
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
			_.get('msg').scrollIntoView();
			break;
		case 'success':
			_.getClass("msgCheck").style.display='none';
			_.get('clist').innerHTML=jso.html;
			alert(jso.info);
			break;
		default:
			alert(jso.info)
			break;
	}
}


</script>
<input type="button" name="bOK" id="bOK" value="保存" onclick="bOK_Click()" class="anniucss"/>
        
          <input type="button" value="取消" onclick="location.href='<%=Request.Url.AbsolutePath %>'" class="anniucss3" />
              
              </div>
            </form>
        </div>
      
    	<div class="clear"></div>
  	</div>
<w:bottom id="ucBottom" runat="server" />

</body>
</html>
