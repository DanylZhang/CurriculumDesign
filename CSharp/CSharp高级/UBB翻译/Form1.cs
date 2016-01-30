using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UBB翻译
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            txtBoxHTML.Text = Regex.Replace(txtBoxUBB.Text, @"\[(\w+?)(=.+)?\](\.+?)\[(\w+?)\]", "<$1>$3<$1>");
        }
    }
}