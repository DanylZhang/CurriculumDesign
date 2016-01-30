namespace 用户控件2
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
            this.sanQiangButton1 = new 用户控件2.SanQiangButton();
            this.SuspendLayout();
            // 
            // sanQiangButton1
            // 
            this.sanQiangButton1.Location = new System.Drawing.Point(65, 103);
            this.sanQiangButton1.Name = "sanQiangButton1";
            this.sanQiangButton1.Size = new System.Drawing.Size(154, 54);
            this.sanQiangButton1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.sanQiangButton1);
            this.Name = "Form1";
            this.Text = "用户控件2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SanQiangButton sanQiangButton1;
    }
}

