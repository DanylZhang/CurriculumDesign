using GlobalHook;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace 键盘钩子
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Hook hook = new Hook();
        private MyBackgroundGradientBrush gradBrush;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            gradBrush = new MyBackgroundGradientBrush(Color.FromArgb(255, 91, 33, 247), Color.FromArgb(255, 191, 226, 35), new Point(0.5, 1.0), new Point(0.5, 0));
            this.Background = gradBrush.LinearBrush;
            timer = new DispatcherTimer();
            timer.IsEnabled = true;
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        public void timer_Tick(Object sender, EventArgs e)
        {
            gradBrush.ChangeStartColorRGB(1);
            gradBrush.ChangeEndColorRGB(1);
            gradBrush.RadialBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255, 33, 99, 220), 0.5));
            this.Background = gradBrush.RadialBrush;
            btnStart.Background = gradBrush.RadialBrush;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (btnStart.Content.ToString() == "关闭")
            {
                hook.Clear();
                btnStart.Content = "开始";
            }
            else
            {
                hook.Start();
                btnStart.Content = "关闭";
            }
        }
    }
}