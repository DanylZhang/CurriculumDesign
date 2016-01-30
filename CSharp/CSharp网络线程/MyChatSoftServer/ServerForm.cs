using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace MyChatSoftServer
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        //负责侦听端口
        private Socket sockWelcome = null;
        //负责和客户端的Socket通讯
        private Socket sockConnection = null;
        //负责侦听端口
        private Thread threadWatchPort = null;
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

        #region 监听端口并接收消息
        private void btnListen_Click(object sender, EventArgs e)
        {
            StartListening();
        }
        private void StartListening()
        {
            try
            {
                //IP地址
                IPAddress address = IPAddress.Parse(txtIPAddress.Text.Trim());
                //绑定端口
                IPEndPoint endpoint = new IPEndPoint(address, int.Parse(txtPort.Text.Trim()));
                //创建监听套接字(寻址协议，流方式，Tcp协议)
                sockWelcome = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //套接字绑定到端口
                sockWelcome.Bind(endpoint);
                //后备请求处理队列最大为10
                sockWelcome.Listen(10);
                txtShow.AppendText("开始监听……\n");
                threadWatchPort = new Thread(new ThreadStart(WatchPort));
                //设置为后台线程(当所有前台线程退出后自动关闭)
                threadWatchPort.IsBackground = true;
                threadWatchPort.Start();
            }
            catch (Exception ex)
            {
                ShowErr("", ex);
            }
        }
        private void WatchPort()
        {
            try
            {
                while (true)
                {
                    sockConnection = sockWelcome.Accept();
                    ShowMsg("监听" + sockConnection.RemoteEndPoint.ToString() + "到连接了……");
                    threadReceiveMsg = new Thread(new ThreadStart(ReceiveMsg));
                    threadReceiveMsg.IsBackground = true;
                    threadReceiveMsg.Start();
                }
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
                    byte[] msgByte = new byte[1024 * 1024 * 4];
                    int length = sockConnection.Receive(msgByte);
                    string msgStr = Encoding.UTF8.GetString(msgByte, 0, length);
                    ShowMsg(msgStr);
                }
            }
            catch (Exception ex)
            {
                ShowErr("", ex);
            }
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
            try
            {
                if (!File.Exists(msg))
                {
                    byte[] msgByte = Encoding.UTF8.GetBytes(msg);
                    byte[] msgByteFinal = new byte[msgByte.Length + 1];
                    msgByteFinal[0] = 0;//传输协议：消息0，文件1
                    Buffer.BlockCopy(msgByte, 0, msgByteFinal, 1, msgByte.Length);
                    if (sockConnection != null)
                    {
                        sockConnection.Send(msgByteFinal, msgByteFinal.Length, SocketFlags.None);
                    }
                }
                else
                {
                    using (FileStream fs = new FileStream(msg, FileMode.Open, FileAccess.Read))
                    {
                        byte[] byteData = new byte[1024 * 1024 * 4];
                        int length = 0;
                        while ((length = fs.Read(byteData, 0, byteData.Length)) > 0)
                        {
                            byte[] byteDataFinal = new byte[length + 1];
                            byteDataFinal[0] = 1;
                            Buffer.BlockCopy(byteData, 0, byteDataFinal, 1, length);
                            sockConnection.Send(byteDataFinal, byteDataFinal.Length, SocketFlags.None);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErr("", ex);
            }
        }
        #endregion
        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //强制退出所有线程
            Environment.Exit(0);
        }
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"D:\Documents\Visual Studio 2015\Projects\Html\Html";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = ofd.FileName;
            }
        }

        private void btnShakeWindow_Click(object sender, EventArgs e)
        {
            byte[] byteMsg = new byte[1];
            byteMsg[0] = 2;
            if (sockConnection != null)
            {
                sockConnection.Send(byteMsg);
            }
        }
    }
}