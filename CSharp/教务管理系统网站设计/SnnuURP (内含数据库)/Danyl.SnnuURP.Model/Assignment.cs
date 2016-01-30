using System;

namespace Danyl.SnnuURP.Model
{
    /// <summary>
    /// Assignment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Assignment
    {
        public Assignment()
        { }

        #region Model
        private int _assignid;
        private int _tid;
        private int _cid;
        private DateTime? _releasetime;
        private DateTime? _deadline;
        private string _assigndetail;
        private int _accessory;

        /// <summary>
        /// 
        /// </summary>
        public int AssignId
        {
            set { _assignid = value; }
            get { return _assignid; }
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
        public int Cid
        {
            set { _cid = value; }
            get { return _cid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ReleaseTime
        {
            set { _releasetime = value; }
            get { return _releasetime; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Deadline
        {
            set { _deadline = value; }
            get { return _deadline; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string AssignDetail
        {
            set { _assigndetail = value; }
            get { return _assigndetail; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Accessory
        {
            set { _accessory = value; }
            get { return _accessory; }
        }
        #endregion Model
    }
}