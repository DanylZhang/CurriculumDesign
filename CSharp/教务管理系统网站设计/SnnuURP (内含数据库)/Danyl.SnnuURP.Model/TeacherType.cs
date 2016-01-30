using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class TeacherType
	{
		public TeacherType()
		{}

		#region Model
		private int _teatypeid;
		private string _teachertypes;
		private decimal? _hourssalary;

		/// <summary>
		/// 
		/// </summary>
		public int TeaTypeId
		{
			set{ _teatypeid=value;}
			get{return _teatypeid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string TeacherTypes
		{
			set{ _teachertypes=value;}
			get{return _teachertypes;}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal? HoursSalary
		{
			set{ _hourssalary=value;}
			get{return _hourssalary;}
		}
		#endregion Model
	}
}