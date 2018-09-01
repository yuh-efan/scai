using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// Model
    /// </summary>
    public class KeyWordM
    {
        private int _KeyWordSN;
        private string _KeyWordName;
        private int _Num;
        private int _Taxis;
        private int _Item;
        private string _URL;

        public int KeyWordSN
        {
            get { return this._KeyWordSN; }
            set { this._KeyWordSN = value; }
        }

        public string KeyWordName
        {
            get { return this._KeyWordName; }
            set { this._KeyWordName = value; }
        }

        public int Num
        {
            get { return this._Num; }
            set { this._Num = value; }
        }

        public int Taxis
        {
            get { return this._Taxis; }
            set { this._Taxis = value; }
        }

        /// <summary>
        /// 1:前台显示 2:显示在搜索框(商品) 4:显示在搜索框(食谱) 8:显示在搜索框(资讯)
        /// </summary>
        public int Item
        {
            get { return this._Item; }
            set { this._Item = value; }
        }

        public string URL
        {
            get { return this._URL; }
            set { this._URL = value; }
        }
    }
}
