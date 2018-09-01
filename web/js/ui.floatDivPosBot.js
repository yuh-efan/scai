var Class = {
	create: function() {
		return function() { this.initialize.apply(this, arguments); }
	}
}
var Extend = function(destination, source) {
	for (var property in source) {
		destination[property] = source[property];
	}
}

//获取页面被卷去部分的宽度、高度
function fnGetDocumentScrollPos()
{
    return {x:top.document.documentElement.scrollLeft||top.document.body.scrollLeft,y:top.document.documentElement.scrollTop||top.document.body.scrollTop} 
}
//获取页面可见区域宽度、高度（不包含边框）
function fnGetDocumentClient()
{
    return {width:top.document.documentElement.clientWidth||top.document.body.clientWidth,height:top.document.documentElement.clientHeight||top.document.body.clientHeight}
}

//类开始
var FloatDivPosBot=Class.create();
FloatDivPosBot.prototype=
{
	initialize:function(options)
	{
		this.div=top.document.getElementById("cFloatDivPosBot")||top.document.createElement("div");
		this.b=true;//hidden()  方法所用
		
		this.setOptions(options)
		
		this.width=this.options.width;
		this.height=this.options.height;
		this.content=this.options.content;
		this.speed=this.options.speed;//速度
		this.slowSpeed=this.options.slowSpeed;//放慢的速度
			
		this.set();
		
	},
	//设置默认属性
	setOptions: function(options) 
	{
		this.options = {
			width:0,//宽度
			height:0,//高度
			content:"",//div里面的内容
			
			//一下一般采用默认值
			speed:50,//速度
			slowSpeed:600//放慢的速度
		};
		Extend(this.options, options || {});
	},
	set:function()
	{
		with(this.div.style)
		{
			position="absolute";
			display="none";
			zIndex="10000";
		}
	},
	move:function()
	{
		if(!this.b) return ;
		
		var speed;
		var top=fnGetDocumentScrollPos().y+fnGetDocumentClient().height-this.height-50;
		var oStyle=this.div.style;
		if(parseInt(oStyle.top)==top)
		{
			oStyle.display="block";
			speed=this.speed;
		}
		else
		{
			oStyle.top=top+"px";
			oStyle.display="none";
			speed=this.slowSpeed;
		}
		setTimeout(function(o){return function(){o.move()}}(this),speed)
	},
	hidden:function()
	{
		this.b=false;
		this.div.style.display="none";
	},
	show:function()
	{
		var floatDiv=top.document.getElementById("cFloatDivPosBot");
		if(!floatDiv)
		{	
			this.div.setAttribute("id","cFloatDivPosBot")
			top.document.body.appendChild(this.div);
		}
		
		this.div.innerHTML=this.content;
		with(this.div.style)
		{
			right="100px";
			width=this.width+"px";
			height=this.height+"px";
		}
		this.b=true;
		this.move();
	}
	
}
