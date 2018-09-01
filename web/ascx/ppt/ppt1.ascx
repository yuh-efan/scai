<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ppt1.ascx.cs" Inherits="WZ.Web.ascx.ppt.ppt1" %>
<ul class="<%=prefix %>img" id="<%=prefix %>img">

<%foreach (DataRow drw in dtPPT.Rows)
  {%>
    <li><a href="<%=drw["WebURL"] %>" target="_blank"><img alt="<%=drw["PPTName"] %>" <%=imgAttr %> src="<%=GetURL.PPT.Pic(drw["PicB"]) %>" /></a></li>
<%} %>
</ul>

<ul class="<%=prefix %>num" id="<%=prefix %>num">
<%for (int i = 1; i <= dtPPT.Rows.Count;i++ )
  {%>
    <li><%=i%></li>
<%} %>
</ul>

<script type="text/javascript">
PPT("<%=prefix %>img","<%=prefix %>num",{path:1}).exe();
</script>