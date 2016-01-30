namespace MultiThread
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
            this.btnCount = new System.Windows.Forms.Button();
            this.btnCountThread = new System.Windows.Forms.Button();
            this.txtBoxCount = new System.Windows.Forms.TextBox();
            this.btnShowCount = new System.Windows.Forms.Button();
            this.btnShowCountSecurity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCount
            // 
            this.btnCount.Location = new System.Drawing.Point(220, 108);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(75, 23);
            this.btnCount.TabIndex = 0;
            this.btnCount.Text = "计数";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // btnCountThread
            // 
            this.btnCountThread.Location = new System.Drawing.Point(220, 151);
            this.btnCountThread.Name = "btnCountThread";
            this.btnCountThread.Size = new System.Drawing.Size(75, 23);
            this.btnCountThread.TabIndex = 1;
            this.btnCountThread.Text = "线程计数";
            this.btnCountThread.UseVisualStyleBackColor = true;
            this.btnCountThread.Click += new System.EventHandler(this.btnCountThread_Click);
            // 
            // txtBoxCount
            // 
            this.txtBoxCount.Location = new System.Drawing.Point(207, 64);
            this.txtBoxCount.Name = "txtBoxCount";
            this.txtBoxCount.Size = new System.Drawing.Size(100, 21);
            this.txtBoxCount.TabIndex = 2;
            // 
            // btnShowCount
            // 
            this.btnShowCount.Location = new System.Drawing.Point(220, 193);
            this.btnShowCount.Name = "btnShowCount";
            this.btnShowCount.Size = new System.Drawing.Size(75, 23);
            this.btnShowCount.TabIndex = 3;
            this.btnShowCount.Text = "显示计数";
            this.btnShowCount.UseVisualStyleBackColor = true;
            this.btnShowCount.Click += new System.EventHandler(this.btnShowCount_Click);
            // 
            // btnShowCountSecurity
            // 
            this.btnShowCountSecurity.AutoSize = true;
            this.btnShowCountSecurity.Location = new System.Drawing.Point(208, 239);
            this.btnShowCountSecurity.Name = "btnShowCountSecurity";
            this.btnShowCountSecurity.Size = new System.Drawing.Size(99, 23);
            this.btnShowCountSecurity.TabIndex = 4;
            this.btnShowCountSecurity.Text = "显示计数(安全)";
            this.btnShowCountSecurity.UseVisualStyleBackColor = true;
            this.btnShowCountSecurity.Click += new System.EventHandler(this.btnShowCountSecurity_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 295);
            this.Controls.Add(this.btnShowCountSecurity);
            this.Controls.Add(this.btnShowCount);
            this.Controls.Add(this.txtBoxCount);
            this.Controls.Add(this.btnCountThread);
            this.Controls.Add(this.btnCount);
            this.Name = "Form1";
            this.Text = "多线程";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button btnCountThread;
        private System.Windows.Forms.TextBox txtBoxCount;
        private System.Windows.Forms.Button btnShowCount;
        private System.Windows.Forms.Button btnShowCountSecurity;
    }
}

