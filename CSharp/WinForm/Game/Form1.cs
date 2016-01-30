using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Plane plane = null;
        Bullet bullet = null;
        Graphics g = null;
        private void StartPlane()
        {
            plane = new Plane();
            plane.Size = 40;
            plane.X = 0;
            Random rand = new Random();
            plane.Y = rand.Next(0, gPnlField.Height - plane.Size - 50);
            plane.FieldArea = gPnlField.ClientRectangle;
            plane.HitTimes = 0;
            plane.IsHit = false;
            plane.Speed = 5;
            g = this.gPnlField.CreateGraphics();
            plane.Draw(g);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //在窗体加载事件中初始化飞机
            StartPlane();
            //在窗体加载时绘制飞机是不成功的，panel会重绘，plane将会被覆盖
            plane.Draw(this.gPnlField.CreateGraphics());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            plane.Move();
            //让panel控件的绘制失效，并重新绘制。重绘时自动调用panel的Paint事件
            gPnlField.Invalidate();
        }
        private void gPnlField_Paint(object sender, PaintEventArgs e)
        {
            plane.Draw(e.Graphics);
        }

        private void gPnlField_MouseClick(object sender, MouseEventArgs e)
        {
            bullet = new Bullet();
            bullet.X = e.X;
            bullet.Y = e.Y;
            bullet.Speed = 5;
        }
    }
}