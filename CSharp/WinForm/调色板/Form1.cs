using System;
using System.Windows.Forms;

namespace 调色板
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetColor();
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            SetColor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                trackBarAlpha.Value = colorDialog1.Color.A;
                trackBarRed.Value = colorDialog1.Color.R;
                trackBarGreen.Value = colorDialog1.Color.G;
                trackBarBlue.Value = colorDialog1.Color.B;
                SetColor();
            }
        }

        private void SetColor()
        {
            lblAlpha.Text = trackBarAlpha.Value.ToString();
            lblRed.Text = trackBarRed.Value.ToString();
            lblGreen.Text = trackBarGreen.Value.ToString();
            lblBlue.Text = trackBarBlue.Value.ToString();
            lblColor.BackColor = System.Drawing.Color.FromArgb(trackBarAlpha.Value, trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
            lblColorValue.Text = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", trackBarAlpha.Value, trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);
        }
    }
}