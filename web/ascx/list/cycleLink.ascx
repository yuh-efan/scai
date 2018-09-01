<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cycleLink.ascx.cs" Inherits="WZ.Web.ascx.list.cycleLink" %>
<%if (dt == null) return;
  Response.Write(listEvent(dt, li).ToString());
%>