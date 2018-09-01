(function(){
	window.PPT100=function(display,a,options){return new PPT100.prototype.init(display,a,options)};
	PPT100.fn=PPT100.prototype={
		init:function(display,a,options)
		{
			this.oldEle=null;//应用样式对象
			this.oldEleDiv=null;
			this.timeOutObj=null;//timeout对象
			this.i=0;//当前div
			this.interval=null;//切换
			this.tt=true;
			
			this.setOptions(options)//设置默认属性
			this.div=display.constructor!==Array?_.getChild(display):display;
			this.a=a.constructor!==Array?_.getChild(a):a;
			
			this.inSpeed=this.options.inSpeed;
			this.speed=this.options.speed;
			this.b=this.options.b;
			this.outSpeed=this.options.outSpeed;
			this.event=this.options.event;
			this.overCss=this.options.overCss;
			this.outCss=this.options.outCss;
		},
		//设置默认属性
		setOptions: function(options) 
		{
			this.options = {
				//a:null,//a数组
				//div:null,//div数组
				//display:null,//显示在那个元素
				outSpeed:4000,//一张到另一张的速度
				b:true,//是否开启自动切换效果
				event:"onmouseover",//事件默认
				overCss:"over",//移上去样式
				outCss:"",//移开样式
				
				//以下一般采用默认
				inSpeed:0.05,//内部切换时速度
				speed:20//内部切换时速度用于timeout
			};
			_.copyP(this.options, options || {});
		},
		setCss:function(i)
		{
			if(this.a[i]!=this.oldEle)
			{   
				this.a[i].className=this.overCss;
				this.oldEle.className=this.outCss;
				this.oldEle=this.a[i];
			}
		},
		
		tab:function(curr)
		{
			if(this.timeOutObj)
			{
				clearTimeout(this.timeOutObj);
			}
			this.i=curr;
			this.tt=false;
			
			var opa=Number(this.div[curr].style.opacity);
			opa=opa?opa:0;
			opa+=this.inSpeed;
			if(opa>=1)
			{
				this.tt=true;
				this.swapDiv();
				return false;
			}
			this.div[curr].style.filter="Alpha(opacity="+(opa*100)+")";
			this.div[curr].style.opacity=opa;
			this.timeOutObj=setTimeout(_.bind(this,function(){this.tab(curr)}),this.speed);
		},
		swapDiv:function()
		{
			with(this)
			{
				oldEleDiv.style.opacity=0;
				oldEleDiv.style.filter="Alpha(opacity=0)";
				
				div[i].style.opacity=1;
				div[i].style.filter="Alpha(opacity=100)";
				
				oldEleDiv=div[i];
			}
			//以上是 以下的 简写
//			this.oldEleDiv.style.opacity=0;
//			this.oldEleDiv.style.filter="Alpha(opacity=0)";
//			
//			this.div[this.i].style.opacity=1;
//			this.div[this.i].style.filter="Alpha(opacity=100)";
//			
//			this.oldEleDiv=this.div[this.i];
		},
		setopa:function(i)
		{
			if(this.div[i]!=this.oldEleDiv)
			{   
				this.oldEleDiv.style.zIndex=1;
				this.div[i].style.zIndex=2;
			}
		},
		auto:function()
		{
			
			if(this.i>=(this.div.length-1))
				this.i=-1;
			this.i++;
			this.setCss(this.i);
			this.setopa(this.i);
			this.tab(this.i);
		},
		exe:function()
		{
			if(this.div.length<2)
				return;
			
			this.oldEleDiv=this.div[0];
			this.oldEleDiv.style.zIndex=2;
			this.oldEleDiv.style.filter="Alpha(opacity=100)";
			this.oldEleDiv.style.opacity=1;
			
			this.oldEle=this.a[0];
			this.oldEle.className=this.overCss;
			
			if(this.b)
				this.interval=setInterval(_.bind(this,this.auto),this.outSpeed);
			for(var j=0;j<this.a.length;j++)
			{
				this.a[j][this.event]=_.bind(this,function(j){return function(){
					if(this.interval) clearInterval(this.interval);
					
					if(this.div[j]==this.div[this.i])
						return
					
					if(!this.tt)
						this.swapDiv();
						
					this.setCss(j);this.setopa(j);this.tab(j);
				}}(j))
				
				if(this.b)
				{
					this.a[j].onmouseout=_.bind(this,function(j){return function(){
						this.interval=setInterval(_.bind(this,this.auto),this.outSpeed);
					}}(j))
				}
			}
		}
	};
	PPT100.fn.init.prototype = PPT100.fn;
	//一下多余
	PPT100.extend=PPT100.fn.extend=function(o)//单层继承
	{
		_.copyP(this,o);
		return this;
	};
	//扩展
	PPT100.fn.extend(
	{
		
	});
	//扩展  静态
	PPT100.extend(
	{
		
	});
	
})();