using System;

namespace Danyl.SnnuURP.Model
{
    /// <summary>
    /// UserPower
    /// </summary>
    [Serializable]
	public partial class UserPower
	{
		public UserPower()
		{}

		#region Model
		private int _usertype;
		private string _userpower1;
		private string _userpower2;

		/// <summary>
		/// 
		/// </summary>
		public int UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string UserPower1
		{
			set{ _userpower1=value;}
			get{return _userpower1;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string UserPower2
		{
			set{ _userpower2=value;}
			get{return _userpower2;}
		}
		#endregion Model
	}
}