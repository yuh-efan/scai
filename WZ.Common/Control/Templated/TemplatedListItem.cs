using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WZ.Common.Control.Templated
{
    public class TemplatedListItem : System.Web.UI.Control, INamingContainer
    {
        private int itemIndex;
        private object dataItem;

        public TemplatedListItem(int itemIndex)
        {
            this.itemIndex = itemIndex;
        }

        public virtual object DataItem
        {
            get { return dataItem; }
            set { dataItem = value; }
        }

        public virtual int ItemIndex
        {
            get { return itemIndex; }
        }
    }
}
