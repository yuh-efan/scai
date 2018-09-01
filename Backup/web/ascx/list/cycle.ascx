<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cycle.ascx.cs" Inherits="WZ.Web.ascx.list.cycle" %>
<%if (dt == null) return;
  Response.Write(listEvent(dt, li).ToString());
%>

