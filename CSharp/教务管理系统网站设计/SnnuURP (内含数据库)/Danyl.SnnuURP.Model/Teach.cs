using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class Teach
	{
		public Teach()
		{}

		#region Model
		private int _cid;
		private int _cno;
		private int _tid;
		private int? _courseremainder;
		private string _period;
		private string _week;
		private int? _section;
		private int? _sectioncount;
		private int? _districtid;
		private int? _buildid;
		private int _classroomid;

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
		public int Tid
		{
			set{ _tid=value;}
			get{return _tid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? CourseRemainder
		{
			set{ _courseremainder=value;}
			get{return _courseremainder;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Period
		{
			set{ _period=value;}
			get{return _period;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Week
		{
			set{ _week=value;}
			get{return _week;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? Section
		{
			set{ _section=value;}
			get{return _section;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? SectionCount
		{
			set{ _sectioncount=value;}
			get{return _sectioncount;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? DistrictId
		{
			set{ _districtid=value;}
			get{return _districtid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? BuildId
		{
			set{ _buildid=value;}
			get{return _buildid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int ClassRoomId
		{
			set{ _classroomid=value;}
			get{return _classroomid;}
		}
		#endregion Model
	}
}