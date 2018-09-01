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
using WZ.Common;


public partial class _alipaydefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.TxtOrderno.Text = Fn.SCNumber();
            string idSub=Req.GetQueryString("id");
            this.TxtSubject.Text = idSub;

            if (idSub.Length > 0)
            {
                this.TxtSubject.ReadOnly = true;
                this.htm01.Visible = false;
            }
            
        }
    }

    protected void BtnAlipay_Click(object sender, EventArgs e)
    {
        #region 支付宝业务参数
        string gateway = "https://www.alipay.com/cooperate/gateway.do?";	//支付接口
        string service = "create_partner_trade_by_buyer";                           //服务名称

        string seller_email = "236283719@qq.com";				        //支付宝帐号
        string sign_type = "MD5";                                           //加密类型,签名方式“不用改”
        string key = "w8jd71rc3pbdwg6qgf1r7j2g9t5sazuo";                    //安全校验码
        string partner = "2088002009652262";		                        //商户ID，合作ID
        string _input_charset = "gb2312"; 

        string show_url = "www.alipay.com";                                 //展示地址，支付页时商品名称旁的详情的链接地址

        string out_trade_no = TxtOrderno.Text.Trim();                       //客户网站订单号，（现取系统时间，可改成网站自己的变量）
        string subject = TxtSubject.Text.Trim();                            //商品名称
        string body = TxtBody.Text.Trim();                                  //商品描述
        body = body.Replace("\n", string.Empty);
        body = body.Replace("\r", string.Empty);
        string price = TxtPrice.Text.Trim();                                //商品价格
        string quantity = "1";// TxtQua.Text.Trim();                               //商品数量

        string logistics_type = "POST";                                     //物流配送方式：POST(平邮)、EMS(EMS)、EXPRESS(其他快递)
        string logistics_fee = "0";// TxtPost.Text.Trim();                         //物流配送费用
        string logistics_payment = "BUYER_PAY";                             //物流配送费用付款方式：SELLER_PAY(卖家支付)、BUYER_PAY(买家支付)、BUYER_PAY_AFTER_RECEIVE(货到付款)

        //服务器通知url（Alipay_Notify.asp文件所在路经）
        string notify_url = "http://192.168.1.190/zfb/Alipay_Notify.aspx";
        //服务器返回url（return_Alipay_Notify.asp文件所在路经）
        string return_url = "http://192.168.1.190/zfb/Alipay_Return.aspx";
        //相关参数名称具体含义，可以在支付宝接口服务文档中查询到，
        //以上两个文件，通知正常都可以在notify data目录找到通知过来的日志

        string aliay_url = AliPay.CreatUrl(
            gateway,
            service,
            partner,
            sign_type,
            out_trade_no,
            subject,
            body,
            price,
            show_url,
            seller_email,
            key,
            return_url,
            _input_charset,
            notify_url,
            logistics_type,
            logistics_fee,
            logistics_payment,
            quantity
            );

        //以下是POST方式传递参数
        Response.Write("<form name='alipaysubmit' method='get' action='https://www.alipay.com/cooperate/gateway.do?'>");
        Response.Write("<input type='hidden' name='service' value=" + service + ">");
        Response.Write("<input type='hidden' name='partner' value=" + partner + ">");
        Response.Write("<input type='hidden' name='sign_type' value=" + sign_type + ">");
        Response.Write("<input type='hidden' name='out_trade_no' value=" + out_trade_no + ">");
        Response.Write("<input type='hidden' name='subject' value=" + subject + ">");
        Response.Write("<input type='hidden' name='body' value=" + body + ">");
        Response.Write("<input type='hidden' name='price' value=" + price + ">");
        Response.Write("<input type='hidden' name='show_url' value=" + show_url + ">");
        Response.Write("<input type='hidden' name='seller_email' value=" + seller_email + ">");
        Response.Write("<input type='hidden' name='return_url' value=" + return_url + ">");
        Response.Write("<input type='hidden' name='notify_url' value=" + notify_url + ">");
        Response.Write("<input type='hidden' name='logistics_type' value=" + logistics_type + ">");
        Response.Write("<input type='hidden' name='logistics_fee' value=" + logistics_fee + ">");
        Response.Write("<input type='hidden' name='logistics_payment' value=" + logistics_payment + ">");
        Response.Write("<input type='hidden' name='payment_type' value=1>");
        Response.Write("<input type='hidden' name='quantity' value=" + quantity + ">");
        Response.Write("<input type='hidden' name='sign' value=" + aliay_url + ">");
        Response.Write("</form>");
        Response.Write("<script>");
        Response.Write("document.alipaysubmit.submit()");
        Response.Write("</script>");

        //以下是GET方式传递参数
        //Response.Redirect(aliay_url);
        #endregion
    }
}
#region alipay类文件请不要随便改动
/// <summary>
/// created by zhui_0
/// </summary>
public class AliPay
{


