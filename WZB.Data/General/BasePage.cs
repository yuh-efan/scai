using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common.CacheData;

namespace WZ.Client.Data.General
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            this.EnableViewState = false;
        }
    }
}
