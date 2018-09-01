c<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="applyFor1.aspx.cs" Inherits="WZ.Web.user.applyFor1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>申请推广员 - 搜菜网</title>
    <w:headerUser id="header1" runat="server"></w:headerUser>
    <link href="/css/msgCheck.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/msgCheck.js"></script>
    <style type="text/css">
    .showtext{text-align:center; padding:20px; font-size:16px;}
    </style>
</head>
<body>
<w:top id="ucTop" runat="server" />
  <w:userLocation id="ucUL" runat="server" Text=" &gt; 申请推广员"></w:userLocation>
  <div class="main">
    <div class="left">
      <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
    </div>
    <form id="form1" runat="server">
    <div class="right"> 
    
    	<div class="User-box p-top">
            <h3><span>申请推广员</span></h3>
            
            <div id="htm_ApplyFor_no" runat="server" visible="false">
            <div class="Edit_Info">
                <div id="msg"><%=WZ.Common.Config.HTML.CheckMsg%></div>
                <table width="600" border="0" cellpadding="0" cellspacing="0" align="center">
                    <tr>
                      <td>姓名：</td>
                      <td><input id="name" name="name" type="text" /><span>*</span></td>
                    </tr>            
                    <tr>
                      <td>性别：</td>
                      <td><%=pageSex %><span>*</span></td>
                    </tr>
                    <tr>
                      <td>地址：</td>
                      <td><input id="address" name="address" type="text" style="width:280px" /><span>*</span></td>
                    </tr>
                    <tr>
                      <td>手机：</td>
                      <td><input id="tel" name="tel" type="text" /><span>手机和电话请至少输入一项</span></td>
                    </tr>
                    <tr>
                      <td>固定电话：</td>
                      <td><input id="fixtel" name="fixtel" type="text" /></td>
                    </tr>
                    
                    <tr>
                      <td>开户银行：</td>
                      <td><input id="bank" name="bank" type="text" style="width:280px" /><span>*</span></td>
                    </tr>
                    
                    <tr>
                      <td>银行账号：</td>
                      <td><input id="bankaccount" name="bankaccount" type="text" style="width:280px" /><span>*</span></td>
                    </tr>
                    
                    <tr>
                      <td>备注：</td>
                      <td><textarea id="remark" name="remark" style="width:440px; height:125px"></textarea></td>
                    </tr>
                    
                  </table>
            </div>
            
            <div class="btns">
                <script type="text/javascript">
                function bOK_Click()
                {
                    var param='hid=1&cmd=save'
                            +'&name='+_.getValue('name')
                            +'&sex='+_.getValue('sex')
                            +'&address='+_.getValue('address')
                            +'&tel='+_.getValue('tel')
                            +'&fixtel='+_.getValue('fixtel')
                            +'&bank='+_.getValue('bank')
                            +'&bankaccount='+_.getValue('bankaccount')
                            +'&remark='+_.getValue('remark')
                            ;
                            
                    Ajax('applyFor1.aspx',{
                    param:param,
                    method:'post',
                    fnSuccess:function(){
                        cb_ok(this.xmlHttp.responseText);
                    }
                    }).exe();
                    
                    return false;
                }
                
                function cb_ok(pStr)
                {
                    eval('var jso='+pStr);
                    switch(jso.type)
                    {
                        case 'error':
                            checkPub(function(){
                                var msg=jso.info;
                                return msg;
                            });
                            _.get('msg').scrollIntoView();
                            break;
                        case 'success':
                            _.getClass("msgCheck").style.display='none';
                            alert('申请成功');
                            break;
                        default:
                            alert(jso.info)
                            break;
                    }
                }
                </script>
                <input type="button" name="bOK" id="bOK" value="申请" onclick="bOK_Click()" class="anniucss"/>
                </div>
            </div>
            
            <div id="htm_ApplyFor_1" runat="server" visible="false" class="showtext">
                您推广资料已请提交申请。
            </div>
            
            <div id="htm_ApplyFor_2" runat="server" visible="false" class="showtext">
                您推广资料未通过申请。
            </div>
            
            <div id="htm_ApplyFor_3" runat="server" visible="false" class="showtext">
                您已成功申请为推广员。
            </div>
         </div>
      
    	</div>
    </form>
    <div class="clear"></div>
  </div>
<w:bottom id="ucBottom" runat="server" />
</body>
</html>
