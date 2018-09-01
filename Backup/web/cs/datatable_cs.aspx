<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="datatable_cs.aspx.cs" Inherits="WZ.Web.cs.datatable_cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Repeater ID="rpList" runat="server">
    <ItemTemplate>
    <%# ((System.Data.DataRow)Container.DataItem)["Item"]%>
    <br />
    </ItemTemplate>
    </asp:Repeater>
    </div>
    </form>
</body>
</html>
