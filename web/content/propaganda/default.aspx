<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WZ.Web.content.propaganda._default" %>
<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="bottom.ascx" tagname="bottom" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>搜菜网推广</title>
<link href="css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/base.js"></script>
<script type="text/javascript" src="js/ui.ppt.js"></script>
<script type="text/javascript" src="/js/ui.floatFrame.js"></script>
<script type="text/javascript" src="/js/pub.js"></script>
</head>

<body>
<uc1:top id="top1" runat="server" T1="home"></uc1:top>
<div class="main">
  
  <div class="content">
    <div class="banner">
      <ul id="pic">
        <li id="s1"><a href="#" target="_blank"><img src="images/pic/001.jpg" width="930" height="340" alt="" title="" /></a></li>
        <li id="s2"><img src="images/pic/001.jpg" width="930" height="340" alt="" /></li>
      </ul>
      <div id="Number"> <a id="a1">1</a> <a id="a2">2</a></div>
    </div>
    <script type="text/javascript">

//display  可以是id  或  对象   
//a  可以是id  或  对象 或  伪数组 对象   

PPT("pic","Number",{path:1,overCss:"over",outCss:""}).exe();
//PPT(display,a,{path:1}).exe();
//
</script>
	<div class="box1">
    	<p class="Abuot-txt1">- 轻点鼠标，各式生鲜食品送到您的手中<br />- 烹饪学堂，轻松学会各种菜系的制作</p>
        <p class="Abuot-txt2">- 美容、瘦身、营养等不同功能的套餐定制<br />- 满足孕妇、老人、幼儿等不同人群套餐需求</p>
        <p class="Abuot-txt3">- 在线预定与平台合作的餐厅、休闲吧<br />- 平台快速呼叫，外卖直接送餐上门</p>
        <p class="Abuot-txt4">- 酒店式的家庭用餐服务，配备星级厨师<br />- 烧制、侍应、酒水、卫生等一条龙服务流程</p>
        <p class="Abuot">搜菜网是一家以经营农副产品销售为主，提供家庭厨房一站式服务的B2C电子商务平台。搜菜网顺应市场发展的主流，依托对农副产品传统行业的成功运营，集合连锁产业的庞大资源以及通过对本地市场的长期调查分析，将平台的主体定位在一站式厨房服务上。</p>
    </div><a id="fzzl"></a>
    <div class="box2">
    	<p class="Strategy-1">以目前的传统行业运营基础，建立搜菜网平台，从中心区域的运营口碑不断扩展丽水地区各县市区域市场。 </p>
        <p class="Strategy-2">保证丽水地区的稳定运营，逐步向浙江省内一、二、三线城市推行搜菜网平台，各个地区以丽水总部为中心，稳定口碑化运营。 </p>
        <p class="Strategy-3">以浙江省的市场覆盖、口碑影响为基础，向长三角乃至全国拓展市场。以分部或加盟的方式逐渐形成搜菜网的全国战略概念。</p>
        <p class="Strategy-4">稳定国内的电子商务市场，逐步拓展海外电子商务项目。形成一个以电子商务平台为中心的全球互联网体系。</p>
    </div>
    <a id="scxj"></a>
    <div class="box3">
    	<div class="Market">搜菜网愿意合作企业一起，通过搜菜网的线上优势以及海量会员群体，使合作企业提升品牌知名度、扩大销售、占领市场，共同实现以丽水市场为中心，逐步向全国、全球市场开拓的战略目标！</div>
    </div>
    <a id="rzsj"></a>
    <div class="Join">
    	<h3></h3>
        <ul>
        	<li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
        </ul>
        <div class="clear"></div>
    </div>
    <div class="Schedule"></div>
  </div>
</div>
<uc1:bottom id="bo1" runat="server" T1="reg"></uc1:bottom>

<script type="text/javascript" src="/js/ui.floatDivMove.js"></script>
<script type="text/javascript">
new FloatDivMove({width:35,height:180,content:"<a href=\"javascript:floatLayer.src='/floatLayer/survey.aspx';floatLayer.show();\"><img src='/images/survey/survey_01.gif' /></a><a href='#'><img src='/images/survey/survey_02.gif' /></a>"}).show();
</script>

</body>
</html>
