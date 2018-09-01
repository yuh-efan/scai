<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userInfoEdit_team.aspx.cs" Inherits="WZ.Web.user.userInfoEdit_team" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑个人信息 - 搜菜网</title>
    <w:headerUser id="header1" runat="server"></w:headerUser>
    <link href="/css/msgCheck.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    <script type="text/javascript" src="/js/calendar.js"></script>
    <script type="text/javascript" src="/js/ClassAjax_Drop.js"></script>
    <script type="text/javascript" src="/js/msgCheck.js"></script>
</head>
<body>
    <w:top id="ucTop" runat="server" />
   <w:userLocation id="ucUL" runat="server" Text=" &gt; 个人信息管理 &gt; 编辑个人信息"></w:userLocation>
   	<div class="main">
    	<div class="left">
    <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
    </div>
    <form id="form1" runat="server">
    	<div class="right">
<div id="msg">
<%=WZ.Common.Config.HTML.CheckMsg%>
</div>
      <div class="User-box p-top">
        <h3><span>编辑个人信息</span></h3>
        <div class="Edit_Info">
          <h4>帮助我们完善您的个人信息，有助于我们未来根据您的情况提供更加个性化的服务；搜菜网会对您的个人资料隐私加以保密。</h4>
          <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td class="lefttd">公司名称：</td>
              <td>
              <w:InputText ID="cName1" runat="server" Attr='size="50"'></w:InputText>
                <span>*</span></td>
            </tr>
          
            <tr>
              <td class="lefttd">联系人：</td>
              <td>
              <w:InputText ID="cName" runat="server" Attr='size="30"'></w:InputText>
                <span>*</span></td>
            </tr>
           
            
            <tr>
              <td class="lefttd">手机：</td>
              <td><w:InputText ID="cTel" runat="server" Attr='size="30"'></w:InputText>
                <span>* 手机/电话必填一项</span></td>
            </tr>
            
            <tr>
              <td class="lefttd">电话：</td>
              <td><w:InputText ID="cFixTel" runat="server" Attr='size="30"'></w:InputText></td>
            </tr>
            
            <tr>
              <td class="lefttd">所在区域：</td>
              <td>
              <w:InputText ID="cArea" runat="server" Type="hidden"></w:InputText>
              <span id="cArea_htm"></span>
              <script type="text/javascript">ClassAjax_Drop("cArea","cArea_htm","/ajax/getclass.ashx").exe();</script>
              <span>*</span>
              
              </td>
            </tr>
            <tr>
              <td valign="top" class="lefttd">详细地址：</td>
              <td><w:InputText ID="cAddress" runat="server" Attr='size="50"'></w:InputText>
                <span>*</span></td>
            </tr>
            
            <tr>
              <td valign="top" class="lefttd">E-mail：</td>
              <td><w:InputText ID="cEmail" runat="server"></w:InputText>
                <span>* 用于密码找回或订阅本站最新信息</span></td>
            </tr>
            
            <tr>
              <td valign="top" class="lefttd">公司介绍：</td>
              <td><textarea id="cInfo" name="cInfo" style="width:340px; height:123px;"><%=pageDetail %></textarea>
                <span>*</span></td>
            </tr>
            
          </table>
        </div>
        
        <div class="btns">

<script type="text/javascript">
function bOK_Click()
{
	var param='hid=1&cmd=edit'
			+'&cName1='+_.getValue('cName1')
			+'&cName='+_.getValue('cName')
			+'&cTel='+_.getValue('cTel')
			+'&cFixTel='+_.getValue('cFixTel')
			+'&cAddress='+_.getValue('cAddress')
			+'&cArea='+_.getValue('cArea')
			+'&cEmail='+_.getValue('cEmail')
			+'&cInfo='+_.getValue('cInfo')
	;
	
	Ajax('userInfoEdit_team.aspx',{
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
			alert('修改成功');
			break;
		default:
			alert(jso.info)
			break;
	}
}
</script>

<input id="bBuy" class="anniucss" type="button" onclick="return bOK_Click()" value="保存" />
<div id="htm_msg" class="red"></div>
       
        </div>
      </div>
    </div>
    </form>
    	<div class="clear"></div>
	</div>
    <w:bottom id="ucBottom" runat="server" />
   
</body>
</html>
