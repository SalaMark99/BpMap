using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using TerkepAdatok;

namespace bpmap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adatok a = new Adatok();
            pictureBox1.Image = new Bitmap(500, 500);

            foreach (Koords kord in a.Koordinatak)
            {
                ((Bitmap)(pictureBox1.Image)).SetPixel((int)kord.X, (int)kord.Y, Color.Red);
            }

        }
    }
}
