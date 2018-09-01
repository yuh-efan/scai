using System;
using System.Collections.Generic;
using System.Text;
using WZ.Data.IData;
using System.Data;

namespace WZ.Data
{
    public class Pay_AttrL : AbsPay
    {
        public Pay_AttrL(string pPayType)
            : base(pPayType)
        {

        }

        public DataTable GetAttr(DataRow[] pADrw)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("attrName"));
            dt.Columns.Add(new DataColumn("attrValue"));

            foreach (DataRow drw in pADrw)
            {
                string attrStr = drw["AttrStr"].ToString();
                foreach (string s in this.iPay.attrName.Keys)
                {
                    if (s == attrStr)
                    {
                        DataRow drw1 = dt.NewRow();
                        drw1["attrName"] = this.iPay.attrName[s];
                        drw1["attrValue"] = drw["attrValue"];
                        dt.Rows.Add(drw1);
                        break;
                    }
                }
            }

            return dt;
        }
    }
}
