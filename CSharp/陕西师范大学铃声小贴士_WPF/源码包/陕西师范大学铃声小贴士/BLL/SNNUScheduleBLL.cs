using System;
using System.Collections.Generic;
using 陕西师范大学铃声小贴士.Model;
using 陕西师范大学铃声小贴士.DAL;

namespace 陕西师范大学铃声小贴士.BLL
{
    partial class SNNUScheduleBLL
    {
        public int AddNew(SNNUSchedule model)
        {
            return new SNNUScheduleDAL().AddNew(model);
        }
        public bool Delete(int id)
        {
            return new SNNUScheduleDAL().Delete(id);
        }
        public bool Update(SNNUSchedule model)
        {
            return new SNNUScheduleDAL().Update(model);
        }
        public SNNUSchedule Get(int id)
        {
            return new SNNUScheduleDAL().Get(id);
        }
        public IEnumerable<SNNUSchedule> ListAll()
        {
            return new SNNUScheduleDAL().ListAll();
        }
    }
}