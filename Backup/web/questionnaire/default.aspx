<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WZ.Web.questionnaire._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title>搜菜网-客户调查</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/news.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    <script type="text/javascript" src="/js/xcookie.js"></script>
    <style type="text/css">
    .comment { padding:10px ; color:#999; background:#f7f7f7; margin-bottom:0;}
    .Reply2 { background:url(/images/products_bg.gif) no-repeat;}
    .Reply2 { float:left; display:block; width:40px; height:20px; background-position:-110px -102px;}
    .com-txt { padding:5px 0 10px 10px; color:#666;}
    .twLeft {padding-top:0 }
    .twLeft h4 { height:25px; background:url(/images/fbpj.gif) no-repeat;}
    .Commentary-left { float:left; width:920px; }
    .com-left { width:100%; padding:10px 10px 0 10px; border-bottom:#ddd solid 1px;}
	.Sub-box{width:940px;}
    .Sub { float:right; text-align:right; padding-top:10px;}
    .comment { padding:10px; color:#999; background:#fff; margin-bottom:15px;}
    .Commentary { padding-bottom:3px; padding-top:0;}
    /*   结果 css   */
    .Finally { float:left; width:650px;}
	    .Finally h1 { height:30px; background:url(/images/Inves.gif) no-repeat; margin:10px 0;}
	    .Finallymian h2 { height:30px; line-height:30px; font-size:14px; font-weight:bold;}
	    .Finallymian li { height:25px; padding-top:5px; padding-left:10px;}

        /*新加*/
        .Finallymian div{width:0px;height:20px;background-color:red; font-size:0px; float:left}
        .Finallymian .paddL5{padding-left:5px;}


    /*   客户调查 css   */
	    .Investigation { float:right; width:280px; border:#e2e2e2 solid 1px; padding:10px;}
	    .Investigation h1 { background:url(/images/index/box3.gif) no-repeat; background-position:0 -62px; height:23px; padding-top:8px; border-bottom:#e2e2e2 solid 1px; text-align:right;}
		    .Inve-main { padding:10px;}
		    .Inve-main h2 { height:26px; line-height:26px; font-weight:bold;}
		    .Inve-main ul { padding-top:3px;}
			    .Inve-main li { padding-bottom:5px;}
				    .Inve-main li input { vertical-align:middle; margin-right:3px;}
		    .Inve-main .suntj { width:80px; height:22px; background:url(/images/index/box3.gif) no-repeat; background-position:0 -96px; border:0;}
		.txaAddText{padding:0}
		.txaAddText textarea{width:100%}
    </style>
</head>
<body>
    <w:top id="ucTop" runat="server" />
    <div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 客户调查" /></div>
   <div class="main">
  <div class="Commentary">
  <div class="Finally">
  	<h1></h1>
    <div class="Finallymian">
    	<h2><%=QuName%></h2>
        <table id="voteN" cellpadding="0" cellspacing="0" border="0">
    	<asp:Repeater ID="rpVoteN" runat="server">
    	<ItemTemplate>
    	<tr>
    	<td height="30"><span><%#Eval("VoteName")%>：</span></td>
    	<td><div id="a_<%#Eval("VoteSN") %>" total="<%#Eval("Total") %>"></div><span class="paddL5" id="s_<%#Eval("VoteSN") %>"><%#Eval("Total")%></span></td>
    	</tr>
    	</ItemTemplate>
        </asp:Repeater>
    	</table>
        <script type="text/javascript">
        function setVote(pMax)
        {
            var arr= _.getTN("div",_.get("voteN"));
            var a=[];
            for(var i=0;i<arr.length;i++)
            {
                a.push(_.attr(arr[i],"total"));
            }
            
            var iMax=Math.max.apply(null,a);
            
            
            for(var i=0;i<arr.length;i++)
            {
                if(iMax>pMax)
                    arr[i].style.width=(Number(a[i])/iMax*pMax)+'px';
                else
                    arr[i].style.width=a[i]+'px';
            }
        }
        setVote(200);
        </script>
    </div>
  </div>
  <div class="Investigation">
      	<h1></h1>
        <div class="Inve-main">
        	<h2><%=QuName%></h2>
            <ul>
            <w:Item ID="rpVote" runat="server">
            <ItemTemplate>
            	<li><input name="cVote" id="cVote<%#Eval("VoteSN") %>" type="<%=ShowType %>" value="<%#Eval("VoteSN") %>" />
            	<label for="cVote<%#Eval("VoteSN") %>"><%#Eval("VoteName")%></label>
            	</li>
            </ItemTemplate>
            </w:Item>
            </ul>
           
              <div><input name="cVoteOK" type="button" class="suntj" onclick="voteSubmit()" value="提交" />
              <span id="msgsuc" style="color:#f00;display:none"></span>
              </div>
            
        </div>
      </div>
      <div class="clear"></div>
  </div>
  <a id="msg_list"></a>
  <div class="reviews" id="locate">
   
    <div class="comment">
      <div class="Commentary-left">
      
<div id="comment" runat="server">
 <h1> 网友评论数 <span>（共<b><%=lNum %></b>条）</span> </h1>
    <asp:Repeater ID="rpList" runat="server">
    <ItemTemplate>
    <div class="com-left">
        <h3><span><%#Eval("AddDate")%></span><strong><%#Eval("UserName").ToString() == "" ? "匿名" : Eval("UserName")%></strong>： </h3>
        <div class="com-txt"><%#Eval("Detail")%></div>
    </div>
    </ItemTemplate>
    </asp:Repeater>
    <div class="paging"><w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" Style="ajax_style_1" /></div>
</div>

       <div class="twLeft">
      <h4></h4>
      <div class="txaAddText">
        <textarea name="content" id="content" cols="" rows="">欢迎您对该产品提问咨询。同时，我们不欢迎任何违反国家法律法规和攻击他人的言论，并有权随时删除。</textarea>
      </div>
      <div class="Sub-box">
        <div class="Sub">
        <span id="htm_msg_comment" style="color:#f00;display:none"></span>
        <input type="button" class="Subinput" onclick="msgSubmit()" /></div>
      </div>
<script type="text/javascript">
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

//投票
function voteSubmit()
{
    var obj=document.getElementsByName('cVote');
    var s='';
	for(var i=0;i<obj.length;i++)
	{
		if(obj[i].checked)
	    	s+=obj[i].value+',';
    }
    
	var param='cVote='+_.getValue('cVote')

	Ajax("/ajax/vote.aspx?id=<%=QuSN%>",{
		param:param,
		method:'post',
		fnSuccess:function(){
			eval('var jso='+this.xmlHttp.responseText)
			switch(jso.type)
            {
	            case 'success':
		            _.get('msgsuc').style.display='';
		            _.get('msgsuc').innerHTML='投票成功，感谢您的参与。';
		            
		            var a=s.split(",");
					a.length=a.length-1;
					for(var i=0;i<a.length;i++)
					{
					    var obj;
					    obj= _.get("a_"+a[i]);
					    obj.style.width=(obj.offsetWidth>=200?200:(obj.offsetWidth+1))+"px";
					    
					    obj= _.get("s_"+a[i]);
					    obj.innerHTML=Number(obj.innerHTML)+1;
					}
		            break;
				
	            default:
		            _.get('msgsuc').style.display='';
		            _.get('msgsuc').innerHTML=jso.info;
		            break;
            }
		}
	}).exe();
}

var std=new setTextDef('content');
//评论
function msgSubmit()
{
	var obj=_.get('content');
	if((!obj.value) || std.old==obj.value)
	{
	    msg_show('htm_msg_comment','请输入内容。');
		return ;
	}
	
	Ajax("/ajax/vote.aspx?id=<%=QuSN%>&t=1",{
		param:'content='+obj.value,
		method:'post',
		fnSuccess:function(){
			eval('var jso='+this.xmlHttp.responseText)
		    switch(jso.type)
            {
                case 'success':
                    msg_show('htm_msg_comment','评论成功，感谢您的参与。');
                    getMsg();
                    obj.value='';
					obj.focus();
                    break;
                    
                case 'error':
	                switch(jso.info)
	                {
	                    case 'above':
	                        msg_show('htm_msg_comment','不能超出600字。');
	                        break;
	                    case 'ban':
	                        msg_show('htm_msg_comment','您的提交太过频繁，隔几秒再试！');
	                        break;
	                    default:
	                        msg_show('htm_msg_comment',jso.info);
	                        break;
	                }
		            break;
				
                default:
                    msg_show('htm_msg_comment',jso.info);
                    break;
            }
		}
	}).exe();
}
	   </script>
    </div>
      </div>
      <div class="clear"></div>
    </div>
  </div>
</div>
   <w:bottom id="ucBottom" runat="server" />
</body>
</html>
