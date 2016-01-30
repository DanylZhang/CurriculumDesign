using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace 键盘钩子
{
    class MyBackgroundGradientBrush
    {
        private Color startColor;
        private Color endColor;
        private Point startPoint;
        private Point endPoint;
        //private double startOffset = 0.0;
        //private double endOffset = 1.0;
        private double angle = 0.0;
        private LinearGradientBrush linearBrush;
        private RadialGradientBrush radialBrush;
        public LinearGradientBrush LinearBrush
        {
            get
            {
                return new LinearGradientBrush(startColor, endColor, startPoint, endPoint); 
            }
            set
            {
                this.linearBrush = value;
            } 
        }
        public RadialGradientBrush RadialBrush
        {
            get
            {
                return new RadialGradientBrush(startColor, endColor);
            }
            set
            {
                this.radialBrush = value;
            }
        }
        public MyBackgroundGradientBrush()
        {
            InitTwoColors();
            InitTwoPoints();
            InitLinearBrush();
            InitRadialBrush();
        }
        public MyBackgroundGradientBrush(Color startColor, Color endColor)
        {
            this.startColor = startColor;
            this.endColor = endColor;
            InitRadialBrush();
        }
        public MyBackgroundGradientBrush(Color startColor, Color endColor, Point startPoint, Point endPoint)
        {
            this.startColor = startColor;
            this.endColor = endColor;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            InitLinearBrush();
            InitRadialBrush();
        }

        #region 初始化起始终止颜色
        /// <summary>
        /// 初始化起始终止颜色
        /// </summary>
        public void InitTwoColors()
        {
            startColor = new Color();
            startColor.A = 0xff;
            startColor.R = 91;
            startColor.G = 33;
            startColor.B = 247;
            endColor = new Color();
            endColor.A = 0xff;
            endColor.R = 191;
            endColor.G = 226;
            endColor.B = 35;
        }
        #endregion

        #region 以增量改变起始颜色的RGB
        /// <summary>
        /// 以增量改变起始颜色的RGB
        /// </summary>
        /// <param name="delt">增量</param>
        public void ChangeStartColorRGB(byte delt)
        {
            startColor.R += delt;
            startColor.G += delt;
            startColor.B += delt;
        }
        #endregion

        #region 以增量改变终止颜色的RGB
        /// <summary>
        /// 以增量改变终止颜色的RGB
        /// </summary>
        /// <param name="delt">增量</param>
        public void ChangeEndColorRGB(byte delt)
        {
            endColor.R += delt;
            endColor.G += delt;
            endColor.B += delt;
        }
        #endregion

        #region 初始化起始终止点
        /// <summary>
        /// 初始化起始终止点
        /// </summary>
        public void InitTwoPoints()
        {
            startPoint = new Point(1.0, 0.0);
            endPoint = new Point(1.0, 0.0);
        }
        #endregion

        #region 以增量改变起始点坐标
        /// <summary>
        /// 以增量改变起始点坐标
        /// </summary>
        /// <param name="delt">增量</param>
        public void ChangeStartPoint(int delt)
        {
            startPoint.X += delt;
            startPoint.Y += delt;
        }
        #endregion

        #region 以增量改变终止点坐标
        /// <summary>
        /// 以增量改变终止点坐标
        /// </summary>
        /// <param name="delt">增量</param>
        public void ChangeEndPoint(int delt)
        {
            endPoint.X += delt;
            endPoint.Y += delt;
        }
        #endregion

        #region 以增量改变角度值
        /// <summary>
        /// 以增量改变角度值
        /// </summary>
        /// <param name="delt">增量</param>
        public void ChangeAngle(double delt)
        {
            angle += delt;
        }
        #endregion

        #region 初始化线性渐变刷子
        /// <summary>
        /// 初始化线性渐变刷子
        /// </summary>
        public void InitLinearBrush()
        {
            LinearBrush = new LinearGradientBrush(startColor, endColor, startPoint, endPoint);
        }
        #endregion

        #region 初始化放射渐变刷子
        /// <summary>
        /// 初始化放射渐变刷子
        /// </summary>
        public void InitRadialBrush()
        {
            RadialBrush = new RadialGradientBrush(startColor, endColor);
        }
        #endregion

        //public LinearGradientBrush GetNewLinearBrush(int delt)
        //{
        //    ChangeStartColorRGB(1);
        //    ChangeEndColorRGB(-1);
        //}

        //public RadialGradientBrush GetNewRadialBrush()
        //{

        //}
    }
}