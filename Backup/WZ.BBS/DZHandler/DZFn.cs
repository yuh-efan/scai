using System;
using System.Collections.Generic;
using System.Text;
using Discuz.Toolkit;

namespace WZ.BBS.DZHandler
{
    public class DZFn
    {
        private static readonly DiscuzSession ds = DiscuzSessionHelper.GetSession();

        public static void Login(string pUserName, string puserPwd)
        {
            int userid = ds.GetUserID(pUserName);
            ds.Login(userid, puserPwd, false, 100, "");
        }

        public static void Logout(string pCookieDomain)
        {
            ds.Logout(pCookieDomain);
        }

        public static int Register(string username, string password, string email, bool isMD5Passwd)
        {
            return ds.Register(username, password, email, isMD5Passwd);
        }
    }
}
