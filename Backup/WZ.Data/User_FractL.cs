using System;
using System.Collections.Generic;
using System.Text;
using WZ.Common;
using System.Data;

namespace WZ.Data
{
    public class User_FractL
    {
        #region help
        protected IDbHelp curHelp;

        public User_FractL()
        {
            this.curHelp = new DefaultHelp();
        }

        public User_FractL(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        #region 获取分值
        /// <summary>
        /// 获取分值
        /// Dictionary int(f_Type), int(f_Value)
        /// </summary>
        /// <param name="pType">事件类型 0:积分 1:经验</param>
        /// <param name="pIdentifier">事件标识符</param>
        /// <returns> </returns>
        public Dictionary<int, int> GetFract(string pIdentifier)
        {
            string sql = "select f_Type,f_Value from User_Fract where f_Identifier=@f_Identifier";
            IDataParameter[] dp = { 
                                  DbHelp.Def.AddParam("@f_Identifier",pIdentifier),
                                  };

            DataTable dt = DbHelp.GetDataTable(sql, dp);
            IList<int> lValue = new List<int>();
            Dictionary<int, int> dValue = new Dictionary<int, int>();
            foreach (DataRow drw in dt.Rows)
            {
                int ftype = int.Parse(drw["f_Type"].ToString());
                int fvalue = int.Parse(drw["f_Value"].ToString());

                if (!dValue.ContainsKey(ftype))
                {
                    dValue.Add(ftype, fvalue);
                }
            }

            return dValue;
        }
        #endregion
    }

    public class User_FractHandler
    {
        #region help
        protected IDbHelp curHelp;

        public User_FractHandler()
        {
            this.curHelp = new DefaultHelp();
        }

        public User_FractHandler(IDbHelp pHelp)
        {
            this.curHelp = pHelp;
        }
        #endregion

        /// <summary>
        /// User_FractHandler 传参类
        /// </summary>
        public class FractHandlerParam
        {
            private int _UserID;
            private string _Operator;
            private int _NT;//次数
            private string _FractIdentifier;
            private string _LogIdentifier;
            private string _Remark;

            private int _FK_All = 0;

            /// <summary>
            /// 用户ID
            /// </summary>
            public int UserID
            {
                get { return this._UserID; }
            }

            /// <summary>
            /// 操作者名(可以是管理员,也可以是system)
            /// </summary>
            public string Operator
            {
                get { return this._Operator; }
            }

            /// <summary>
            /// 次数
            /// </summary>
            public int NT
            {
                get { return this._NT; }
            }

            /// <summary>
            /// 搜索分值标识符 User_Fract
            /// </summary>
            public string FractIdentifier
            {
                get { return this._FractIdentifier; }
            }

            /// <summary>
            /// 添加到日志的标识符
            /// </summary>
            public string LogIdentifier
            {
                get { return this._LogIdentifier; }
            }

            public string Remark
            {
                get { return this._Remark; }
            }

            /// <summary>
            /// 被操作对象id(如 产品,新闻,菜谱等)
            /// </summary>
            public int FK_All
            {
                get { return this._FK_All; }
                set { this._FK_All = value; }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="pUserID">用户ID</param>
            /// <param name="pOperator">操作者名(可以是管理员,也可以是system)</param>
            /// <param name="pNT">次数</param>
            /// <param name="pFractIdentifier">搜索分值标识符 User_Fract</param>
            /// <param name="pLogIdentifier">添加到日志的标识符</param>
            /// <param name="pRemark"></param>
            public FractHandlerParam(int pUserID, string pOperator, int pNT, string pFractIdentifier, string pLogIdentifier, string pRemark)
            {
                this._UserID = pUserID;
                this._Operator = pOperator;
                this._NT = pNT;
                this._FractIdentifier = pFractIdentifier;
                this._LogIdentifier = pLogIdentifier;
                this._Remark = pRemark;
            }
        }

        public string SetFract(FractHandlerParam pm)
        {
            Dictionary<int, int> fract = new User_FractL(this.curHelp).GetFract(pm.FractIdentifier);

            //设置积分
            int integral;
            if (fract.TryGetValue(0, out integral))
            {
                if (integral > 0)
                {
                    int __integral = integral * pm.NT;
                    string __msg = __integral > 0 ? ",增加" : ",扣除";
                    string slog = new User_InfoL(this.curHelp).SetUserIntegral(pm.UserID, pm.FK_All, pm.LogIdentifier, __integral, pm.Operator, pm.Remark + __msg + __integral + "积分");
                    if (slog != "1")
                        return slog;
                }
            }

            //设置经验
            int exp;
            if (fract.TryGetValue(1, out exp))
            {
                if (exp > 0)
                {
                    int __exp = exp * pm.NT;
                    string __msg = __exp > 0 ? ",增加" : ",扣除";

                    string slog = new User_InfoL(this.curHelp).SetUserExp(pm.UserID, pm.FK_All, pm.LogIdentifier, __exp, pm.Operator, pm.Remark + __msg + __exp + "经验");
                    if (slog != "1")
                        return slog;
                }
            }

            return "1";
        }

        //public string SetFract(int pUserID, string pOperator, int pNT, string pFractIdentifier, string pLogIdentifier, string pRemark)
        //{
        //    FractHandlerParam pm = new FractHandlerParam();

        //    Dictionary<int, int> fract = new User_FractL(this.curHelp).GetFract(pFractIdentifier);

        //    //设置积分
        //    int integral;
        //    if (fract.TryGetValue(0, out integral))
        //    {
        //        if (integral > 0)
        //        {
        //            int __integral = integral * pNT;
        //            string __msg = __integral > 0 ? ",增加" : ",扣除";
        //            string slog = new User_InfoL(this.curHelp).SetUserIntegral(pUserID, pLogIdentifier, __integral, pOperator, pRemark + __msg + __integral + "积分");
        //            if (slog != "1")
        //                return slog;
        //        }
        //    }

        //    //设置经验
        //    int exp;
        //    if (fract.TryGetValue(1, out exp))
        //    {
        //        if (exp > 0)
        //        {
        //            int __exp = exp * pNT;
        //            string __msg = __exp > 0 ? ",增加" : ",扣除";

        //            string slog = new User_InfoL(this.curHelp).SetUserExp(pUserID, pLogIdentifier, __exp, pOperator, pRemark + __msg + __exp + "经验");
        //            if (slog != "1")
        //                return slog;
        //        }
        //    }

        //    return "1";
        //}
    }
}