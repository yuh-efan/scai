(function(){
	window.PPT=function(display,a,options){return new PPT.prototype.init(display,a,options)};
	PPT.fn=PPT.prototype={
		init:function(display,a,options)
		{
			this.oldEle=null;//应用样式对象
			this.len=0;//div长度
			this.timeOutObj=null;//timeout对象
			this.i=0;//当前div
			this.interval=null;//切换
			
			this.setOptions(options)//设置默认属性
			this.display=_.get(display);
			this.div=_.getChild(this.display);
			
			this.a=a.constructor!==Array?_.getChild(a):a;
			
			this.inSpeed=this.options.inSpeed;
			this.speed=this.options.speed;
			this.b=this.options.b;
			this.outSpeed=this.options.outSpeed;
			this.path=this.options.path;
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
				path:0,//0 上下  1左右
				event:"onmouseover",//事件默认
				overCss:"over",//移上去样式
				outCss:"",//移开样式
				
				//以下一般采用默认
				inSpeed:5,//内部切换时速度用于被除数
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
		getPath:function()
		{
			if(this.path)
				return this.display.scrollLeft;
			else
				return this.display.scrollTop;
		},
		setPath:function(i)
		{
			if(this.path)
				this.display.scrollLeft+=i;
			else
				this.display.scrollTop+=i;
		},
		tab:function(curr)
		{
			if(this.timeOutObj)
			{
				clearTimeout(this.timeOutObj);
			}
			this.i=curr;
			var left=curr*this.len;
			var size=this.getPath();
			var dist = Math.ceil(Math.abs(left-size)/this.inSpeed);
			if (dist==0)
			{
				return false;
			}
			if(left<size)
			{
				dist=-dist;
			}
			this.setPath(dist)
			this.timeOutObj=setTimeout(_.bind(this,function(){this.tab(curr)}),this.speed);
		},
		auto:function()
		{
			if(this.i>=(this.div.length-1))
				this.i=-1;
			this.i++;
			this.setCss(this.i);
			this.tab(this.i);
		},
		exe:function()
		{
			var lenObj=_.offset(this.div[0]);
			this.len=this.path?lenObj.w:lenObj.h;
			this.oldEle=this.a[0];
			
			this.oldEle.className=this.overCss;
			
			
			
			//新加
			if(this.div.length<2)
				return;
			//横  新加  还有上面定义的 this.div
			if(this.path==1)
			{
				var div=_.newEle("div");
				var w=this.len*this.div.length;
				div.style.width=w+"px";
				for(var i=0;i<this.div.length;i++)
					_.append(div,this.div[i]);
				_.append(this.display,div);
				
			}
			
			
			
			if(this.b)
				this.interval=setInterval(_.bind(this,this.auto),this.outSpeed);
			for(var j=0;j<this.a.length;j++)
			{
				this.a[j][this.event]=_.bind(this,function(j){return function(){
					if(this.interval) clearInterval(this.interval);
					this.setCss(j); this.tab(j);
				}}(j))
				
				if(this.b)
				{
					this.a[j].onmouseout=_.bind(this,function(j){return function(){
						this.interval=setInterval(_.bind(this,this.auto),this.outSpeed);
						this.tab(j);
					}}(j))
				}
			}
		}
	};
	PPT.fn.init.prototype = PPT.fn;
	//一下多余
	PPT.extend=PPT.fn.extend=function(o)//单层继承
	{
		_.copyP(this,o);
		return this;
	};
	//扩展
	PPT.fn.extend(
	{
		
	});
	//扩展  静态
	PPT.extend(
	{
		
	});
	
})();