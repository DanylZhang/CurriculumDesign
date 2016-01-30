using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// CourseCategory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CourseCategory
	{
		public CourseCategory()
		{}

		#region Model
		private int _cousecateid;
		private string _category;

		/// <summary>
		/// 
		/// </summary>
		public int CouseCateId
		{
			set{ _cousecateid=value;}
			get{return _cousecateid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Category
		{
			set{ _category=value;}
			get{return _category;}
		}
		#endregion Model
	}
}