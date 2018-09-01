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
    #region ��ȡԶ�̷�����ATN���
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

            strResult = "����" + exp.Message;
        }

        return strResult;
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        string alipayNotifyURL = "https://www.alipay.com/cooperate/gateway.do?service=notify_verify";
        //string alipayNotifyURL = "http://notify.alipay.com/trade/notify_query.do?";
        string partner = "w8jd71rc3pbdwg6qgf1r7j2g9t5sazuo"; 		//partner�������id��������д��
        string key = "2088002009652262"; //partner �Ķ�Ӧ���װ�ȫУ���루������д��
        string _input_charset = "gb2312";

        alipayNotifyURL = alipayNotifyURL + "&partner=" + partner + "&notify_id=" + Request.Form["notify_id"];

        //��ȡ֧����ATN���ؽ����true����ȷ�Ķ�����Ϣ��false ����Ч��
        string responseTxt = Get_Http(alipayNotifyURL, 120000);

        int i;
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.Form;

        // Get names of all forms into a string array.
        String[] requestarr = coll.AllKeys;

        //��������
        string[] Sortedstr = AliPay.BubbleSort(requestarr);


        #region �����md5ժҪ�ַ��� ��
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

        if (mysign == sign && responseTxt == "true")   //��֤֧������������Ϣ��ǩ���Ƿ���ȷ
        {
			if (Request.Form["trade_status"] == "WAIT_BUYER_PAY")//   �ж�֧��״̬_�ȴ���Ҹ���ĵ�����ö�ٱ���Բο���            
			{
				//�����Լ����ݿ�Ķ�����䣬���Լ���дһ��
				string strOrderNO = Request.Form["out_trade_no"];//������
				string strPrice = Request.Form["price"];//���



				Response.Write("success");     //���ظ�֧������Ϣ���ɹ����벻Ҫ��д���success
			}
			else if(Request.Form["trade_status"] == "WAIT_SELLER_SEND_GOODS")//   �ж�֧��״̬_��Ҹ���ɹ�,�ȴ����ҷ������ĵ�����ö�ٱ���Բο���   
			{
				//�����Լ����ݿ�Ķ�����䣬���Լ���дһ��



				Response.Write("success");     //���ظ�֧������Ϣ���ɹ����벻Ҫ��д���success
			}
			else if(Request.Form["trade_status"] == "WAIT_BUYER_CONFIRM_GOODS")//   �ж�֧��״̬_�����ѷ����ȴ����ȷ�ϣ��ĵ�����ö�ٱ���Բο���   
			{
				//�����Լ����ݿ�Ķ�����䣬���Լ���дһ��



				Response.Write("success");     //���ظ�֧������Ϣ���ɹ����벻Ҫ��д���success
			}
			else if(Request.Form["trade_status"] == "TRADE_FINISHED")//   �ж�֧��״̬_���׳ɹ��������ĵ�����ö�ٱ���Բο���   
			{
				//�����Լ����ݿ�Ķ�����䣬���Լ���дһ��



				Response.Write("success");     //���ظ�֧������Ϣ���ɹ����벻Ҫ��д���success
			}
			else
			{
				Response.Write("fail");

				//���дTXT�ļ����Լ�¼���Ƿ��첽���ؼ�¼��

				//д�ı�����¼֧����������Ϣ���ȶ�md5������������վ��֧��дtxt�ļ����ɸĳ�д���ݿ⣩
				string TOEXCELLR = "MD5���:mysign=" + mysign + ",sign=" + sign + ",responseTxt=" + responseTxt;
				StreamWriter fs = new StreamWriter(Server.MapPath("Notify_DATA/" + DateTime.Now.ToString().Replace(":", "")) + ".txt", false, System.Text.Encoding.Default);
				fs.Write(TOEXCELLR);
				fs.Close();
			}
           
		}
		else
		{
			Response.Write("fail");

			//���дTXT�ļ����Լ�¼���Ƿ��첽���ؼ�¼��

			//д�ı�����¼֧����������Ϣ���ȶ�md5������������վ��֧��дtxt�ļ����ɸĳ�д���ݿ⣩
			string TOEXCELLR = "MD5���:mysign=" + mysign + ",sign=" + sign + ",responseTxt=" + responseTxt;
			StreamWriter fs = new StreamWriter(Server.MapPath("Notify_DATA/" + DateTime.Now.ToString().Replace(":", "")) + ".txt", false, System.Text.Encoding.Default);
			fs.Write(TOEXCELLR);
			fs.Close();
		}
    }
}
