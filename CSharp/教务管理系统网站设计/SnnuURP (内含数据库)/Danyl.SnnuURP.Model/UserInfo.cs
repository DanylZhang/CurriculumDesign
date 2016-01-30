using System;

namespace Danyl.SnnuURP.Model
{
    /// <summary>
    /// UserInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class UserInfo
    {
        public UserInfo()
        {}

        #region Model
        private int _uid;
        private string _uname;
        private string _pwd;
        private int? _usertype;
        private string _userphone;
        private string _useremail;

        /// <summary>
        /// 
        /// </summary>
        public int Uid
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
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
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
        public string UserEmail
        {
            set { _useremail = value; }
            get { return _useremail; }
        }
        #endregion Model
    }
}