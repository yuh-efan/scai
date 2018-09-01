<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="msgList.aspx.cs" Inherits="WZ.Web.caiPu.msgList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>咨询列表</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/news.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    <style type="text/css">
.comment { padding:10px ; color:#999; background:#f7f7f7; margin-bottom:0;}
.Reply2 { background:url(/images/products_bg.gif) no-repeat;}
.Reply2 { float:left; display:block; width:40px; height:20px; background-position:-110px -102px;}
.com-txt { padding:5px 0 10px 10px; color:#666;}
.twLeft h4 { height:25px; background:url(images/fbpj.gif) no-repeat 0 -25px;}
.Commentary-left { float:left; width:920px; }
.com-left { width:900px; padding:10px 10px 0 10px; border-bottom:#ddd solid 1px;}
</style>
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" > 咨询列表" /></div>
<div class="main">
  <div class="Commentary">
    <h1><%=d.Eval("ProName") %><a href="<%=GetURL.CaiPu.Info(id) %>" target="_blank">[查看商品]</a></h1>
    <div class="msg">本评论仅代表网友个人观点，不代表搜菜网观点</div>
  </div>
  <div class="reviews">
    <a id="msg_list"></a>
    
    <div class="comment">
      <div class="Commentary-left">
      
      <div id="comment" runat="server">
      <h1> 全部咨询 <span>(共<b><%=cou%></b>条)</span> </h1>
     <w:Item ID="rpList" runat="server">
        <ItemTemplate>
        
        <div class="com-left">
          <h3><span><%# Eval("AddDate")%></span><strong><%# Eval("UserName").ToString().Length == 0 ? "匿名" : Eval("UserName")%></strong>：</h3>
          <div class="com-txt"><%# Eval("Detail")%>
          	<div class="Replymain" <%#Eval("ReDetail").ToString().Length>0?"":"style=\"display:none\"" %>>
            	<h4></h4>
                <div class="com-txt"><span class="Reply2"></span><%# Eval("ReDetail")%></div>
            </div>
          </div>
        </div>
        
       </ItemTemplate>
      </w:Item>
      
      <div class="paging">
      <w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" Style="ajax_style_1" />
</div>
      </div>

       <div class="twLeft">
      <h4></h4>
      <div class="txaAddText">
        <textarea id="content" name="content" cols="" rows="">请输入内容。</textarea>
      </div>
      <div class="Sub-box">
        <div class="Sub">
        <span style="color:#f00; display:none" id="htm_msgMsg"></span>
        <input name="contentOK" type="button" class="Subinput" onclick="msgSubmit()" />
        <script type="text/javascript">
			var std=new setTextDef('content');
			
			function msgSubmit()
			{
				var obj=_.get('content');
				if((!obj.value) || std.old==obj.value)
				{
			        msg_show('htm_msgMsg','请输入内容。');
					return;
				}
				
				Ajax("/ajax/caiPuMsg.aspx?id=<%=id%>&t=1",{
					param:'content='+obj.value,
					method:'post',
					fnSuccess:function(){
						eval('var jso='+this.xmlHttp.responseText)
						
							switch(jso.type)
							{
								case 'nologin':
									flogin();
									break;
								case 'error':
			                        switch(jso.info)
			                        {
			                            case 'above':
			                                msg_show('htm_msgMsg','不能超出600字。');
			                                break;
			                            case 'ban':
			                                msg_show('htm_msgMsg','您的提交太过频繁，隔几秒再试！');
			                                break;
			                            default:
			                                msg_show('htm_msgMsg',jso.info);
			                                break;
			                        }
            						
				                    break;
								case 'success':
								    getMsg();
								     msg_show('htm_msgMsg',"提交成功");
								     
									obj.value='';
									obj.focus();
									break;
							}
					}
				}).exe();
			}
			
function ajaxPage(pCmd,pPageIndex)
{
    Ajax('<%=Request.Url %>',{
	param:'hid=1&cmd='+pCmd+'&ajax_page='+pPageIndex,
	method:'post',
	fnSuccess:function(){
		_.get('comment').innerHTML=this.xmlHttp.responseText;
		_.get('msg_list').scrollIntoView();
		}
    }).exe();
}

function getMsg()
{
    ajaxPage('ajax_page_msg',1);
}

function msg_show(pName,pMsg)
{
    _.get(pName).style.display='';
    _.get(pName).innerHTML=pMsg;
}			
		</script>
        </div>
      </div>
    </div>
      </div>
      <div class="clear"></div>
      
    </div>
  </div>
</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
