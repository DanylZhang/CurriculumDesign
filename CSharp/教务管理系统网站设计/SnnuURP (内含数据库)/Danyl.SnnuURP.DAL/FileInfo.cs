using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:FileInfo
	/// </summary>
	public partial class FileInfo
	{
		public FileInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Guid", "FileInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Guid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FileInfo");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.Int,4)			};
			parameters[0].Value = Guid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.FileInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FileInfo(");
			strSql.Append("Guid,FileName,FileExtension,Uploader,DownloadCount,Comment,IsAssignmentFile)");
			strSql.Append(" values (");
			strSql.Append("@Guid,@FileName,@FileExtension,@Uploader,@DownloadCount,@Comment,@IsAssignmentFile)");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.Int,4),
					new SqlParameter("@FileName", SqlDbType.VarChar,45),
					new SqlParameter("@FileExtension", SqlDbType.VarChar,45),
					new SqlParameter("@Uploader", SqlDbType.Int,4),
					new SqlParameter("@DownloadCount", SqlDbType.Int,4),
					new SqlParameter("@Comment", SqlDbType.VarChar,45),
					new SqlParameter("@IsAssignmentFile", SqlDbType.Bit,1)};
			parameters[0].Value = model.Guid;
			parameters[1].Value = model.FileName;
			parameters[2].Value = model.FileExtension;
			parameters[3].Value = model.Uploader;
			parameters[4].Value = model.DownloadCount;
			parameters[5].Value = model.Comment;
			parameters[6].Value = model.IsAssignmentFile;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Danyl.SnnuURP.Model.FileInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FileInfo set ");
			strSql.Append("FileName=@FileName,");
			strSql.Append("FileExtension=@FileExtension,");
			strSql.Append("Uploader=@Uploader,");
			strSql.Append("DownloadCount=@DownloadCount,");
			strSql.Append("Comment=@Comment,");
			strSql.Append("IsAssignmentFile=@IsAssignmentFile");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileName", SqlDbType.VarChar,45),
					new SqlParameter("@FileExtension", SqlDbType.VarChar,45),
					new SqlParameter("@Uploader", SqlDbType.Int,4),
					new SqlParameter("@DownloadCount", SqlDbType.Int,4),
					new SqlParameter("@Comment", SqlDbType.VarChar,45),
					new SqlParameter("@IsAssignmentFile", SqlDbType.Bit,1),
					new SqlParameter("@Guid", SqlDbType.Int,4)};
			parameters[0].Value = model.FileName;
			parameters[1].Value = model.FileExtension;
			parameters[2].Value = model.Uploader;
			parameters[3].Value = model.DownloadCount;
			parameters[4].Value = model.Comment;
			parameters[5].Value = model.IsAssignmentFile;
			parameters[6].Value = model.Guid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FileInfo ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.Int,4)			};
			parameters[0].Value = Guid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Guidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FileInfo ");
			strSql.Append(" where Guid in ("+Guidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Danyl.SnnuURP.Model.FileInfo GetModel(int Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Guid,FileName,FileExtension,Uploader,DownloadCount,Comment,IsAssignmentFile from FileInfo ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.Int,4)			};
			parameters[0].Value = Guid;

			Danyl.SnnuURP.Model.FileInfo model=new Danyl.SnnuURP.Model.FileInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Danyl.SnnuURP.Model.FileInfo DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.FileInfo model=new Danyl.SnnuURP.Model.FileInfo();
			if (row != null)
			{
				if(row["Guid"]!=null && row["Guid"].ToString()!="")
				{
					model.Guid=int.Parse(row["Guid"].ToString());
				}
				if(row["FileName"]!=null)
				{
					model.FileName=row["FileName"].ToString();
				}
				if(row["FileExtension"]!=null)
				{
					model.FileExtension=row["FileExtension"].ToString();
				}
				if(row["Uploader"]!=null && row["Uploader"].ToString()!="")
				{
					model.Uploader=int.Parse(row["Uploader"].ToString());
				}
				if(row["DownloadCount"]!=null && row["DownloadCount"].ToString()!="")
				{
					model.DownloadCount=int.Parse(row["DownloadCount"].ToString());
				}
				if(row["Comment"]!=null)
				{
					model.Comment=row["Comment"].ToString();
				}
				if(row["IsAssignmentFile"]!=null && row["IsAssignmentFile"].ToString()!="")
				{
					if((row["IsAssignmentFile"].ToString()=="1")||(row["IsAssignmentFile"].ToString().ToLower()=="true"))
					{
						model.IsAssignmentFile=true;
					}
					else
					{
						model.IsAssignmentFile=false;
					}
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Guid,FileName,FileExtension,Uploader,DownloadCount,Comment,IsAssignmentFile ");
			strSql.Append(" FROM FileInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Guid,FileName,FileExtension,Uploader,DownloadCount,Comment,IsAssignmentFile ");
			strSql.Append(" FROM FileInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM FileInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Guid desc");
			}
			strSql.Append(")AS Row, T.*  from FileInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "FileInfo";
			parameters[1].Value = "Guid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

