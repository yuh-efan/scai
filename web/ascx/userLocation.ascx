<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="userLocation.ascx.cs" Inherits="WZ.Web.ascx.userLocation" %>


    <div class="weblocation">
    	<p class="weblocation-l">
        	<span id="webLocation">您当前所在位置:<a href="<%=GetURL.Default.Home() %>">首页</a> &gt; <a href="center.aspx">用户中心</a><%=text %></span>
       	</p>
    </div>