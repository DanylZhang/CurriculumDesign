using System;

namespace Danyl.SnnuURP.Model
{
    /// <summary>
    /// TeacherWageAdjustmentView:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TeacherWageAdjustmentView
    {
        public TeacherWageAdjustmentView()
        {}

        #region Model
        private int _id;
        private int _tid;
        private string _tname;
        private bool _sex;
        private string _idnumber;
        private int? _teachertypeid;
        private string _degree;
        private string _deptname;
        private decimal? _newsalary;
        private decimal? _oldsalary;
        private decimal? _basicwage;
        private decimal? _jobsubsidies;
        private string _personalincometax;

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Tid
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tname
        {
            set { _tname = value; }
            get { return _tname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IdNumber
        {
            set { _idnumber = value; }
            get { return _idnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TeacherTypeId
        {
            set { _teachertypeid = value; }
            get { return _teachertypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Degree
        {
            set { _degree = value; }
            get { return _degree; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeptName
        {
            set { _deptname = value; }
            get { return _deptname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? NewSalary
        {
            set { _newsalary = value; }
            get { return _newsalary; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OldSalary
        {
            set { _oldsalary = value; }
            get { return _oldsalary; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BasicWage
        {
            set { _basicwage = value; }
            get { return _basicwage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? JobSubsidies
        {
            set { _jobsubsidies = value; }
            get { return _jobsubsidies; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PersonalIncomeTax
        {
            set { _personalincometax = value; }
            get { return _personalincometax; }
        }
        #endregion Model
    }
}