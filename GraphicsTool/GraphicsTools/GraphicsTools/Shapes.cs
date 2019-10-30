using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsTools
{
   
    public partial class Shapes : MainForm

       
    {

        public static Bitmap MyBitmap;
        
        public void DrawRectangle(int x, int y, int height, int width)
        {
            Graphics g = Graphics.FromImage(MyBitmap);

            Pen blackpen = new Pen(Color.Black, 3);

            Rectangle rect = new Rectangle(x, y, height, width);

            g.DrawRectangle(blackpen, rect);

           

        }

        public void DrawCircle()
        {
            Graphics g = Graphics.FromImage(MyBitmap);

            Pen Redpen = new Pen(Color.Black, 3);

          
        }

        public void DrawTriangle()
        {
            Graphics g = Graphics.FromImage(MyBitmap);
            Pen BluePen = new Pen(Color.Blue, 3);
            Point[] points = new Point[3];
            points[0] = new Point(200, 10);
            points[1] = new Point(150, 75);
            points[2] = new Point(250,75);

            g.DrawPolygon(BluePen, points);
        }
        

    }

   

   
}
