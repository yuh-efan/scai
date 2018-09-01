<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cacher.aspx.cs" Inherits="WZ.Web.cs_han.cacher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" method="post" action="../service/cachehandler.ashx">
    <div>
        <input ID="t" name="t" type="text" value="remove_regex">
        <input ID="key" name="key" type="text" />
        
       <input type="submit" value="提交" />
       
       
    </div>
    </form>
    
    
</body>
</html>
