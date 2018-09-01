using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Collections;
using System.Web;
using System.Data;
using System.ComponentModel;

namespace WZ.Common.Control.Templated
{
    [ParseChildren(true)]
    public class TemplatedList : System.Web.UI.Control, INamingContainer
    {
        private object dataSource;
        private ITemplate itemTemplate;

        public TemplatedList()
        {

            base.EnableViewState = false;
        }

        #region 控件属性

        /// <summary>
        /// 绑定的列表的数据源
        /// </summary>
        [Category("Data"), Description("绑定的列表的数据源"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        DefaultValue(null), Bindable(true)]
        public object DataSource
        {
            get
            {
                return dataSource;
            }
            set
            {
                if ((value is IEnumerable) || (value is IListSource) || (value == null))
                    dataSource = value;
                else
                    throw new Exception("错误的数据源类型");
            }
        }

        [
        Browsable(false),
        DefaultValue(null),
        Description("项模板"),
        PersistenceMode(PersistenceMode.InnerProperty),
        TemplateContainer(typeof(TemplatedListItem))
        ]
        public virtual ITemplate ItemTemplate
        {
            get
            {
                return itemTemplate;
            }
            set
            {
                itemTemplate = value;
            }
        }

        #endregion

        #region 方法
        //控件执行绑定时执行
        public override void DataBind()
        {
            this.Controls.Clear();
            base.ClearChildViewState();
            CreateControlHierarchy();
            base.ChildControlsCreated = true;
        }

        /// <summary>
        /// 创建一个带或不带指定数据源的控件层次结构
        /// 注意：当第二次执行数据绑定时，会执行两遍
        /// </summary>
        private void CreateControlHierarchy()
        {
            IEnumerable dataS = null;

            if (this.dataSource is IListSource)
            {
                IListSource listS = (IListSource)this.dataSource;
                IList list = listS.GetList();
                dataS = (IEnumerable)list;
            }
            else
            {
                dataS = (IEnumerable)this.dataSource;
            }

            if (dataS != null)
            {
                int index = 0;
                foreach (object dataItem in dataS)
                {
                    CreateItem(index, dataItem);
                    index++;
                }
            }
        }

        //创建项
        private void CreateItem(int itemIndex, object dataItem)
        {
            TemplatedListItem item = new TemplatedListItem(itemIndex);
            itemTemplate.InstantiateIn(item);

            item.DataItem = dataItem;
            this.Controls.Add(item);

            item.DataBind();

            

            item.DataItem = null;
        }
        #endregion
    }
}

