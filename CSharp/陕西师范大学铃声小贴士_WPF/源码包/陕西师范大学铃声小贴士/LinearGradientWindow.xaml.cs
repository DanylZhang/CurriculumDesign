//经测试：
//使用Margin做动画的源数据，不好控制，容易出现遮挡，效果不好
//使用TranslateTransform虽然不会出现遮挡，但每次都以当前坐标为原点，容易脱离屏幕，不好控制
//故使用Canvas画布
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace 陕西师范大学铃声小贴士
{
    /// <summary>
    /// Interaction logic for LinearGradientWindow.xaml
    /// </summary>
    public partial class LinearGradientWindow : Window
    {
        private Hook myhook = null;
        private int flag = 0;
        private DispatcherTimer timer = null;
        public LinearGradientWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myhook = new Hook();
            try
            {
                myhook.Start();
            }
            catch (Exception)
            {
            }
            Random rand = new Random();
            Canvas.SetLeft(image1, rand.Next(Convert.ToInt32(SystemParameters.FullPrimaryScreenWidth - 128)));
            Canvas.SetTop(image1, rand.Next(Convert.ToInt32(SystemParameters.FullPrimaryScreenHeight - 128)));

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(10);
            timer.Tick += Timer_Tick;
            timer.IsEnabled = true;//首先DispatcherTimer不需要手动Start，其次把IsEnabled放在最后可以避免在计时开始之前先执行Tick一次
        }

        //十分钟后窗口关闭并清除键盘钩子
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                myhook.Clear();
            }
            catch(Exception)
            {
            }
            this.Close();
        }

        //鼠标点击小黄人2次后窗口关闭
        private void image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            flag++;
            if (flag == 2)
            {
                try
                {
                    myhook.Clear();
                }
                catch (Exception)
                {
                }
                this.Close();
            }
        }

        private void image1_MouseEnter(object sender, MouseEventArgs e)
        {
            Random rand = new Random();
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;
            double screenHeigth = SystemParameters.FullPrimaryScreenHeight;

            Storyboard myStoryboard = new Storyboard();
            myStoryboard.AutoReverse = true;
            myStoryboard.AccelerationRatio = 0.6;
            myStoryboard.DecelerationRatio = 0.4;

            DoubleAnimation myDoubleAnimation = new DoubleAnimation(rand.Next((int)screenWidth - 128), new Duration(TimeSpan.FromSeconds(1)), FillBehavior.HoldEnd);//横向移动
            Storyboard.SetTarget(myDoubleAnimation, image1);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Canvas.LeftProperty));
            myStoryboard.Children.Add(myDoubleAnimation);

            myDoubleAnimation = new DoubleAnimation(rand.Next((int)screenHeigth - 128), new Duration(TimeSpan.FromSeconds(1)), FillBehavior.HoldEnd);//纵向移动
            Storyboard.SetTarget(myDoubleAnimation, image1);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Canvas.TopProperty));
            myStoryboard.Children.Add(myDoubleAnimation);

            myStoryboard.Begin();
        }
    }
}