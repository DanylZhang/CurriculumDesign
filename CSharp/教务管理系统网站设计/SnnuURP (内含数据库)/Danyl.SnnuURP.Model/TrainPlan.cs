using System;

namespace Danyl.SnnuURP.Model
{
    /// <summary>
    /// 1
    /// </summary>
    [Serializable]
    public partial class TrainPlan
    {
        public TrainPlan()
        {}

        #region Model
        private int _planid;
        private string _planname;
        private string _grade;
        private int _majorid;
        private int? _coursecount;
        private decimal? _coursecredit;
        private decimal? _coursehours;
        private string _remark;

        /// <summary>
        /// 
        /// </summary>
        public int PlanId
        {
            set { _planid = value; }
            get { return _planid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PlanName
        {
            set { _planname = value; }
            get { return _planname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MajorId
        {
            set { _majorid = value; }
            get { return _majorid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? CourseCount
        {
            set { _coursecount = value; }
            get { return _coursecount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal? CourseCredit
        {
            set { _coursecredit = value; }
            get { return _coursecredit; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal? CourseHours
        {
            set { _coursehours = value; }
            get { return _coursehours; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model
    }
}