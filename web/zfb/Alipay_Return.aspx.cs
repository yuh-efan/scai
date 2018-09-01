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


public partial class Alipay_Return : System.Web.UI.Page
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
        string key = "w8jd71rc3pbdwg6qgf1r7j2g9t5sazuo"; //partner 的对应交易安全校验码（必须填写）
        string partner = "2088002009652262"; 		//partner合作伙伴id（必须填写）
        string _input_charset = "gb2312";

        alipayNotifyURL = alipayNotifyURL + "&partner=" + partner + "&notify_id=" + Request.QueryString["notify_id"];

        // 获取支付宝ATN返回结果，true是正确的订单信息，false 是无效的
        string responseTxt = Get_Http(alipayNotifyURL, 120000);
        int i;
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.QueryString;

        // Get names of all forms into a string array.
        String[] requestarr = coll.AllKeys;

        //进行排序；
        string[] Sortedstr = AliPay.BubbleSort(requestarr);

        #region 构造待md5摘要字符串 ；

        StringBuilder prestr = new StringBuilder();

        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (Request.Form[Sortedstr[i]] != "" && Sortedstr[i] != "sign" && Sortedstr[i] != "sign_type")
            {
                if (i == Sortedstr.Length - 1)
                {
                    prestr.Append(Sortedstr[i] + "=" + Request.QueryString[Sortedstr[i]]);
                }
                else
                {
                    prestr.Append(Sortedstr[i] + "=" + Request.QueryString[Sortedstr[i]] + "&");

                }
            }
        }
        prestr.Append(key);
        #endregion

        //生成Md5摘要；
        string mysign = AliPay.GetMD5(prestr.ToString(), _input_charset);

        string sign = Request.QueryString["sign"];

        //  Response.Write(prestr.ToString());  

        if (mysign == sign && responseTxt == "true")   //验证支付发过来的消息，签名是否正确
        {

            //更新自己数据库的订单语句，请自己填写一下
            string strOrderNO = Request.QueryString["out_trade_no"];//订单号
            string strPrice = Request.QueryString["price"];//金额



            Response.Write("订单号：" + strOrderNO + "<br>金额：" + strPrice);     //成功，可美化该页面
        }
        else
        {
            // Response.Write("------------------------------------------");
            // Response.Write("<br>Result:responseTxt=" + responseTxt);
            // Response.Write("<br>Result:mysign=" + mysign);
            // Response.Write("<br>Result:sign=" + sign);
            Response.Write("fail");
        }
    }
}
