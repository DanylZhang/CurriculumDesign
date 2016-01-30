using System;

namespace Danyl.SnnuURP.Model
{
    /// <summary>
    /// WageAdjustment
    /// </summary>
    [Serializable]
	public partial class WageAdjustment
	{
		public WageAdjustment()
		{}

		#region Model
		private int _id;
		private int _tid;
		private decimal? _newsalary;
		private decimal? _oldsalary;
		private string _reason;
		private DateTime? _adjustdate;
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
		public decimal? NewSalary
		{
			set{ _newsalary=value;}
			get{return _newsalary;}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal? OldSalary
		{
			set{ _oldsalary=value;}
			get{return _oldsalary;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Reason
		{
			set{ _reason=value;}
			get{return _reason;}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime? AdjustDate
		{
			set{ _adjustdate=value;}
			get{return _adjustdate;}
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