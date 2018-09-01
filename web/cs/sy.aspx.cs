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
using WZ.Model;
using System.Text;
using System.Collections.Generic;
using WZ.Common.OperationFile;
using System.Drawing;

namespace WZ.Web.cs
{
    public partial class sy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var a = "";


            //string addText = "文字水印";
            //Image image = Image.FromFile(Path);
            //Graphics g = Graphics.FromImage(image);
            //g.DrawImage(image, 0, 0, image.Width, image.Height);
            //Font f = new Font("Verdana", 60);
            //Brush b = new SolidBrush(Color.Green);

            //g.DrawString(addText, f, b, 35, 35);
            //g.Dispose();

            //image.Save(Path_sy);
            //image.Dispose(); 


        }

        protected void fff(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = Request.Files[0];

            PFileVar ff = new PFileVar
            {
                IsSaveOld = true,
            };

            PFileVar pfv = new PFileVar();
            pfv.File_Upload = postedFile;
            pfv.PathRelative = "/pf/";

            pfv.IsWatermark = true;
            pfv.WatermarkPath = Request.MapPath("/images/sy/clz.png");
            pfv.IsSaveOld = true;
            pfv.SaveOldPathPrefix = "/pf#old/";

            pfv.IsThumbnail = true;
            pfv.ThumbnailWith = 250;
            pfv.XLType = PFileVar.ThumPicType.限制宽;

            pfv.IsWatermarkThum = true;
            pfv.WatermarkPathThum = Request.MapPath("/images/sy/clz.png");


           


            PFile pf = new PFile(pfv);
            //开始上传
            if (pf.Upload_File())
            {
                Response.Write(pf.GetRelativeAllPath + "<br>");//大图路径
                Response.Write(pf.GetRelativeAllPathThum);//小图路径
            }
            else
            {
                Response.Write(pf.ReturnMessage);//上传失败的错误信息
            }
            

        }
    }

 


}
