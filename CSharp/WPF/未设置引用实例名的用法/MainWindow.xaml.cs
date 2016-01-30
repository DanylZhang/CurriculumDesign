using System.Windows;
using System.Windows.Controls;

namespace 未设置引用实例名的用法
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Grid g = this.Content as Grid;
            Button btn = g.Children[0] as Button;
            btn.Content = "WPF";
        }
    }
}
//声明引用变量，如果声明的实例的类派生自FrameWorkElement类，就可以直接使用Name属性赋值
//否则就得使用x:Name赋值