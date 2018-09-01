<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="findPwd.aspx.cs" Inherits="WZ.Web.email.findPwd" %>
<html>
<body>
<%=uq.GetQueryString(0)%>,您好！<br />
<br />
感谢你使用搜菜网(www.souc.cn)，点击下面的链接即可修改密码：
<br /><br /><br />
        <a href="<%=ConfigInfo.WebURL %>user/findPwd2.aspx?s=<%=uq.ToString() %>"><%=ConfigInfo.WebURL %>user/findPwd2.aspx?s=<%=uq.ToString() %></a>
        <br />
        (如果链接无法点击，请将它拷贝到浏览器的地址栏中。)
<a href="<%=ConfigInfo.WebURL %>" target="_blank">点击进入搜菜网</a>
</body>
</html>
