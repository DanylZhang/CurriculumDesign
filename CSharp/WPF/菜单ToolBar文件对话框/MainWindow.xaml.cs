using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace 菜单
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
        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opfile = new OpenFileDialog();
            opfile.Title = "打开文件";
            opfile.Filter = "图片|*.jpg文本文件|*.txt|所有文件|*.*";
            if (opfile.ShowDialog() == true)
            {
                StreamReader reader = new StreamReader(opfile.FileName);
                txtBoxMain.Text = reader.ReadToEnd();
            }
        }
        private void miAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutwindow = new AboutWindow();
            aboutwindow.UserName = txtBoxMain.Text;
            aboutwindow.ShowDialog();//模态
            //aboutwindow.Show();//非模态
            MessageBox.Show(aboutwindow.Password);//MessageBox只有一个模态Show()方法
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "另存为";
            sfd.Filter = "文本文件|*.txt|图片|*.jpg|所有文件|*.*";
            if (sfd.ShowDialog() == true)
            {
                MessageBox.Show("文件已保存");
            }
            else
            {
                MessageBox.Show("文件未保存");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}