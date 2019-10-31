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
        Image File;
        Shapes shapes;
        Commands commands;
        bool MouseDown;

        int x = 0; int y = 0; int width = 0; int height = 0;

        string Function;
        
        public int alpha;

        public MainForm()
        {
            InitializeComponent();
            // Entry point of program, creating a bitmap     
            Mybitmap = new Bitmap(Size.Width, Size.Height);
            Graphics g = Graphics.FromImage(Mybitmap);



        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(Mybitmap, 0, 0);
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

        // Command strip menu shows a message box of the commands that can be used in the program
        private void commandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Position Pen \n" +
                "Pendraw \n" +
                "Resetpen \n" +
                "Rectangle 0,0,200,200 \n", "Commands", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        /// <summary>
        /// This method will save the bitmap image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        public void DrawCircle()
        {
            Graphics g = Graphics.FromImage(Mybitmap);

            Pen redpen = new Pen(Color.Red, 3);

            g.DrawEllipse(redpen, x, y, width, height);

            Refresh();

            width = 0; height = 0;


        }

        /// <summary>
        /// This method draws the rectangle 
        /// </summary>

        public void DrawRectangle()
        {
            Graphics g = Graphics.FromImage(Mybitmap);

            Pen blackpen = new Pen(Color.Black, 3);

            g.DrawRectangle(blackpen,x,y,width,height);
         
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
          

            if (e.KeyCode == Keys.Enter)
            {
                
                string command = txtCommand.Text;
                command = command.ToLower();

                try
                {
                    string[] sSplit = command.Split(' ');
                    Function = sSplit[0];
                    width= Int32.Parse(sSplit[1]);
                    height = Int32.Parse(sSplit[2]);
                    

                }
                catch (Exception i)
                {

                }

                Graphics g = Graphics.FromImage(Mybitmap);

                if (Function == "triangle")
                {
                    DrawTriangle();


                }
                if (Function == ("rectangle"))
                {
                    DrawRectangle();
                }
                if (Function == ("circle"))
                {
                    DrawCircle();
                }
                else if (Function == ("clear"))
                {
                    g.Clear(Color.White);
                }
                else if (Function == ("save"))
                {

                }

           
                Refresh();
            }






        }

        /*
        private int _x;

        public int x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }

            
        }

        private int _y;

        public int y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

    */

        /// <summary>
        /// This method clears the bitmap and repaints it white 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnClear_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(Mybitmap);

            g.Clear(Color.White);

            txtCommand.Clear();

            Refresh();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG(*.JPG)|*.jpg";

            if (f.ShowDialog() == DialogResult.OK)
            {
                File = Image.FromFile(f.FileName);
                

            }
        }

        private void btnPaint_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(Mybitmap);
            if (MouseDown == true)
            {
                g = Graphics.FromImage(Mybitmap);
                Pen myRedPen = new Pen(Color.Red, 25);
                g.DrawLine(myRedPen, e.X, e.Y, e.X + 1, e.Y + 1);
                myRedPen.Dispose();
                Refresh();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close this application?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        public void Validation()
        {
            

        }
    }
    }

