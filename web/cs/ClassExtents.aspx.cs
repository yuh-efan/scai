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
using System.Reflection;
using System.Collections.Generic;
using WZ.Common;
using System.Data.SqlClient;
using WZ.Model;
using WZ.Data;

namespace WZ.Web.cs
{
    public partial class ClassExtents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pro_ClassM ex_mod = new Pro_ClassM();
            ex_mod.ClassSN = 1006;
            ex_mod.PClassSN = 1;
            ex_mod.ClassName = "";
            ex_mod.Taxis = 34;
            ex_mod.ClassLevel = 2;
            
            //string[] arrObj = { "PClassSN", "ClassSN", "taxis", "classLevel", "Classname" };

            string s = "PClassSN,ClassSN,taxis,classLevel,Classname";

            //SQLData.Add(arrObj, ex_mod);
            SqlData.Add(ex_mod, s);


            //string sql = string.Empty;
            //string sql1 = string.Empty;

            //foreach (string s in arrObj)
            //{
            //    sql += s + ",";
            //    sql1 += "@" + s + ",";
            //}


            //sql = sql.TrimEnd(',');
            //sql1 = sql1.TrimEnd(',');
            //string sSQL = "insert into  " + table + "(" + sql + ") values(" + sql1 + ")";

            //IDataParameter[] dp = { 
                                  //DbHelp.Def.AddParam("@ClassSN",LFn.GetAddRowID("Pro_Class","ClassSN")),
                                  //DbHelp.Def.AddParam("@PClassSN",pMod.PClassSN),
                                  //DbHelp.Def.AddParam("@ClassName",pMod.ClassName),
                                  //DbHelp.Def.AddParam("@Taxis",pMod.Taxis),
                                  //DbHelp.Def.AddParam("@ClassLevel",pMod.ClassLevel),
                                  //};

            //IDataParameter idp = new SqlParameter();
            //idp.Value = "";
            //idp.ParameterName = "";

            //Response.Write(sSQL);

            


            //object aaa = ex_mod;
            //FieldInfo[] fi = aaa.GetType().GetFields();

            //foreach (FieldInfo mi in fi)
            //{

            //    Response.Write("<br> " + mi.Name + " = " + mi.GetValue(ex_mod) + "<br>");
            //}

            //string aaa = "sdfds";

            //Response.Write(aaa.GetType() + "<br>");

            //FieldInfo[] fi1 = aaa.GetType().GetFields();

            //foreach (FieldInfo mi in fi1)
            //{
            //    Response.Write(mi.ReflectedType + "<br>");
            //}


            //FieldInfo[] fi = arrObj.GetType().GetFields();

            //foreach (MemberInfo mi in fi)
            //{
            //    Response.Write(mi.DeclaringType + "<br>");
            //}
            
            //Array a = (Array)fi.GetValue();
            
            //for (int i = 0; i < a.Length; i++)
            //{
            //    //Book b = (Book)a.GetValue(i);
            //    //Console.WriteLine(b.Price);
            //    Response.Write(a.GetValue(i)+"<br>");
            //}   

        }
    }

    


    public class ext1
    {
        public virtual void aaa()
        {
            HttpContext.Current.Response.Write("ext1 <br>");
        }
    }

    public class ext2 : ext1
    {
        public override void aaa()
        {
            HttpContext.Current.Response.Write("ext2 <br>");
            base.aaa();
        }
    }


}
