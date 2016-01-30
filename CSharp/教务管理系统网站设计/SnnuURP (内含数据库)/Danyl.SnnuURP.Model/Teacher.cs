using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class Teacher
	{
		public Teacher()
		{}

		#region Model
		private int _tid;
		private string _tname;
		private bool _sex;
		private string _idnumber;
		private int _deptid;
		private int _teachertypeid;
		private string _degree;

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
		public string Tname
		{
			set{ _tname=value;}
			get{return _tname;}
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
		public string IdNumber
		{
			set{ _idnumber=value;}
			get{return _idnumber;}
		}

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
		public int TeacherTypeId
		{
			set{ _teachertypeid=value;}
			get{return _teachertypeid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Degree
		{
			set{ _degree=value;}
			get{return _degree;}
		}
		#endregion Model
	}
}