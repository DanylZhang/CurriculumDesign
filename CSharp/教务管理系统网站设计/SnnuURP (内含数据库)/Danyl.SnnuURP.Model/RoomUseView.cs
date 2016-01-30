using System;

namespace Danyl.SnnuURP.Model
{
    /// <summary>
    /// RoomUseView:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RoomUseView
    {
        public RoomUseView()
        {}

        #region Model
        private int _id;
        private string _uid;
        private string _uname;
        private string _userphone;
        private string _rname;
        private string _roomtype;
        private int? _capacity;
        private string _purpose;
        private DateTime? _usedate;
        private string _usestatus;
        private int _rid;
        private string _useremail;

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
        public string Uid
        {
            set { _uid = value; }
            get { return _uid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Uname
        {
            set { _uname = value; }
            get { return _uname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UserPhone
        {
            set { _userphone = value; }
            get { return _userphone; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Rname
        {
            set { _rname = value; }
            get { return _rname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string RoomType
        {
            set { _roomtype = value; }
            get { return _roomtype; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? Capacity
        {
            set { _capacity = value; }
            get { return _capacity; }
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
        public DateTime? UseDate
        {
            set { _usedate = value; }
            get { return _usedate; }
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
        public int Rid
        {
            set { _rid = value; }
            get { return _rid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UserEmail
        {
            set { _useremail = value; }
            get { return _useremail; }
        }
        #endregion Model
    }
}