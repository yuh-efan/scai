<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="letterList.aspx.cs" Inherits="WZ.Web.user.letterList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>收到的信 - 搜菜网</title>
    <w:headerUser id="header1" runat="server"></w:headerUser>
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
	<script type="text/javascript">
	function click_del(id)
	{
		if(!confirm('确定删除'))
			return;
			
		var aj=new Ajax(location.href);
		aj.method='post';
		aj.param='hid=1&id='+id;
		
		aj.fnSuccess=function()
		{
			eval('var jso='+this.xmlHttp.responseText);
			
			if(jso.type)
			{
				switch(jso.type)
				{
					case 'success':
						location.href=location.href;
						break;
					
					default:
						alert(jso.info);
						break;
				}
			}
		}
		aj.exe();
	}
	
	function click_show(id)
	{
		floatLayer.src='/floatLayer/user_letterInfo.aspx?id='+id;
		floatLayer.show();
	}
	</script>
</head>
<body>
<w:top id="ucTop" runat="server" />
<w:userLocation id="ucUL" runat="server" Text=" &gt; 收到的信"></w:userLocation>

   	<div class="main">
    	<div class="left">
    <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
    </div>
        <div class="right">
          <div class="User-box p-top">
            <h3><span>收到的信</span></h3>
            <div class="ordertable">
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr bgcolor="#f7f7f7">
            <th>发送人</th>
            <th>标题</th>
            <th>时间</th>
            <th>状态</th>
            <th>操作</th>
          </tr> 
          <w:Rep ID="rpList" runat="server">
          <ItemTemplate>
          <tr>
            <td><%# Eval("FK_User_From").ToString() == "0" ? "系统" : Eval("fromUserName")%></td>
            <td><a href="javascript:click_show(<%# Eval("LetSN") %>)"><%# Eval("Title")%></a></td>
            <td><%#Eval("AddDate")%></td>
            <td><%#kpRead.GetDirc( Eval("IsRead").ToString())%></td>
            <td>
            <a href="javascript:click_show(<%# Eval("LetSN") %>)">查看</a>&nbsp;&nbsp;
            <a href="javascript:click_del(<%# Eval("LetSN") %>)">删除</a>
            </td>
          </tr>
          </ItemTemplate>
          </w:Rep>
        </table>
            </div>
            <!-- 翻页 -->
            <div class="paging"><w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" /></div>
          </div>
        </div>
    	<div class="clear"></div>
    </div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
