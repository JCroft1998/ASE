using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GraphicsTools
{
    class Commands:MainForm
    {
        public static void DrawCircle(int radius)
        {
            Graphics g = Graphics.FromImage(Mybitmap);
            g.DrawEllipse(new Pen(Color.Aqua, penT), xPos, yPos, radius, radius);
            Mypanel.Invalidate();
        }

        public static void DrawTriangle(int firstSide, int secondSide)
        {
            Point[] triPoints = new Point[3];
            triPoints[0] = new Point(xPos, yPos);
            triPoints[1] = new Point(firstSide + xPos, firstSide + yPos);
            triPoints[2] = new Point(triPoints[1].X - secondSide, triPoints[1].Y);

            Graphics g = Graphics.FromImage(Mybitmap);
            g.DrawPolygon(new Pen(Color.Red, penT), triPoints);
            Mypanel.Invalidate();
        }

        public static void DrawRectangle(int width, int height)
        {
            Graphics g = Graphics.FromImage(Mybitmap);
            g.DrawRectangle(new Pen(Color.Black, penT), xPos, yPos, width, height);
            Mypanel.Invalidate();
        }

        public static void DrawPen(int x, int y)
        {
            Graphics g = Graphics.FromImage(Mybitmap);
            g.DrawLine(new Pen(Color.Purple, penT), new Point(xPos, yPos), new Point(x, y));
            PenPosition(x, y);
            Mypanel.Invalidate();
        }

        public static void PenPosition(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

        public static void Reset()
        {
            xPos = 0;
            yPos = 0;
        }

        public static void Clear()
        {
            Graphics g = Graphics.FromImage(Mybitmap);
            g.Clear(Color.White);
            Mypanel.Invalidate();
        }

        public static void ProgramSave()
        {
            try
            {
                // Generates name:
                string generated = DateTime.Now.ToString("ddMMyyyy-hhmmss");
                string savePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + Path.DirectorySeparatorChar + "Programs" + Path.DirectorySeparatorChar + generated + ".txt";

                // Saves text:
                TextWriter write = new StreamWriter(savePath);
                write.Write(Mytextbox.Text);
                write.Close();

                MessageBox.Show("Program saved as: " + generated + ".txt");
            } catch(Exception)
            {

            }
        }

        public static void ProgramLoad()
        {
            try
            {
                string loadPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + Path.DirectorySeparatorChar + "Programs" + Path.DirectorySeparatorChar;

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = loadPath;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Loads selected file:
                    string set = File.ReadAllText(ofd.FileName);
                    Mytextbox.Clear();
                    Mytextbox.AppendText(set);
                }
            }
            catch (Exception)
            {

            }
        }

        public static void Run()
        {
            try
            {
                Reset();
                Clear();

                // 
                foreach(string line in Mytextbox.Lines)
                {
                    DoCommand(line);
                }
            } catch(Exception)
            {

            }
        }

        public static void DoCommand(string command)
        {
            command = command.ToLower().Trim();
            string[] sSplit = command.Split(' ');

            try
            {
                Function = sSplit[0].Trim();
                valOne = Int32.Parse(sSplit[1].Trim());
                valTwo = Int32.Parse(sSplit[2].Trim());
            }
            catch (Exception)
            {
            }

            try
            {
                if (string.IsNullOrEmpty(Function))
                {
                    // Leave blank
                }

                else if (Function == "triangle" && int.TryParse(sSplit[1], out valOne) && int.TryParse(sSplit[2], out valTwo))
                {
                    DrawTriangle(valOne, valTwo);
                }

                else if (Function == "rectangle" && int.TryParse(sSplit[1], out valOne) && int.TryParse(sSplit[2], out valTwo))
                {
                    DrawRectangle(valOne, valTwo);
                }

                else if (Function == "circle" && int.TryParse(sSplit[1], out valOne))
                {
                    DrawCircle(valOne);
                }

                else if (Function == "moveto" && int.TryParse(sSplit[1], out valOne) && int.TryParse(sSplit[2], out valTwo))
                {
                    PenPosition(valOne, valTwo);
                }

                else if (Function == ("clear"))
                {
                    Clear();
                }

                else if (Function == ("reset"))
                {
                    Reset();
                }

                else if (Function == "drawto" && int.TryParse(sSplit[1], out valOne) && int.TryParse(sSplit[2], out valTwo))
                {
                    DrawPen(valOne, valTwo);
                }

                else if (Function == ("save"))
                {
                    ProgramSave();
                }

                else if (Function == ("load"))
                {
                    ProgramLoad();
                }

                else if (Function == ("run"))
                {
                    Run();
                }

                else
                {
                    MessageBox.Show("Invalid command: " + command);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid command: " + command);
            }
        }
    }
}
