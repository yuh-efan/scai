<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="email_cs.aspx.cs" Inherits="WZ.Web.cs.email_cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        收件人<asp:TextBox ID="toMail" runat="server" Text="304902140@qq.com" />
        <br />
        主题<asp:TextBox ID="title" runat="server" />
        <br />
        内容<asp:TextBox ID="detail" runat="server" />
        <br />
        <asp:Button ID="Button1" runat="server"
            Text="Button" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>
