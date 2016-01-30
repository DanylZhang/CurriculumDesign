using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 报表
{
    class DrawReport
    {
        private double[] data = { 34.3, 65.7, 33.1, 87, 57.3, 56, 99, 56.3, 41.6, 48.1, 57.3, 35.8 };
        public Graphics G
        {
            get;
            set;
        }
        public Point CenterPoint
        {
            get;
            set;
        }
        public void Draw()
        {
            Font font = new Font("宋体", 9, FontStyle.Regular);
            PointF[] dataPoint = new PointF[12];//声明数据点
            for (int i = 0; i < 12; ++i)
            {
                dataPoint[i] = new PointF(CenterPoint.X + (i + 1) * 30f, 370 - (float)data[i] * 3);
            }

            RectangleF[] rects = new RectangleF[12];
            for (int i = 0; i < 12; ++i)
            {
                rects[i] = new RectangleF(dataPoint[i].X, dataPoint[i].Y, 3, 3);
                dataPoint[i] = new PointF(CenterPoint.X + (i + 1) * 30f, 370 - (float)data[i] * 3);
            }

            Pen pen = new Pen(Color.Black, 1);
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            G.DrawLine(pen, CenterPoint, new Point(CenterPoint.X + 400, CenterPoint.Y));//x
            G.DrawLine(pen, CenterPoint, new Point(CenterPoint.X, CenterPoint.Y - 320));//y

            for (int i = 1; i <= 12; ++i)
            {
                G.DrawLine(Pens.Black, new Point(CenterPoint.X + i * 30, CenterPoint.Y), new Point(CenterPoint.X + i * 30, CenterPoint.Y - 5));
                G.DrawString(i.ToString() + "月", font, Brushes.Black, new Point(CenterPoint.X + i * 30 - 15, CenterPoint.Y + 5));
            }
            G.DrawString("月份", font, Brushes.Black, CenterPoint.X+400,CenterPoint.Y+10);

            for (int i = 1; i <= 10; ++i)
            {
                G.DrawLine(Pens.Black, new Point(CenterPoint.X, CenterPoint.Y - i * 30), new Point(CenterPoint.X + 5, CenterPoint.Y - i * 30));
                G.DrawString((i * 10).ToString(), font, Brushes.Black, new Point(CenterPoint.X - 20, CenterPoint.Y - i * 30 - 5));
            }
            G.DrawString("销售额：单位（万元）", font, Brushes.Black, CenterPoint.X-100, CenterPoint.Y-340);

            G.DrawLines(Pens.Black, dataPoint);//绘制数据线
            G.DrawRectangles(Pens.Black, rects);//绘制矩形
            G.DrawString("XX产品年度销售额", font, Brushes.Black, CenterPoint.X+160, CenterPoint.Y -370);
            pen.Dispose();
            font.Dispose();
        }
    }
}