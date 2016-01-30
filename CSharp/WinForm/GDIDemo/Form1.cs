using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDIDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawEllipse(Pens.Red, 50, 100, 100, 100);
            g.DrawRectangle(Pens.Chocolate, 50, 100, 100, 100);
            g.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = this.panel1.CreateGraphics();
            g.FillEllipse(Brushes.GreenYellow, 100, 30, 50, 50);
            g.Dispose();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point[] p = new Point[3];
            p[0] = new Point(20, 30);
            p[1] = new Point(90, 100);
            p[2] = new Point(120, 250);
            Pen pen = new Pen(Color.Yellow, 5);
            g.DrawCurve(Pens.Black, p);
            g.DrawLines(Pens.Black, p);
            pen.Dispose();
            //g.DrawCurve()
            //g.Dispose();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = string.Format("X={0},Y={1}", e.X, e.Y);
        }
    }
}