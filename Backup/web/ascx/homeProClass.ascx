<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="homeProClass.ascx.cs" Inherits="WZ.Web.ascx.homeProClass" %>
<%
DataRow[] aDrw = dtProClassHome.Select("PClassSN=0", "Taxis asc");
foreach (DataRow drw in aDrw)
{
    
%>
<li>
<a class="category-class" href="<%= GetURL.Pro.Class(drw["ClassSN"])%>">
<span class="category-name"><%=drw["ClassName"] %></span>
<%
DataRow[] aDrw1 = dtProClassHome.Select("PClassSN=" + drw["ClassSN"], "Taxis asc");
foreach (DataRow drw1 in aDrw1){
%>
<span class="category-pro"><%=drw1["ClassName"] %></span>
<%}%>
</a>


<div class="category-float">
	<div class="category-float-l"></div>
    <div class="category-float-main">
    	<div class="category-float-c">
    		<div class="category-float-title">选择分类</div> 
            <div class="category-float-pro">
<%
DataRow[] aDrw2 = dtProClass.Select("PClassSN=" + drw["ClassSN"], "Taxis asc");

foreach (DataRow drw1 in aDrw2)
{
%><a href="<%= GetURL.Pro.Class(drw1["ClassSN"])%>"><%=drw1["ClassName"]%></a><%}%></div>

            <ul class="def-list category-float-list">
<%
            string classID = drw["ClassSN"].ToString();
            string sql = "select top 3 ProSN,ProName,Price,PicS from vgPro_Info a,T_Pro_Class_GetChildAndSelf(" + classID + ") b where a.FK_Pro_Class=b.id order by Hit desc, EditDate desc";
            DataTable proDt = cac.GetDataTable("prolist_order by Hit desc" + classID, sql);

            if (proDt != null)
            {
               Response.Write(WZ.Data.Layout.ProLay.d_1(proDt, lay1));
            }
%>
            </ul>
        
        </div>
    </div>
</div>

</li>
<%}%>
<script type="text/javascript">
var swap={
	list:"categoryList",
	timeover:null,
	timeout:null,
	show:function(obj){
		obj.className="sel";
		_.getChild(obj,1).style.display="block";
	},
	hidden:function(obj){
		obj.className="";
		_.getChild(obj,1).style.display="none";

	},
	init:function(){
		var arr=_.getChild(swap.list);
		
		for(var i=0;i<arr.length;i++){
			arr[i].onmouseover=function(){swap.show(this)};
			arr[i].onmouseout=function(){swap.hidden(this)};
		}
		
	}
	
}
swap.init();
</script>

<%--<script type="text/javascript">
var currChild=null;
var timeChild=null;
function setChildOver(str,pThis)
{
    clearChild();
    
    currChild={};
    currChild.div=_.get('childHome'+str);
    currChild.obj=pThis;
    currChild.dl=_.get('childdl'+str);
    
    _.get('childHome'+str).style.display='block';
     _.get('childdl'+str).style.zIndex="888";
    //pThis.style.zIndex="888";
    pThis.className='loc';
}

function setChildOut(str,pThis)
{
    timeChild=setTimeout('clearChild()',500)
}
function clearChild()
{
    if(currChild)
    {
        currChild.div.style.display='none';
        currChild.obj.className="";
        currChild.dl.style.zIndex="887";
        clearTimeout(timeChild);
    }
}
</script>--%>