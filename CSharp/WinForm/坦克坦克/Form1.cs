using System;
using System.Windows.Forms;
using 坦克坦克.Properties;
//注意因为添加了NumericUpDown控件使Form无法检测KeyDown事件
//解决方法：设 Form的 KeyPreview属性为 true
//同时设 NumericUpDown的InterceptArrowKeys属性为 false
namespace 坦克坦克
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetLabelText();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                //Left KeyDown
                case 37:
                    {
                        pictureBox1.Image = Resources.tankL;
                        pictureBox1.Left -= Convert.ToInt32(numUDSpeed.Value);
                        if (pictureBox1.Left <= panel1.Left)
                        {
                            pictureBox1.Left = 0;
                        }
                        SetLabelText();
                        break;
                    }
                //Up KeyDown
                case 38:
                    {
                        pictureBox1.Image = Resources.tankU;
                        pictureBox1.Top -= Convert.ToInt32(numUDSpeed.Value);
                        if (pictureBox1.Top <= panel1.Top)
                        {
                            pictureBox1.Top = 0;
                        }
                        SetLabelText();
                        break;
                    }
                //Right KeyDown
                case 39:
                    {
                        pictureBox1.Image = Resources.tankR;
                        pictureBox1.Left+= Convert.ToInt32(numUDSpeed.Value);
                        if (pictureBox1.Right >= panel1.Right)
                        {
                            pictureBox1.Left -= Convert.ToInt32(numUDSpeed.Value);
                        }
                        SetLabelText();
                        break;
                    }
                //Right KeyDown
                case 40:
                    {
                        pictureBox1.Image = Resources.tankD;
                        pictureBox1.Top += Convert.ToInt32(numUDSpeed.Value);
                        if (pictureBox1.Bottom >= panel1.Bottom)
                        {
                            pictureBox1.Top -= Convert.ToInt32(numUDSpeed.Value);
                        }
                        SetLabelText();
                        break;
                    }
                default: break;
            }
        }

        private void SetLabelText()
        {
            lblXPos.Text = "X坐标：" + pictureBox1.Location.X.ToString();
            lblYPos.Text = "Y坐标：" + pictureBox1.Location.Y.ToString();
        }
    }
}