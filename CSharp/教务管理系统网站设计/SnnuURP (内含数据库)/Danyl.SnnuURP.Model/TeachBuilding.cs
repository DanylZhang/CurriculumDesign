using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class TeachBuilding
	{
		public TeachBuilding()
		{}

		#region Model
		private int _buildid;
		private string _buildname;
		private int _districtid;

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
		public string BuildName
		{
			set{ _buildname=value;}
			get{return _buildname;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int DistrictId
		{
			set{ _districtid=value;}
			get{return _districtid;}
		}
		#endregion Model
	}
}