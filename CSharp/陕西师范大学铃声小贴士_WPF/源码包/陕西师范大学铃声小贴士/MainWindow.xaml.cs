using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Threading;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using 陕西师范大学铃声小贴士.BLL;
using 陕西师范大学铃声小贴士.Model;

namespace 陕西师范大学铃声小贴士
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = null;
        private Dictionary<DateTime, string> schedule = null;
        public MainWindow()
        {
            InitializeComponent();
            InitEssential();
        }

        private void InitEssential()
        {
            SetSchedule();

            timer = new DispatcherTimer();
            timer.IsEnabled = true;
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += Timer_Tick;
        }

        private void SetSchedule()
        {
            SNNUSchedule model = null;
            try
            {
                model = new SNNUScheduleBLL().Get(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            schedule = new Dictionary<DateTime, string>();
            if (model != null)
            {
                schedule.Add(model.BeginTime1.Value, "上课");
                schedule.Add(model.EndTime1.Value, "下课");
                schedule.Add(model.BeginTime2.Value, "上课");
                schedule.Add(model.EndTime2.Value, "下课");
                schedule.Add(model.BeginTime3.Value, "上课");
                schedule.Add(model.EndTime3.Value, "下课");
                schedule.Add(model.BeginTime4.Value, "上课");
                schedule.Add(model.CloseTime1.Value, "放学");
                schedule.Add(model.BeginTime5.Value, "上课");
                schedule.Add(model.EndTime5.Value, "下课");
                schedule.Add(model.BeginTime6.Value, "上课");
                schedule.Add(model.EndTime6.Value, "下课");
                schedule.Add(model.BeginTime7.Value, "上课");
                schedule.Add(model.EndTime7.Value, "下课");
                schedule.Add(model.BeginTime8.Value, "上课");
                schedule.Add(model.CloseTime2.Value, "放学");
                schedule.Add(model.BeginTime9.Value, "上课");
                schedule.Add(model.EndTime9.Value, "下课");
                schedule.Add(model.BeginTime10.Value, "上课");
                schedule.Add(model.CloseTime3.Value, "放学");

                txtSchedule1.Text = model.BeginTime1.Value.ToString("H:mm") + "--" + model.EndTime1.Value.ToString("H:mm");
                txtSchedule2.Text = model.BeginTime2.Value.ToString("H:mm") + "--" + model.EndTime2.Value.ToString("H:mm");
                txtSchedule3.Text = model.BeginTime3.Value.ToString("H:mm") + "--" + model.EndTime3.Value.ToString("H:mm");
                txtSchedule4.Text = model.BeginTime4.Value.ToString("H:mm") + "--" + model.CloseTime1.Value.ToString("H:mm");
                txtSchedule5.Text = model.BeginTime5.Value.ToString("H:mm") + "--" + model.EndTime5.Value.ToString("H:mm");
                txtSchedule6.Text = model.BeginTime6.Value.ToString("H:mm") + "--" + model.EndTime6.Value.ToString("H:mm");
                txtSchedule7.Text = model.BeginTime7.Value.ToString("H:mm") + "--" + model.EndTime7.Value.ToString("H:mm");
                txtSchedule8.Text = model.BeginTime8.Value.ToString("H:mm") + "--" + model.CloseTime2.Value.ToString("H:mm");
                txtSchedule9.Text = model.BeginTime9.Value.ToString("H:mm") + "--" + model.EndTime9.Value.ToString("H:mm");
                txtSchedule10.Text = model.BeginTime10.Value.ToString("H:mm") + "--" + model.CloseTime3.Value.ToString("H:mm");
            }
            else
            {
                schedule.Add(Convert.ToDateTime("8:00"), "上课");
                schedule.Add(Convert.ToDateTime("8:50"), "下课");
                schedule.Add(Convert.ToDateTime("9:00"), "上课");
                schedule.Add(Convert.ToDateTime("9:50"), "下课");
                schedule.Add(Convert.ToDateTime("10:10"), "上课");
                schedule.Add(Convert.ToDateTime("11:00"), "下课");
                schedule.Add(Convert.ToDateTime("11:10"), "上课");
                schedule.Add(Convert.ToDateTime("12:00"), "放学");
                schedule.Add(Convert.ToDateTime("14:30"), "上课");
                schedule.Add(Convert.ToDateTime("15:20"), "下课");
                schedule.Add(Convert.ToDateTime("15:30"), "上课");
                schedule.Add(Convert.ToDateTime("16:20"), "下课");
                schedule.Add(Convert.ToDateTime("16:30"), "上课");
                schedule.Add(Convert.ToDateTime("17:20"), "下课");
                schedule.Add(Convert.ToDateTime("17:30"), "上课");
                schedule.Add(Convert.ToDateTime("18:20"), "放学");
                schedule.Add(Convert.ToDateTime("19:10"), "上课");
                schedule.Add(Convert.ToDateTime("20:00"), "下课");
                schedule.Add(Convert.ToDateTime("20:10"), "上课");
                schedule.Add(Convert.ToDateTime("21:00"), "放学");

                txtSchedule1.Text = "8:00--8:50";
                txtSchedule2.Text = "9:00--9:50";
                txtSchedule3.Text = "10:10--11:00";
                txtSchedule4.Text = "11:10--12:00";
                txtSchedule5.Text = "14:30--15:20";
                txtSchedule6.Text = "15:30--16:20";
                txtSchedule7.Text = "16:30--17:20";
                txtSchedule8.Text = "17:30--18:20";
                txtSchedule9.Text = "19:10--20:00";
                txtSchedule10.Text = "20:10--21:00";
            }
        }

        #region 调用Win32API实现电子铃声
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);

        private void PlayRing()
        {
            Random rand = new Random();
            for (int i = 0; i < 300; ++i)
            {
                Beep(rand.Next(10000), 100);
            }
        }
        #endregion

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (DateTime dt in schedule.Keys)
            {
                if (dt.ToShortTimeString() == DateTime.Now.ToShortTimeString())
                {
                    if (schedule[dt].Contains("上"))
                    {
                        Thread ringThread = new Thread(new ThreadStart(PlayRing));
                        ringThread.Start();
                    }
                    else if (schedule[dt].Contains("下"))
                    {
                        LinearGradientWindow myRingWindow = new LinearGradientWindow();
                        myRingWindow.Show();
                    }
                    else
                    {
                        ShutdownTipWindow shutdownWindow = new ShutdownTipWindow();
                        shutdownWindow.Show();
                    }
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"Html\index.html");
            }
            catch (Exception)
            {
                MessageBox.Show("帮助页面找不到了哟......", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btnShowReport_Click(object sender, RoutedEventArgs e)
        {
            SNNUScheduleReport reportForm = new SNNUScheduleReport();
            reportForm.Show();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            SetSchedule();
        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {
            listbox.ScrollIntoView(LstBxImSchedule);
        }

        private void btnAssistant_Click(object sender, RoutedEventArgs e)
        {
            listbox.ScrollIntoView(LstBxImAssistant);
            AssistantWindow shutAssistant = new AssistantWindow();
            shutAssistant.Show();
        }

        private void btnSetup_Click(object sender, RoutedEventArgs e)
        {
            listbox.ScrollIntoView(LstBxImSetup);
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            listbox.ScrollIntoView(LstBxImAbout);
        }

        private void btnUpdateSchedule_Click(object sender, RoutedEventArgs e)
        {
            UpdateScheduleWindow updateWindow = new UpdateScheduleWindow();
            updateWindow.ShowDialog();//模态窗口，即阻塞窗口
        }

        private void btnSaveSetup_Click(object sender, RoutedEventArgs e)
        {
            string exeDir = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string exeName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
            RegistryKey reg = null;
            try
            {
                reg = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                reg.SetValue(exeName, exeDir + exeName);
                MessageBox.Show("恭喜你成功设置开机自启！", "提醒", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (reg != null)
                {
                    reg.Dispose();
                }
            }
        }

        private void notifyMenuSchedule_Click(object sender, RoutedEventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            listbox.ScrollIntoView(LstBxImSchedule);
        }

        private void notifyMenuAssistant_Click(object sender, RoutedEventArgs e)
        {
            AssistantWindow ShutDownAssistant = new AssistantWindow();
            ShutDownAssistant.Show();
        }

        private void notifyMenuSetup_Click(object sender, RoutedEventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            listbox.ScrollIntoView(LstBxImSetup);
        }

        private void notifyMenuAbout_Click(object sender, RoutedEventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            listbox.ScrollIntoView(LstBxImAbout);
        }

        private void notifyMenuExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
            //这条语句可以使程序完全退出，并关闭所有后台线程，但这样会终止未完成的作业，所以不常用，不如退出主程序，等后台线程结束时自动退出
        }

        private void MyNotifyIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            listbox.ScrollIntoView(LstBxImSchedule);
        }

        private void MyNotifyIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            AssistantWindow shutAssistant = new AssistantWindow();
            shutAssistant.Show();
            shutAssistant.Activate();
        }
    }
}