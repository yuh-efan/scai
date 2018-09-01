(function(){
	window.PPT3=function(display,options){return new PPT3.prototype.init(display,options)};
	PPT3.fn=PPT3.prototype={
		init:function(display,options)
		{
			this.len=0;//步长
			this.tLen=0;//总长
			this.dLen=0;//display 长度
			
			
			this.display=_.get(display);
			this.timeOutObj=null;//timeout对象
			
			this.setOptions(options)//设置默认属性
			//this.div=_.getChild(this.display);
			
			//this.a=a.constructor!==Array?_.getChild(a):a;
			
			
//			this.b=this.options.b;
//			this.outSpeed=this.options.outSpeed;
			this.path=this.options.path;
			this.b1=_.get(this.options.b1);//+
			this.b2=_.get(this.options.b2);//-
			this.event=this.options.event;
			this.inSpeed=this.options.inSpeed;
			this.speed=this.options.speed;
			
			this.c1=this.options.c1;
			this.c2=this.options.c2;
			
			
		},
		//设置默认属性
		setOptions: function(options) 
		{
			this.options = {
				//a:null,//a数组
				//div:null,//div数组
				//display:null,//显示在那个元素
				//outSpeed:4000,//一张到另一张的速度
				//b:true,//是否开启自动切换效果
				path:0,//0 上下  1左右
				b1:{},//+ 按钮
				b2:{},//-按钮
				event:"onclick",//事件默认
				
				//以下一般采用默认
				inSpeed:5,//内部切换时速度用于被除数
				speed:20,//内部切换时速度用于timeout
				
				c1:["marq_yes1","marq_no1"],
				c2:["marq_yes2","marq_no2"]
				
				
				
			};
			_.copyP(this.options, options || {});
		},
		//setCss:function(i)
//		{
//			if(this.a[i]!=this.oldEle)
//			{   
//				this.a[i].className=this.overCss;
//				this.oldEle.className=this.outCss;
//				this.oldEle=this.a[i];
//			}
//		},
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
		move:function(pos)
		{
			if(this.timeOutObj)
			{
				clearTimeout(this.timeOutObj);
			}
			
			var size=this.getPath();
			var dist = Math.ceil(Math.abs(pos-size)/this.inSpeed);
			if (dist==0)
			{
				return false;
			}
			if(pos<size)
			{
				dist=-dist;
			}
			this.setPath(dist)
			this.timeOutObj=setTimeout(_.bind(this,function(){this.move(pos)}),this.speed);
		},
		tab:function(e)
		{
			
			e=e||event;
			var target=e.target||e.srcElement;
			
			var scrLen=this.getPath();
			
			if(target==this.b1)//+
			{
				//解决不停触发时scroll的空隙
				scrLen=Math.ceil(scrLen/this.len)*this.len;
				
				//新加 加了  样式
				if(scrLen+this.dLen+this.len>=this.tLen)
					this.b1.className=this.c1[1];
				else
				{
					this.b1.className=this.c1[0];
					this.b2.className=this.c2[0];
				}
				
				if(scrLen+this.dLen==this.tLen)
					return;
				this.move(scrLen+this.len);
			}
			else if(target==this.b2)//-
			{
				//解决不停触发时scroll的空隙
				scrLen=Math.floor(scrLen/this.len)*this.len;
				
				//新加 加了  样式
				if(scrLen-this.len<=0)
					this.b2.className=this.c2[1];
				else
				{
					this.b2.className=this.c2[0];
					this.b1.className=this.c1[0];
				}
				
				if(scrLen==0)
					return;
				this.move(scrLen-this.len);
			}
		},
		exe:function()
		{
			var aObj=_.getChild(this.display);
			var l=aObj.length;
			if(l==0) return;
			var lenObj=_.offset(aObj[0]);
			this.len=this.path?lenObj.w:lenObj.h;//步长
			this.tLen=this.len*l;//总长
			
			var dl=_.client(this.display);
			this.dLen=this.path?dl.w:dl.h;//display 长度
			
			
			this.b2.className=this.c2[1];//左边  暗色
			
			if(this.dLen>=this.tLen)
			{
				this.b1.className=this.c1[1];//右边  暗色
				return;
			}
			else
				this.b1.className=this.c1[0];//右边  彩色
			
			if(this.path==1)
			{
				var div=_.newEle("div");
				div.style.width=this.tLen+"px";
				for(var i=0;i<aObj.length;i++)
					_.append(div,aObj[i]);
				_.append(this.display,div);
			}			
			this.b1[this.event]=this.b2[this.event]=_.bindE(this,this.tab);
		}
	};
	PPT3.fn.init.prototype = PPT3.fn;
	//一下多余
	PPT3.extend=PPT3.fn.extend=function(o)//单层继承
	{
		_.copyP(this,o);
		return this;
	};
	//扩展
	PPT3.fn.extend(
	{
		
	});
	//扩展  静态
	PPT3.extend(
	{
		
	});
	
})();