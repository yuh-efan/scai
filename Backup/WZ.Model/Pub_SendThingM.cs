using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 送货方式
    /// </summary>
    public class Pub_SendThingM
    {
        private int _SendSN;
        private string _Name;
        private int _Taxis;

        /// <summary>
        /// 送货方式
        /// </summary>
        public int SendSN
        {
            get { return this._SendSN; }
            set { this._SendSN = value; }
        }

        public string Name
        {
            get { return this._Name; }
            set { this._Name = value; }
        }

        public int Taxis
        {
            get { return this._Taxis; }
            set { this._Taxis = value; }
        }
    }
}
