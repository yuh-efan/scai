<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default1.aspx.cs" Inherits="WZ.Web.caiPu._default1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>烹饪课堂</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/columns.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ui.ppt.js"></script>
</head>
<body>
<w:top id="ucTop" runat="server" />
<div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 烹饪课堂" /></div>
   <div class="main">
  <div class="box-1">
    <div class="box-left">
      <div class="promo">
            <div class="container" id="idTransformView">
                <w:ppt1 ID="ucPPT1" runat="server" Str="caipu" ImgAttr='width="680" height="275"' Prefix="ppt1_" />
            </div>
          </div>
    </div>
    <div class="box-right">
      <h2></h2>
      <div class="def d_list5">
        <ul>
 <w:cycle id="rpTeJja" runat="server" width="110" height="96" detailN="32" />

        </ul>
      </div>
      <div class="box-bootom"></div>
    </div>
  </div>
  <div class="left">
    <div class="Category-box">
      <h2></h2>
       <div class="Category">
      <%=pageClass.ToString()%>
      </div>
      <div class="clear"></div>
    </div>
    <div class="Recently-box">
      <h2></h2>
      <div class="def d_list4">
        <ul>
<w:cycle id="rpNewEval" runat="server" width="60" height="39" />
        
        </ul>
        <div class="clear"></div>
      </div>
    </div>
  </div>
  <div class="right">
    <div class="Hot-main">
      <h1></h1>
      <ul class="def d_list6">
      
        <w:cycle id="rpTJ" runat="server" width="230" height="150" />

      </ul>
      <div class="clear"></div>
    </div>
    <div class="Hot-main">
      <h2></h2>
      <ul class="def d_list6">
        <w:cycle id="rpJingPin" runat="server" width="230" height="150" />

        
      </ul>
      <div class="clear"></div>
    </div>
  </div>
</div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
