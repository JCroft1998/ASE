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

            Rectangle();
         

            this.Width = 700;
            this.Height = 475;

        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(Mybitmap, 350,100);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          
        }

        public void Rectangle()
        {
            Graphics g = Graphics.FromImage(Mybitmap);

            Pen blackpen = new Pen(Color.Black, 3);

            Rectangle rect = new Rectangle(0, 0, 200, 200);

            g.DrawRectangle(blackpen, rect);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
           /* if (txtCommand.Text == "Rectangle")
            {
                Rectangle();
            }
            else
            {
                MessageBox.Show("Invalid command");
            }*/
        }

        private void txtCommand_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