    /// <summary>
    /// 与ASP兼容的MD5加密算法
    /// </summary>
    public static string GetMD5(string s, string _input_charset)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
        StringBuilder sb = new StringBuilder(32);
        for (int i = 0; i < t.Length; i++)
        {
            sb.Append(t[i].ToString("x").PadLeft(2, '0'));
        }
        return sb.ToString();
    }

    /// <summary>
    /// 冒泡排序法
    /// </summary>
    public static string[] BubbleSort(string[] r)
    {
        int i, j; //交换标志 
        string temp;

        bool exchange;

        for (i = 0; i < r.Length; i++) //最多做R.Length-1趟排序 
        {
            exchange = false; //本趟排序开始前，交换标志应为假

            for (j = r.Length - 2; j >= i; j--)
            {
                if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)　//交换条件
                {
                    temp = r[j + 1];
                    r[j + 1] = r[j];
                    r[j] = temp;

                    exchange = true; //发生了交换，故将交换标志置为真 
                }
            }

            if (!exchange) //本趟排序未发生交换，提前终止算法 
            {
                break;
            }
        }
        return r;
    }

    public static string CreatUrl(
        string gateway,
        string service,
        string partner,
        string sign_type,
        string out_trade_no,
        string subject,
        string body,
        string total_fee,
        string show_url,
        string seller_email,
        string key,
        string return_url,
        string _input_charset,
        string notify_url,
        string logistics_type,
        string logistics_fee,
        string logistics_payment,
        string quantity
        )
    {
        /// <summary>
        /// created by sunzhizhi 2006.5.21,sunzhizhi@msn.com。
        /// </summary>
        int i;

        //构造数组；
        string[] Oristr ={ 
                "service="+service, 
                "partner=" + partner, 
                "subject=" + subject, 
                "body=" + body, 
                "out_trade_no=" + out_trade_no, 
                "price=" + total_fee, 
                "show_url=" + show_url,  
                "payment_type=1", 
                "seller_email=" + seller_email, 
                "notify_url=" + notify_url,       
                "return_url=" + return_url,
                "quantity="+quantity,
                "logistics_type="+logistics_type,
                "logistics_fee="+logistics_fee ,
                "logistics_payment="+logistics_payment
                };

        //进行排序；
        string[] Sortedstr = BubbleSort(Oristr);


        //构造待md5摘要字符串 ；

        StringBuilder prestr = new StringBuilder();

        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (i == Sortedstr.Length - 1)
            {
                prestr.Append(Sortedstr[i]);

            }
            else
            {

                prestr.Append(Sortedstr[i] + "&");
            }

        }

        prestr.Append(key);

        //生成Md5摘要；
        string sign = GetMD5(prestr.ToString(), _input_charset);

        //以下是POST方式传递参数
        return sign;

        //以下是GET方式传递参数

        //构造支付Url；
        //StringBuilder parameter = new StringBuilder();
        //parameter.Append(gateway);
        //for (i = 0; i < Sortedstr.Length; i++)
        //{
        //    parameter.Append(Sortedstr[i] + "&");
        //}

        //parameter.Append("sign=" + sign + "&sign_type=" + sign_type);

        ////返回支付Url；
        //return parameter.ToString();

    }

}
#endregion