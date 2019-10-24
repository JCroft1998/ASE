using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsTools
{
   
    public class Shapes : MainForm

       
    {

        public static Bitmap DrawIamge;
        
        public void DrawRectangle(int x, int y, int height, int width)
        {
            Graphics g = Graphics.FromImage(DrawIamge);

            Pen blackpen = new Pen(Color.Black, 3);

            Rectangle rect = new Rectangle(x, y, height, width);

            g.DrawRectangle(blackpen, rect);


        }

        public void DrawCircle()
        {

        }

        public void DrawTriangle()
        {



        }
        

    }

   

   
}
