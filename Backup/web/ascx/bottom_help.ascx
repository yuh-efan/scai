<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bottom_help.ascx.cs" Inherits="WZ.Web.ascx.bottom_help" %>
<div class="helpIntro">
      <div class="Tel"></div>
      <div class="help">
        <ul>
        <%=GetList("xssl") %>
        </ul>
        <ul>
        <%=GetList("rhfk") %>
        </ul>
        <ul>
        <%=GetList("psfs")%>
          
        </ul>
        <ul>
        <%=GetList("yhzx") %>
          
        </ul>
        <ul class="helpAbout">
        <%=GetList("gywm") %>
        </ul>
      </div>
      <div class="clear"></div>
</div>