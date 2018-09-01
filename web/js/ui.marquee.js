(function(){
	window.Marquee=function(obj,options){return new Marquee.prototype.init(obj,options)};
	Marquee.fn=Marquee.prototype={
		init: function(obj,options){
			
			this.obj=_.get(obj);
			this.newE=null;
			this.interval=null;
			
			this.setOptions(options);
			
			this.speed=this.options.speed;
			this.path=this.options.path;
		},
		//设置默认属性
		setOptions: function(options) {
			this.options = {
				speed:50,
				path:"left"//up  down   left   right
			};
			_.copyP(this.options, options || {});
		},
		move:function()
		{
			switch(this.path)
			{
				case "left":
					if(this.obj.scrollLeft>=this.newE.scrollWidth)
						this.obj.scrollLeft=0;
					this.obj.scrollLeft+=2;
					break;
				case "right":
					if(this.obj.scrollLeft<=0)
						this.obj.scrollLeft=this.newE.scrollWidth;
					this.obj.scrollLeft-=2;
					break;
				case "up":
					if(this.obj.scrollTop>=this.newE.scrollHeight)
						this.obj.scrollTop=0;
					this.obj.scrollTop+=2;
					break;
				case "down":
					if(this.obj.scrollTop<=0) 
						this.obj.scrollTop=this.newE.scrollHeight;
					this.obj.scrollTop-=2;
					break;
			}
		},
		set:function()
		{
			var scroll=_.scroll(this.obj),
				client=_.client(this.obj);
				
			var a,b,c;
			if((/left|right/).test(this.path))
			{
				a=scroll.w;
				b=client.w;
				c=0;
			}
			else if((/up|down/).test(this.path))
			{
				a=scroll.h;
				b=client.h;
				c=1;
			}
				
			if(c==1&&a>=b)//上下滚动
			{
				this.newE=_.newEle("div");
				this.newE.innerHTML=this.obj.innerHTML;
				_.append(this.obj,this.newE);
			}
			
			else if(c==0)//左右
			{
				var aObj=_.getChild(this.obj);
				var fristObj=aObj[0];
				var totalW=(fristObj.offsetWidth)*(aObj.length);
				if(totalW>=b)
				{
					this.newE=_.newEle("div");
					this.newE.style.cssText="width:"+totalW+"px;float:left;";
					
					var count=_.newEle("div");
					count.style.cssText="width:"+(totalW*2)+"px;";
					
					this.newE.innerHTML=this.obj.innerHTML;
					this.obj.innerHTML="";
					_.append(this.obj,this.newE);
					
					count.innerHTML=this.obj.innerHTML+this.obj.innerHTML;
					this.obj.innerHTML=""
					_.append(this.obj,count);
					
					this.newE=_.firstChild(count);
				}
				
				
				
				//this.newE.innerHTML+=this.newE.innerHTML;
				
				//var tmp="";
//					tmp+="  <table cellspacing=\"0\" cellPpadding=\"0\" align=\"center\" border=\"0\" cellspace=\"0\">";
//					tmp+="    <tr> ";
//					tmp+="       <td  valign=\"top\">"+this.obj.innerHTML+"</td>";
//					tmp+="       <td  valign=\"top\">"+this.obj.innerHTML+"</td>";
//					tmp+="    </tr>";
//					tmp+="  </table>";
//					this.obj.innerHTML=tmp;
//					this.newE=this.obj.getElementsByTagName("table")[0];
			}
			if(this.newE)
				this.interval=setInterval(_.bind(this,this.move),this.speed)
			
		},
		exe:function()
		{
			this.set();
			
			if(this.interval)
			{
				this.obj.onmouseover=_.bind(this,function(){clearInterval(this.interval)});
				this.obj.onmouseout=_.bind(this,function(){this.interval=setInterval(_.bind(this,this.move),this.speed)});
			}
		}
	};
	Marquee.fn.init.prototype = Marquee.fn;
	
	//以下多余
	Marquee.extend=Marquee.fn.extend=function(o)//单层继承
	{
		_.copyP(this,o);
		return this;
	};
	//扩展
	Marquee.fn.extend(
	{
		
	});
	//扩展  静态
	Marquee.extend(
	{
		
	});
})();










