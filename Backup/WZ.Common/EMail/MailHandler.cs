using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace WZ.Common.EMail
{
    /// <summary>
    /// 邮件发送
    /// </summary>
    public class MailHandler
    {
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="mail">发送邮件所需的参数</param>
        public void SendSmtpEMail(MailParam mail)
        {
            SmtpClient client = new SmtpClient(mail.SmtpServer);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(mail.FromMail.Address, mail.FromPass);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage message = new MailMessage(mail.FromMail, mail.ToMail);
            message.Subject = mail.Subject;
            message.Body = mail.Body;
            

            //添加符件
            if (mail.AttachmentList != null && mail.AttachmentList.Count > 0)
            {
                foreach (Attachment att in mail.AttachmentList)
                {
                    message.Attachments.Add(att);
                }
            }

            //message.Priority = MailPriority.High;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            client.Port = mail.SmtpPort;
            client.EnableSsl = mail.EnableSsl;

            client.Send(message);
        }
    }
}
