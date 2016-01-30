using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 报表
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawReport draw = new DrawReport();
            draw.G = this.panel1.CreateGraphics();
            draw.CenterPoint = new Point(100, 400);
            draw.Draw();
            draw.G.Dispose();
        }
    }
}