<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="evaluateList.aspx.cs" Inherits="WZ.Web.taoCan.evaluateList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>评价列表</title>
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
.star { float:right;}
.Commentary-left { float:left; width:920px; }
.com-left { width:900px; padding:10px 10px 0 10px; border-bottom:#ddd solid 1px;}
</style>
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" > 评价列表" /></div>
<div class="main">
  <div class="Commentary">
    <h1><%=d.Eval("ProName") %><a href="<%=GetURL.TaoCan.Info(id) %>" target="_blank">[查看商品]</a></h1>
    <div class="msg">本评论仅代表网友个人观点，不代表搜菜网观点</div>
  </div>
  <div class="reviews">
    <h1> 全部评价 <span>(共<b><%=cou %></b>条)</span> </h1>
    <div class="comment">
      <div class="Commentary-left">
 
        <w:Item ID="rpList" runat="server">
        <ItemTemplate>
           <div class="com-left">
              <h3><p class="star"><%#Eval("Fraction")%></p>
              <span><%# Eval("AddDate")%></span><%# Eval("FK_User").ToString() == "0" ? "匿名：" : Eval("UserName").ToString() + " 说："%> </h3>
              <div class="com-txt"><%# Eval("Detail")%>
          	    <div class="Replymain" <%#Eval("ReDetail").ToString().Length>0?"":"style=\"display:none\"" %>>
            	    <h4><strong class="Reply2"></strong></h4>
                    <div class="com-txt"><%# Eval("ReDetail")%></div>
                </div>
              </div>
            </div>
        </ItemTemplate>
        </w:Item>
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

<div class="paging">
      <w:Paging_Show runat="server" id="ucPS1" IsShowJump="false" />
</div>

 <div class="twLeft">

    <div id="selStar" style="width:80px; height:13px;background:url('/images/star.gif');position:relative; margin-left:80px;">
            <span style="width:48px; display:inline-block; height:100%;background:url('/images/star1.gif')"></span>
            <input type="hidden" id="starHidden" value="3" />
          </div>
          
<script type="text/javascript">
(function(){
	window.stars={
		objS:"selStar",
		init:function()
		{
			stars.obj=_.get(stars.objS)
			stars.N=3;//初始化时3颗星
			stars.cObj=_.firstChild(stars.obj);
			
			stars.obj.onmousemove=function(e){
				e=e||event;
				var x=e.layerX||e.offsetX;
				stars.temp=Math.ceil(x/16);
				stars.cObj.style.width=stars.temp*16+"px";
			};
			stars.obj.onmouseout=function(){
				stars.cObj.style.width=stars.N*16+"px";
			};
			stars.obj.onclick=function(){
				stars.N=stars.temp;
				_.get('starHidden').value=stars.N;
			}
		}
	}
})();
stars.init();
</script>

      <div class="txaAddText">
        <textarea id="evalContent" name="evalContent" cols="" rows="">欢迎您对该产品提问咨询。同时，我们不欢迎任何违反国家法律法规和攻击他人的言论，并有权随时删除。</textarea>
      </div>
      <div class="Sub-box">
        <div class="Sub">
        <input name="evalOK" type="button" class="Subinput" onclick="evalSubmit()" />
        
<script type="text/javascript">
			var evalText=new setTextDef('evalContent');
			
			function evalSubmit()
			{
				var obj=_.get('evalContent');
				if((!obj.value) || evalText.old==obj.value)
				{
					alert('请输入内容');
					return ;
				}
				
				Ajax("/ajax/taoCanEvaluate.aspx?id=<%=id%>&t=1&star="+_.get('starHidden').value,{
					param:'content='+obj.innerHTML,
					method:'post',
					fnSuccess:function(){
						
						eval('var jso='+this.xmlHttp.responseText)
						if(jso.info)
						{
							switch(jso.info)
							{
								case 'above':
									alert('不能超出600字');
									break;
								case 'success':
									alert('提交成功');
									obj.innerHTML='';
									obj.focus();
									break;
								
							}
						}
						else 
						{
							alert(this.xmlHttp.responseText);
							alert('非法操作')
						}
						}
				}).exe();
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
