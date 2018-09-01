<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="callback.aspx.cs" Inherits="WZ.Web.cs.callback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
 <form id="form1" runat="server" enctype="multipart/form-data">
    <script type="text/javascript">
    function setAttr(pStr)
    {
    __theFormPostData="";
    WebForm_InitCallback();
        <% =this.ClientScript.GetCallbackEventReference(this,"'aa1|'+pStr","callBack","aa")  %>
    }
    
    function callBack(pStr,pContext)
    {
       pContext.innerHTML=pStr;
    }
    
    function aaaaa()
    {
    __theFormPostData="";
    WebForm_InitCallback();
    alert(__theFormPostData);
    }
    
    </script>
    <input name="cTxt" id="cTxt" type="text" value="sss" />
    <br />
    <input type="file" name="cFile" size="30" />
    
    <asp:Button ID="bOK1" runat="server" OnClick="bOK_Click1" Text="提交1" />
    <asp:Button ID="bOK2" runat="server" OnClick="bOK_Click2" Text="提交2" />
    
    <div id="aa"></div>
    
    
    <input type="button" onclick="setAttr('ff')" value="测试" />
    <input type="button" onclick="aaaaa()" value="测试1111" />
   </form>
   
   
</body>
</html>
