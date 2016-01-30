using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// Depart:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Depart
	{
		public Depart()
		{}

		#region Model
		private int _deptid;
		private string _deptname;
		private string _mastername;
		private int _districtid;

		/// <summary>
		/// 
		/// </summary>
		public int DeptId
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string DeptName
		{
			set{ _deptname=value;}
			get{return _deptname;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string MasterName
		{
			set{ _mastername=value;}
			get{return _mastername;}
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