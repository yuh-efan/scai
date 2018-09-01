<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WZ.Web.news._1._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>健康快报</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/news.css" rel="stylesheet" type="text/css" />
    <link href="/style/modBot.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ui.ppt.js"></script>
</head>
<body>
    <w:top id="ucTop" runat="server" />
    <div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 健康快报" /></div>
    <div class="main">
  <div class="box-1">
    <div class="box-left">
      <div class="flashbox" align="center">
        <div id="SwitchBigPic" class="picleft">
          
          <asp:Repeater ID="rpPPTImg" runat="server">
          <ItemTemplate>
          <div><a title="<%#Eval("Title") %>" href="<%#GetURL.News.Info(Container.DataItem) %>" target="_blank"><img class="pic" alt="<%#Eval("Title") %>" 
src="<%#GetURL.News.Pic(Eval("PicB")) %>"></a></div>
          </ItemTemplate>
          </asp:Repeater>
          
        </div>
        <ul id="SwitchNav">
          <asp:Repeater ID="rpPPTList" runat="server">
          <ItemTemplate>
           <li><a href="<%#GetURL.News.Info(Container.DataItem) %>" target="_blank"><strong><%#Eval("Title")%></strong><img 
  src="<%#GetURL.News.Pic(Eval("PicS")) %>"></a> </li>
          </ItemTemplate>
          </asp:Repeater>
        </ul>
      </div>
      
      <script type="text/javascript">
      
        PPT("SwitchBigPic","SwitchNav",{overCss:"selected"}).exe();
		</script>
    </div>
    <div class="box-right">
      <h2></h2>
      <div class="box-main">
        <ul class="box-mainul">
          <asp:Repeater ID="rpHotNO1" runat="server">
           <ItemTemplate>   
                <li><a href="<%#GetURL.News.Info(Container.DataItem) %>" target="_blank" class="Quite-pic"><img src="<%#GetURL.News.Pic(Eval("PicS")) %>" width="110" height="96" alt="<%#Eval("Title") %>" /></a><span><a href="<%#GetURL.News.Info(Container.DataItem) %>" target="_blank" class="Blue"><%#FnData.GetNewsTitle(Container.DataItem)%></a></span>
                <p><b class="Red2"><%#Fn.Left(Fn.ReplaceHTML(Eval("Detail").ToString()),20,"...")%></b></p>
                </li>
           </ItemTemplate>
        </asp:Repeater>
        
        </ul>
        <ul class="box-mainul2">
        <asp:Repeater ID="rpHotList" runat="server">
        <ItemTemplate>
            <li><a href="<%#GetURL.News.Info(Container.DataItem) %>" target="_blank" class="Blue"><%#FnData.GetNewsTitle(Container.DataItem)%></a></li>
        </ItemTemplate>
        </asp:Repeater>
        </ul>
      </div>
      <div class="box-bootom"></div>
    </div>
  </div>
  <div class="box-2" id="newsclass">
    <div class="box2-left">
      <div class="dhooo_tab">
        <ul class="tab_btn" id="newsNav">
          <li class="hot"><a href="?id=17#newsclass" class="list1">美容饮食</a></li>
          <li><a href="?id=18#newsclass" class="list2">食物营养</a></li>
          <li><a href="?id=19#newsclass" class="list3">减肥食品</a></li>
          <li><a href="?id=20#newsclass" class="list4">疾病饮食</a></li>
          <li><a href="?id=21#newsclass" class="list5">饮食禁忌</a></li>
          <li><a href="?id=22#newsclass" class="list6">食物选购</a></li>
        </ul>
        
        <script type="text/javascript">
            function InitNav()
            {
                var id=_.getUrlParam("id");
                var arr=_.getTN("a",_.get("newsNav"))
                if(id)
                { 
                    id=Number(id)-17;
                    if(id>-1&&id<arr.length)
                        arr[id].className+="1";
                    else
                        arr[0].className+="1";
                }
                else
                {
                    arr[0].className+="1";
                }
            }
            InitNav();
        </script>
        
        <div class="tab_main" id="main1">
          <div class="shell">
            <ul id="content1">
              <li>
                <ul>
                <w:cycleText ID="rpList" runat="server" />
                  <li style="border:0">
                 <div class="more"><a href="<%=GetURL.News.Class(id)%>">查看更多资讯....</a></div>
                 </li>
                </ul>
              </li>
             
            </ul>
             
          </div>
        </div>
      </div>
      <script language=javascript src="js/scroll.js" type=text/javascript></script>
    </div>
    <div class="box2-right">
      <div class="Recently-box">
        <h1></h1>
        <div class="def d_list1">
          <ul>
<w:cycle id="rpDJ" runat="server" width="100" height="65" />
          </ul>
          <div class="clear"></div>
        </div>
      </div>
    </div>
    <div class="clear"></div>
  </div>
</div>
    <w:bottom1 id="ucBottom" runat="server" />
</body>
</html>
