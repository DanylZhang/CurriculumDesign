using System.Windows;

namespace 陕西师范大学铃声小贴士
{
    /// <summary>
    /// Interaction logic for AssistantWindow.xaml
    /// </summary>
    public partial class AssistantWindow : Window
    {
        public AssistantWindow()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnReboot_Click(object sender, RoutedEventArgs e)
        {
            WindowsExit.Reboot();
        }

        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            WindowsExit.Lock();
        }

        private void btnLogOff_Click(object sender, RoutedEventArgs e)
        {
            WindowsExit.LogOff();
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            WindowsExit.PowerOff();
        }
    }
}