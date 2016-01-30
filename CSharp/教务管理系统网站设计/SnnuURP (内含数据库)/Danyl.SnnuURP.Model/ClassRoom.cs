using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// ClassRoom:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ClassRoom
	{
		public ClassRoom()
		{}

		#region Model
		private int _rid;
		private string _rname;
		private int _buildid;
		private string _roomtype;
		private int? _capacity;
		/// <summary>
		/// 
		/// </summary>
		public int Rid
		{
			set{ _rid=value;}
			get{return _rid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Rname
		{
			set{ _rname=value;}
			get{return _rname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int BuildId
		{
			set{ _buildid=value;}
			get{return _buildid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoomType
		{
			set{ _roomtype=value;}
			get{return _roomtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Capacity
		{
			set{ _capacity=value;}
			get{return _capacity;}
		}
		#endregion Model
	}
}