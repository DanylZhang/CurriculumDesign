using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyChatSoftClient
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }
        //客户端套接字负责和服务端通信
        private Socket sockClient = null;
        //负责接收消息
        private Thread threadReceiveMsg = null;

        #region 显示消息和异常消息
        private void ShowErr(string msg, Exception ex)
        {
            ShowMsg("----------Begin----------\n");
            ShowMsg(msg + " " + ex.Message + "\n");
            ShowMsg("----------End------------\n");
        }
        private void ShowMsg(string msg)
        {
            txtShow.AppendText(msg + "\n");
        }
        #endregion

        #region 和服务端连接并监听消息
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }
        private void Connect()
        {
            try
            {
                IPAddress address = IPAddress.Parse(txtIPAddress.Text.Trim());
                IPEndPoint endPoint = new IPEndPoint(address, int.Parse(txtPort.Text.Trim()));
                sockClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sockClient.Connect(endPoint);
                threadReceiveMsg = new Thread(new ThreadStart(ReceiveMsg));
                //设置为后台线程(当前台线程关闭时自动关闭)
                threadReceiveMsg.IsBackground = true;
                threadReceiveMsg.Start();
            }
            catch (Exception ex)
            {
                ShowErr("", ex);
            }
        }
        private void ReceiveMsg()
        {
            try
            {
                while (true)
                {
                    byte[] msgByte = new byte[1024 * 1024 * 4 + 1];
                    int length = sockClient.Receive(msgByte);
                    if (msgByte[0] == 0)
                    {
                        string msgStr = Encoding.UTF8.GetString(msgByte, 1, length - 1);
                        ShowMsg(msgStr);
                    }
                    else if (msgByte[0] == 1)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.InitialDirectory = @"D:\";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            using (FileStream fs = new FileStream(sfd.FileName, FileMode.Append, FileAccess.ReadWrite))
                            {
                                fs.Write(msgByte, 1, length - 1);
                            }
                            ShowMsg("保存完毕" + sfd.FileName);
                        }
                    }
                    else if (msgByte[0] == 2)
                    {
                        ShakeWindow();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErr("", ex);
            }
        }
        private void ShakeWindow()
        {
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            Random rand = new Random();
            Point oldLocation = this.Location;
            for (int i = 0; i < 50; ++i)
            {
                this.Location = new Point(oldLocation.X + rand.Next(-3, 3), oldLocation.Y + rand.Next(-3, 3));
                Thread.Sleep(20);
            }
            this.Location = oldLocation;
            this.TopMost = false;
        }
        #endregion

        #region 发送消息
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMsg(txtInput.Text.Trim());
            txtInput.Focus();
        }
        private void SendMsg(string msg)
        {
            byte[] msgByte = Encoding.UTF8.GetBytes(msg);
            if (sockClient != null)
            {
                sockClient.Send(msgByte, msgByte.Length, SocketFlags.None);
            }
        }
        #endregion

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            //退出程序并关闭所有线程
            Environment.Exit(0);
        }
    }
}