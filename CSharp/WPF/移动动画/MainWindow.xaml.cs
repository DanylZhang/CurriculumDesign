using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 移动动画
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ellipse ell;

        public MainWindow()
        {
            InitializeComponent();

            ell = new Ellipse();

            ell.Fill = new SolidColorBrush(Colors.Red);
            ell.Width = 50;
            ell.Height = 50;

            body.Children.Add(ell);

            Canvas.SetLeft(ell, 100);
            Canvas.SetTop(ell, 100);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveTo(e.GetPosition(body));
        }


        private void moveTo(Point deskPoint)
        {
            //Point p = e.GetPosition(body);

            Point curPoint = new Point();
            curPoint.X = Canvas.GetLeft(ell);
            curPoint.Y = Canvas.GetTop(ell);

            double _s = System.Math.Sqrt(Math.Pow((deskPoint.X - curPoint.X), 2) + Math.Pow((deskPoint.Y - curPoint.Y), 2));

            double _secNumber = (_s / 1000) * 500;

            Storyboard storyboard = new Storyboard();

            //创建X轴方向动画

            DoubleAnimation doubleAnimation = new DoubleAnimation(

              Canvas.GetLeft(ell),

              deskPoint.X,

              new Duration(TimeSpan.FromMilliseconds(_secNumber))

            );
            Storyboard.SetTarget(doubleAnimation, ell);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Left)"));
            storyboard.Children.Add(doubleAnimation);

            //创建Y轴方向动画

            doubleAnimation = new DoubleAnimation(
              Canvas.GetTop(ell),
              deskPoint.Y,
              new Duration(TimeSpan.FromMilliseconds(_secNumber))
            );
            Storyboard.SetTarget(doubleAnimation, ell);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(doubleAnimation);

            //动画播放
            storyboard.Begin();
        }
    }
}