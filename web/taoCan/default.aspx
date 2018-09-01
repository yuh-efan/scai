<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WZ.Web.taoCan._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>烹饪课堂</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/columns.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ui.ppt.js"></script>
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
    
</head>
<body>
    <w:top id="ucTop" runat="server" />
    <div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 营养套餐" /></div>
    <div class="main">
  <div class="main">
    <div class="box-tc">
      <div class="box-tcbox">
          <div class="tc-Category">
          
          <asp:Repeater ID="rpClass1" runat="server" onitemdatabound="rpClass1_ItemDataBound">
          <ItemTemplate>
            <dl onmouseover="setChildOver(<%#Eval("ClassSN")%>,this)" onmouseout="setChildOut(<%#Eval("ClassSN")%>,this)"><asp:Label ID="ClassID" runat="server" style="display:none" Text='<%#Eval("ClassSN") %>'></asp:Label>
              <dt ><a href="<%#GetURL.TaoCan.Class(Eval("ClassSN")) %>"><%#Eval("ClassName")%></a></dt>
              <dd style="display:none;" id="childHome<%#Eval("ClassSN")%>">
              <ul>
              <asp:Repeater ID="rpClass2" runat="server">
                <ItemTemplate>
          
                    <li><a href="<%#GetURL.TaoCan.Class(Eval("ClassSN")) %>"><%#Eval("ClassName")%></a></li>
                    
               </ItemTemplate>
              </asp:Repeater>
              </ul>
              </dd>
            </dl>
            
          </ItemTemplate>
          </asp:Repeater>
            <script type="text/javascript">
function setChildOver(str,pThis)
{
    _.get('childHome'+str).style.display='block';
    
    pThis.style.zIndex="888";
    _.getChild(pThis,1).className='loc';
}

function setChildOut(str,pThis)
{
    _.get('childHome'+str).style.display='none';
    //_.get('classDD'+str).className='';
    pThis.style.zIndex="887";
     _.getChild(pThis,1).className='';
}
</script>
            
          </div>
          <div class="promo3">
            <div class="container3" id="idTransformView">
              <w:ppt1 ID="ucPPT1" runat="server" Str="taocan" ImgAttr='width="590" height="273"' Prefix="ppt3_" />
            </div>
          </div>
        <div class="clear"></div>
      </div>
      <div class="box1-right">
        <div class="Seckill">
          <h1></h1>
          <div class="Seckill-main">
            <ul class="tc-center">
                <asp:Repeater ID="rpTJ1" runat="server">
                <ItemTemplate>
                 <li><a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" target="_blank" class="products-pic"><img src="<%#GetURL.TaoCan.Pic(Eval("PicS")) %>" width="123" height="80" alt="<%#Eval("ProName")%>" /></a>
                <div><a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" target="_blank" class="Blue"><%#Eval("ProName")%></a></div>
                 </li>
                </ItemTemplate>
                </asp:Repeater>
            </ul>
          </div>
          <div class="Seckill-bottom"></div>
        </div>
      </div>
    </div>
    <div class="tc-main">
      <h1><a href="#" target="_blank">更多..</a></h1>
      <ul class="tc-center2">
      
      <asp:Repeater ID="rpTJ2" runat="server">
            <ItemTemplate>
                <li> <a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" target="_blank" class="products-pic"><img src="<%#GetURL.TaoCan.Pic(Eval("PicS")) %>" width="220" height="143" alt="<%#Eval("ProName")%>" /></a>
                  <p><span><a href="javascript:;" onclick="AddCart(<%#Eval("ProSN")%>,1,2);" >订购</a></span><a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" target="_blank" class="Blue"><%#Eval("ProName")%></a></p>
                </li>
            </ItemTemplate>
      </asp:Repeater>
      </ul>
      <div class="clear"></div>
    </div>
    <div class="Hot-main">
      <h3><a href="#" target="_blank">更多..</a></h3>
      <ul class="tc-center2">
      
      <asp:Repeater ID="rpJP" runat="server">
            <ItemTemplate>
        <li> <a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" target="_blank" class="products-pic"><img src="<%#GetURL.TaoCan.Pic(Eval("PicS")) %>" width="220" height="143" alt="<%#Eval("ProName")%>" /></a>
          <p><span><a href="javascript:;" onclick="AddCart(<%#Eval("ProSN")%>,1,2);" >订购</a></span><a href="<%#GetURL.TaoCan.Info(Eval("ProSN")) %>" target="_blank" class="Blue"><%#Eval("ProName")%></a></p>
        </li>
        </ItemTemplate>
      </asp:Repeater>
      
      </ul>
      <div class="clear"></div>
    </div>
  </div>
</div>
<w:bottom id="ucBottom" runat="server" />
    
</body>
</html>
