using System;
using System.Linq;
using System.Windows;

namespace 菜单
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtblockName.Text = UserName;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Password = pwdBox1.Password;
        }
    }
}