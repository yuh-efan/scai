<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm13.aspx.cs" Inherits="WZ.Web.cs.WebForm13" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript" src="/js/base.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   
   <span id="d"></span><br />
   <span id="h"></span><br />
   <span id="m"></span><br />
   <span id="s"></span>
    </form>
</body>
<script type="text/javascript">
var TO={
    loop:null,
    startN:0,
    endN:0,
    startTime:null,
    endTime:null,
    isShow:false,//是否显示
    showObj:{d:"d",h:"h",m:"m",s:"s"},
    fnSuccess:function(){},
    init:function(startS,endS,obj)
    {
        TO.startN=Date.parse(startS.replace(/-/g,"/"));
        TO.endN=Date.parse(endS.replace(/-/g,"/"));
        
        TO.startTime=new Date(TO.startN);
        TO.endTime=new Date(TO.endN);
        if (obj)
            TO.showObj=obj;           
    },
    handle:function()
    {
        TO.startN+=1000;
        TO.isShow?TO.show():null;
    },
    show:function()
    {
        TO.startTime=new Date(TO.startN);
        var nMS=TO.endTime-TO.startTime;
        if(nMS<=0)
        {
            clearInterval(TO.loop);
            //时间到处理程序
            TO.fnSuccess();
            return ;
        }
        var tt={
            d:Math.floor(nMS/(1000 * 60 * 60 * 24)),
            h:Math.floor(nMS/(1000 * 60 * 60)) % 24,
            m:Math.floor(nMS/(1000*60)) % 60,
            s:Math.floor(nMS/1000) % 60
        }
        if(!_.get(TO.showObj.d))
        {
            tt.h=tt.h+(24*tt.d)
        }
        for(var obj in TO.showObj)
        {
            var o=_.get(TO.showObj[obj]);
            if(o)
                o.innerHTML=tt[obj];
        }
    },
    exe:function()
    {
        TO.loop=setInterval(TO.handle,1000);
    }
}

var str=document.getElementById("str").innerHTML;
var str2=document.getElementById("str2").innerHTML;

TO.init(str,str2);
TO.exe();

TO.fnSuccess=function(){alert("倒计时已到")}
TO.isShow=true;

//var   s   =   "2005-12-15   09:41:30";   
//var   d   =   new   Date(Date.parse(s.replace(/-/g,   "/"))); 

</script>
</html>