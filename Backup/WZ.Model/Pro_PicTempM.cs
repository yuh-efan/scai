using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Model
{
    /// <summary>
    /// Model
    /// </summary>
    public class Pro_PicTempM
    {
        private int _PTSN;
        private int _FK_AdminUser;
        private string _PicS;
        private string _PicB;
        private DateTime _AddDate;

        public int PTSN
        {
            get { return this._PTSN; }
            set { this._PTSN = value; }
        }

        public int FK_AdminUser
        {
            get { return this._FK_AdminUser; }
            set { this._FK_AdminUser = value; }
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

        public DateTime AddDate
        {
            get { return this._AddDate; }
            set { this._AddDate = value; }
        }
    }
}
