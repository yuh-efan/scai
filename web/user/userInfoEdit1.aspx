<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userInfoEdit1.aspx.cs" Inherits="WZ.Web.user.userInfoEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑个人档案 - 搜菜网</title>
    <w:headerUser id="header1" runat="server"></w:headerUser>
    <script type="text/javascript" src="/js/ui.floatFrame.js"></script>
    <script type="text/javascript" src="/js/pub.js"></script>
</head>
<body>
    <w:top id="ucTop" runat="server" />
   <w:userLocation id="ucUL" runat="server" Text=" &gt; 个人信息管理 &gt; 编辑个人档案"></w:userLocation>
   	<div class="main">
    	<div class="left">
    <w:userMenu ID="ucMenu" runat="server"></w:userMenu>
    </div>
    <form id="form1" runat="server">
    	<div class="right">
      
      <div class="User-box p-top">
        <h3><span>编辑个人档案</span></h3>
        <div class="Edit_Info">
          <h4>帮助我们完善您的个人信息，有助于我们未来根据您的情况提供更加个性化的服务；搜菜网会对您的个人资料隐私加以保密。</h4>
          <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td class="lefttd">姓名：</td>
              <td>
              <w:InputText ID="cName" runat="server" Attr='size="30"'></w:InputText>
                <span>*</span></td>
            </tr>
            <tr>
              <td class="lefttd">性别：</td>
              <td>
              <w:ShowText ID="cSex" runat=server></w:ShowText>
              <span>*</span></td>
            </tr>
            <tr>
              <td class="lefttd">Email：</td>
              <td><w:InputText ID="cEMail" runat="server" Attr='size="30"'></w:InputText>
                <span>*</span></td>
            </tr>
            <tr>
              <td class="lefttd">手机：</td>
              <td><w:InputText ID="cTel" runat="server" Attr='size="30"'></w:InputText>
                <span>*</span></td>
            </tr>
            <tr>
              <td class="lefttd">所在区域：</td>
              <td>
              <a id="cSelect" href="javascript:;"><b>选择</b></a>
              <span id="cSelectSpan"></span>
              <w:InputText ID="cArea" runat="server" Type="hidden"></w:InputText>
              <w:InputText ID="cSelectSpanHidden" runat="server" Type="hidden"></w:InputText>
              <span>*</span>
              </td>
            </tr>
            <tr>
              <td valign="top" class="lefttd">详细地址：</td>
              <td><w:InputText ID="cAddress" runat="server" Attr='size="50"'></w:InputText>
                <span>*</span></td>
            </tr>
          </table>
        </div>
        <div class="Edit_Info hidden">
          <h5>以下为选填信息</h5>
          <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td class="lefttd">固定电话：</td>
              <td><input name="" type="text" size="30" /></td>
            </tr>            
            <tr>
              <td class="lefttd">出生日期：</td>
              <td><select name="" disabled="disabled">
                  <option>1987</option>
                </select>
                <select name="" disabled="disabled">
                  <option>11</option>
                </select>
                <select name="" disabled="disabled">
                  <option>28</option>
                </select>
                <em>注意：出生日期填写后将不可修改，请认真填写，谢谢！</em></td>
            </tr>
            
            <tr>
              <td class="lefttd">婚姻状况：</td>
              <td><select name="">
                  <option>请选择</option>
                  <option>单身</option>
                  <option>已婚且有子女</option>
                  <option>已婚暂无子女</option>
                  <option>恋爱中</option>
                </select></td>
            </tr>
            <tr>
              <td class="lefttd">教育程度：</td>
              <td><select name="">
                  <option>请选择</option>
                  <option>高中及以下</option>
                  <option>大学专科</option>
                  <option>大学本科</option>
                  <option>硕士</option>
                  <option>博士及以上</option>
                </select></td>
            </tr>
            <tr>
              <td class="lefttd">从事职业：</td>
              <td><select name="">
                  <option>请选择</option>
                  <option>企业雇主/企业经营者</option>
                  <option>高级行政人员(行政总裁、总经理、董事等)</option>
                  <option>中层管理人员(总监、经理、主任等)</option>
                  <option>专业人士(会计师、律师、工程师、医生、教师等)</option>
                  <option>办公职员(一般文职、业务、办事人员等)工人、蓝领</option>
                  <option>工人/蓝领</option>
                  <option>公务员、公共事业单位员工</option>
                  <option>自由职业者</option>
                  <option>军人</option>
                  <option>学生</option>
                  <option>退休/无业人员</option>
                  <option>家庭主妇</option>
                  <option>其他</option>
                </select></td>
            </tr>
            <tr>
              <td class="lefttd">工作所属行业：</td>
              <td><select name="">
                  <option>请选择</option>
                  <option>政府机关/社会团体</option>
                  <option>邮电通讯</option>
                  <option>IT业/互联网</option>
                  <option>商业/贸易</option>
                  <option>旅游/餐饮/酒店</option>
                  <option>银行/金融/证券/保险/投资</option>
                  <option>健康/医疗服务</option>
                  <option>建筑/房地产</option>
                  <option>交通运输/物流仓储</option>
                  <option>法律/司法</option>
                  <option>文化/娱乐/体育</option>
                  <option>媒介/广告/咨询</option>
                  <option>教育/科研</option>
                  <option>林业/农业/牧业/渔业</option>
                  <option>制造业(轻工业)</option>
                  <option>制造业(重工业)</option>
                  <option>能源/公用事业</option>
                  <option>其他</option>
                </select></td>
            </tr>
            <tr>
              <td class="lefttd">月均收入：</td>
              <td><select name="">
                  <option value="" selected="selected"> 请选择&nbsp; </option>
                  <option value="无收入">无收入</option>
                  <option value="2000 元以下">2000 元以下</option>
                  <option value="2000～3999 元">2000～3999 元</option>
                  <option value="4000～5999 元">4000～5999 元</option>
                  <option value="6000～7999 元">6000～7999 元</option>
                  <option value="8000～9999 元">8000～9999 元</option>
                  <option value="10000～15000 元">10000～15000 元</option>
                  <option value="15000 元以上">15000 元以上</option>
                </select></td>
            </tr>
            <tr>
              <td class="lefttd">逛菜市场频率：</td>
              <td><select name="">
                  <option value="" selected="selected"> 请选择&nbsp; </option>
                  <option value="每天都逛">每天都逛</option>
                  <option value="三到五天一次">三到五天一次</option>
                  <option value="每周一次">一个星期一次</option>
                  <option value="一个星期到半个月一次">一个星期到半个月一次</option>
                  <option value="每月一次">每月一次</option>
                  <option value="三个月没去过了">三个月没去过了</option>
                  <option value="从来没去过">从来没去过</option>
                </select></td>
            </tr>
            <tr>
              <td class="lefttd">每次消费金额：</td>
              <td><select name="">
                  <option value="" selected="selected"> 请选择&nbsp; </option>
                  <option value="20元以下">20元以下</option>
                  <option value="20~50元">20~50元</option>
                  <option value="50~100元">50~100元</option>
                  <option value="100~300元">100~300元</option>
                  <option value="300元以上">300元以上</option>
                </select></td>
            </tr>
            <tr>
              <td valign="top" class="lefttd">喜欢吃些什么：</td>
              <td><ul class="Eating">
                  <li>
                    <input name="" type="checkbox" value="" />
                    绿叶蔬菜</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    菌类</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    猪肉</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    牛肉</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    羊肉</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    淡水河鲜</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    海鲜</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    豆制品</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    面食</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    禽蛋</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    鸡鸭</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    其他蔬菜</li>
                </ul></td>
            </tr>
            <tr>
              <td valign="top" class="lefttd">购买食品您更重那些因素：</td>
              <td><ul class="Eating">
                  <li>
                    <input name="" type="checkbox" value="" />
                    食品安全性保障</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    新鲜程度</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    品种产地</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    价格</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    食用方便</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    营养价值</li>
                  <li>
                    <input name="" type="checkbox" value="" />
                    可储存时间</li>
                </ul></td>
            </tr>
            <tr>
              <td valign="top" class="lefttd">兴趣爱好：</td>
              <td><textarea name="" cols="50" rows="3"></textarea></td>
            </tr>
            <tr>
              <td valign="top" class="lefttd">自我介绍：</td>
              <td><textarea name="" cols="50" rows="3"></textarea></td>
            </tr>
          </table>
          
        </div>
        <div class="btns">
        <asp:Button ID="bOK" runat="server" Text="保存" OnClick="bOK_Click" CssClass="anniucss" />
       
        </div>
      </div>
    </div>
    </form>
    	<div class="clear"></div>
	</div>
    <w:bottom id="ucBottom" runat="server" />
   
</body>
<script type="text/javascript" src="/js/ui.floatFrame.js"></script>
<script type="text/javascript">
//地区
floatLayer.width=658;
floatLayer.height=453;

var areaId=document.getElementById("cArea");

document.getElementById("cSelect").onclick=function()
{
	floatLayer.src="/floatLayer/classAjax.aspx?classId=area&id="+areaId.value;
	floatLayer.show();
}
function fnCallSure(o)//o.id==0 表示无限
{
    if(floatLayer.id!=0)
    {
        areaId.value=o.id;
        var sname=o.name.join(" > ");
	    document.getElementById("cSelectSpan").innerHTML=sname;
		document.getElementById("cSelectSpanHidden").value=sname;
    }
	fnHidden();
}
//框架 取消 按钮提交
function fnCallCancel()
{
	fnHidden();
}
function  fnHidden()
{
	floatLayer.hidden();
}

window.onload=function()
{
    document.getElementById("cSelectSpan").innerHTML=document.getElementById("cSelectSpanHidden").value;
}
</script>
</html>
