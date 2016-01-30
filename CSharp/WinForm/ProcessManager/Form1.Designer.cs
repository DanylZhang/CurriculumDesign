namespace ProcessManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.线程数 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CPU时间 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.内存使用 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemCreateProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemKillProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.名称,
            this.ID,
            this.线程数,
            this.CPU时间,
            this.内存使用});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 25);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(337, 279);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // 名称
            // 
            this.名称.Text = "名称";
            this.名称.Width = 80;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // 线程数
            // 
            this.线程数.Text = "线程数";
            // 
            // CPU时间
            // 
            this.CPU时间.Text = "CPU时间";
            this.CPU时间.Width = 61;
            // 
            // 内存使用
            // 
            this.内存使用.Text = "内存使用";
            this.内存使用.Width = 77;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCreateProcess,
            this.menuItemKillProcess,
            this.刷新列表ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(337, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItemCreateProcess
            // 
            this.menuItemCreateProcess.Name = "menuItemCreateProcess";
            this.menuItemCreateProcess.Size = new System.Drawing.Size(68, 21);
            this.menuItemCreateProcess.Text = "创建进程";
            this.menuItemCreateProcess.Click += new System.EventHandler(this.menuItemCreateProcess_Click);
            // 
            // menuItemKillProcess
            // 
            this.menuItemKillProcess.Name = "menuItemKillProcess";
            this.menuItemKillProcess.Size = new System.Drawing.Size(68, 21);
            this.menuItemKillProcess.Text = "结束进程";
            this.menuItemKillProcess.Click += new System.EventHandler(this.menuItemKillProcess_Click);
            // 
            // 刷新列表ToolStripMenuItem
            // 
            this.刷新列表ToolStripMenuItem.Name = "刷新列表ToolStripMenuItem";
            this.刷新列表ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.刷新列表ToolStripMenuItem.Text = "刷新列表";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 304);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "进程管理器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 名称;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader 线程数;
        private System.Windows.Forms.ColumnHeader CPU时间;
        private System.Windows.Forms.ColumnHeader 内存使用;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemCreateProcess;
        private System.Windows.Forms.ToolStripMenuItem menuItemKillProcess;
        private System.Windows.Forms.ToolStripMenuItem 刷新列表ToolStripMenuItem;
    }
}

