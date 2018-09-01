<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WZ.Web.basket._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>菜篮子专栏</title>
    <w:header id="header" runat="server"></w:header>
    <link href="/css/columns.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/ui.ppt.js"></script>
</head>
<body>
    <w:top id="ucTop" runat="server" />
    <div class="current"><w:CurrentPath ID="curPath" runat="server" Text=" &gt; 菜篮子专栏" /></div>
    <div class="main">
  <div class="left">
    <div class="Category-box">
      <h1></h1>
      <div class="tc-Category">
            <%=pageClass.ToString()%>
      </div>
      
      <script type="text/javascript">
function setChildOver(str,pThis)
{
    _.get('childHome'+str).style.display='block';
    
    pThis.style.zIndex="62";
    _.getChild(pThis,0).className='loc';
}

function setChildOut(str,pThis)
{
    _.get('childHome'+str).style.display='none';
    //_.get('classDD'+str).className='';
    pThis.style.zIndex="61";
     _.getChild(pThis,0).className='';
}
</script>
      <div class="clear"></div>
    </div>
    <div class="Recently-box">
      <h1></h1>
      <div class="def d_list4">
        <ul>
<w:cycle id="rpNewSell" runat="server" width="60" height="39" />
        </ul>
        <div class="clear"></div>
      </div>
    </div>
  </div>
  <div class="right">
  
  <div class="box-1">
  <div class="box-left2">
      <div class="promo2">
        <div class="container2" id="idTransformView">
        <w:ppt1 ID="ucPPT1" runat="server" Str="cailangzi" ImgAttr='width="270" height="275"' Prefix="ppt2_" />
             
            </div>
        </div>
    </div>
  <div class="clz-right">
      <h2><img src="/images/clz_01.gif" width="137" height="31" alt="超值疯抢" /></h2>
      <div class="def d_list1">
        <ul>
        <w:cycle id="rpTJ" runat="server" width="110" height="96" />
        </ul>
      </div>
    </div>
  </div>
  
    <div class="claz-main">
      <h1><a href="/search/product.aspx?s=-------1" target="_blank">更多..</a></h1>
      <div class="clz-box">
          <div class="pre">
          <div class="def d_list2">
          <ul>
          <%
              if (dtCLZ != null && dtCLZ.Rows.Count > 0)
              {
                  int j = 0;
                  foreach (DataRow lsdrw in dtCLZ.Rows)
                  {
                      j++;
                      if (j > 2)
                          break;
                   %>
                   
                <li><a href="<%=GetURL.Pro.Info(lsdrw["ProSN"]) %>" class="d-pic" target="_blank"><img src="<%=GetURL.Pro.Pic(lsdrw["PicS"]) %>" width="165" height="124" alt="<%=lsdrw["ProName"]%>" /></a>
                  <div class="d-name"><a href="<%=GetURL.Pro.Info(lsdrw["ProSN"]) %>" target="_blank"><%=lsdrw["ProName"]%></a></div>
                  <div>搜菜价：<span class="d-price">￥<%=lsdrw["Price"]%></span></div>
                </li>
                <%}
              }%>
                
            </ul>
          
          </div>
          <ul class="def d_list3">
          
          <%
              if (dtCLZ != null && dtCLZ.Rows.Count > 0)
              {
                  for (int i = 2; i < dtCLZ.Rows.Count; i++)
                  {
                      DataRow lsdrw = dtCLZ.Rows[i];
              %>
            <li> <a href="<%=GetURL.Pro.Info(lsdrw["ProSN"]) %>" class="d-pic" target="_blank"><img src="<%=GetURL.Pro.Pic(lsdrw["PicS"]) %>" width="107" height="80" alt="<%=lsdrw["ProName"]%>" /></a>
              <div class="d-name"><a href="<%=GetURL.Pro.Info(lsdrw["ProSN"]) %>" target="_blank"><%=lsdrw["ProName"]%></a></div>
              <div>搜菜价：<span class="d-price">￥<%=lsdrw["Price"]%></span></div>
            </li>
            <%}
              } %>
           
          </ul>
          </div>
      <div class="clear"></div>
      </div>
      
    </div>
    <div class="claz-main">
      <h2><a href="/search/product.aspx?s=-------2" target="_blank">更多..</a></h2>
      <div class="clz-box">
      <div class="pre">
      <div class="def d_list2">
      <ul>
            <%
                if (dtSJ != null && dtSJ.Rows.Count > 0)
          {
                    int j = 0;
              foreach (DataRow lsdrw in dtSJ.Rows)
              {
                  j++;
                  if (j > 2)
                      break;
                    
              
               %>
               
            <li><a href="<%=GetURL.Pro.Info(lsdrw["ProSN"]) %>" class="d-pic" target="_blank"><img src="<%=GetURL.Pro.Pic(lsdrw["PicS"]) %>" width="165" height="124" alt="<%=lsdrw["ProName"]%>" /></a>
              <div class="d-name"><a href="<%=GetURL.Pro.Info(lsdrw["ProSN"]) %>" target="_blank"><%=lsdrw["ProName"]%></a></div>
              <div>搜菜价：<span class="d-price">￥<%=lsdrw["Price"]%></span></div>
            </li>
            <%}} %>
        </ul>
      
      </div>
      <ul class="def d_list3">
      
       <%
           if (dtSJ != null && dtSJ.Rows.Count > 0)
          {
              for (int i = 2; i < dtSJ.Rows.Count; i++)
              {
                  DataRow lsdrw = dtSJ.Rows[i];
          %>
        <li> <a href="<%=GetURL.Pro.Info(lsdrw["ProSN"]) %>" class="d-pic" target="_blank"><img src="<%=GetURL.Pro.Pic(lsdrw["PicS"]) %>" width="107" height="80" alt="<%=lsdrw["ProName"]%>" /></a>
          <div class="d-name"><a href="<%=GetURL.Pro.Info(lsdrw["ProSN"]) %>" target="_blank"><%=lsdrw["ProName"]%></a></div>
          <div>搜菜价：<span class="d-price">￥<%=lsdrw["Price"]%></span></div>
        </li>
        <%}
          } %>
      </ul>
      </div>
      <div class="clear"></div>
      </div>
      
    </div>
  </div>
</div>
    <w:bottom id="ucBottom" runat="server" />
</body>
</html>
