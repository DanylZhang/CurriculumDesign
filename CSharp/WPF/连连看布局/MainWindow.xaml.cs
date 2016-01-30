using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace 连连看布局
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
        Random rand = new Random();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; ++i)
            {
                RowDefinition rowdf = new RowDefinition();
                gridGame.RowDefinitions.Add(rowdf);
                ColumnDefinition coldf = new ColumnDefinition();
                gridGame.ColumnDefinitions.Add(coldf);
            }
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("Images\\" + rand.Next(1, 9).ToString() + ".png", UriKind.Relative));
                    Grid.SetRow(img, i);
                    Grid.SetColumn(img, j);
                    gridGame.Children.Add(img);
                }
            }
        }
    }
}