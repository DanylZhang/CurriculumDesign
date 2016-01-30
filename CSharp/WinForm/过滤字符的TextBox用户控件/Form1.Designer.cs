namespace 过滤字符的TextBox用户控件
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFilterByRegex1 = new 过滤字符的TextBox用户控件.TextBoxFilterByRegex();
            this.textBoxFilterByKeyPress1 = new 过滤字符的TextBox用户控件.TextBoxFilterByKeyPress();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "正则表达式过滤控件：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "KeyPress过滤：";
            // 
            // textBoxFilterByRegex1
            // 
            this.textBoxFilterByRegex1.Location = new System.Drawing.Point(160, 36);
            this.textBoxFilterByRegex1.Name = "textBoxFilterByRegex1";
            this.textBoxFilterByRegex1.Size = new System.Drawing.Size(106, 22);
            this.textBoxFilterByRegex1.TabIndex = 2;
            // 
            // textBoxFilterByKeyPress1
            // 
            this.textBoxFilterByKeyPress1.Location = new System.Drawing.Point(161, 84);
            this.textBoxFilterByKeyPress1.Name = "textBoxFilterByKeyPress1";
            this.textBoxFilterByKeyPress1.Size = new System.Drawing.Size(105, 21);
            this.textBoxFilterByKeyPress1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "41212205 ZhangDanyu";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 209);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFilterByKeyPress1);
            this.Controls.Add(this.textBoxFilterByRegex1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "过滤字符的TextBox用户控件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private TextBoxFilterByRegex textBoxFilterByRegex1;
        private TextBoxFilterByKeyPress textBoxFilterByKeyPress1;
        private System.Windows.Forms.Label label3;
    }
}

