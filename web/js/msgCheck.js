function msgCheck(msg)
{
	if(!msg)
		return;
	
	var s='';
	var arrS=msg.split(';');
	for(var i=0;i<arrS.length;i++)
	{
		if(arrS[i])
			s+='<li>'+arrS[i]+'</li>';
	}
	_.getClass('msgCheck').style.display='';
	_.getClass('msgCheck1').innerHTML=s;
}

function checkPub(funCheck)
{
	var msg=funCheck();
	
	if(msg)
	{
		msgCheck(msg);
		return false;
	}
	
	return true;
}

_.getValue=function(s)
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