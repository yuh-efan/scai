<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="b.aspx.cs" Inherits="WZ.Web.dzapi.b" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        用户名<asp:TextBox ID="un" runat="server"></asp:TextBox><br />
        密码<asp:TextBox ID="pwd" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" /><br />
    <asp:Button ID="Button3" runat="server" Text="退出" OnClick="Button2_Click" /><br />
    <asp:Button ID="Button2" runat="server" Text="注册" OnClick="Button3_Click" />
    
    </div>
    </form>
</body>
</html>
 