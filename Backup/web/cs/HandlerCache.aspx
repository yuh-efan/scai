<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandlerCache.aspx.cs" Inherits="WZ.Web.cs.HandlerCache" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <input id="Submit1" type=submit OnServerClick="AddItemToCache" value="Add Item To Cache" runat="server"/>
   <input id="Submit2" type=submit OnServerClick="RemoveItemFromCache" value="Remove Item From Cache" runat="server"/>
<%
    if (itemRemoved)
    {
        Response.Write("RemovedCallback event raised.");
        Response.Write("<BR>");
        Response.Write("Reason: <B>" + reason.ToString() + "</B>");
    }
    else
    {
        Response.Write("Value of cache key: <B>" + Server.HtmlEncode(Cache["Key1"] as string) + "</B>");
       
    }
     %>
    </div>
    </form>
</body>
</html>
