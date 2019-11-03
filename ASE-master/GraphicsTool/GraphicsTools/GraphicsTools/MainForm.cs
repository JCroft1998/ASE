using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;


namespace GraphicsTools
{
    public partial class MainForm : Form


    {   //Referencing classes 
        public static Bitmap Mybitmap;
        public static Panel Mypanel;
        public static RichTextBox Mytextbox;
        public static int xPos = 0, yPos = 0, penT = 3, valOne = 0, valTwo = 0;
        public static string Function;

        public MainForm()
        {
            InitializeComponent();
            Mybitmap = new Bitmap(Size.Width, Size.Height);
            Mypanel = panel1;
            Mytextbox = richTextBox1;
        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(Mybitmap, 0, 0);

            // Stops the panel from flashing:
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Mypanel, new object[] { true });
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
            //Mybitmap.Save("Desktop/Test.png");

        }

        /// <summary>
        /// This method is executed when the enter button is pressed
        /// Includes the spliter for the txtbox command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Commands.DoCommand(txtCommand.Text);
            }
        }

        /// <summary>
        /// This method clears the bitmap and repaints it white 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnClear_Click(object sender, EventArgs e)
        {
            Commands.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commands.ProgramLoad();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close this application?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
    }

