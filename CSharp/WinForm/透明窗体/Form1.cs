using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace 透明窗体
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int i = trackBar1.Value;
            int j = trackBar1.Maximum;
            this.Opacity = (double)(j - i) / j;
        }
        private void btnAutoOpacity_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            trackBar1.Enabled = false;
            btnAutoOpacity.Enabled = false;
            for (double i = 0.02; i <= 1; i += 0.02)
            {
                this.Opacity = i;
                System.Windows.Forms.Application.DoEvents();//仍然接受windows消息，不加这句代码，for循环执行时，窗体处于假死状态，加上相当于开启了多线程
                System.Threading.Thread.Sleep(20);
            }
            this.Opacity = 1;
            trackBar1.Enabled = true;
            btnAutoOpacity.Enabled = true;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool hasNormalRegion = true;
        private void btnChangeShape_Click(object sender, EventArgs e)
        {
            if (hasNormalRegion)
            {
                GraphicsPath p = new GraphicsPath();
                int bigDiameter = this.ClientSize.Height;
                int donutWidth = 100;
                p.AddEllipse(0, 0, bigDiameter, bigDiameter);
                p.AddEllipse(donutWidth, donutWidth, bigDiameter - (donutWidth * 2), bigDiameter - (donutWidth * 2));
                this.Region = new Region(p);
            }
            else
            {
                this.Region = null;
            }
            hasNormalRegion = !hasNormalRegion;
        }

        private void tlstripmenuEllipseShap_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hasNormalRegion = true;
            btnChangeShape_Click(sender, e);
            tlstripmenuRectangle.Checked = false;
            tlstripmenuEllipseShap.Checked = true;
        }

        private void tlstripmenuRectangle_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            hasNormalRegion = false;
            btnChangeShape_Click(sender, e);
            tlstripmenuEllipseShap.Checked = false;
            tlstripmenuRectangle.Checked = true;
        }

        private void tlstripmenuChangeOpacity_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            btnAutoOpacity_Click(sender, e);
        }

        private void tlstripmenuQuit_Click(object sender, EventArgs e)
        {
            btnQuit_Click(sender, e);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }

        private void timerToRight_Tick(object sender, EventArgs e)
        {
            Point p = new Point(this.DesktopLocation.X + 1, this.DesktopLocation.Y);
            this.DesktopLocation = p;
            if (p.X == 600)
            {
                timerToRight.Enabled = false;
                timerToLeft.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Point p = new Point(0, 240);
            this.DesktopLocation = p;
        }

        private void timerToLeft_Tick(object sender, EventArgs e)
        {
            Point p = new Point(this.DesktopLocation.X - 1, this.DesktopLocation.Y);
            this.DesktopLocation = p;
            if (p.X == 1)
            {
                timerToLeft.Enabled = false;
                timerToRight.Enabled = true;
            }
        }
    }
}