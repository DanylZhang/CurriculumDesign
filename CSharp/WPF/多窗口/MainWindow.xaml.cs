using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace 多窗口
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
            InputWindow inputWin = new InputWindow();
            if (inputWin.ShowDialog() == true)
            {
                btnShow.Content = inputWin.UserName;
            }
            else
            {
                Image img=new Image();
                img.Source=new BitmapImage(new Uri(@"Images\2.png",UriKind.Relative));
                btnShow.Content = img;
            }
        }
    }
}