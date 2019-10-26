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

       
    {   //Referencing classes 
        Bitmap Mybitmap;
        Shapes shapes;
        Commands commands;
    
        public MainForm()
        {
            InitializeComponent();
            // Entry point of program, creating a bitmap 
            
            Mybitmap = new Bitmap(Size.Width,Size.Height);
            Graphics g = Graphics.FromImage(Mybitmap);

            this.Width = 700;
            this.Height = 475;   
        }

        

        private void btnSubmit_Click(object sender, EventArgs e)
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            
                int width = Convert.ToInt32(Mybitmap.Width);
                int height = Convert.ToInt32(Mybitmap.Height);
                Bitmap bmp = new Bitmap(width, height);
                Mybitm
                */
            }



        public void DrawRectangle(int x, int y, int height, int width)
        {
            Graphics g = Graphics.FromImage(Mybitmap);

            Pen blackpen = new Pen(Color.Black, 3);

            Rectangle rect = new Rectangle(x, y, height, width);

            g.DrawRectangle(blackpen, rect);



        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter)
            {
                Graphics g = Graphics.FromImage(Mybitmap);

                if (txtCommand.Text == "Triangle")
                {
                    DrawTriangle();



                }
                else if (txtCommand.Text == "Rectangle")
                {
                    DrawRectangle(0, 0, 200,200);
                }
                else if (txtCommand.Text == "Clear")
                {
                    g.Clear(Color.White);
                }
                
                    
                

                Refresh();
            }


            
           

            
        }
    }
    }

