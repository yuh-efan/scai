using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace WZ.Data.Layout
{
    /// <summary>
    /// 一般用于有图片的
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="li">LayoutInfo对象</param>
    /// <returns></returns>
    public delegate StringBuilder CycleEvent(DataTable dt, LayoutInfo li);

    /// <summary>
    /// 一般用于只带链接
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="li">LayoutInfoLink 对象</param>
    /// <returns></returns>
    public delegate StringBuilder CycleEventLink(DataTable dt, LayoutInfoLink li);


    public delegate StringBuilder CycleEventText(DataTable dt);


}
