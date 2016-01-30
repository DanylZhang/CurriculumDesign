using System;
using System.Drawing;
using System.Windows.Forms;

namespace 鼠标绘画
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool flag = false;
        private Point lastPoint;
        private Color penColor = Color.Black;
        private void 选择画笔颜色CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                penColor = colorDialog1.Color;
            }
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutbox = new AboutBox1();
            aboutbox.ShowDialog();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                Pen p = new Pen(penColor, (float)(trackBarPenWidth.Value / 10.0));
                Graphics g = this.panel1.CreateGraphics();
                Point newPoint = new Point(e.X, e.Y);
                g.DrawLine(p, lastPoint, newPoint);
                if (rdoBtnTrack.Checked)
                {
                    lastPoint = newPoint;
                }
                else if (rdoBtnRadial.Checked)
                {

                }
            }
        }
    }
}