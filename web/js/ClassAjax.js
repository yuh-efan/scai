var Class = {
	create: function() {
		return function() { this.initialize.apply(this, arguments); }
	}
}

var Extend = function(destination, source) {
	for (var property in source) {
		destination[property] = source[property];
	}
}

//去除前后空格
String.prototype.trim = function()
{
    return this.replace(/(^\s*)|(\s*$)/g,"");
}
//类开始
var ClassAjax=Class.create();
ClassAjax.prototype=
{
	initialize:function(options)
	{
		
		this.address=new Array();//存储位置（浙江省》金华）
		this.repClass=new Array();//选中的样式替换
		
		this.setOptions(options)
		
		this.url=this.options.url;
		this.classId=this.options.classId;
		this.input=this.options.input;
		this.appToElement=this.options.appToElement;
	},
	//设置默认属性
	setOptions: function(options) {
		this.options = {
			url:"",//请求路径
			classId:"area",//"area"=默认地区   "product"=产品  "news"=新闻中心   "help"=帮助中心
			input:null,//文本框对象
			appToElement:null//添加到哪个对象
		};
		Extend(this.options, options || {});
	},
	getDiv:function(i)//获取div
	{
		var oDiv=document.getElementById("cDiv"+i);
		if(!oDiv)
		{
			oDiv=document.createElement("div");
			oDiv.setAttribute("id","cDiv"+i);
		}
		else
		{
			var a=oDiv.getElementsByTagName("a");
			while(a.length)
			{
				oDiv.removeChild(a[0]);
			}
		}
		return oDiv;
	},
	//工厂
	factory:function(aObj,i,b)
	{
		var oDiv=this.getDiv(i);
		
		if(!b)
			this.setClass(i);
		i++;
		var oThis=this;
		
		for(var j=0;j<aObj.length;j++)
		{
			var sName=aObj[j].n;
			var sId=aObj[j].i.toString();
			var bHasChild=aObj[j].b;
			var oA=document.createElement("a");
			oA.setAttribute("id",sId);
			oA.innerHTML=sName;
			oDiv.appendChild(oA);

			if(bHasChild>0)
				oA.className+="hasList";

			if(aObj[j].s)
			{
				oA.className+=" selected";
				oThis.address[i-2]=sName;
				oThis.repClass[i-2]=oA;
			}
			oA.onclick=function(bHasChild)
			{
				return function()
				{					
					var oThisElem=this;
					var thisId=this.getAttribute("id");
					oThis.address[i-2]=this.innerHTML;
					if(oThis.repClass[i-2]!=this)
					{
						oThis.hiddenDiv(i);
						oThis.input.value=thisId;
						if(bHasChild>0)
						{
							var ajax=Ajax(oThis.url+'?id='+thisId+'&t='+oThis.classId);
							ajax.fnSuccess=function()
							{
								var str=this.xmlHttp.responseText;
								eval("var arr="+str);
								oThis.factory(arr,i);
								oThis.repClass[i-2]=oThisElem;//必须分开写(ajax是异步)
							}
							ajax.exe();
						}
						else
						{
							oThis.setClass(i)
							oThis.repClass[i-2]=oThisElem//必须分开写
						}
						this.className+=" selected";
					}
					
				}
			}(bHasChild)
			
		}
		if(b)
			this.appToElement.appendChild(oDiv);
		else
		{
			if(!this.repClass[i-2]&&!document.getElementById("cDiv"+(i-1)))
				this.appToElement.appendChild(oDiv);
			else
				oDiv.style.display="block";
		}
		
		
		
	},
	setClass:function(i)
	{
		if(this.repClass[i-2])
			this.repClass[i-2].className=this.repClass[i-2].className.replace(new RegExp("(\\S*)(\\s*)(selected)","i"),"$1")
	},
	hiddenDiv:function(i)
	{
		var arr=this.appToElement.getElementsByTagName("div");
		for(var j=0;j<arr.length;j++)
		{
			if(j+1>=i&&arr[j].style.display!="none")
				arr[j].style.display="none";
		}
		for(var k=0;k<this.address.length;k++)
		{
			if(k+2>=i)
			{
				this.address=this.address.slice(0,k+1);
				break;
			}
		}
	},
	nav:function()//导航
	{
		if(this.address.length==0)
		{
			return [""];
		}
		else
		{
			return this.address;
		}
	},
	init:function(aObj)
	{
		for(var i=0;i<aObj.length;i++)
		{
			this.factory(aObj[i],i+1,true)
		}
		for(var i=0;i<this.repClass.length;i++)
		{
			//this.repClass[i].scrollIntoView();
		}
	},
	exe:function()
	{
		var strInput=this.input.value.trim();
		var oThis=this;
		if(strInput.length==0 || Number(strInput)<1)
		{
			var ajax=Ajax(oThis.url+'?id=0&t='+oThis.classId);
			ajax.fnSuccess=function()
			{
				var str=this.xmlHttp.responseText;
				eval("var arr="+str);
				oThis.factory(arr,1);
			}
		}
		else//用于修改类目
		{
			ajax=Ajax(oThis.url+'?sid='+strInput+'&t='+oThis.classId);
			ajax.fnSuccess=function()
			{
				var str=this.xmlHttp.responseText;
				eval("var arr="+str);
				oThis.init(arr);
			}
		}
		ajax.exe();
		
		
	}
	
}

