using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 不破坏背景的慢跑动画
{
    public partial class Form1 : Form
    {
        AnimateImage image;

        public Form1()
        {
            InitializeComponent();
            image = new AnimateImage(Image.FromFile(@"慢跑.gif"));
            image.OnFrameChanged += new EventHandler(image_OnFrameChanged);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        void image_OnFrameChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image.Play();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            lock (image.Image)
            {
                e.Graphics.DrawImage(image.Image, new Point(170, 260));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Stop"))
            {
                image.Stop();
                button1.Text = "Play";
            }
            else
            {
                image.Play();
                button1.Text = "Stop";
            }
            Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            image.Reset();
            button1.Text = "Play";
            Invalidate();
        }
    }
}