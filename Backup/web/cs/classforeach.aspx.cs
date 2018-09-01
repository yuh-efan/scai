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
using System.Collections.Generic;
using WZ.Data;
using WZ.Common;

namespace WZ.Web.cs
{
    public partial class classforeach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ff2();
        }

        private void ff1()
        {
            DataTable dt = DbHelp.GetDataTable("select * from cs_class");

            GetClassPathqq acp = new GetClassPathqq();
            ClassPath1 cp = new ClassPath1(dt, acp);
            cp.Exe(8);

            string sPath = acp.GetPath;
            Response.Write(sPath);
        }

        private void ff2()
        {

            DataTable dt = DbHelp.GetDataTable("select * from cs_class");
            ClassPath2 cp = new ClassPath2(dt, (drw) => ClassEach(drw));
            cp.Exe(8);

            Response.Write(sPath);
        }

        string sPath = "";
        private void ClassEach(System.Data.DataRow pDrw)
        {
            this.sPath = pDrw["ClassName"].ToString() + " > " + this.sPath;
        }
    }

    public class ClassPath2 : AbsClassRecursive1
    {
        public delegate void classEach(DataRow drw);

        private classEach ce;

        public ClassPath2(DataTable pDt, classEach pce)
            : base("ClassSN", "ClassName", pDt)
        {
            this.ce = pce;
        }

        public void Exe(int pClassID)
        {
            base.Run(pClassID);
        }

        protected override void HandlerRecursive(DataRow pDrw)
        {
            ce(pDrw);
        }
    }

    public class GetClassPathqq : IClassPath1
    {
        private string sPath = string.Empty;
        private byte level = 0;//当前id是第几层

        public byte GetLevel
        {
            get { return this.level; }
        }

        /// <summary>
        /// 获取分类路径
        /// </summary>
        public string GetPath
        {
            get
            {
                if (this.sPath.Length > 0)
                    this.sPath = this.sPath.Trim().TrimEnd('>');

                return this.sPath;
            }
        }

        #region IClassPath 成员

        public void ClearData()
        {
            this.sPath = string.Empty;
        }

        public void ClassEach(System.Data.DataRow pDrw)
        {
            this.sPath = pDrw["ClassName"].ToString() + " > " + this.sPath;
            level++;
        }
        #endregion
    }

    public class ClassPath1 : AbsClassRecursive1
    {
        private IClassPath1 iclassPath;

        public ClassPath1(DataTable pDt, IClassPath1 pCP)
            : base("ClassSN", "ClassName", pDt)
        {
            this.iclassPath = pCP;
        }

        /// <summary>
        /// 分类ID
        /// </summary>
        /// <param name="pClassID"></param>
        public void Exe(int pClassID)
        {
            iclassPath.ClearData();
            base.Run(pClassID);
        }

        public void Exe(object pClassID)
        {
            iclassPath.ClearData();
            base.Run(Convert.ToInt32(pClassID));
        }

        /// <summary>
        /// 循环ID所在的每一个等级只一次
        /// </summary>
        /// <param name="pDrw"></param>
        protected override void HandlerRecursive(DataRow pDrw)
        {
            iclassPath.ClassEach(pDrw);
        }
    }

    public abstract class AbsClassRecursive1
    {
        protected string fieldClassID;
        protected string fieldPClassID;
        protected string fieldClassName;
        protected DataTable dtClass;
        protected List<int> errList = new List<int>();//阻止死循环

        public DataTable DtClass
        { get { return this.dtClass; } }

        public AbsClassRecursive1(string pFieldClassID, string pFieldClassName, DataTable pDt)
        {
            this.fieldClassID = pFieldClassID;
            this.fieldPClassID = "P" + pFieldClassID;
            this.fieldClassName = pFieldClassName;
            this.dtClass = pDt;
        }

        protected void Run(int pClassID)
        {
            RunRecursive(pClassID);
            this.errList.Clear();
        }

        /// <summary>
        /// 递归设置分类路径
        /// </summary>
        /// <param name="pPClassID">PClassID</param>
        /// <returns></returns>
        private void RunRecursive(int pClassID)
        {
            if (errList.Contains(pClassID))
                return;

            errList.Add(pClassID);
            int lsID;
            int iPClassID = 0;//上一级分类id
            foreach (DataRow drw in this.dtClass.Rows)
            {
                lsID = Convert.ToInt32(drw[fieldClassID]);
                if (lsID == pClassID)
                {
                    HandlerRecursive(drw);
                    iPClassID = Convert.ToInt32(drw[fieldPClassID]);
                    break;
                }
            }

            if (iPClassID > 0)
                RunRecursive(iPClassID);
        }

        protected abstract void HandlerRecursive(DataRow pDrw);
    }

    public interface IClassPath1
    {
        /// <summary>
        /// 初始或清空一次递归后的数据
        /// </summary>
        void ClearData();

        /// <summary>
        /// 循环ID所在的每一个等级只一次
        /// </summary>
        /// <param name="pDrw"></param>
        void ClassEach(DataRow pDrw);
    }
}
