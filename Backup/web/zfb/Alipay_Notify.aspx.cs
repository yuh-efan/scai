using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Net;


public partial class Alipay_Notify : System.Web.UI.Page
{
    #region 获取远程服务器ATN结果
    public String Get_Http(String a_strUrl, int timeout)
    {
        string strResult;
        try
        {

            HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(a_strUrl);
            myReq.Timeout = timeout;
            HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
            Stream myStream = HttpWResp.GetResponseStream();
            StreamReader sr = new StreamReader(myStream, Encoding.Default);
            StringBuilder strBuilder = new StringBuilder();
            while (-1 != sr.Peek())
            {
                strBuilder.Append(sr.ReadLine());
            }

            strResult = strBuilder.ToString();
        }
        catch (Exception exp)
        {

            strResult = "错误：" + exp.Message;
        }

        return strResult;
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        string alipayNotifyURL = "https://www.alipay.com/cooperate/gateway.do?service=notify_verify";
        //string alipayNotifyURL = "http://notify.alipay.com/trade/notify_query.do?";
        string partner = "w8jd71rc3pbdwg6qgf1r7j2g9t5sazuo"; 		//partner合作伙伴id（必须填写）
        string key = "2088002009652262"; //partner 的对应交易安全校验码（必须填写）
        string _input_charset = "gb2312";

        alipayNotifyURL = alipayNotifyURL + "&partner=" + partner + "&notify_id=" + Request.Form["notify_id"];

        //获取支付宝ATN返回结果，true是正确的订单信息，false 是无效的
        string responseTxt = Get_Http(alipayNotifyURL, 120000);

        int i;
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.Form;

        // Get names of all forms into a string array.
        String[] requestarr = coll.AllKeys;

        //进行排序；
        string[] Sortedstr = AliPay.BubbleSort(requestarr);


        #region 构造待md5摘要字符串 ；
        string prestr = "";
        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (Request.Form[Sortedstr[i]] != "" && Sortedstr[i] != "sign" && Sortedstr[i] != "sign_type")
            {
                if (i == Sortedstr.Length - 1)
                {
                    prestr = prestr + Sortedstr[i] + "=" + Request.Form[Sortedstr[i]];
                }
                else
                {
                    prestr = prestr + Sortedstr[i] + "=" + Request.Form[Sortedstr[i]] + "&";
                }
            }

        }
        prestr = prestr + key;
        #endregion
        string mysign = AliPay.GetMD5(prestr, _input_charset);

        string sign = Request.Form["sign"];

        if (mysign == sign && responseTxt == "true")   //验证支付发过来的消息，签名是否正确
        {
			if (Request.Form["trade_status"] == "WAIT_BUYER_PAY")//   判断支付状态_等待买家付款（文档中有枚举表可以参考）            
			{
				//更新自己数据库的订单语句，请自己填写一下
				string strOrderNO = Request.Form["out_trade_no"];//订单号
				string strPrice = Request.Form["price"];//金额



				Response.Write("success");     //返回给支付宝消息，成功，请不要改写这个success
			}
			else if(Request.Form["trade_status"] == "WAIT_SELLER_SEND_GOODS")//   判断支付状态_买家付款成功,等待卖家发货（文档中有枚举表可以参考）   
			{
				//更新自己数据库的订单语句，请自己填写一下



				Response.Write("success");     //返回给支付宝消息，成功，请不要改写这个success
			}
			else if(Request.Form["trade_status"] == "WAIT_BUYER_CONFIRM_GOODS")//   判断支付状态_卖家已发货等待买家确认（文档中有枚举表可以参考）   
			{
				//更新自己数据库的订单语句，请自己填写一下



				Response.Write("success");     //返回给支付宝消息，成功，请不要改写这个success
			}
			else if(Request.Form["trade_status"] == "TRADE_FINISHED")//   判断支付状态_交易成功结束（文档中有枚举表可以参考）   
			{
				//更新自己数据库的订单语句，请自己填写一下



				Response.Write("success");     //返回给支付宝消息，成功，请不要改写这个success
			}
			else
			{
				Response.Write("fail");

				//最好写TXT文件，以记录下是否异步返回记录。

				//写文本，纪录支付宝返回消息，比对md5计算结果（如网站不支持写txt文件，可改成写数据库）
				string TOEXCELLR = "MD5结果:mysign=" + mysign + ",sign=" + sign + ",responseTxt=" + responseTxt;
				StreamWriter fs = new StreamWriter(Server.MapPath("Notify_DATA/" + DateTime.Now.ToString().Replace(":", "")) + ".txt", false, System.Text.Encoding.Default);
				fs.Write(TOEXCELLR);
				fs.Close();
			}
           
		}
		else
		{
			Response.Write("fail");

			//最好写TXT文件，以记录下是否异步返回记录。

			//写文本，纪录支付宝返回消息，比对md5计算结果（如网站不支持写txt文件，可改成写数据库）
			string TOEXCELLR = "MD5结果:mysign=" + mysign + ",sign=" + sign + ",responseTxt=" + responseTxt;
			StreamWriter fs = new StreamWriter(Server.MapPath("Notify_DATA/" + DateTime.Now.ToString().Replace(":", "")) + ".txt", false, System.Text.Encoding.Default);
			fs.Write(TOEXCELLR);
			fs.Close();
		}
    }
}
