using System;
using System.Linq;
using System.Windows;

namespace 多窗口
{
    /// <summary>
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        public InputWindow()
        {
            InitializeComponent();
        }
        public string UserName { get; set; }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            UserName = txtboxName.Text;
            DialogResult = true;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}