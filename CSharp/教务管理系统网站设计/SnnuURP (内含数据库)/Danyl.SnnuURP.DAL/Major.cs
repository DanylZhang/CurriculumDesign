using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:Major
	/// </summary>
	public partial class Major
	{
		public Major()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MajorId", "Major"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MajorId,int DeptId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Major");
			strSql.Append(" where MajorId=@MajorId and DeptId=@DeptId ");
			SqlParameter[] parameters = {
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@DeptId", SqlDbType.Int,4)			};
			parameters[0].Value = MajorId;
			parameters[1].Value = DeptId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.Major model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Major(");
			strSql.Append("MajorId,MajorName,DeptId)");
			strSql.Append(" values (");
			strSql.Append("@MajorId,@MajorName,@DeptId)");
			SqlParameter[] parameters = {
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@MajorName", SqlDbType.NVarChar,30),
					new SqlParameter("@DeptId", SqlDbType.Int,4)};
			parameters[0].Value = model.MajorId;
			parameters[1].Value = model.MajorName;
			parameters[2].Value = model.DeptId;

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
		public bool Update(Danyl.SnnuURP.Model.Major model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Major set ");
			strSql.Append("MajorName=@MajorName");
			strSql.Append(" where MajorId=@MajorId and DeptId=@DeptId ");
			SqlParameter[] parameters = {
					new SqlParameter("@MajorName", SqlDbType.NVarChar,30),
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@DeptId", SqlDbType.Int,4)};
			parameters[0].Value = model.MajorName;
			parameters[1].Value = model.MajorId;
			parameters[2].Value = model.DeptId;

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
		public bool Delete(int MajorId,int DeptId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Major ");
			strSql.Append(" where MajorId=@MajorId and DeptId=@DeptId ");
			SqlParameter[] parameters = {
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@DeptId", SqlDbType.Int,4)			};
			parameters[0].Value = MajorId;
			parameters[1].Value = DeptId;

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
		/// 得到一个对象实体
		/// </summary>
		public Danyl.SnnuURP.Model.Major GetModel(int MajorId,int DeptId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MajorId,MajorName,DeptId from Major ");
			strSql.Append(" where MajorId=@MajorId and DeptId=@DeptId ");
			SqlParameter[] parameters = {
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@DeptId", SqlDbType.Int,4)			};
			parameters[0].Value = MajorId;
			parameters[1].Value = DeptId;

			Danyl.SnnuURP.Model.Major model=new Danyl.SnnuURP.Model.Major();
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
		public Danyl.SnnuURP.Model.Major DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.Major model=new Danyl.SnnuURP.Model.Major();
			if (row != null)
			{
				if(row["MajorId"]!=null && row["MajorId"].ToString()!="")
				{
					model.MajorId=int.Parse(row["MajorId"].ToString());
				}
				if(row["MajorName"]!=null)
				{
					model.MajorName=row["MajorName"].ToString();
				}
				if(row["DeptId"]!=null && row["DeptId"].ToString()!="")
				{
					model.DeptId=int.Parse(row["DeptId"].ToString());
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
			strSql.Append("select MajorId,MajorName,DeptId ");
			strSql.Append(" FROM Major ");
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
			strSql.Append(" MajorId,MajorName,DeptId ");
			strSql.Append(" FROM Major ");
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
			strSql.Append("select count(1) FROM Major ");
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
				strSql.Append("order by T.DeptId desc");
			}
			strSql.Append(")AS Row, T.*  from Major T ");
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
			parameters[0].Value = "Major";
			parameters[1].Value = "DeptId";
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

