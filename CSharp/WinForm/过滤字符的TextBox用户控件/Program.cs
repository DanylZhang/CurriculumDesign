using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 过滤字符的TextBox用户控件
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
