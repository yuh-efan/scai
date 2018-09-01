using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// 送货方式
    /// </summary>
    public class Deliver_InfoM
    {
        private int _DeliverSN;
        private string _DeliverName;
        private string _Detail;
        private int _Taxis;

        public int DeliverSN
        {
            get { return this._DeliverSN; }
            set { this._DeliverSN = value; }
        }

        public string DeliverName
        {
            get { return this._DeliverName; }
            set { this._DeliverName = value; }
        }

        public string Detail
        {
            get { return this._Detail; }
            set { this._Detail = value; }
        }

        public int Taxis
        {
            get { return this._Taxis; }
            set { this._Taxis = value; }
        }
    }
}
