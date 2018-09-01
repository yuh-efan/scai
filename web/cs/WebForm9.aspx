<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm9.aspx.cs" Inherits="WZ.Web.cs.WebForm9" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
   <script language="javascript" type="text/javascript">  
        function SetText(text) {  
            document.getElementById("lbltext").innerHTML = text;  
        }  
    </script>  
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <label id="lbltext">Hi</label>  
    </div>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="ff" />
    </form>
</body>
</html>
