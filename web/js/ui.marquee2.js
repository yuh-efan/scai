(function(){
	window.Marquee2=function(display,options){return new Marquee2.prototype.init(display,options)};
	Marquee2.fn=Marquee2.prototype={
		init:function(display,options)
		{
			this.len=0;//步长
			this.tLen=0;//总长
			this.dLen=0;//display 长度
			this.p=0;//0 上下  1左右
			
			this.display=_.get(display);
			this.timeOutObj=null;//timeout对象
			this.time=null;
			this.setOptions(options)//设置默认属性
			//this.div=_.getChild(this.display);
			
			//this.a=a.constructor!==Array?_.getChild(a):a;
			
			
//			this.b=this.options.b;
			this.outSpeed=this.options.outSpeed;
			this.path=this.options.path;
			this.b1=_.get(this.options.b1);
			this.b2=_.get(this.options.b2);
			this.event=this.options.event;
			this.inSpeed=this.options.inSpeed;
			this.speed=this.options.speed;
			this.b=this.options.b;
			//this.overCss=this.options.overCss;
			//this.outCss=this.options.outCss;
		},
		//设置默认属性
		setOptions: function(options) 
		{
			this.options = {
				//a:null,//a数组
				//div:null,//div数组
				//display:null,//显示在那个元素
				outSpeed:2000,//一张到另一张的速度
				//b:true,//是否开启自动切换效果
				path:"up",//  up  down   left   right
				b1:{},//+ 按钮
				b2:{},//-按钮
				event:"onclick",//事件默认
				//overCss:"over",//移上去样式
				//outCss:"",//移开样式
				b:true,//自动切换
				//以下一般采用默认
				inSpeed:5,//内部切换时速度用于被除数
				speed:20//内部切换时速度用于timeout
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
			if(this.p)
				return this.display.scrollLeft;
			else
				return this.display.scrollTop;
		},
		setPath:function(i)
		{
			if(this.p)
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
		setPos:function(i)
		{
			if(this.p==1)
				this.display.scrollLeft=i;
			else if(this.p==0)
				this.display.scrollTop=i;
		},
		tab:function(e)
		{
			
			var target,auto;
			if(typeof e=="boolean")
				auto=e;
			else
			{
				e=e||event;
				target=e.target||e.srcElement;
			}
			
			
			var scrLen=this.getPath();
			if(target==this.b1||auto)//+
			{
				//解决不停触发时scroll的空隙
				scrLen=Math.ceil(scrLen/this.len)*this.len;
				if(scrLen==this.tLen)
				{	
					scrLen=0;
					this.setPos(0);
				}
				this.move(scrLen+this.len);
			}
			
			else if(target==this.b2||!auto)//-
			{
				//解决不停触发时scroll的空隙
				scrLen=Math.floor(scrLen/this.len)*this.len;
				if(scrLen==0)
				{	
					scrLen=this.tLen;
					this.setPos(this.tLen);
				}
				this.move(scrLen-this.len);
			}
		},
		
		exe:function()
		{
			if ((/up|down/).test(this.path))
				this.p=0;
			else if((/left|right/).test(this.path))
				this.p=1;
			var aObj=_.getChild(this.display);
			var l=aObj.length;
			if(l==0)return;
			var lenObj=_.offset(aObj[0]);
			this.len=this.p?lenObj.w:lenObj.h;//步长
			this.tLen=this.len*l;//总长
			
			var dl=_.client(this.display);
			this.dLen=this.p?dl.w:dl.h;//display 长度
			
			if(this.dLen>=this.tLen)
				return;
			
			var newE=_.newEle("div");
			if(this.p==0)//上下
			{
				newE.innerHTML=this.display.innerHTML;
				_.append(this.display,newE);
			}
			else if(this.p==1)//左右
			{
				newE.style.cssText="width:"+this.tLen+"px;float:left;";
				
				var count=_.newEle("div");
				count.style.cssText="width:"+(this.tLen*2)+"px;";
				
				newE.innerHTML=this.display.innerHTML;
				this.display.innerHTML="";
				_.append(this.display,newE);
				
				count.innerHTML=this.display.innerHTML+this.display.innerHTML;
				this.display.innerHTML=""
				_.append(this.display,count);
				
				newE=_.firstChild(count);
			}
			
			if(this.b1&&this.b2)
				this.b1[this.event]=this.b2[this.event]=_.bindE(this,this.tab);
				
			if(this.b)
				this.time=setInterval(_.bind(this,function(){this.tab((/up|left/).test(this.path))}),this.outSpeed);
				//this.move();
			this.display.onmouseover=_.bind(this,function()
			{
				clearInterval(this.time);
			})
			this.display.onmouseout=_.bind(this,function()
			{
				this.time=setInterval(_.bind(this,function(){this.tab((/up|left/).test(this.path))}),this.outSpeed);
			})
		}
	};
	Marquee2.fn.init.prototype = Marquee2.fn;
	//一下多余
	Marquee2.extend=Marquee2.fn.extend=function(o)//单层继承
	{
		_.copyP(this,o);
		return this;
	};
	//扩展
	Marquee2.fn.extend(
	{
		
	});
	//扩展  静态
	Marquee2.extend(
	{
		
	});
	
})();