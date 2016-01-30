namespace 透明窗体
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAutoOpacity = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnChangeShape = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlstripmenuEllipseShap = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstripmenuRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstripmenuChangeOpacity = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstripmenuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.timerToRight = new System.Windows.Forms.Timer(this.components);
            this.timerToLeft = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(35, 316);
            this.trackBar1.Maximum = 90;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(482, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickFrequency = 3;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "<<--减少透明度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "增加透明度-->>";
            // 
            // btnAutoOpacity
            // 
            this.btnAutoOpacity.Location = new System.Drawing.Point(239, 358);
            this.btnAutoOpacity.Name = "btnAutoOpacity";
            this.btnAutoOpacity.Size = new System.Drawing.Size(75, 23);
            this.btnAutoOpacity.TabIndex = 4;
            this.btnAutoOpacity.Text = "自动";
            this.btnAutoOpacity.UseVisualStyleBackColor = true;
            this.btnAutoOpacity.Click += new System.EventHandler(this.btnAutoOpacity_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(314, 358);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnChangeShape
            // 
            this.btnChangeShape.Location = new System.Drawing.Point(164, 358);
            this.btnChangeShape.Name = "btnChangeShape";
            this.btnChangeShape.Size = new System.Drawing.Size(75, 23);
            this.btnChangeShape.TabIndex = 6;
            this.btnChangeShape.Text = "环形/方形";
            this.btnChangeShape.UseVisualStyleBackColor = true;
            this.btnChangeShape.Click += new System.EventHandler(this.btnChangeShape_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::透明窗体.Properties.Resources._1;
            this.pictureBox1.Location = new System.Drawing.Point(35, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(482, 301);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "我的系统托盘";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstripmenuEllipseShap,
            this.tlstripmenuRectangle,
            this.tlstripmenuChangeOpacity,
            this.tlstripmenuQuit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            // 
            // tlstripmenuEllipseShap
            // 
            this.tlstripmenuEllipseShap.Name = "tlstripmenuEllipseShap";
            this.tlstripmenuEllipseShap.Size = new System.Drawing.Size(124, 22);
            this.tlstripmenuEllipseShap.Text = "环形";
            this.tlstripmenuEllipseShap.Click += new System.EventHandler(this.tlstripmenuEllipseShap_Click);
            // 
            // tlstripmenuRectangle
            // 
            this.tlstripmenuRectangle.Name = "tlstripmenuRectangle";
            this.tlstripmenuRectangle.Size = new System.Drawing.Size(124, 22);
            this.tlstripmenuRectangle.Text = "方形";
            this.tlstripmenuRectangle.Click += new System.EventHandler(this.tlstripmenuRectangle_Click);
            // 
            // tlstripmenuChangeOpacity
            // 
            this.tlstripmenuChangeOpacity.Name = "tlstripmenuChangeOpacity";
            this.tlstripmenuChangeOpacity.Size = new System.Drawing.Size(124, 22);
            this.tlstripmenuChangeOpacity.Text = "自动渐变";
            this.tlstripmenuChangeOpacity.Click += new System.EventHandler(this.tlstripmenuChangeOpacity_Click);
            // 
            // tlstripmenuQuit
            // 
            this.tlstripmenuQuit.Name = "tlstripmenuQuit";
            this.tlstripmenuQuit.Size = new System.Drawing.Size(124, 22);
            this.tlstripmenuQuit.Text = "退出";
            this.tlstripmenuQuit.Click += new System.EventHandler(this.tlstripmenuQuit_Click);
            // 
            // timerToRight
            // 
            this.timerToRight.Enabled = true;
            this.timerToRight.Interval = 10;
            this.timerToRight.Tick += new System.EventHandler(this.timerToRight_Tick);
            // 
            // timerToLeft
            // 
            this.timerToLeft.Interval = 10;
            this.timerToLeft.Tick += new System.EventHandler(this.timerToLeft_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 390);
            this.Controls.Add(this.btnChangeShape);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnAutoOpacity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "透明窗体";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAutoOpacity;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnChangeShape;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tlstripmenuEllipseShap;
        private System.Windows.Forms.ToolStripMenuItem tlstripmenuRectangle;
        private System.Windows.Forms.ToolStripMenuItem tlstripmenuChangeOpacity;
        private System.Windows.Forms.ToolStripMenuItem tlstripmenuQuit;
        private System.Windows.Forms.Timer timerToRight;
        private System.Windows.Forms.Timer timerToLeft;
    }
}

