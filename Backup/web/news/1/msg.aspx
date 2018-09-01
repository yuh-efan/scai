<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="msg.aspx.cs" Inherits="WZ.Web.news._1.msg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title>健康快报-<%=title %>-评论</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/news.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; <a href='/news/1'>健康快报</a> &gt; {0} &gt; 评论" /></div>
<div class="main">
  <div class="Commentary">
    <h1><%=title %><a href="<%=GetURL.News.Info(id.ToString())%>" >[查看原文]</a></h1>
    <div class="msg">本评论仅代表网友个人观点，不代表搜菜网观点</div>
  </div>
    <a id="msg_list"></a>
  
  <div class="reviews">
    <div class="msg_title">对“<strong><%=title %></strong>”的评论</span> </div>
    <div class="comment">
     
      <div class="Commentary-left" id="htmMsgList">
      
        <div id="comment" runat="server">
        <h1> 网友评论数 <span>（共<b><%=lNum %></b>条）</span> </h1>
        <asp:Repeater ID="rpMsgList" runat="server">
        <ItemTemplate>
                <div class="com-left width2">
                    <h3><span><%#Eval("AddDate")%></span><strong><%# Eval("FK_User").ToString()=="0"?"匿名":Eval("UserName")%></strong>： </h3>
                    <div class="com-txt"><%#Eval("Detail")%></div>
                </div>
        </ItemTemplate>
        </asp:Repeater>
        
        <div class="paging">
              <w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" Style="ajax_style_1" />
        </div>
        </div>
        
      <div class="twLeft2">
      <div class="twLeft2-text"></div>
      <div class="txaAddText2">
        <textarea name="content" id="content">请输入内容。</textarea>
      </div>
      
      <div class="Sub-box">
        <div class="Sub">
        <span style="color:#f00; display:none" id="htm_msgMsg"></span>
        <input name="" type="button" class="Subinput" onclick="msgSubmit()" /></div>
      </div>
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

    Ajax("/ajax/newsMsg.aspx?id=<%=id%>",{
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
                        msg_show('htm_msgMsg','提交成功。');
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
           
       <div class="Commentary-right">
            	<h2>热门评论</h2>
                <ul class="Commentary-mainul2">
                
                <asp:Repeater ID="rpHot" runat="server">
                <ItemTemplate>
                <li><a href="<%#GetURL.News.Info(Container.DataItem) %>" target="_blank" class="Blue"><%#FnData.GetNewsTitle(Container.DataItem)%></a></li>
                </ItemTemplate>
                </asp:Repeater>
          
        </ul>
            </div>

      <div class="clear"></div>
    </div>
  </div>
</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
