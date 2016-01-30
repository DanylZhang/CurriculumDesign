using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 报表
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = string.Format("x={0},y={1}", e.X, e.Y);
        }
        double[] data = { 34.3, 65.7, 33.1, 87, 57.3, 56, 99, 56.3, 41.6, 48.1, 57.3, 35.8 };
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point centerPoint = new Point(90, 370);//确定原点
            PointF[] dataPoint = new PointF[12];//声明数据点
            for (int i = 0; i < 12; ++i)
            {
                dataPoint[i] = new PointF(centerPoint.X + (i + 1) * 30f, 370 - (float)data[i] * 3);
            }

            RectangleF[] rects = new RectangleF[12];
            for (int i = 0; i < 12; ++i)
            {
                rects[i] = new RectangleF(dataPoint[i].X, dataPoint[i].Y, 3, 3);
                dataPoint[i] = new PointF(centerPoint.X + (i + 1) * 30f, 370 - (float)data[i] * 3);
            }

            Graphics g = e.Graphics;

            Pen pen = new Pen(Color.Black, 1);
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            g.DrawLine(pen, centerPoint, new Point(centerPoint.X + 400, centerPoint.Y));//x
            g.DrawLine(pen, centerPoint, new Point(centerPoint.X, centerPoint.Y - 320));//y

            for (int i = 1; i <= 12; ++i)
            {
                g.DrawLine(Pens.Black, new Point(centerPoint.X + i * 30, centerPoint.Y), new Point(centerPoint.X + i * 30, centerPoint.Y - 5));
                g.DrawString(i.ToString() + "月", this.Font, Brushes.Black, new Point(centerPoint.X + i * 30 - 15, centerPoint.Y + 5));
            }
            g.DrawString("月份", this.Font, Brushes.Black, 500, 380);

            for (int i = 1; i <= 10; ++i)
            {
                g.DrawLine(Pens.Black, new Point(centerPoint.X, centerPoint.Y - i * 30), new Point(centerPoint.X + 5, centerPoint.Y - i * 30));
                g.DrawString((i * 10).ToString(), this.Font, Brushes.Black, new Point(centerPoint.X - 20, centerPoint.Y - i * 30 - 5));
            }
            g.DrawString("销售额：单位（万元）", this.Font, Brushes.Black, new Point(5, 30));

            g.DrawLines(Pens.Black, dataPoint);//绘制数据线
            g.DrawRectangles(Pens.Black, rects);//绘制矩形
            g.DrawString("XX产品年度销售额", this.Font, Brushes.Black, 260, 30);
            pen.Dispose();
        }
    }
}