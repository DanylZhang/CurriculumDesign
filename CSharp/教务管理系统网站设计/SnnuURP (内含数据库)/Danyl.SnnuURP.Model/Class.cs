using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// Class:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Class
	{
		public Class()
		{}

		#region Model
		private int _classid;
		private string _classname;
		private int _majorid;
		private string _grade;
		private int? _stucount;
		private int _districtid;

		/// <summary>
		/// 
		/// </summary>
		public int ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string ClassName
		{
			set{ _classname=value;}
			get{return _classname;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int MajorId
		{
			set{ _majorid=value;}
			get{return _majorid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Grade
		{
			set{ _grade=value;}
			get{return _grade;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? StuCount
		{
			set{ _stucount=value;}
			get{return _stucount;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int DistrictId
		{
			set{ _districtid=value;}
			get{return _districtid;}
		}
		#endregion Model
	}
}