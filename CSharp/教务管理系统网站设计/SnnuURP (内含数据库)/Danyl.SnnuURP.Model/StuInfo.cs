using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// StuInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StuInfo
	{
		public StuInfo()
		{}

		#region Model
		private int _sid;
		private string _sname;
		private string _snamespell;
		private string _snameenglish;
		private string _snameold;
		private string _idnumber;
		private bool _sex;
		private string _stutype;
		private string _stunationality;
		private string _stuprovince;
		private DateTime? _stubirthday;
		private string _stupolitical;
		private int? _studept;
		private string _stuzipcode;
		private DateTime? _stuenrolldate;
		private int _stumajor;
		private int? _stugrade;
		private int _stuclassid;
		private int _planid;
		private string _district;

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
		public string SnameSpell
		{
			set{ _snamespell=value;}
			get{return _snamespell;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SnameEnglish
		{
			set{ _snameenglish=value;}
			get{return _snameenglish;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SnameOld
		{
			set{ _snameold=value;}
			get{return _snameold;}
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
		public bool Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string StuType
		{
			set{ _stutype=value;}
			get{return _stutype;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string StuNationality
		{
			set{ _stunationality=value;}
			get{return _stunationality;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string StuProvince
		{
			set{ _stuprovince=value;}
			get{return _stuprovince;}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime? StuBirthday
		{
			set{ _stubirthday=value;}
			get{return _stubirthday;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string StuPolitical
		{
			set{ _stupolitical=value;}
			get{return _stupolitical;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? StuDept
		{
			set{ _studept=value;}
			get{return _studept;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string StuZipCode
		{
			set{ _stuzipcode=value;}
			get{return _stuzipcode;}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime? StuEnrollDate
		{
			set{ _stuenrolldate=value;}
			get{return _stuenrolldate;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int StuMajor
		{
			set{ _stumajor=value;}
			get{return _stumajor;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? StuGrade
		{
			set{ _stugrade=value;}
			get{return _stugrade;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int StuClassId
		{
			set{ _stuclassid=value;}
			get{return _stuclassid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int PlanId
		{
			set{ _planid=value;}
			get{return _planid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string District
		{
			set{ _district=value;}
			get{return _district;}
		}
		#endregion Model
	}
}