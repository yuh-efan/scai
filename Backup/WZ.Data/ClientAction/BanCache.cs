using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WZ.Data.ClientAction
{
    public class BanCache
    {
        #region
        private static List<Info> listInfo = new List<Info>();
        private static List<Info> listBan = new List<Info>();
        private static readonly object lockInfo = new object();
        private static readonly object lockBan = new object();
        private static int timerCount = 0;
        private static DateTime timerLast;

        private string banIdentifier;
        private TimeSpan areaTime;
        private int banCount;

        /// <summary>
        /// 记录密码输入错误的用户
        /// </summary>
        public static IList<Info> ListInfo
        {
            get { return listInfo.AsReadOnly(); }
        }

        /// <summary>
        /// 记录需要输入验证码的用户
        /// </summary>
        public static IList<Info> ListBan
        {
            get { return listBan.AsReadOnly(); }
        }

        /// <summary>
        /// Timer运行总次数
        /// </summary>
        public static int TimerCount
        {
            get { return timerCount; }
        }

        public static string TimerLast
        {
            get
            {
                if (timerLast != null)
                {
                    return timerLast.ToString();
                }
                else
                {
                    return "0";
                }
            }

        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBanType">记录类型</param>
        /// <param name="pAreaType">多少时间范围</param>
        /// <param name="pBanCount">违法次数或提交次数</param>
        public BanCache(string pBanType, TimeSpan pAreaTime, int pBanCount)
        {
            this.banIdentifier = pBanType;
            this.areaTime = pAreaTime;
            this.banCount = pBanCount;
        }

        /// <summary>
        /// 添加密码输错用户
        /// </summary>
        public void Add()
        {
            string ip = HttpContext.Current.Request.UserHostAddress;
            Info oi = new Info()
            {
                IP = ip,
                Dtime = DateTime.Now,
                Identifier = this.banIdentifier,
                AreaTime = this.areaTime
            };

            int cou = 1;

            lock (lockInfo)
            {
                foreach (Info s in listInfo)
                {
                    //判断在时间内违法资料
                    if ((s.Identifier == this.banIdentifier) && ((DateTime.Now - s.Dtime) < this.areaTime) && (s.IP == ip))
                        cou++;
                }
            }

            //如果指定超过次数
            if (cou >= this.banCount)
            {
                bool b = true;
                lock (lockBan)
                {
                    foreach (Info s in listBan)
                    {
                        if (s.Identifier == this.banIdentifier && ((DateTime.Now - s.Dtime) < this.areaTime) && s.IP == ip)
                        {
                            b = false;
                            break;
                        }
                    }

                    //是否已记录此项违法记录
                    if (b)
                    {
                        listBan.Add(new Info()
                        {
                            IP = HttpContext.Current.Request.UserHostAddress,
                            Dtime = DateTime.Now,
                            Identifier = this.banIdentifier,
                            AreaTime = this.areaTime
                        });
                    }
                }
            }
            else
            {
                listInfo.Add(oi);
            }
        }

        /// <summary>
        /// 判断是否有被记录的用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool IsBan()
        {
            string ip = HttpContext.Current.Request.UserHostAddress;
            bool b = false;
            lock (lockBan)
            {
                foreach (Info s in listBan)
                {
                    if (s.Identifier == this.banIdentifier && ((DateTime.Now - s.Dtime) < this.areaTime) && s.IP == ip)//((DateTime.Now - s.Dtime) < this.areaTime)
                    {
                        b = true;
                        break;
                    }
                }
            }

            return b;
        }

        private static System.Threading.Timer timer = null;
        static BanCache()
        {
            if (timer == null)
                timer = new System.Threading.Timer(new System.Threading.TimerCallback(thrBanUser), null, 50000, 50000);
        }

        private static void thrBanUser(object o)
        {
            lock (lockInfo)
            {
                for (int i = 0; i < listInfo.Count; i++)
                {
                    Info s = listInfo[i];

                    if ((DateTime.Now - s.Dtime) > s.AreaTime)
                    {
                        listInfo.Remove(s);
                    }
                }
            }

            lock (lockBan)
            {
                for (int i = 0; i < listBan.Count; i++)
                {
                    Info s = listBan[i];

                    if ((DateTime.Now - s.Dtime) > s.AreaTime)
                    {
                        listBan.Remove(s);
                    }
                }
            }

            timerCount++;
            timerLast = DateTime.Now;
        }

        public class Info
        {
            /// <summary>
            /// 客户端IP
            /// </summary>
            public string IP;

            /// <summary>
            /// 记录时间
            /// </summary>
            public DateTime Dtime;

            /// <summary>
            /// 时间范围
            /// </summary>
            public TimeSpan AreaTime;

            public string Identifier;
        }
    }
}