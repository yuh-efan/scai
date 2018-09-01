using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Data.IData
{
    public abstract class AbsPay
    {
        protected IPay iPay;

        public AbsPay(string pPayType)
        {
            Load_Pay_Attr(pPayType);
        }

        public void Load_Pay_Attr(string pPayType)
        {

            switch (pPayType)
            {
                case "zfb"://支付宝
                    iPay = new Pay_Attr_zfb();
                    break;

                case "gs"://工
                case "ny"://农
                case "zg"://中
                case "js"://建
                    iPay = new Pay_Attr_yh();
                    break;

                //case "cft"://财
                //    iPay = new Pay_Attr_cft();
                //    break;
                default:
                    break;
            }
        }
    }
}
