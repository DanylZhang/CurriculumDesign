namespace 陕西师范大学铃声小贴士
{
    partial class SNNUScheduleReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SNNUScheduleReport));
            this.SNNUScheduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SNNURingTipDataSet = new 陕西师范大学铃声小贴士.SNNURingTipDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SNNUScheduleTableAdapter = new 陕西师范大学铃声小贴士.SNNURingTipDataSetTableAdapters.SNNUScheduleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SNNUScheduleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SNNURingTipDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // SNNUScheduleBindingSource
            // 
            this.SNNUScheduleBindingSource.DataMember = "SNNUSchedule";
            this.SNNUScheduleBindingSource.DataSource = this.SNNURingTipDataSet;
            // 
            // SNNURingTipDataSet
            // 
            this.SNNURingTipDataSet.DataSetName = "SNNURingTipDataSet";
            this.SNNURingTipDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SNNUScheduleDataSet";
            reportDataSource1.Value = this.SNNUScheduleBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "陕西师范大学铃声小贴士.SNNUScheduleReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(635, 378);
            this.reportViewer1.TabIndex = 0;
            // 
            // SNNUScheduleTableAdapter
            // 
            this.SNNUScheduleTableAdapter.ClearBeforeFill = true;
            // 
            // SNNUScheduleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 378);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SNNUScheduleReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "陕西师范大学课堂时间表";
            this.Load += new System.EventHandler(this.SNNUScheduleReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SNNUScheduleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SNNURingTipDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SNNUScheduleBindingSource;
        private SNNURingTipDataSet SNNURingTipDataSet;
        private SNNURingTipDataSetTableAdapters.SNNUScheduleTableAdapter SNNUScheduleTableAdapter;
    }
}