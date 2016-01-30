using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// TeacherScoreView:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TeacherScoreView
	{
		public TeacherScoreView()
		{}

		#region Model
		private int _sid;
		private int _tid;
		private string _cname;
		private string _sname;
		private DateTime? _years;
		private int? _semaster;
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
		public int Tid
		{
			set{ _tid=value;}
			get{return _tid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Cname
		{
			set{ _cname=value;}
			get{return _cname;}
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