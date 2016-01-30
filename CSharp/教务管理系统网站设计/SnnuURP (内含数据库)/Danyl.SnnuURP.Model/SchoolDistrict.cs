using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// SchoolDistrict:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SchoolDistrict
	{
		public SchoolDistrict()
		{}

		#region Model
		private int _districtid;
		private string _districtname;
		private string _address;

		/// <summary>
		/// 
		/// </summary>
		public int DistrictId
		{
			set{ _districtid=value;}
			get{return _districtid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string DistrictName
		{
			set{ _districtname=value;}
			get{return _districtname;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		#endregion Model
	}
}