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
    }
}
