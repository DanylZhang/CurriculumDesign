using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FileOperator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChooseOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"D:\Documents";
            ofd.Filter = "文本文件|*.txt|所有文件|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtBoxReadFilePath.Text = ofd.FileName;
            }
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(txtBoxReadFilePath.Text, FileMode.Open, FileAccess.Read))
            {
                //考虑到文件流以字节数组的方式读取文件，所以先定义字节数组
                byte[] byteFile = new byte[1024 * 1024 * 4];
                //将文件以字节方式读入字节数组
                fs.Read(byteFile, 0, byteFile.Length);
                //将字节数组转换为字符串
                txtBoxReadFileContent.Text = Encoding.UTF8.GetString(byteFile);
            }
        }

        private void btnChooseSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"D:\Documents";
            sfd.Filter = "文本文件|*.txt|所有文件|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txtBoxSaveFilePath.Text = sfd.FileName;
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            using (FileStream fs=new FileStream(txtBoxSaveFilePath.Text, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] bytefile = Encoding.UTF8.GetBytes(txtBoxWriteFileContent.Text);
                fs.Write(bytefile, 0, bytefile.Length);
            }
        }
    }
}