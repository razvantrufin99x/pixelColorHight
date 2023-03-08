using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pixelColorHight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        Graphics g;
        Bitmap bmp = new Bitmap("img.png");
        Color c1;
        int ccode = 0;
        int c1code = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
          
           
            panel1.BackgroundImage = bmp;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < bmp.Height; i++)
            {
                for (int j = 1; j < bmp.Width; j++)
                {
                    Color c = bmp.GetPixel(j,i);
                    ccode = c.A + c.R + c.G + c.B;
                    if (ccode > c1code-10 && ccode< c1code+10)
                    {
                        g.DrawLine(new Pen(c), j, i, j + ccode/100, i + ccode/100);
                    }
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            c1 = bmp.GetPixel(e.X,e.Y);
            c1code = c1.A + c1.R + c1.G + c1.B;
            Text = c1code.ToString();
        }
    }
}
