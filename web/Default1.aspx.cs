using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using WZ.Common;
using System.Collections.Generic;
using WZ.Common.CacheData;
using WZ.Data;
using System.Text;
using WZ.Common.Config;
using WZ.Client.Data;

namespace WZ.Web
{
    public partial class _Default1 : WZ.Client.Data.General.BasePage
    {
        private static DbCache dbCac;

        static _Default1()
        {
            dbCac = new DbCache("default_");
        }

        private DataTable dtProClass = SCWCache.GetDataTable(SCWCache.CacheKey.Pro_Class);
        protected DataTable dtHotSell1;//本周热卖
        protected DataTable dtHotSell2;//本月热卖
        private void LL()
        {

            
            
            

            string sSQL;

            //推荐
            sSQL = string.Format("select top 4 ProSN,ProName,PicS,Price,Item from vgPro_Info where Item&{0}={0} order by EditDate desc", (int)PubEnum.ProItem.新品);
            this.rpRecommend.dt = dbCac.GetDataTable("Pro_rpRecommend", ref sSQL);

            //热门
            sSQL = string.Format("select top 5 ProSN,ProName,PicS,Price,Item from vgPro_Info where Item&{0}={0} order by EditDate desc", (int)PubEnum.ProItem.热销);
            this.rpHot.dt = dbCac.GetDataTable("Pro_rpHot", ref sSQL);

            //网站公告
            sSQL = "select top 5 BulletinSN,Title from Bulletin where BulletinType=0 order by EditDate desc";
            Bind.BGRepeater(dbCac.GetDataTable("Bulletin_rpWebNotice", ref sSQL), this.rpWebNotice, false);

            //活运通知
            sSQL = "select top 5 BulletinSN,Title from Bulletin where BulletinType=1 order by EditDate desc";
            Bind.BGRepeater(dbCac.GetDataTable("Bulletin_rpWebActive", ref sSQL), this.rpWebActive, false);

            //幻灯片
            sSQL = "select AdvName,AdvImg,AdvURL from Adv_Info where Keyword='default_ppt' order by Taxis asc";
            Bind.BGRepeater(dbCac.GetDataTable("Adv_rpPPT", ref sSQL), this.rpPPT, false);

            #region 热卖
            //本周热卖
            Pro_Info_HotSell pihHotSell1 = new Pro_Info_HotSell("Pro_pihHotSell1", DateTime.Now.Add(new TimeSpan(-7, 0, 0, 0)));
            dtHotSell1 = dbCac.GetDataTable(pihHotSell1);

            //本月热卖
            Pro_Info_HotSell pihHotSell2 = new Pro_Info_HotSell("Pro_pihHotSell2", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
            dtHotSell2 = dbCac.GetDataTable(pihHotSell2);
            #endregion

            //分类商品
            this.rpClassPro1.dt = dbCac.GetDataTable("Pro_Class_rpClassPro1", GetClassSQL(2));
            this.rpClassPro2.dt = dbCac.GetDataTable("Pro_Class_rpClassPro2", GetClassSQL(1));
            this.rpClassPro3.dt = dbCac.GetDataTable("Pro_Class_rpClassPro3", GetClassSQL(19));

            //子级分类列表
            DataTable classPro1 = dtProClass.Clone();
            DataTable classPro2 = dtProClass.Clone();
            DataTable classPro3 = dtProClass.Clone();
            Fn.DrwToDt(dtProClass.Select("PClassSN=" + 2, "Taxis asc"), classPro1);
            Fn.DrwToDt(dtProClass.Select("PClassSN=" + 1, "Taxis asc"), classPro2);
            Fn.DrwToDt(dtProClass.Select("PClassSN=" + 19, "Taxis asc"), classPro3);
            Bind.BGRepeater(classPro1, this.rpClass1, false);
            Bind.BGRepeater(classPro2, this.rpClass2, false);
            Bind.BGRepeater(classPro3, this.rpClass3, false);
        }

        //获取产品分类sql
        private static StringBuilder GetClassSQL(int pClassID)
        {
            return new StringBuilder("select top 8 ProSN,ProName,PicS,Price,Item from vgPro_Info a,T_Pro_Class_GetChildAndSelf(" + pClassID + ") b where a.FK_Pro_Class=b.id order by EditDate desc");
        }

        protected object GetClassName(int pClassID)
        {
            return ClassDataTable.GetName(dtProClass, pClassID);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LL();
            }
        }
    }
}
