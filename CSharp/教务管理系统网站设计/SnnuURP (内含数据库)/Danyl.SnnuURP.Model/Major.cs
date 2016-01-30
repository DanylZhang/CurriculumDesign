using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// Major:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Major
	{
		public Major()
		{}

		#region Model
		private int _majorid;
		private string _majorname;
		private int _deptid;

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
		public string MajorName
		{
			set{ _majorname=value;}
			get{return _majorname;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int DeptId
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		#endregion Model
	}
}