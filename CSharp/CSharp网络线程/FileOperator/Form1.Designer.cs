namespace FileOperator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBoxReadFileContent = new System.Windows.Forms.TextBox();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.btnChooseOpenFile = new System.Windows.Forms.Button();
            this.txtBoxReadFilePath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBoxWriteFileContent = new System.Windows.Forms.TextBox();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnChooseSaveFile = new System.Windows.Forms.Button();
            this.txtBoxSaveFilePath = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBoxReadFileContent);
            this.groupBox1.Controls.Add(this.btnReadFile);
            this.groupBox1.Controls.Add(this.btnChooseOpenFile);
            this.groupBox1.Controls.Add(this.txtBoxReadFilePath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 243);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "读文件操作";
            // 
            // txtBoxReadFileContent
            // 
            this.txtBoxReadFileContent.Location = new System.Drawing.Point(6, 48);
            this.txtBoxReadFileContent.Multiline = true;
            this.txtBoxReadFileContent.Name = "txtBoxReadFileContent";
            this.txtBoxReadFileContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxReadFileContent.Size = new System.Drawing.Size(664, 189);
            this.txtBoxReadFileContent.TabIndex = 3;
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(588, 21);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(75, 23);
            this.btnReadFile.TabIndex = 2;
            this.btnReadFile.Text = "读取文件";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // btnChooseOpenFile
            // 
            this.btnChooseOpenFile.Location = new System.Drawing.Point(507, 21);
            this.btnChooseOpenFile.Name = "btnChooseOpenFile";
            this.btnChooseOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnChooseOpenFile.TabIndex = 1;
            this.btnChooseOpenFile.Text = "选择文件";
            this.btnChooseOpenFile.UseVisualStyleBackColor = true;
            this.btnChooseOpenFile.Click += new System.EventHandler(this.btnChooseOpenFile_Click);
            // 
            // txtBoxReadFilePath
            // 
            this.txtBoxReadFilePath.BackColor = System.Drawing.Color.White;
            this.txtBoxReadFilePath.Location = new System.Drawing.Point(7, 21);
            this.txtBoxReadFilePath.Name = "txtBoxReadFilePath";
            this.txtBoxReadFilePath.ReadOnly = true;
            this.txtBoxReadFilePath.Size = new System.Drawing.Size(494, 21);
            this.txtBoxReadFilePath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBoxWriteFileContent);
            this.groupBox2.Controls.Add(this.btnSaveFile);
            this.groupBox2.Controls.Add(this.btnChooseSaveFile);
            this.groupBox2.Controls.Add(this.txtBoxSaveFilePath);
            this.groupBox2.Location = new System.Drawing.Point(12, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(676, 243);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "写文件操作";
            // 
            // txtBoxWriteFileContent
            // 
            this.txtBoxWriteFileContent.Location = new System.Drawing.Point(6, 47);
            this.txtBoxWriteFileContent.Multiline = true;
            this.txtBoxWriteFileContent.Name = "txtBoxWriteFileContent";
            this.txtBoxWriteFileContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxWriteFileContent.Size = new System.Drawing.Size(664, 189);
            this.txtBoxWriteFileContent.TabIndex = 4;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(588, 20);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFile.TabIndex = 3;
            this.btnSaveFile.Text = "保存文件";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnChooseSaveFile
            // 
            this.btnChooseSaveFile.Location = new System.Drawing.Point(507, 20);
            this.btnChooseSaveFile.Name = "btnChooseSaveFile";
            this.btnChooseSaveFile.Size = new System.Drawing.Size(75, 23);
            this.btnChooseSaveFile.TabIndex = 2;
            this.btnChooseSaveFile.Text = "选择文件";
            this.btnChooseSaveFile.UseVisualStyleBackColor = true;
            this.btnChooseSaveFile.Click += new System.EventHandler(this.btnChooseSaveFile_Click);
            // 
            // txtBoxSaveFilePath
            // 
            this.txtBoxSaveFilePath.Location = new System.Drawing.Point(6, 20);
            this.txtBoxSaveFilePath.Name = "txtBoxSaveFilePath";
            this.txtBoxSaveFilePath.Size = new System.Drawing.Size(494, 21);
            this.txtBoxSaveFilePath.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 513);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "文件流操作";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBoxReadFileContent;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.Button btnChooseOpenFile;
        private System.Windows.Forms.TextBox txtBoxReadFilePath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBoxWriteFileContent;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnChooseSaveFile;
        private System.Windows.Forms.TextBox txtBoxSaveFilePath;
    }
}

