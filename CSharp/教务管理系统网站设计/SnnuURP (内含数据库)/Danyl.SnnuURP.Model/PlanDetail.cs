using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// PlanDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PlanDetail
	{
		public PlanDetail()
		{}

		#region Model
		private int _planid;
		private int _cid;

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
		public int Cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		#endregion Model
	}
}