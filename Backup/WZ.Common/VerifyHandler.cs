using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Web;

namespace WZ.Common
{
    public class VerifyHandler
    {
        private const string letters = "ABCDEFGHIJKLNPRSTUVXYZ432869";
        private int w;
        private int h;
        private string sessionName = "verify";
        public Color BackGroundColor = Color.Beige;
        public Color TextColor = Color.Black;

        public VerifyHandler()
        {
            this.w = 64;
            this.h = 20;
            this.sessionName = "verify";
        }

        public VerifyHandler(int pWidth, int pHeight, string pSessionName)
        {
            this.w = pWidth;
            this.h = pHeight;
            this.sessionName = pSessionName;
        }

        public Bitmap GetImg()
        {
            Random r = new Random();

            Bitmap basemap = new Bitmap(w, h);
            Graphics graph = Graphics.FromImage(basemap);

            graph.FillRectangle(new SolidBrush(BackGroundColor), 0, 0, w, h);

            Font[] font ={ 
                             new Font(FontFamily.GenericSerif, r.Next(17, 22), FontStyle.Regular, GraphicsUnit.Pixel),
                             new Font(FontFamily.GenericSerif, r.Next(17, 22), FontStyle.Regular, GraphicsUnit.Pixel),
                             new Font(FontFamily.GenericSerif, r.Next(17, 22), FontStyle.Regular, GraphicsUnit.Pixel),
                             new Font(FontFamily.GenericSerif, r.Next(17, 22), FontStyle.Regular, GraphicsUnit.Pixel),
                         };

            string letter;
            StringBuilder s = new StringBuilder();

            //添加随机的五个字母
            int rota = r.Next(-30, 30);
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            for (int x = 0; x < 4; x++)
            {
                letter = letters.Substring(r.Next(0, letters.Length), 1);
                s.Append(letter);
                graph.DrawString(letter, font[x], new SolidBrush(TextColor), x * r.Next(12, 16), r.Next(-1, 1));
            }

            //混淆背景
            Pen linePen = new Pen(new SolidBrush(Color.Black), r.Next(1, 3));
            for (int x = 0; x < 1; x++)
                graph.DrawLine(linePen, new Point(r.Next(0, w - 10), r.Next(0, h - 5)), new Point(r.Next(10, w - 1), r.Next(0, h - 5)));

            HttpContext.Current.Session[sessionName] = s;

            return basemap;
        }
    }
}
