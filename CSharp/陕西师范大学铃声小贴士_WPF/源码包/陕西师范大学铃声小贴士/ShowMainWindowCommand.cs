using System;
using System.Windows;
using System.Windows.Input;

namespace 陕西师范大学铃声小贴士
{
    /// <summary>
    /// show main window.
    /// </summary>
    class ShowMainWindowCommand : ICommand
    {
        public void Execute(object parameter)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                try
                {
                    mainWindow.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                mainWindow.WindowState = WindowState.Normal;
                mainWindow.listbox.ScrollIntoView(mainWindow.listbox.Items[0]);
                mainWindow.Activate();
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}