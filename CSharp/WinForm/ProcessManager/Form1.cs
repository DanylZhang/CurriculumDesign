using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ListAllProcesss()
        {
            string processName;
            int processID;
            int threadsNumber;
            TimeSpan cpuTime;
            string aaa = "00";
            int processMemory;
            //清除列表视图中原有的内容
            listView1.Items.Clear();
            Process[] processes = Process.GetProcesses();
            for (int i = 0; i < processes.Length; ++i)
            {
                processName = processes[i].ProcessName;
                processID = processes[i].Id;
                threadsNumber = processes[i].Threads.Count;
                processMemory = processes[i].WorkingSet;
                string[] subitems = { processName, processID.ToString(), threadsNumber.ToString(), aaa, string.Format("{0:#,#,#}K", processMemory / 1024) };
                listView1.Items.Insert(i, new ListViewItem(subitems));
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ListAllProcesss();
        }

        private void menuItemCreateProcess_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDlg = new OpenFileDialog();
            ofDlg.Filter = "可执行文件|*.exe";
            if (ofDlg.ShowDialog() == DialogResult.OK)
            {
                Process newProcess = new Process();
                try
                {
                    newProcess.StartInfo.UseShellExecute = false;
                    newProcess.StartInfo.FileName = ofDlg.FileName;
                    newProcess.StartInfo.CreateNoWindow = true;
                    newProcess.Start();
                    if (newProcess != null)
                    {
                        newProcess.EnableRaisingEvents = true;
                        newProcess.Exited += new EventHandler(OnProcessExited);
                        newProcess.WaitForExit();
                    }
                    ListAllProcesss();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void OnProcessExited(object sender, EventArgs e)
        {
            ListAllProcesss();
        }
        private void menuItemKillProcess_Click(object sender, EventArgs e)
        {

        }
    }
}