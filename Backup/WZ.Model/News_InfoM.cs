using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 新闻信息
    /// </summary>
    public class News_InfoM
    {
        private int _NewsSN;
        private int _FK_News_Class;
        private byte _UrlType;
        private string _Url;
        private string _Title;
        private string _Title1;
        private string _PicS;
        private string _PicB;
        private string _Detail;
        private string _Source;
        private string _Author;
        private int _Hit;
        private byte _NewsType;
        private int _Item;
        private string _Vote;
        private DateTime _EditDate;
        private DateTime _AddDate;

        public int NewsSN
        {
            get { return this._NewsSN; }
            set { this._NewsSN = value; }
        }

        public int FK_News_Class
        {
            get { return this._FK_News_Class; }
            set { this._FK_News_Class = value; }
        }

        /// <summary>
        /// 页面链接类型 1:资讯页 2:独立页
        /// </summary>
        public byte UrlType
        {
            get { return this._UrlType; }
            set { this._UrlType = value; }
        }

        public string Url
        {
            get { return this._Url; }
            set { this._Url = value; }
        }

        /// <summary>
        /// 主标题
        /// </summary>
        public string Title
        {
            get { return this._Title; }
            set { this._Title = value; }
        }

        /// <summary>
        /// 副标题
        /// </summary>
        public string Title1
        {
            get { return this._Title1; }
            set { this._Title1 = value; }
        }

        public string PicS
        {
            get { return this._PicS; }
            set { this._PicS = value; }
        }

        public string PicB
        {
            get { return this._PicB; }
            set { this._PicB = value; }
        }

        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }

        public string Source
        {
            get { return this._Source; }
            set { this._Source = value; }
        }

        public string Author
        {
            get { return this._Author; }
            set { this._Author = value; }
        }

        public int Hit
        {
            get { return this._Hit; }
            set { this._Hit = value; }
        }

        /// <summary>
        /// 1:原创 2:转载
        /// </summary>
        public byte NewsType
        {
            get { return this._NewsType; }
            set { this._NewsType = value; }
        }

        /// <summary>
        /// 新闻属性 1:内页图文 2:幻灯片 4:内页推荐 8:公告 16:活动 32:首页推荐 64:首页图文
        /// </summary>
        public int Item
        {
            get { return this._Item; }
            set { this._Item = value; }
        }

        public string Vote
        {
            get { return this._Vote; }
            set { this._Vote = value; }
        }

        public DateTime EditDate
        {
            get { return this._EditDate; }
            set { this._EditDate = value; }
        }

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }
    }
}
