namespace 鼠标绘画
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.选择画笔颜色CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBarPenWidth = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoBtnTrack = new System.Windows.Forms.RadioButton();
            this.rdoBtnRadial = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPenWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择画笔颜色CToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(727, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 选择画笔颜色CToolStripMenuItem
            // 
            this.选择画笔颜色CToolStripMenuItem.Name = "选择画笔颜色CToolStripMenuItem";
            this.选择画笔颜色CToolStripMenuItem.Size = new System.Drawing.Size(108, 21);
            this.选择画笔颜色CToolStripMenuItem.Text = "选择画笔颜色(&C)";
            this.选择画笔颜色CToolStripMenuItem.Click += new System.EventHandler(this.选择画笔颜色CToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(100, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 403);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // trackBarPenWidth
            // 
            this.trackBarPenWidth.Location = new System.Drawing.Point(2, 68);
            this.trackBarPenWidth.Maximum = 100;
            this.trackBarPenWidth.Name = "trackBarPenWidth";
            this.trackBarPenWidth.Size = new System.Drawing.Size(94, 45);
            this.trackBarPenWidth.TabIndex = 2;
            this.trackBarPenWidth.Value = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "画笔大小";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoBtnTrack);
            this.groupBox1.Controls.Add(this.rdoBtnRadial);
            this.groupBox1.Location = new System.Drawing.Point(2, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 68);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "画笔类型";
            // 
            // rdoBtnTrack
            // 
            this.rdoBtnTrack.AutoSize = true;
            this.rdoBtnTrack.Checked = true;
            this.rdoBtnTrack.Location = new System.Drawing.Point(24, 37);
            this.rdoBtnTrack.Name = "rdoBtnTrack";
            this.rdoBtnTrack.Size = new System.Drawing.Size(47, 16);
            this.rdoBtnTrack.TabIndex = 1;
            this.rdoBtnTrack.TabStop = true;
            this.rdoBtnTrack.Text = "轨迹";
            this.rdoBtnTrack.UseVisualStyleBackColor = true;
            // 
            // rdoBtnRadial
            // 
            this.rdoBtnRadial.AutoSize = true;
            this.rdoBtnRadial.Location = new System.Drawing.Point(24, 16);
            this.rdoBtnRadial.Name = "rdoBtnRadial";
            this.rdoBtnRadial.Size = new System.Drawing.Size(47, 16);
            this.rdoBtnRadial.TabIndex = 0;
            this.rdoBtnRadial.Text = "射线";
            this.rdoBtnRadial.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 428);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarPenWidth);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "鼠标绘画";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPenWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选择画笔颜色CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBarPenWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoBtnTrack;
        private System.Windows.Forms.RadioButton rdoBtnRadial;
    }
}

