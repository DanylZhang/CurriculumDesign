using System;

namespace Danyl.SnnuURP.Model
{
    /// <summary>
    /// RoomUse:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RoomUse
    {
        public RoomUse()
        {}

        #region Model
        private int _id;
        private int _rid;
        private int? _uid;
        private DateTime? _usedate;
        private string _purpose;
        private string _usestatus;
        private string _roomusecol;

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
        public int Rid
        {
            set { _rid = value; }
            get { return _rid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? Uid
        {
            set { _uid = value; }
            get { return _uid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? UseDate
        {
            set { _usedate = value; }
            get { return _usedate; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Purpose
        {
            set { _purpose = value; }
            get { return _purpose; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UseStatus
        {
            set { _usestatus = value; }
            get { return _usestatus; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string RoomUsecol
        {
            set { _roomusecol = value; }
            get { return _roomusecol; }
        }
        #endregion Model
    }
}