using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// Course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Course
	{
		public Course()
		{}

		#region Model
		private int _cid;
		private string _cname;
		private string _cnameenglish;
		private int _deptid;
		private DateTime? _years;
		private int? _semaster;
		private string _courseattribute;
		private int _coursecategory;
		private decimal? _credit;
		private string _textbook;
		private int? _hours;
		private int? _weekhours;

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
		public string Cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string CnameEnglish
		{
			set{ _cnameenglish=value;}
			get{return _cnameenglish;}
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
		public string CourseAttribute
		{
			set{ _courseattribute=value;}
			get{return _courseattribute;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int CourseCategory
		{
			set{ _coursecategory=value;}
			get{return _coursecategory;}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal? Credit
		{
			set{ _credit=value;}
			get{return _credit;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string TextBook
		{
			set{ _textbook=value;}
			get{return _textbook;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? Hours
		{
			set{ _hours=value;}
			get{return _hours;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? WeekHours
		{
			set{ _weekhours=value;}
			get{return _weekhours;}
		}
		#endregion Model
	}
}