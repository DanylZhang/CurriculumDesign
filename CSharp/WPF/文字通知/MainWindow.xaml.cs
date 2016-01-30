using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 文字通知
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
        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            Brush brush = new SolidColorBrush(Color.FromArgb(0x90, 0xFF, 0xFF, 0xFF));
            grid.Background = brush;
        }
        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            Brush brush = new SolidColorBrush(Color.FromArgb(0x50, 0xFF, 0xFF, 0xFF));
            grid.Background = brush;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}