<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cycleText.ascx.cs" Inherits="WZ.Web.ascx.list.cycleText" %>
<%if (dt == null) return;
  Response.Write(listEvent(dt).ToString());
%>

