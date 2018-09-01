<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm11.aspx.cs" Inherits="WZ.Web.cs.WebForm11" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript" src="/js/base.js"></script>
    <script type="text/javascript" src="/js/ajax.js"></script>
</head>
<body>
    <form id="form1" method="post" >
        <div>
        <input  id="a1" name="aa" value="10"/>
        <input type="radio" id="a2" name="aa" value="20"/>
        <input type="radio" id="a3" name="aa" value="30"/>
        <input type="radio" id="a4" name="aa" value="40"/>
        <input type="radio" id="a5" name="aa"value="50"/>
        <input type="radio" id="a6" name="aa" value="60"/>
        
        <input type="text" id="a7" name="aa" value="70"/>
        <br />
        <input type="submit" />
        <input type="hidden" name="hid" value="add" />
        
        </div>
    </form>
    
    
    <script type="text/javascript">
    
    var urlJoin={
        form:null,
        urlParam:[],
        ajax:null,
        init:function(pForm)
        {
            urlJoin.form=document.getElementById(pForm)||document.forms[0];
            urlJoin.url=location.href.replace(/[?][\S|\s]*/,"");
            urlJoin.ajax=Ajax(urlJoin.url,{method:"post"});
        },
        
        addUrlParam:function(eleName,val)
        {
            urlJoin.urlParam.push("&{0}={1}".format(eleName,encodeURIComponent(val)));
        },
        getUrlParam:function()
        {
            var count = urlJoin.form.elements.length;
            var element;
            for (var i = 0; i < count; i++) {
                element = urlJoin.form.elements[i];
                var tagName = element.tagName.toLowerCase();
                if (tagName == "input") {
                    var type = element.type;
                    
                    if(type == "text" || type == "hidden" || type == "password"||((type == "checkbox" || type == "radio") && element.checked))
                    {
                        urlJoin.addUrlParam(element.name, element.value);
                    }
                }
                else if (tagName == "select") {
                    var selectCount = element.options.length;
                    for (var j = 0; j < selectCount; j++) {
                        var selectChild = element.options[j];
                        if (selectChild.selected == true) {
                            urlJoin.addUrlParam(element.name, element.value);
                        }
                    }
                }
                else if (tagName == "textarea") {
                    urlJoin.addUrlParam(element.name, element.value);
                }
            }
            
            return urlJoin.urlParam.join("");
            //var str=urlJoin.urlParam.join("");
            //return urlJoin.url+str.replace(/^&/,"?");
        },
        exe:function()
        {
            urlJoin.ajax.param=urlJoin.getUrlParam();
            urlJoin.ajax.fnSuccess=function()
            {
                alert(this.xmlHttp.responseText);
            }
            urlJoin.ajax.exe();
        }
    }
    urlJoin.init();
    urlJoin.exe();
    </script>
</body>
</html>
