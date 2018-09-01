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
				fnError:function(){}//请求失败函数
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
			var queryString=this.url+"?r="+Math.random()+"&"+this.param;
			this.xmlHttp.open("GET",queryString,this.async);
			this.xmlHttp.onreadystatechange=_.bind(this,this.handleStateChange);
			this.xmlHttp.send(null);
		},
		//Post方式请求
		doPost:function()
		{
			this.createRequest();
			this.xmlHttp.open("POST",this.url+"?r="+Math.random(),this.async);
			this.xmlHttp.onreadystatechange=_.bind(this,this.handleStateChange)
			this.xmlHttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
			//if(this.param.isDoubleByte())
				//this.param=encodeURI(encodeURI(this.param))//两次编码解决responseText时中文乱码问题  获取时解码decodeURI(this.xmlHttp.responseText)
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
					this.fnError();
			}
			/*switch(this.xmlHttp.readyState)
			{
				case 0:break;//尚未初始化
				case 1:break;//正在发送请求
				case 2:break;//请求完成
				case 3:break;//请求成功，正在接受数据
				case 4:break;//数据接受成功
			}
			switch(this.xmlHttp.status)
			{
				case 200:break;//表示请求成功
				case 202:break;//表示请求被接受，但处理未完成
				case 400:break;//表示错误的请求
				case 404:break;//表示资源未找到
				case 500:break;//表示内部服务器错误，如aspx代码错误等
			}*/
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
	//判断字符串是否有双字节
	//String.prototype.isDoubleByte=function()
//	{
//		if(this.search(/[^\x00-\xff]/)>-1)
//			return true;
//		else
//			return false;
//	};

	Ajax.extend=Ajax.fn.extend=function(o)//单层继承
	{
		_.copyP(this,o);
		return this;
	};
	//扩展
	Ajax.fn.extend(
	{
		
	});
	//扩展  静态
	Ajax.extend(
	{
		//ajax:null,
//		aData:new Array(),
//		aId:new Array(),
//		fn:null,
//		handle:function(data)
//		{
//			if(Ajax.fn)
//				Ajax.fn(data);
//		},
//		getData:function(id)
//		{
//			var i=Ajax.aId.indexOf(id);
//			if(i>-1)
//			{
//				Ajax.handle(Ajax.aData[i]);
//			}
//			else
//			{
//				Ajax.ajax.fnSuccess=function()
//				{
//					Ajax.aId.push(id);
//					var data=this.xmlHttp.responseText;
//					Ajax.aData.push(data);
//					Ajax.handle(data);
//				}
//				Ajax.ajax.exe();
//			}
//		}
	});
	
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
	
	DataAjax.extend=DataAjax.fn.extend=function(o)//单层继承
	{
		_.copyP(this,o);
		return this;
	};
	//扩展
	DataAjax.fn.extend(
	{
		
	});
	//扩展  静态
	DataAjax.extend(
	{
		
	});
})();