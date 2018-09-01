using System;
using System.Collections.Generic;
using System.Text;

namespace WZ.Data.IData
{
    public interface IPay
    {
        Dictionary<string, string> ValidatorData();

        Dictionary<string, string> attrName { get; set; }
    }
}
