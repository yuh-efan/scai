using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Client.Control
{
    public class Item : System.Web.UI.WebControls.Repeater
    {
        public Item()
        {
            base.EnableViewState = false;
        }
    }
}
