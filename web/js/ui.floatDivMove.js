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

//类开始
var FloatDivMove=Class.create();
FloatDivMove.prototype=
{
	initialize:function(options)
	{
		this.div=top.document.getElementById("cFloatDivMove")||top.document.createElement("div");
		this.b=true;//hidden()  方法所用
		
		this.setOptions(options)
		
		this.width=this.options.width;
		this.height=this.options.height;
		
		//this.rightX=this.options.rightX;
		this.topY=this.options.topY;
		this.content=this.options.content;
		
		this.speed=this.options.speed;
		this.inSpeed=this.options.inSpeed;
		this.slowSpeed=this.options.slowSpeed
		
		this.set();
		
	},
	//设置默认属性
	setOptions: function(options) 
	{
		this.options = {
			width:0,//宽度
			height:0,//高度
			//rightX:50,//距离右边的距离
			topY:220,//距离上边的距离
			content:"",//div里面的内容
			
			//以下参数一般采用默认
			speed:30,//速度
			slowSpeed:80,//放慢的速度
			inSpeed:15//内部速度用于被除数
		};
		Extend(this.options, options || {});
	},
	set:function()
	{
		with(this.div.style)
		{
			position="absolute";
			display="none"
			zIndex="10000";
		}
	},
	move:function()
	{
		if(!this.b) return;
		var startY,endY,speed;
		startY=parseInt(this.div.style.top);
		endY=fnGetDocumentScrollPos().y+this.topY;
		if(startY!=endY)
		{
			var i=Math.ceil(Math.abs(endY-startY)/this.inSpeed );
			this.div.style.top=startY+((endY<startY)?-i:i)+"px";
			speed=this.speed;
		}
		else
			speed=this.slowSpeed;
		setTimeout(function(o){return function(){o.move()}}(this), speed);
	},
	hidden:function()
	{
		this.b=false;
		this.div.style.display="none";
	},
	show:function()
	{
		var floatDiv=top.document.getElementById("cFloatDivMove");
		if(!floatDiv)
		{
			this.div.setAttribute("id","cFloatDivMove")
			top.document.body.appendChild(this.div);
		}
			
		this.div.innerHTML=this.content;
		with(this.div.style)
		{
			width=this.width+"px";
			height=this.height+"px";
			//right=this.rightX+"px";
			left="0px";
			top=this.topY+"px";
			display="block";
		}
		this.b=true;
		this.move();
	}
	
}
