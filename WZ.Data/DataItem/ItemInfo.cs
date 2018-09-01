using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Data.DataItem
{
    public class ItemInfo
    {
        private string _id;
        private string _name;
        private string _detail;

        public ItemInfo() { }
        public ItemInfo(string pId,string pName) 
        {
            this._id = pId;
            this._name = pName;
        }

        public ItemInfo(string pId, string pName,string pDetail)
        {
            this._id = pId;
            this._name = pName;
            this._detail = pDetail;
        }

        public string id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string detail
        {
            get { return this._detail; }
            set { this._detail = value; }
        }

        public override string ToString()
        {
            return this._name;
        }
    }
}
