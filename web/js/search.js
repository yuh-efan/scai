//must have base.js,ajax.js
(function(){
    window.W={
        init:function(jso)
        {
            jso=jso || {};
            if(!jso.pro) jso.pro="请输入商品关键词";
            if(!jso.caipu) jso.caipu="请输入食谱关键词";
            if(!jso.news) jso.news="请输入资讯关键词";
            
            W.url="/ajax/searchKW.aspx";
            W.ajax=Ajax();
            W.bt=_.get("btSearch");
            var tab=_.getChild("searchTab");
            W.type=[
                {ele:tab[0],param:"0",init:jso.pro,href:"/search/product.aspx?s=-----{0}"},
                {ele:tab[1],param:"1",init:jso.caipu,href:"/search/caipu.aspx?s=-----{0}"},
                //{ele:tab[2],param:"2",init:"请输入套餐关键词",href:"/search/taocan.aspx?s=-----{0}"},
                {ele:tab[2],param:"2",init:jso.news,href:"/search/news.aspx?s=-----{0}"}
            ];
            
            W.cssTab=["sel",""];//菜单
            W.cssDivA=["sel",""];//下接
            W.input=_.get("kw");
            W.div=_.get("kwList");
            
            _.attr(W.input,"autocomplete","off");

            W.currType=W.type[0];
            W.currType.ele.className=W.cssTab[0];//tab 初始化选中
            W.setVal();
            W.hidden();
            
            W.tabEvent();
            W.inputEvent();
            W.divEvent();
            W.btEvent();
			W.tabCng(navIndex);
            
			W.initInput();
			
        },
		initInput:function()
		{
			var s=_.getUrlParam('s');
			if(!s) 
				return;
			var arrS=s.split('-');
			
			if(arrS[5])
				W.setVal(decodeURIComponent(arrS[5]));
			
		},
        btEvent:function()
        {
            W.bt.onclick=function()
            {
				//if(W.currInitN()>=0)
					//W.setVal("");
                W.GO();
            }
        },
        tabEvent:function()
        {
            for(var i=0;i<W.type.length;i++)
            {
                W.type[i].ele.onmousedown=(function(i)
                {
                    return function()
                    {
                        W.tabCng(i);
                    }
                    
                })(i)
            }
        },
        tabCng:function(i)
        {
            //是否是当前对象
            if(W.type.indexOf(W.currType)==i)
                return;
            
            //文本框处理
            if(W.currInitN()>=0)//已改
                W.setVal(W.type[i].init);
            
            //跟换样式
            W.currType.ele.className=W.cssTab[1];
            W.currType=W.type[i];
            W.type[i].ele.className=W.cssTab[0];
           
            //div清空
            W.div.innerHTML="";
        },
        currInitN:function()//加
        {
            return W.getVal().indexOf(W.currType.init);
        },
        
        b:false,
        val:"",
        inputEvent:function()
        {
            
            W.input.onfocus=function()//input 获得焦点
            {
                if(W.currInitN()>=0)
                {
                    W.setVal("");
                }
                else
                {
                    W.liInitCss();
                    if(_.getTN("li",W.div).length>0)
                        W.show();
                }
            }
            W.input.onblur=function()//input 失去焦点
            {
                if(!W.getVal())
                    W.setVal();
                    
                W.hidden();
            }
            W.input.onkeydown=function(e)
            {
                e=e||window.event;
                W.key(e)
            }
            W.input.onkeyup=function(e)
            {
                if(!W.b)
                    return ;
                    
                W.val=W.getVal();
                
                e=e||window.event;
                if(!W.getVal())
                {
                    W.hidden();//隐藏和清空
                }
                else
                    W.getData();
            }
        },
        
        key:function(e)
        {
            W.b=false;
            
            var k=e.keyCode;
            switch(k)
            {
                case 13://enter
                    if (e.preventDefault)
		                e.preventDefault();//标准DOM取消默认事件
	                else
		                e.returnValue=false;//取消默认事件
		            W.GO();
		            break;
		        case 40://down
		            W.time("down");
		            break;
		        case 38://up
		            W.time("up");
		            break;
//		        case 37://left
//		        case 39://right
		            break;
		        default:
		            W.b=true;
		            break;
            }
        },
        
        time:function(s)
        {
            if(!W.t)
            {
                W.t=true;
                setTimeout(function(){W.path(s)},100);
            }
        },
        
        path:function(s)
	    {
	        var aA=_.getTN("li",W.div);
	        if(aA.length==0)
	        {
	            W.t=false;
	            return false;
    	    }
    	    
            var n=-1;
            for(var i=0;i<aA.length;i++)
            {
                if(aA[i]==W.currLI)
                {
                    n=i;
                }
            }

	        var iSel=-1;
	        if(s=="down")
	        {
	            if(n==-1)
	                iSel=0;
	            else if(n==aA.length-1)
	            {
	                W.reset();
	                return;
	            }
	            else
	                iSel=n+1;
	        }
	        else if(s=="up")
	        {
	            if(n==-1)
	                iSel=aA.length-1;
	            else if(n==0)
	            {
	                W.reset();
	                return;
	            }
	            else
	                iSel=n-1;
	        }
    	    
            W.liSelCss(aA[iSel]);
            
            W.setVal(_.lastChild(W.currLI).innerHTML);
            
            W.t=false;
	    },
	    reset:function()
	    {
	        W.setVal(W.val);
            W.liInitCss();
            W.t=false;
	    },
	    
	    //数据获取
	    xmlHttp:{},
	    
	    getData:function()
        {
            W.ajax.url="{0}?t={1}&kw={2}".format(W.url,W.currType.param,encodeURIComponent(W.getVal()));
            W.ajax.fnSuccess=function(){
                eval("var aStr="+this.xmlHttp.responseText);
                var aS=[];
                for(var i=0;i<aStr.length;i++)
                {
                    if(!aStr[i])
                        continue;
                    aS.push('<li><span class="seaRight"></span><span>{0}</span></li>'.format(aStr[i]));
                    //aS.push('<li>{0}</li>'.format(aStr[i]));
                }
                if(aS.length>0)
                {
                    W.div.innerHTML="<ul>{0}</ul>".format(aS.join(""));
                    //去除最后li的边框
                    var li=_.getTN("li",W.div);
                    li[li.length-1].style.borderBottom="none";
                    
                    W.show();
                }
                else
                {
                    W.hidden();
                    
                    W.div.innerHTML="";//加
                }
            
            }
            W.ajax.exe();
        },
        show:function()
        {
            with(W.div.style)
            {
                display="";
            }            
        },
        hidden:function()
        {
            with(W.div.style)
            {
                display="none";
            }
        },
        
        currLI:{},
        divEvent:function()
        {
            W.div.onmouseover=W.div.onmousedown=W.liE;//mouseover   click   指向同一函数
        },
        
        liE:function(e)
        {
            e=e||event;
            var obj=e.target||e.srcElement;
            while(obj!=W.div)
            {
                if(obj.tagName=="LI")
                {
                    if(e.type=="mouseover")
                    {
                        W.liSelCss(obj)
                    }
                    else if(e.type=="mousedown")
                    {
                    
                        W.setVal(_.lastChild(obj).innerHTML);
                        W.GO();
                    }
                }
                obj=obj.parentNode;
            }
        },
        liSelCss:function(obj)
        {
            if(W.currLI!=obj)
            {
                W.currLI.className=W.cssDivA[1];//还原
                W.currLI=obj;
                W.currLI.className=W.cssDivA[0];//选中
            }
           
        },
        liInitCss:function()
        {
            W.currLI.className=W.cssDivA[1];
            W.currLI={};
        },
        setVal:function(s)
        {
            if(typeof s!=="string")
                s=W.currType.init;
            W.input.value=s;
        },
        getVal:function()
        {
            return W.input.value.trim();
        },
        GO:function()
        {
            location.href=W.currType.href.format(encodeURIComponent(W.getVal().split('-').join(' ')));
        }
    };
})();

