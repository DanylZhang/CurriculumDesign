using System;
using System.Windows.Forms;

namespace 陕西师范大学铃声小贴士
{
    public partial class SNNUScheduleReport : Form
    {
        public SNNUScheduleReport()
        {
            InitializeComponent();
        }

        private void SNNUScheduleReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'SNNURingTipDataSet.SNNUSchedule' table. You can move, or remove it, as needed.
            this.SNNUScheduleTableAdapter.Fill(this.SNNURingTipDataSet.SNNUSchedule);

            this.reportViewer1.RefreshReport();
        }
    }
}