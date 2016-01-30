using System;

namespace Danyl.SnnuURP.Model
{
	/// <summary>
	/// FileInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FileInfo
	{
		public FileInfo()
		{}

		#region Model
		private int _guid;
		private string _filename;
		private string _fileextension;
		private int? _uploader;
		private int? _downloadcount;
		private string _comment;
		private bool _isassignmentfile;

		/// <summary>
		/// 
		/// </summary>
		public int Guid
		{
			set{ _guid=value;}
			get{return _guid;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string FileExtension
		{
			set{ _fileextension=value;}
			get{return _fileextension;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? Uploader
		{
			set{ _uploader=value;}
			get{return _uploader;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int? DownloadCount
		{
			set{ _downloadcount=value;}
			get{return _downloadcount;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsAssignmentFile
		{
			set{ _isassignmentfile=value;}
			get{return _isassignmentfile;}
		}
		#endregion Model
	}
}