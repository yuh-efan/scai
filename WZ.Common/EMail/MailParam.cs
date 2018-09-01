using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace WZ.Common.EMail
{
    /// <summary>
    /// 发送邮件专用专数数类
    /// </summary>
    public class MailParam
    {
        private string smtpServer;
        private MailAddress fromMail;
        private string fromPass;
        private MailAddress toMail;
        private string subject;
        private string body;
        private IList<Attachment> attachmentList;
        private int smtpPort = 25;
        private bool enableSsl = false;

        public MailParam(string smtpServer, MailAddress fromMail, string fromPass, MailAddress toMail, string subject, string body, IList<Attachment> attachmentList)
        {
            this.smtpServer = smtpServer;
            this.fromMail = fromMail;
            this.fromPass = fromPass;
            this.toMail = toMail;
            this.subject = subject;
            this.body = body;
            this.attachmentList = attachmentList;
        }

        #region 属性
        /// <summary>
        /// 用于 SMTP 事务的主机的名称或 IP 地址。
        /// </summary>
        public string SmtpServer
        {
            get { return this.smtpServer; }
        }

        /// <summary>
        /// 发件人邮箱地址
        /// </summary>
        public MailAddress FromMail
        {
            get { return this.fromMail; }
        }

        /// <summary>
        /// 发件人邮箱密码
        /// </summary>
        public string FromPass
        {
            get { return this.fromPass; }
        }

        /// <summary>
        /// 收件人邮箱地址
        /// </summary>
        public MailAddress ToMail
        {
            get { return this.toMail; }
        }

        /// <summary>
        /// 主题
        /// </summary>
        public string Subject
        {
            get { return this.subject; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Body
        {
            get { return this.body; }
        }

        /// <summary>
        /// 符件列表
        /// </summary>
        public IList<Attachment> AttachmentList
        {
            get { return this.attachmentList; }
        }

        /// <summary>
        /// 邮件服务器端口
        /// </summary>
        public int SmtpPort
        {
            get { return this.smtpPort; }
            set { this.smtpPort = value; }
        }

        /// <summary>
        /// 是否加密发送
        /// </summary>
        public bool EnableSsl
        {
            get { return this.enableSsl; }
            set { this.enableSsl = value; }
        }
        #endregion
    }
}
