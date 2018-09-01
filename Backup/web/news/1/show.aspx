<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="show.aspx.cs" Inherits="WZ.Web.News._1.show" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=d.Eval("Title") %></title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/news.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; <a href='/news/1'>健康快报</a> &gt; " /></div>
<div class="main">
  <div class="news-left">
    <!--新闻基本信息-->
    
    <div class="news-content">
      <h1><%=d.Eval("Source").ToString().Length > 0 ? "[" + d.Eval("Source") + "]" : ""%><%=d.Eval("Title") %></h1>
      <div class="mgs"><%=d.Eval("Source").ToString().Length > 0 ? "来源：" + d.Eval("Source") : d.Eval("Source")%>  时间：<%=d.Eval("EditDate")%></div>
      <div class="news-txt "><%=d.Eval("Detail")%></div>
      
<div style="text-align:center"><span style="color:#f00; display:none" id="htm_msgVote"></span></div>
      
    <table  align="center" cellpadding="0" cellspacing="0" border="0" class="Mood" id="cList">
        
        <tr>
            <asp:Repeater ID="rpVoteList" runat="server">
            <ItemTemplate>
                <td width="80" align="center" valign="bottom"><span str="<%#Eval("Str") %>"></span><span class="show" id="spanJD_<%#Eval("Str") %>">&nbsp;</span><img align="middle" src="/images/news/<%#Eval("PicS") %>" width="50" height="45" alt="<%#Eval("ClassName") %>"  str="<%#Eval("Str") %>" for="radio<%#Container.ItemIndex%>"/><span><%#Eval("ClassName") %></span><span><input type="radio" name="radio" id="radio<%#Container.ItemIndex%>" str="<%#Eval("Str") %>" /></span></td>
            </ItemTemplate>
            </asp:Repeater>
        </tr>
    </table>
    
    </div>
    <script type="text/javascript">
  
function setVote(pMax)
{
	var jso;
	try
	{eval('jso=<%=d.Eval("Vote") %>');}
	catch(e)
	{jso={};}
	
	var objVote=[];
	var tmp=_.getTN("td",_.get("cList"));
	
    for(var i=0;i<tmp.length;i++)
        objVote.push(_.firstChild(tmp[i]))

	var iMax=0;
	for(var i=0;i<objVote.length;i++)
	{
		var curObj=objVote[i];
		var s=curObj.getAttribute('str');
		var s1=Number(jso[s]);
		if(!s1)
			s1=0;
		curObj.innerHTML=s1;
		
		if(s1>iMax)
			iMax=s1;
	}
	
	if(iMax>pMax)
	{
		for(var o in jso)
		{
			var s1=jso[o];
			document.getElementById('spanJD_'+o).style.height=(Number(s1)/iMax*pMax)+'px';
		}
	}
	else
	{
		for(var o in jso)
		{
			var s1=jso[o];
			document.getElementById('spanJD_'+o).style.height=jso[o]+'px';
		}
	}
}
setVote(100);

  _.get("cList").onclick=function(e)
  {
    e=e||event;
    var target=e.target||e.srcElement;
    while(target!==this)
    {
        if(target.tagName=="IMG"||target.tagName=="INPUT")
        {
            if(target.tagName=="IMG")
                _.get(_.attr(target,"for")).checked=true;
                
            var cur=target;
            Ajax("/ajax/newsVote.aspx?id=<%=id%>&s="+_.attr(cur,"str"),{
					method:'post',
					fnSuccess:function(){
						eval('var jso='+this.xmlHttp.responseText)
						
						switch(jso.type)
		                {
			                case 'error':
			                    switch(jso.info)
			                    {
			                        case 'ban':
			                            msg_show('htm_msgVote','已投票');
			                            break;
			                        default:
			                            msg_show('htm_msgVote',jso.info);
			                            break;
			                    }
        						
				                break;
			                case 'success':
				                var str=_.attr(cur,"str")
                                var objN=_.get("spanJD_"+str);
                                objN.style.height=(objN.offsetHeight>=100?100:(objN.offsetHeight+1))+"px";
                                
                                var arrSpan=_.getTN("span",_.get("cList"));
                                for(var i=0;i<arrSpan.length;i++)
                                {
                                    if(_.attr(arrSpan[i],"str")==str)
                                    {
                                        var tmp=arrSpan[i].innerHTML;
                                        arrSpan[i].innerHTML=Number(tmp)?Number(tmp)+1:1;
                                    }
                                }
				                
                                msg_show('htm_msgVote','投票成功');
				                
				                break;
		                }
						
						
//						if(jso.info)
//						{
//							switch(jso.info)
//							{
//								case 'success':
//								
//								    var str=_.attr(cur,"str")
//                                    var objN=_.get("spanJD_"+str);
//                                    objN.style.height=(objN.offsetHeight>=100?100:(objN.offsetHeight+1))+"px";
//                                    
//                                    var arrSpan=_.getTN("span",_.get("cList"));
//                                    for(var i=0;i<arrSpan.length;i++)
//                                    {
//                                        if(_.attr(arrSpan[i],"str")==str)
//                                        {
//                                            var tmp=arrSpan[i].innerHTML;
//                                            arrSpan[i].innerHTML=Number(tmp)?Number(tmp)+1:1;
//                                        }
//                                    }
//									
//									
//                                    alert('投票成功');
//									break;
//								default:
//								    alert(jso.info);
//								    break;
//							}
//						}
//						else 
//						{
//							alert(this.xmlHttp.responseText);
//							alert('非法操作')
//						}
					}
				}).exe();
        }
        target=target.parentNode;
    }
  }
