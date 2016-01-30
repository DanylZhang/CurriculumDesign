using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// CourseSelect:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CourseSelect
	{
		public CourseSelect()
		{}

		#region Model
		private int _sid;
		private int _cid;
		private int _cno;
		private string _selectstatus;
		private int? _usualscore;
		private int? _midtermscore;
		private int? _finalexamscore;
		private int? _totalscore;

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
		public int Cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Cno
		{
			set{ _cno=value;}
			get{return _cno;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SelectStatus
		{
			set{ _selectstatus=value;}
			get{return _selectstatus;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? UsualScore
		{
			set{ _usualscore=value;}
			get{return _usualscore;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? MidtermScore
		{
			set{ _midtermscore=value;}
			get{return _midtermscore;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? FinalExamScore
		{
			set{ _finalexamscore=value;}
			get{return _finalexamscore;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? TotalScore
		{
			set{ _totalscore=value;}
			get{return _totalscore;}
		}
		#endregion Model
	}
}