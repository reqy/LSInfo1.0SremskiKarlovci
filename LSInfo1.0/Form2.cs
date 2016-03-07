using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LSInfo1._0
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Bitmap bmp = Properties.Resources.LSInfoLogo;

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = bmp;
            Timer tm = new Timer();
            tm.Interval = 1000;
            tm.Tick += timerTick;
            pictureBox1.Visible = true;
            tm.Enabled = false;
            tm.Start();            
        }



        private void timerTick(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            ((Timer)sender).Stop();
            this.Hide();         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
