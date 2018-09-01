(function(){
                window.unl=
                {
                    arr:["qq.com","163.com","126.com","sina.com","sina.cn","sohu.com","hotmail.com","gmail.com"],
                    input:_.get("cName"),
                    pwd:_.get("cPwd"),
                    div:_.get("cNameList"),
                    b:false,
                    cssDivA:["select",""],
                    
                    
                    go:function(s,e)
                    {
                        if(s)
                            unl.setVal(s);
                        unl.hidden();
                        if(unl.tt)
                            clearTimeout(unl.tt)
                        unl.tt=setTimeout(function(){unl.pwd.focus();},0)
                        
                    },
                    init:function()
                    {
                        _.attr(unl.input,"autocomplete","off");//去除默认 提示
                        
                        unl.inputEvent();
                        unl.divEvent();
                    },
                    inputEvent:function()
                    {
                        unl.input.onfocus=function()//input 获得焦点
                        {
                            if(!unl.getVal())
                                unl.hidden();
                            else
                                unl.show();
                        }
                        unl.input.onblur=function()//input 失去焦点
                        {                                
                            unl.hidden();
                        }
                        
                        unl.input.onkeydown=function(e)
                        {
                            e=e||window.event;
                            unl.key(e)
                        }
                        unl.input.onkeyup=function(e)
                        {
                            if(!unl.b)
                                return ;
                            
                            e=e||window.event;
                            if(!unl.getVal())
                                unl.hidden();
                            else
                                unl.getData();
                        }
                        
                        
                    },
                    key:function(e)
                    {
                        unl.b=false;
                        
                        var k=e.keyCode;
                        switch(k)
                        {
                            case 13://enter
                                if (e.preventDefault)
		                            e.preventDefault();//标准DOM取消默认事件
	                            else
		                            e.returnValue=false;//取消默认事件
		                        
		                        unl.go(unl.currSpan.innerHTML,e);

		                        break;
		                    case 40://down
		                        unl.time("down");
		                        break;
		                    case 38://up
		                        unl.time("up");
		                        break;
		                    default:
		                        unl.b=true;
		                        break;
                        }
                    },
                    divEvent:function()
                    {
                        unl.div.onmouseover=unl.div.onmousedown=unl.spanE;//mouseover   click   指向同一函数
                    },
                    spanE:function(e)
                    {
                        e=e||event;
                        var obj=e.target||e.srcElement;
                        while(obj!=unl.div)
                        {
                            if(obj.tagName=="SPAN")
                            {
                                if(e.type=="mouseover")
                                {
                                    unl.spanSelCss(obj)
                                }
                                else if(e.type=="mousedown")
                                {
                                    unl.go(obj.innerHTML,e);
                                }
                            }
                            obj=obj.parentNode;
                        }
                    },
                    time:function(s)
                    {
                        if(!unl.t)
                        {
                            unl.t=true;
                            setTimeout(function(){unl.path(s)},100);
                        }
                    },
                    
                    currSpan:{},
                    path:function(s)
	                {
	                    var aA=_.getTN("span",unl.div);
	                    if(aA.length==0)
	                        return false;
                	    
                        var n=-1;
                        for(var i=0;i<aA.length;i++)
                        {
                            if(aA[i]==unl.currSpan)
                            {
                                n=i;
                            }
                        }

	                    var iSel=-1;
	                    if(s=="down")
	                    {
	                        if(n==-1||n==aA.length-1)
	                            iSel=0;
	                        else
	                            iSel=n+1;
	                    }
	                    else if(s=="up")
	                    {
	                        if(n==-1||n==0)
	                            iSel=aA.length-1;
	                        else
	                            iSel=n-1;
	                    }
                	    
                        unl.spanSelCss(aA[iSel]);
                        unl.t=false;
                        
                        
	                },
	                spanSelCss:function(obj)
	                {
                        if(unl.currSpan!=obj)
                        {
                            unl.currSpan.className=unl.cssDivA[1];//还原
                            unl.currSpan=obj;
                            unl.currSpan.className=unl.cssDivA[0];//选中
                        }
                       
                    },
                    getData:function()
                    {
                        var tmp='<span>{0}@{1}</span>';
                        var s="";
                         
                         
                         
                        var ema=unl.getVal()
                        var d=ema.split('@');
                        
                        if(d.length==2)
                        {
                            for(var i=0;i<unl.arr.length;i++)
                            {
                                if(unl.arr[i].search(new RegExp("^"+d[1],"i"))>-1)
                                    s+=tmp.format(d[0],unl.arr[i]);
                            }
                        }
                        else if(d.length<2)
                        {
                            for(var i=0;i<unl.arr.length;i++)
                            {
                                s+=tmp.format(ema,unl.arr[i]);
                            }
                        }
                        
                        if(s)
                        {
                            unl.div.innerHTML=s;
                            _.lastChild(unl.div).style.borderBottom="none";
                            unl.show();
                        }
                        else
                        {
                            unl.hidden();
                        }
                        
                        
                        
                    },
                    getVal:function()
                    {
                        return unl.input.value.trim();
                    },
                    setVal:function(s)
                    {
                        this.input.value=s
                    },
                    hidden:function()
                    {
                        unl.div.style.display="none";
                    },
                    show:function()
                    {
                        unl.div.style.display="block";
                    }
                }
              })();
              
              unl.init();