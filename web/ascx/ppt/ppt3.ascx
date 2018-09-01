<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ppt3.ascx.cs" Inherits="WZ.Web.ascx.ppt.ppt3" %>

<div class="<%=prefix %>">
<div class="<%=prefix %>-pic">
<ul id="<%=prefix %>-pic">

<%foreach (DataRow drw in dtPPT.Rows)
  {%>
    <li><a href="<%=drw["WebURL"] %>" target="_blank"><img alt="<%=drw["PPTName"] %>" <%=imgAttr %> src="<%=GetURL.PPT.Pic(drw["PicB"]) %>" /></a></li>
<%} %>
</ul>
</div>

<div class="<%=prefix %>-trigger">
<ul id="<%=prefix %>-trigger">
<%foreach (DataRow drw in dtPPT.Rows)
  {%>
    <li><a href="<%=drw["WebURL"] %>" target="_blank"><span><%=drw["PPTName"] %></span></a></li>
<%} %>
</ul>
</div>

</div>

<script type="text/javascript">
PPT("<%=prefix %>-pic","<%=prefix %>-trigger",{overCss:"sel"}).exe();
</script>