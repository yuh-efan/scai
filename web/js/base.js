(function(){
	y=window._={
		bind:function(o,f)
		{
			return function(){return f.apply(o,arguments)}
		},
		bindE:function(o,f) 
		{
			return function(e) {return f.call(o,(e||event))}
		},
		get:function(s,o)
		{
			o=o||document;
			if(typeof s==="string")
				s=o.getElementById(s);
			return s
		},
		getClass:function(className)
		{
			var arr=document.getElementsByTagName('*');
			var i=0;
			for(i;i<arr.length;i++)
			{
				var cn=arr[i].className;
				
				if(cn && (cn.search(new RegExp('(^|[\\s])'+className+'($|[\\s])','i'))>=0))
					break;
			}
			
			return arr[i];
		},
		getClassN:function(s)
		{
			var o=_.getTN("*");
			var l=o.length;
			var a=new Array();
			while(l)
				if(o[--l].className==s)
					a.push(o[l]);
			return a
		},
		getN:function(s,o)
		{
			o=o||document;
			return o.getElementsByName(s)
		},
		getTN:function(s,o)
		{
			o=o||document;
			return o.getElementsByTagName(s)
		},
		to:function(v)
		{
			if(typeof v==="string")
				v=_.get(v);
			return v
		},
		//获取页面可见区域宽度、高度（不包含边框）
		client:function(o)
		{
			o=o||document.documentElement;
			return {w:o.clientWidth,h:o.clientHeight}
		},
		//获取页面正文区域宽度、高度
		scroll:function(o)
		{
			o=o||document.documentElement;
			return {w:o.scrollWidth,h:o.scrollHeight}
		},
		offset:function(o)
		{
			//o=o||document.documentElement;
			return {w:o.offsetWidth,h:o.offsetHeight}
		},
		//获取页面被卷去部分的宽度、高度
		//调用须知： 如果 参数 是 document对象 不能调用此方法 
		scrollTo:function(o)
		{
			//o=o||document.documentElement;
			//return {w:o.scrollLeft,h:o.scrollTop} 
			//新版 (修改) Chrome scrollLeft|scrollTop=0问题
			if(o)
				return {w:o.scrollLeft,h:o.scrollTop}
			else
			{
				var d=document.documentElement,b=document.body;
				return {w:d.scrollLeft||b.scrollLeft,h:d.scrollTop||b.scrollTop}
			}
		},
		doc:function(o)
		{
			o=o||document.documentElement;
			var a=_.client(o),b=_.scroll(o);
			return {w:Math.max(a.w,b.w),h:Math.max(a.h,b.h)}
		},
		copyP:function(d, s) {
			for (var p in s) {
				d[p] = s[p]
			}
		},
		stopPropagation:function(e,o)//取消冒泡
		{
			o=o||window;
			if(o.event)
				e.cancelBubble=true; //IE取消事件向上冒泡
			else
				e.stopPropagation();//标准DOM取消事件向上冒泡   
		},
		newEle:function(s,d)
		{
			var o=d||document;
			return o.createElement(s)
		},
		append:function(a,b)
		{
			a.appendChild(b)
		},
		attr:function(v,n,s)
		{
			v=_.to(v);
			if(s)
				v.setAttribute(n,s);
			else
				return v.getAttribute(n)
		},
		addClass:function(v,s)
		{
			v=_.to(v);
			var s=v.className;
			if(!s)
				v.className=s;
			else
				v.className+=" "+s
		},
		removeClass:function(v,s)
		{
			var a,l;
			v=_.to(v);
			a=v.className.split(/\s+/);
			l=a.length;
			while(l)
			{
				if(a[--l]==s)
				{
					a.splice(l,1);
					break;
				}
			}
			v.className=a.join(" ")
		},
		addEvent:function(v,s,f)
		{
			v=_.to(v);
			if (v["addEventListener"])//h.a??????优化??????
				v.addEventListener(s, f, false);
			else if (v["attachEvent"])//h.b??????优化??????
				v.attachEvent("on" + s, f)
		},
		removeEvent:function(v,s,f)
		{
			v=_.to(v);
			if (v["removeEventListener"])//h.a??????优化??????
				v.removeEventListener(s, f, false);
			else if (v["detachEvent"])//h.b??????优化??????
				v.detachEvent("on" + s, f)
		},
		
		load:function(a,q)//url  fn        //js同步  css异步
		{
			var c,d,e,f,k,o,r=q?q:function(){};
			c= /.+\/(\w+\.+\w+)(?:\?.+)?/g;
			d=a.length;
			e=_.getTN("script");
			f=e.length;
			k=_.getTN("link");
			o=k.length;
			while(d)
			{
				var p,g,s,i,j,u,v,x,y,z=0;
				g=a[--d].replace(c,'$1');
				s=g.split('.');
				i=s[s.length-1];//后缀
				if(i=="js")
				{
					p="src";
					v="script";
					x=f;
					y=e;
					u={'type':'text/javascript','src':a[d]}
				}
				else if(i=="css")
				{
					p="href";
					v="link";
					x=o;
					y=k;
					u={'type':'text/css','rel':'stylesheet','href':a[d]}
				}
				while(x)
				{
					var m=_.attr(y[--x],p);
					if(m)
						j=m.replace(c,'$1');
					else
						continue;
					
					if(j==g)
					{
						z=1;
						break
					}
				}
				if(z)
					u=null;
				if(u)
				{
					var w=_.newEle(v);
					
					if(v=="script")
					{
						
						
						if(typeof w["onreadystatechange"]=="object")//ie
						
							_.addEvent(w,"readystatechange",function(){if ((/loaded|complete/).test(w.readyState)){_.removeEvent(w,"readystatechange",arguments.callee);r();}})
						else 
						
							_.addEvent(w,"load",function(){_.removeEvent(w,"load",arguments.callee);r();})
							
					}
					
					_.copyP(w,u);
					
					_.append(_.getTN("head")[0],w)
				}
				else 
					if(v=="script")
						r();
			}
		},
		
		r: false,//isReady: false,
		l: [],//readyList: [],
		g:false,//readyBound : false	
		ready: function(fn){
			_.lis();
			if (_.r)
				fn();//fn.call(document,_);
			else
				_.l.push( fn )
			//return this;
		},
		run: function() {
			if ( !_.r ) {
				_.r = true;
				if (_.l) {
					for(var i=0;i<_.l.length;i++)
						_.l[i]();//_.readyList[i].call(document,_); //?????????????????
					_.l = null
				}
			}
		},
		lis:function(){
			if ( _.g ) return;
			_.g = true;
			if ( document["addEventListener"] ) {//h.a
				//document.addEventListener( h.e, function(){
//					document.removeEventListener( h.e, arguments.callee, false );
//					_.run()
//				}, false )
				//优化
				_.addEvent(document,"DOMContentLoaded",function(){_.removeEvent(document,"DOMContentLoaded",arguments.callee);_.run()});
				
			} else if ( document["attachEvent"] ) {//h.b
				//document.attachEvent(h.f, function(){
//					if ( document.readyState === "complete" ) {
//						document.detachEvent(h.f, arguments.callee );
//						_.run()
//					}
//				});
				//优化
				_.addEvent(document,"onreadystatechange",function(){	if ( document.readyState === "complete" ) {_.removeEvent(document,"onreadystatechange",arguments.callee);_.run()}  });
				
				if ( document.documentElement.doScroll) (function(){ //if语句   如果父窗体调用iframe时必须加 && window == window.top 否则会出错
					if ( _.r ) return;
					try {
						document.documentElement.doScroll("left");
					} catch( error ) {
						setTimeout( arguments.callee, 0 );
						return;
					}
					_.run()
				})();
			}
			//_.addEvent(window,"load",_.run)
			//优化load 没删除  window.onload=_.run  
			_.addEvent(window,"load",function(){_.removeEvent(window,"load",arguments.callee);_.run()})
		},
		
		//获取地址栏参数或锚点值 _.getParam("name")
		getUrlParam:function(n){
			var r = new RegExp("(\\?|#|&)"+n+"=([^&#]*)(&|#|$)","i"),
			a = location.href.match(r)||top.location.href.match(r);
			return (!a?null:a[2])
		},
		//伪数组 转换为 数组 Array
		makeArray: function (a) { 
			var r = [],i= a.length;
			while( i ) r[--i] = a[i];
			return r
		},
		//获取元素坐标
		elePos:function (o)
		{
			o=_.get(o);
			var l=t=0;
			while(o)
			{
				l+=o.offsetLeft;
				t+=o.offsetTop;
				o=o.offsetParent
			}
			return {x:l,y:t}
		},
		firstChild:function (o)
		{
			o=_.get(o);
			if(o.hasChildNodes())
			{
				var a=o.childNodes;
				for(var i=0;i<a.length;i++)
					if(a[i].nodeType==1)
						return a[i];
			}
			return null;
		},
		//获取对象的最后一个子对象
		lastChild:function(o)
		{
			o=_.get(o);
			if(o.hasChildNodes())
			{   var a=o.childNodes;
				for(var i=a.length-1;i>=0;i--)
					if(a[i].nodeType==1)
						return a[i];
			}
			return null;
		},
		//获取子元素
		getChild:function(o,j)
		{
			o=_.get(o);
			var arr=new Array();
			if(o.hasChildNodes())
			{   
				var a=o.childNodes;
				for(var i=0;i<a.length;i++)
					if(a[i].nodeType==1)
						arr.push(a[i]);
			}
			
			if(arguments.length==2)
				return arr[j];
			return arr;
			
		},
		getValue:function(s)
		{
			var a=[];
			var arr=_.getN(s);
            var element;
            for (var i = 0; i <  arr.length; i++)
			{
                element = arr[i];
                var tagName = element.tagName.toLowerCase();
                if (tagName == "input") 
				{
                    var type = element.type;
                    if(type == "text" || type == "hidden" || type == "password"||((type == "checkbox" || type == "radio") && element.checked))
                        a.push(element.value);
                }
                else if (tagName == "select")
				{
                    var selectCount = element.options.length;
                    for (var j = 0; j < selectCount; j++) 
					{
                        var selectChild = element.options[j];
                        if (selectChild.selected == true)
							a.push(element.value);
                    }
                }
                else if (tagName == "textarea")
                    a.push(element.value);
            }
			if(a.length)
				return a.join(",");
			else
				return "";
		}
		
	};
})();
//以下有用
//ie6中无此方法   indexOf
if (!Array.prototype.indexOf)
{
	Array.prototype.indexOf = function(o)
	{
		var i=0,a=this,l=a.length;
		while(l)
			if(a[--l]==o)
				return l;
		return -1
	}
}
//去除前后空格
String.prototype.trim = function()
{
    return this.replace(/(^\s*)|(\s*$)/g,"")
}
//格式化字符串"http://{0}/{1}/{2}".fnFormat("www.meizz.com", "web", "abc.htm")
String.prototype.format=function()
{
	var l=arguments.length,s=this;
	while(l)
		s=s.replace(new RegExp("\\{"+--l+"\\}","g"),arguments[l]);
	return s
}