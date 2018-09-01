(function(){
	window.Ajax=function(url,options){return new Ajax.prototype.init(url,options)};
	Ajax.fn=Ajax.prototype={
		init:function(url,options)
		{
			this.xmlHttp=null;
			
			this.setOptions(options);
			
			this.url=url;
			this.param=this.options.param;
			this.method=this.options.method;
			this.async=this.options.async;
			this.fnSuccess=this.options.fnSuccess;
			this.fnError=this.options.fnError;
		},
		//设置默认属性
		setOptions: function(options) 
		{
			this.options = { 
				param:"",//请求参数
				method:"GET",//Get方式 或 Post方式
				async:true,//异步请求
				fnSuccess:function(){},//请求成功函数
				fnError:function(){alert('error')}//请求失败函数
			};
			_.copyP(this.options, options || {});
		},
		//创建xmlHttp
		createRequest:function()
		{
			if(window.ActiveXObject)
				this.xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");
			else if(window.XMLHttpRequest)
				this.xmlHttp=new XMLHttpRequest();
		},
		//get方式请求
		doGet:function()
		{
			this.createRequest();
			var queryString=this.url+this.param;
			this.xmlHttp.open("GET",queryString,this.async);
			this.xmlHttp.onreadystatechange=_.bind(this,this.handleStateChange);
			this.xmlHttp.send(null);
		},
		//Post方式请求
		doPost:function()
		{
			this.createRequest();
			var queryString=this.url
			this.xmlHttp.open("post",queryString);
			this.xmlHttp.onreadystatechange=_.bind(this,this.handleStateChange)
			this.xmlHttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
			
			this.xmlHttp.send(this.param)
		},
		
		//事件
		handleStateChange:function()
		{
			if(this.xmlHttp.readyState==4)
			{
				if(this.xmlHttp.status==200)//成功
					this.fnSuccess();
				else if(this.xmlHttp.status>202)//失败
					alert(this.xmlHttp.responseText);//this.fnError();
			}
			
		},
		exe:function()
		{
			if(this.method.toUpperCase()=="GET")
				this.doGet();
			else if(this.method.toUpperCase()=="POST")
				this.doPost();
		}
	};
	Ajax.fn.init.prototype = Ajax.fn;
})();

(function(){
	window.DataAjax=function(ajax,options){return new DataAjax.prototype.init(ajax,options)};
	DataAjax.fn=DataAjax.prototype={
		init:function(ajax,options)
		{
			this.aData=new Array();
			this.aId=new Array();
			this.ajax=ajax;
			
			this.setOptions(options);
			this.fn=this.options.fn;
		},
		//设置默认属性
		setOptions:function(options) 
		{
			this.options = {
				fn:null
			};
			_.copyP(this.options, options || {});
		},
		handle:function(data)
		{
			if(this.fn)
				this.fn(data);
		},
		getData:function(id)
		{
			var i=this.aId.indexOf(id);
			if(i>-1)
			{
				this.handle(this.aData[i]);
			}
			else
			{
				var oThis=this;
				this.ajax.fnSuccess=function()
				{
					var data=this.xmlHttp.responseText;
					oThis.aId.push(id);
					oThis.aData.push(data);
					oThis.handle(data);
				}
				this.ajax.exe();
			}
		}
	};
	DataAjax.fn.init.prototype = DataAjax.fn;
})();