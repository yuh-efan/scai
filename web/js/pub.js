//set default of input
function setTextDef(pName)
{
	this.obj=document.getElementById(pName);
	this.old=this.obj.value;
	
	var pThis=this;
	this.obj.onfocus=function()
	{
		if(pThis.old==this.value)
			this.value='';
	}
	
	this.obj.onblur=function()
	{
		if(!this.value)
			this.value=pThis.old;
	}
}

//get star level pic
function GetStar(curN)
{
	var j=0;
	var s='';
	for(j;j<curN;j++)
		s+='<img src="/images/star1.gif" />';

	for(j;j<5;j++)
		s+='<img src="/images/star.gif" />';
	
	return s;
}

var floatLayer=FloatFrame();
function flogin()
{
	floatLayer.src='/floatLayer/login.aspx';
	floatLayer.show();
}

function AddCart(pID,pN,t,buy)
{
	if(!pN) pN=1;
	if(!t) t=0;
	if(!buy) buy=0;
	
	floatLayer.src='/floatLayer/proAddCart.aspx?s='+pID+'-'+t+'-'+pN+'-'+buy;
	floatLayer.show();
}

//add pro to fav
function AddFav(pID,t)
{	
	if(!t) t=0
	
	var aj=new Ajax('/ajax/favAdd.aspx?id='+pID+'&t='+t);
	
	aj.fnSuccess=function()
	{
		eval('var jso='+this.xmlHttp.responseText);
		if(jso.info)
		{
			switch(jso.info)
			{
				case 'nologin':
					flogin();
					break;
				
				case 'success':
					alert('商品已收藏');
					break;
					
				default:
					alert(jso.info);
					break;
			}
		}
		else 
		{
			alert('非法操作')
		}
		
		//if(confirm(this.xmlHttp.responseText+'\r\n\r\n是否查看 我收藏的商品'))
		//{
			//location.href='/user/fav.aspx';
		//}
	}
	aj.exe();
}