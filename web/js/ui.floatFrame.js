(function(){
	window.FloatFrame=function(src,options){return new FloatFrame.prototype.init(src,options)};
	FloatFrame.fn=FloatFrame.prototype={
		init: function(options){
			
			//this.src=src;
			
			this.setOptions(options);
			
			//this.param=this.options.param;
			this.width=this.options.width;
			this.height=this.options.height;
			this.src=this.options.src;
			//this.fnClose=this.options.fnClose;
		},
		//设置默认属性
		setOptions: function(options) {
			this.options = {
				src:"",
				width:100,
				height:100
				//param:""//参数
				//fnClose:this.hidden//关闭时触发的函数
			};
			_.copyP(this.options, options || {});
		},
		hidden:function()
		{
			FloatFrame.hidden();
		},
		show:function()
		{	
			FloatFrame.set();
			FloatFrame.reSize();
			FloatFrame.fullDiv.style.display="";
			
			
			
			//var frameWin=FloatFrame.frame.contentWindow.document.documentElement;
			
			//var frameObj=_.scroll(frameWin);
			//var frameW=frameObj.w,frameH=frameObj.h;
			
			with(FloatFrame.frame.style)
			{
				width=this.width+"px";
				height=this.height+"px";
			}
			
			var cli=_.client(top.document.documentElement);
			var iTop=(cli.h-this.height)/2+(top.document.documentElement.scrollTop||top.document.body.scrollTop);
			var iLeft=(cli.w-this.width)/2;
			iTop=iTop>0?iTop:0;
			iLeft=iLeft>0?iLeft:0;
			
			FloatFrame.frame.src=this.src;
			
			with(FloatFrame.frameDiv.style)
			{
				top=iTop+"px";
				left=iLeft+"px";
				display="";
			}
			_.addEvent(top,"resize",FloatFrame.reSize);
			//FloatFrame.frame.src="{0}?{2}".format(this.src,this.param);
			
		}
		
	};
	FloatFrame.fn.init.prototype = FloatFrame.fn;
	
	//以下多余
	FloatFrame.extend=FloatFrame.fn.extend=function(o)//单层继承
	{
		_.copyP(this,o);
		return this;
	};
	//扩展
	FloatFrame.fn.extend(
	{
		
	});
	//扩展  静态
	FloatFrame.extend(
	{
		fullDiv:null,
		frameDiv:null,
		frame:null,
		
		set:function()
		{
			FloatFrame.fullDiv=_.get("cFullDiv",top.document);
			FloatFrame.frameDiv=_.get("cFrameDiv",top.document);
			FloatFrame.frame=_.get("cFrame",top.document);
			
			if(!FloatFrame.frame)
			{
				FloatFrame.fullDiv=_.newEle("div",top.document);
				FloatFrame.frameDiv=_.newEle("div",top.document);
				
				FloatFrame.fullDiv.style.cssText="z-index:9999;position:absolute;top:0px;left:0px;display:none;background-color:#000;filter:alpha(opacity=10);-moz-opacity:0.1;opacity: 0.1;";
				FloatFrame.frameDiv.style.cssText="position:absolute;top:0px;left:0px;display:none;z-index:9999;";
				
				FloatFrame.frameDiv.innerHTML='<iframe id="cFrame" name="cFrame" frameborder="0" scrolling="no"></iframe>';
	 			
				_.attr(FloatFrame.fullDiv,"id","cFullDiv");
				_.append(top.document.body,FloatFrame.fullDiv);
				
				_.attr(FloatFrame.frameDiv,"id","cFrameDiv");
				_.append(top.document.body,FloatFrame.frameDiv);
				
				FloatFrame.frame=_.get("cFrame",top.document);
				
			}
		},
		reSize:function()
		{
		    var doc=_.doc(top.document.documentElement);
			with(FloatFrame.fullDiv.style)
			{
				width=doc.w+"px";
				height=doc.h+"px";
			}
		},
		hidden:function()
		{
			_.removeEvent(top,"resize",FloatFrame.reSize);
			FloatFrame.fullDiv.style.display="none";
			FloatFrame.frameDiv.style.display="none";
		},
		autoLocal:function()
		{
		    top.FloatFrame.frame.style.width="1px";
			top.FloatFrame.frame.style.heght="1px";
		
            var cur=_.scroll();
            top.FloatFrame.frame.style.width=cur.w+'px';
            top.FloatFrame.frame.style.height=cur.h+'px';
			
            var cli=_.client(top.document.documentElement);
            var iTop=(cli.h-cur.h)/2+(top.document.documentElement.scrollTop||top.document.body.scrollTop);
            //alert(iTop)
            var iLeft=(cli.w-cur.w)/2;
            iTop=iTop>0?iTop:0;
            iLeft=iLeft>0?iLeft:0;

            top.FloatFrame.frameDiv.style.top=iTop+"px";
            top.FloatFrame.frameDiv.style.left=iLeft+"px";
		}
	});
})();


