using System;
using System.Collections.Generic;
using System.Text;
using Discuz.Toolkit;
using WZ.Common;

namespace WZ.BBS.DZHandler
{
    internal class DiscuzSessionHelper
    {
        private static string apikey, secret, url;
        private static DiscuzSession ds;
        static DiscuzSessionHelper()
        {
            apikey = "64c4b33f389ceb88fd826561a745f667";
            secret = "1c1924468fffa63c91a47e027d8cee2a";
            url = Fn.GetAppSettings("bbsurl");
            ds = new DiscuzSession(apikey, secret, url);
        }

        public static DiscuzSession GetSession()
        {
            return ds;
        }
    }
}
