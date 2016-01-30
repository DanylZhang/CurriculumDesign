using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// SelectedStudentView:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SelectedStudentView
	{
		public SelectedStudentView()
		{}

		#region Model
		private int _tid;
		private int _sid;
		private string _sname;
		private bool _sex;
		private string _majorname;
		private string _deptname;
		private DateTime? _years;
		private int? _semaster;

		/// <summary>
		/// 
		/// </summary>
		public int Tid
		{
			set{ _tid=value;}
			get{return _tid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Sname
		{
			set{ _sname=value;}
			get{return _sname;}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Sex
		{
			set{ _sex=value;}
			get{return _sex;}
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
		public string DeptName
		{
			set{ _deptname=value;}
			get{return _deptname;}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime? Years
		{
			set{ _years=value;}
			get{return _years;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? Semaster
		{
			set{ _semaster=value;}
			get{return _semaster;}
		}
		#endregion Model
	}
}