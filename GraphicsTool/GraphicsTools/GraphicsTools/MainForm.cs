using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsTools
{
    public partial class MainForm : Form

       
    {
        Bitmap Mybitmap;

    
        public MainForm()
        {
            InitializeComponent();
            // Entry point of program

            Mybitmap = new Bitmap(Size.Width,Size.Height);
            Graphics g = Graphics.FromImage(Mybitmap);

            DrawTriangle();

        
            this.Width = 700;
            this.Height = 475;

        }

        


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
         
        }

      

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }

        private void txtCommand_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(Mybitmap,0,0);
        }
        public void DrawTriangle()
        {
            Graphics g = Graphics.FromImage(Mybitmap);
            Pen BluePen = new Pen(Color.Blue, 3);
            Point[] points = new Point[3];
            points[0] = new Point(200, 10);
            points[1] = new Point(150, 75);
            points[2] = new Point(250, 75);

            g.DrawPolygon(BluePen, points);
        }

        private void commandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Position Pen \n" +
                "Pendraw \n" +
                "Resetpen \n" +
                "Rectangle 0,0,200,200 \n", "Commands", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
        }
    }
}
