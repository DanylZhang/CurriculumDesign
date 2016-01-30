using System;
using System.Windows;
using System.Windows.Threading;

namespace 陕西师范大学铃声小贴士
{
    /// <summary>
    /// Interaction logic for ShutdownTipWindow.xaml
    /// </summary>
    public partial class ShutdownTipWindow : Window
    {
        DispatcherTimer timer = null;
        int countDown = 30;
        public ShutdownTipWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += Timer_Tick;
            timer.IsEnabled = true;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            countDown--;
            txtTip.Text = countDown.ToString() + "秒无操作后关机";
            if(countDown==0)
            {
                WindowsExit.PowerOff();
            }
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            WindowsExit.PowerOff();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            this.Close();
        }
    }
}