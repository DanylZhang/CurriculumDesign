using System;

namespace Danyl.SnnuURP.Model
{
    /// <summary>
    /// WageInfo
    /// </summary>
    [Serializable]
	public partial class WageInfo
	{
		public WageInfo()
		{}

		#region Model
		private int _id;
		private int _tid;
		private string _tname;
		private string _month;
		private decimal? _basicwage;
		private decimal? _jobsubsidies;
		private string _personalincometax;
		private string _socialsecurity;
		private string _remark;

		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
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
		public string Tname
		{
			set{ _tname=value;}
			get{return _tname;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Month
		{
			set{ _month=value;}
			get{return _month;}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal? BasicWage
		{
			set{ _basicwage=value;}
			get{return _basicwage;}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal? JobSubsidies
		{
			set{ _jobsubsidies=value;}
			get{return _jobsubsidies;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string PersonalIncomeTax
		{
			set{ _personalincometax=value;}
			get{return _personalincometax;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SocialSecurity
		{
			set{ _socialsecurity=value;}
			get{return _socialsecurity;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model
	}
}