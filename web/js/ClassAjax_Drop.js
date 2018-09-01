(function(){
	window.ClassAjax_Drop=function(input,toEle,url,options){return new ClassAjax_Drop.prototype.init(input,toEle,url,options)};
	ClassAjax_Drop.fn=ClassAjax_Drop.prototype={
		init:function(input,toEle,url,options)
		{
			this.input=_.get(input);
			this.toEle=_.get(toEle);
			this.url=url
			
			this.setOptions(options);
			
			this.category=this.options.category;
		},
		//设置默认属性
		setOptions: function(options) 
		{
			this.options = {
				category:"area"//"area"=默认地区   "product"=产品  "news"=新闻中心   "help"=帮助中心
			};
			_.copyP(this.options, options || {});
		},
		getSelect:function(i)//获取div
		{
			var o=_.get("cSelect"+i);
			if(!o)
			{
				o=_.newEle("select");
				_.attr(o,"id","cSelect"+i);
				_.append(this.toEle,o);
				o.onchange=_.bind(this,function(){
					this.input.value=o.value;
					
					if(o.value==0)
					{
						var obj=_.get("cSelect"+(i-1));
						if(obj)//选择了 请选择的时候  文本框值为 上一级select 选中值
							this.input.value=obj.value;
						this.hiddenSelect(i)
						return;
					}
					else
						this.hiddenSelect(i+1)
					
					this.ajax(i+1);
				})
			}
			else
			{
				o.options.length = 0;
				o.style.display=""
			}
			return o;
		},
		ajax:function(num)
		{
			var id=this.input.value;
			var ajax=Ajax(this.url+"?id="+id+"&t="+this.category);
			ajax.fnSuccess=(function(othis)
			{
				return function()
				{
					var str=this.xmlHttp.responseText;
					var arr=eval(str);
					if(arr.length>0)
						othis.factory(arr,num);
					else 
					{
						var obj=_.get("cSelect"+num)
						if(obj)//隐藏下一级select
							obj.style.display="none";
					}
				}
			})(this)
			ajax.exe();
		},
		ajax2:function()
		{
			var id=this.input.value.trim();
			var ajax=Ajax(this.url+"?sid="+id+"&t="+this.category);
			ajax.fnSuccess=(function(othis)
			{
				return function()
				{
					var str=this.xmlHttp.responseText;
					var arr=eval(str);
					if(arr.length>0)
						othis.revert(arr);
				}
			})(this)
			ajax.exe();
		},
		hiddenSelect:function(num)
		{
			var n=_.getTN("select",this.toEle);
			for(var i=num;i<n.length;i++)
			{
				n[i].style.display="none";
			}			
		},
		//n=name;i=id; s=select;   b=是否有下一级  暂时用不到
		factory:function(arr,num)
		{
			var o=this.getSelect(num);
			o.options.add(new Option("请选择","0"));
			for(var i=0;i<arr.length;i++)
			{
				
				o.options[i+1] = new Option(arr[i].n, arr[i].i.toString());
				if(arr[i].s)
					o.options[i+1].selected=true;				
			}
				//o.options.add(new Option(arr[i].n, arr[i].i.toString(),false,arr[i].s?true:false));//ie6中会选中上一项
		},
		revert:function(arr)
		{
			for(var i=0;i<arr.length;i++)
				this.factory(arr[i],i+1);
		},
		exe:function()
		{
			var strInput=this.input.value.trim();
			if(strInput.length==0 || strInput==0)
			{
				this.input.value=0;
				this.ajax(1);
			}
			else//用于修改类目
			{
				this.ajax2();
			}
		}
	};
	ClassAjax_Drop.fn.init.prototype = ClassAjax_Drop.fn;
	//一下多余
	ClassAjax_Drop.extend=ClassAjax_Drop.fn.extend=function(o)//单层继承
	{
		_.copyP(this,o);
		return this;
	};
	//扩展
	ClassAjax_Drop.fn.extend(
	{
		
	});
	//扩展  静态
	ClassAjax_Drop.extend(
	{
		
	});
	
})();