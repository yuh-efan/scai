using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;

namespace WZ.Data
{
    public class EmailInfo
    {
        public static readonly EmailInfo eInfo;

        static EmailInfo()
        {
            string address = DESEncrypt.Decrypt("80A0C0061AB6EEFA343F14AE2524259D", Encoding.ASCII.GetBytes("d*#kdifs"));
            string addresspwd = DESEncrypt.Decrypt("BDFFCA4DD90C4FA4B2CB6D27243CA531", Encoding.ASCII.GetBytes("d*#kdifs"));
            string selfName = "搜菜网";
            string selfServer = "smtp.ym.163.com";

            eInfo = new EmailInfo(address, addresspwd, selfName, selfServer, 25, false);
        }

        private string selfAddress;
        private string selfPwd;
        private string selfName;
        private string selfServer;
        private int port;

        private bool enableSsl;

        public EmailInfo(
            string selfAddress,
            string selfPwd,
            string selfName,
            string selfServer,
            int port,
            bool enableSsl)
        {
            this.selfAddress = selfAddress;
            this.selfPwd = selfPwd;
            this.selfName = selfName;
            this.selfServer = selfServer;
            this.port = port;
            this.enableSsl = enableSsl;
        }

        public string SelfAddress
        {
            get { return this.selfAddress; }
        }

        public string SelfPwd
        {
            get { return this.selfPwd; }
        }

        public string SelfName
        {
            get { return this.selfName; }
        }

        public string SelfServer
        {
            get { return this.selfServer; }
        }

        public int Port
        {
            get { return this.port; }
        }

        public bool EnableSsl
        {
            get { return this.enableSsl; }
        }
    }
}
