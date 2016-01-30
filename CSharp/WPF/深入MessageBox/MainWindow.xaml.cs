using System;
using System.Linq;
using System.Windows;

namespace 深入MessageBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("是否保存更改？", "提醒", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("已保存");
                this.Close();
            }
            else if (result == MessageBoxResult.No)
            {
                MessageBox.Show("未保存");
                this.Close();
            }
            else if (result == MessageBoxResult.Cancel)
            {
                MessageBox.Show("您取消了操作");
            }
        }
    }
}