</script>
    <a id="msg_list"></a>
    <div id="comment" runat="server">
        <div style="background:#ebebeb;padding:5px 10px 10px">
         <p style=" color:#000;"><span style="line-height:2em; font-size:14px;font-weight:bold">评论<b><%=lNum%></b>条 <a href="<%=GetURL.News.Msg(id) %>">查看更多评论</a></span></p>
        <div style="background:#f7f7f7">
        <asp:Repeater ID="rpMsgList" runat="server">
        <ItemTemplate>
                <div class="com-left">
                    <h3><span><%#Eval("AddDate")%></span><strong><%# Eval("FK_User").ToString()=="0"?"匿名":Eval("UserName")%></strong>： </h3>
                    <div class="com-txt"><%#Eval("Detail")%></div>
                </div>
        </ItemTemplate>
        </asp:Repeater>
        </div>
        </div>
    </div>
    
    <!--评论-->
    <div class="twLeft">
      <div class="txaAddText">
        <textarea name="content" id="content" style="width:750px">请输入内容。</textarea>
      </div>
      <div class="Sub-box">
        <div class="Sub">
        <span style="color:#f00; display:none" id="htm_msgMsg"></span>
        <input type="button" class="Subinput" onclick="msgSubmit()" /></div>
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
    Ajax('<%=GetURL.News.Info(id.ToString()) %>',{
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
       
       
//			var std=new setTextDef('content');
//			
//			function msgSubmit()
//			{
//				var obj=document.getElementById('content');
//				if((!obj.value) || std.old==obj.value)
//				{
//					alert('请输入内容');
//					return ;
//				}
//				
//				if(XCookie.exists("isOkNewsMessage"))
//				{
//				    alert("您的提交太过频繁，请稍后再提交！");
//				    return;
//				}
//				
//				
//				Ajax("/ajax/newsMsg.aspx?id=<%=id%>",{
//					param:'content='+obj.value,
//					method:'post',
//					fnSuccess:function(){
//						eval('var jso='+this.xmlHttp.responseText)
//						if(jso.info)
//						{
//							switch(jso.info)
//							{
//								case 'nologin':
//									flogin();
//									break;
//								case 'above':
//									alert('不能超出600字');
//									break;
//								case 'success':
//									XCookie.set("isOkNewsMessage","true","secs=10");
//									alert('提交成功');
//									location.href=location.href;
//									break;
//							}
//						}
//						else 
//						{
//							alert(this.xmlHttp.responseText);
//							alert('非法操作')
//						}
//					}
//				}).exe();
//			}
	   </script>
    </div>
  </div>
  <div class="news-right">
    <div class="content-box">
      <h1></h1>
      <ul class="def d_list2">
<w:cycle id="rpList" runat="server" width="122" height="90" />
      </ul>
      <div class="clear"></div>
    </div>
    
  </div>
</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>