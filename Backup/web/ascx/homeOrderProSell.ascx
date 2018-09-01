<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="homeOrderProSell.ascx.cs" Inherits="WZ.Web.ascx.homeOrderProSell" %>
<%
              if (dtOrder_SellN1 != null && dtOrder_SellN1.Rows.Count > 0)
              {
                  for (int i=0;i<dtOrder_SellN1.Rows.Count;i++)
                  {
                    DataRow lsdrw = dtOrder_SellN1.Rows[i];
               %>
            <dl>
              <dt class="<%=i==0?"sel":""%>"> <em>￥<%=lsdrw["Price"]%></em> <span><%=i+1 %></span> <a target="_blank" href="<%=GetURL.Pro.Info(lsdrw["ProSN"]) %>"><%=lsdrw["ProName"]%></a></dt>
              <dd style="display:<%=i==0?"":"none"%>"> <a  target="_blank" href="<%=GetURL.Pro.Info(lsdrw["ProSN"]) %>" class="Small-pic"><img src="<%=GetURL.Pro.Pic(lsdrw["PicS"]) %>" width="87" height="76" alt="<%=lsdrw["ProName"]%>" /></a>
                <%--<p class="Red3">￥<%=lsdrw["Price"]%></p>--%>
                <p class="Name">已售：<%=lsdrw["SellN1"]%>件</p>
              </dd>
            </dl>
         <%-- <%
              for (int i=1;i<dtOrder_SellN1.Rows.Count;i++)
              {
                  lsdrw = dtOrder_SellN1.Rows[i];
          %>
            <dl>
              <dt> <em>￥<%=lsdrw["Price"]%></em> <span><%=i+1 %></span> <a href="<%=GetURL.Pro.Info(lsdrw["ProSN"]) %>"><%=lsdrw["ProName"]%></a></dt>
            </dl>--%>
            <%} %>
            
            <%} %>
            
            <script type="text/javascript">
                var tab=
                {
                    div:null,
                    curr:null,
                    css:["sel",""],
                    init:function(){
                        tab.div=_.get("proSelRank");
                        tab.curr=_.getTN("dt",tab.div)[0];
                        
                        tab.div.onmousemove=function(e)
                        {
                            e=e||event;
                            var obj=e.target||e.srcElement;
                            while(obj!=tab.div)
                            {
                                if(obj.tagName=="DT")
                                {
                                    tab.curr.className=tab.css[1];
                                    obj.className=tab.css[0];
                                
                                    tab.hidden(tab.getNext(tab.curr));
                                    tab.show(tab.getNext(obj));
                                    tab.curr=obj;
                                    
                                    break;
                                }
                                obj=obj.parentNode;
                            }
                        }
                    },
                    getNext:function(o)
                    {
                        var oTempObj=o.nextSibling;
	                    while(oTempObj.nodeType!=1&&oTempObj.nextSibling)
		                    oTempObj=oTempObj.nextSibling;
	                    return (oTempObj.nodeType==1)?oTempObj:null;
                    },
                    hidden:function(o)
                    {   
                        o.style.display="none";
                    },
                    show:function(o)
                    {
                        o.style.display="";
                    }
                    
                }
                tab.init();
            </script>