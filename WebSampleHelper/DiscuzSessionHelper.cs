using System;
using System.Collections.Generic;
using System.Text;
using Discuz.Toolkit;

namespace WebSampleHelper
{
    public class DiscuzSessionHelper
    {
        private static string apikey, secret, url;
        private static DiscuzSession ds;
        static DiscuzSessionHelper()
        {
            apikey = "64c4b33f389ceb88fd826561a745f667";
            secret = "1c1924468fffa63c91a47e027d8cee2a";
            url = "http://192.168.1.191:94/";
            ds = new DiscuzSession(apikey, secret, url);
        }

        public static DiscuzSession GetSession()
        {
            return ds;
        }
    }
}
