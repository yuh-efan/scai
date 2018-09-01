<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="webLocation.ascx.cs" Inherits="WZ.Web.ascx.webLocation" %>

    <div class="weblocation">
    	<p class="weblocation-l">
        	<span id="webLocation"><%=first%><%=text %></span>
       	</p>
    </div>



<script type="text/javascript">
function navSel(sArr,sNav)
{
    var arr=document.getElementById(sArr).getElementsByTagName("a")
    var text=[];
    for(var i=0;i<arr.length;i++)
    text[i]=arr[i].getAttribute("title");

    var navL=document.getElementById(sNav);
    if(navL)
    {
        var len=text.length;
        var inner=navL.innerHTML;
        var isHas=0;
        for(var i=len-1;i>=0;i--)
        {
            if(inner.indexOf(text[i])>-1)
            {
                arr[i].parentNode.className+="sel";
                isHas=1;
                break;
            }
        }
      
        if(!isHas)
		{
            arr[0].parentNode.className+="sel";
		}
    }
    else
    {
        arr[0].parentNode.className+="sel";
    }
}
//navSel("webMenu","webLocation");
</script>