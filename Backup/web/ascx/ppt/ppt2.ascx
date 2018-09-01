<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ppt2.ascx.cs" Inherits="WZ.Web.ascx.ppt.ppt2" %>
<ul class="<%=prefix %>img" id="<%=prefix %>img">

<%foreach (DataRow drw in dtPPT.Rows)
  {%>
    <li><a href="<%=drw["WebURL"] %>" target="_blank"><img alt="<%=drw["PPTName"] %>" <%=imgAttr %> src="<%=GetURL.PPT.Pic(drw["PicB"]) %>" /></a></li>
<%} %>
</ul>

<ul class="<%=prefix %>num" id="<%=prefix %>num">
<%foreach (DataRow drw in dtPPT.Rows)
  {%>
    <li><%=drw["PPTName"] %></li>
<%} %>
</ul>

<script type="text/javascript">
PPT100("<%=prefix %>img","<%=prefix %>num",{overCss:"sel"}).exe();
</script>