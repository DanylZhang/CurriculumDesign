using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// AssignmentSubmit:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AssignmentSubmit
	{
		public AssignmentSubmit()
		{}

		#region Model
		private int _id;
		private int _sid;
		private int _assignmentid;
		private string _detail;
		private int _accessory;

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
		public int Sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int AssignmentId
		{
			set{ _assignmentid=value;}
			get{return _assignmentid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Detail
		{
			set{ _detail=value;}
			get{return _detail;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Accessory
		{
			set{ _accessory=value;}
			get{return _accessory;}
		}
		#endregion Model
	}
}