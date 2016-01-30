using System;
using System.Windows;
using 陕西师范大学铃声小贴士.BLL;
using 陕西师范大学铃声小贴士.Model;

namespace 陕西师范大学铃声小贴士
{
    /// <summary>
    /// Interaction logic for UpdateScheduleWindow.xaml
    /// </summary>
    public partial class UpdateScheduleWindow : Window
    {
        public UpdateScheduleWindow()
        {
            InitializeComponent();
        }

        private void btnSaveSchedule_Click(object sender, RoutedEventArgs e)
        {
            SNNUSchedule model = new SNNUSchedule();
            model.Id = 1;
            model.BeginTime1 = timePkBeginTime1.Value;
            model.BeginTime2 = timePkBeginTime2.Value;
            model.BeginTime3 = timePkBeginTime3.Value;
            model.BeginTime4 = timePkBeginTime4.Value;
            model.BeginTime5 = timePkBeginTime5.Value;
            model.BeginTime6 = timePkBeginTime6.Value;
            model.BeginTime7 = timePkBeginTime7.Value;
            model.BeginTime8 = timePkBeginTime8.Value;
            model.BeginTime9 = timePkBeginTime9.Value;
            model.BeginTime10 = timePkBeginTime10.Value;
            model.EndTime1 = timePkEndTime1.Value;
            model.EndTime2 = timePkEndTime2.Value;
            model.EndTime3 = timePkEndTime3.Value;
            model.EndTime5 = timePkEndTime5.Value;
            model.EndTime6 = timePkEndTime6.Value;
            model.EndTime7 = timePkEndTime7.Value;
            model.EndTime9 = timePkEndTime9.Value;
            model.CloseTime1 = timePkCloseTime1.Value;
            model.CloseTime2 = timePkCloseTime2.Value;
            model.CloseTime3 = timePkCloseTime3.Value;
            try
            {
                new SNNUScheduleBLL().Update(model);
                if (MessageBox.Show("时间表更新成功！\n是否关闭更改窗口？", "提醒", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}