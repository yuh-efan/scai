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
        #region ֧����ҵ�����
        string gateway = "https://www.alipay.com/cooperate/gateway.do?";	//֧���ӿ�
        string service = "create_partner_trade_by_buyer";                           //��������

        string seller_email = "236283719@qq.com";				        //֧�����ʺ�
        string sign_type = "MD5";                                           //��������,ǩ����ʽ�����øġ�
        string key = "w8jd71rc3pbdwg6qgf1r7j2g9t5sazuo";                    //��ȫУ����
        string partner = "2088002009652262";		                        //�̻�ID������ID
        string _input_charset = "gb2312"; 

        string show_url = "www.alipay.com";                                 //չʾ��ַ��֧��ҳʱ��Ʒ�����Ե���������ӵ�ַ

        string out_trade_no = TxtOrderno.Text.Trim();                       //�ͻ���վ�����ţ�����ȡϵͳʱ�䣬�ɸĳ���վ�Լ��ı�����
        string subject = TxtSubject.Text.Trim();                            //��Ʒ����
        string body = TxtBody.Text.Trim();                                  //��Ʒ����
        body = body.Replace("\n", string.Empty);
        body = body.Replace("\r", string.Empty);
        string price = TxtPrice.Text.Trim();                                //��Ʒ�۸�
        string quantity = "1";// TxtQua.Text.Trim();                               //��Ʒ����

        string logistics_type = "POST";                                     //�������ͷ�ʽ��POST(ƽ��)��EMS(EMS)��EXPRESS(�������)
        string logistics_fee = "0";// TxtPost.Text.Trim();                         //�������ͷ���
        string logistics_payment = "BUYER_PAY";                             //�������ͷ��ø��ʽ��SELLER_PAY(����֧��)��BUYER_PAY(���֧��)��BUYER_PAY_AFTER_RECEIVE(��������)

        //������֪ͨurl��Alipay_Notify.asp�ļ�����·����
        string notify_url = "http://192.168.1.190/zfb/Alipay_Notify.aspx";
        //����������url��return_Alipay_Notify.asp�ļ�����·����
        string return_url = "http://192.168.1.190/zfb/Alipay_Return.aspx";
        //��ز������ƾ��庬�壬������֧�����ӿڷ����ĵ��в�ѯ����
        //���������ļ���֪ͨ������������notify dataĿ¼�ҵ�֪ͨ��������־

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

        //������POST��ʽ���ݲ���
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

        //������GET��ʽ���ݲ���
        //Response.Redirect(aliay_url);
        #endregion
    }
}
#region alipay���ļ��벻Ҫ���Ķ�
/// <summary>
/// created by zhui_0
/// </summary>
public class AliPay
{


    /// <summary>
    /// ��ASP���ݵ�MD5�����㷨
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
    /// ð������
    /// </summary>
    public static string[] BubbleSort(string[] r)
    {
        int i, j; //������־ 
        string temp;

        bool exchange;

        for (i = 0; i < r.Length; i++) //�����R.Length-1������ 
        {
            exchange = false; //��������ʼǰ��������־ӦΪ��

            for (j = r.Length - 2; j >= i; j--)
            {
                if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)��//��������
                {
                    temp = r[j + 1];
                    r[j + 1] = r[j];
                    r[j] = temp;

                    exchange = true; //�����˽������ʽ�������־��Ϊ�� 
                }
            }

            if (!exchange) //��������δ������������ǰ��ֹ�㷨 
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
        /// created by sunzhizhi 2006.5.21,sunzhizhi@msn.com��
        /// </summary>
        int i;

        //�������飻
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

        //��������
        string[] Sortedstr = BubbleSort(Oristr);


        //�����md5ժҪ�ַ��� ��

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

        //����Md5ժҪ��
        string sign = GetMD5(prestr.ToString(), _input_charset);

        //������POST��ʽ���ݲ���
        return sign;

        //������GET��ʽ���ݲ���

        //����֧��Url��
        //StringBuilder parameter = new StringBuilder();
        //parameter.Append(gateway);
        //for (i = 0; i < Sortedstr.Length; i++)
        //{
        //    parameter.Append(Sortedstr[i] + "&");
        //}

        //parameter.Append("sign=" + sign + "&sign_type=" + sign_type);

        ////����֧��Url��
        //return parameter.ToString();

    }

}
#endregion