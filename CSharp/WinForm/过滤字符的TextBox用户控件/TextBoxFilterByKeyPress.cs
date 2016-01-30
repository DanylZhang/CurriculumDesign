using System.Windows.Forms;

namespace 过滤字符的TextBox用户控件
{
    public partial class TextBoxFilterByKeyPress : UserControl
    {
        public TextBoxFilterByKeyPress()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8 || e.KeyChar == 13))
            {
                e.Handled = true;
            }
        }
    }
}