using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Common.Control.Templated
{
    public class Rep : System.Web.UI.WebControls.Repeater
    {
        public Rep()
        {
            base.EnableViewState = false;
        }
    }
}
