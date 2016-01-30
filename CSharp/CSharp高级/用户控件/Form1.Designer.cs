namespace 用户控件
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
            this.sanQiang1 = new 用户控件.SanQiang();
            this.btnShutdelegate = new System.Windows.Forms.Button();
            this.btnPretentDelegate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sanQiang1
            // 
            this.sanQiang1.Location = new System.Drawing.Point(55, 27);
            this.sanQiang1.Name = "sanQiang1";
            this.sanQiang1.Size = new System.Drawing.Size(154, 58);
            this.sanQiang1.TabIndex = 0;
            // 
            // btnShutdelegate
            // 
            this.btnShutdelegate.Location = new System.Drawing.Point(55, 91);
            this.btnShutdelegate.Name = "btnShutdelegate";
            this.btnShutdelegate.Size = new System.Drawing.Size(154, 58);
            this.btnShutdelegate.TabIndex = 1;
            this.btnShutdelegate.Text = "屏蔽委托";
            this.btnShutdelegate.UseVisualStyleBackColor = true;
            this.btnShutdelegate.Click += new System.EventHandler(this.btnShutdelegate_Click);
            // 
            // btnPretentDelegate
            // 
            this.btnPretentDelegate.Location = new System.Drawing.Point(55, 156);
            this.btnPretentDelegate.Name = "btnPretentDelegate";
            this.btnPretentDelegate.Size = new System.Drawing.Size(154, 58);
            this.btnPretentDelegate.TabIndex = 2;
            this.btnPretentDelegate.Text = "假冒事件发生";
            this.btnPretentDelegate.UseVisualStyleBackColor = true;
            this.btnPretentDelegate.Click += new System.EventHandler(this.btnPretentDelegate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnPretentDelegate);
            this.Controls.Add(this.btnShutdelegate);
            this.Controls.Add(this.sanQiang1);
            this.Name = "Form1";
            this.Text = "用户控件";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SanQiang sanQiang1;
        private System.Windows.Forms.Button btnShutdelegate;
        private System.Windows.Forms.Button btnPretentDelegate;
    }
}

