using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:Class
	/// </summary>
	public partial class Class
	{
		public Class()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ClassId", "Class"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ClassId,int MajorId,int DistrictId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Class");
			strSql.Append(" where ClassId=@ClassId and MajorId=@MajorId and DistrictId=@DistrictId ");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@DistrictId", SqlDbType.Int,4)			};
			parameters[0].Value = ClassId;
			parameters[1].Value = MajorId;
			parameters[2].Value = DistrictId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.Class model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Class(");
			strSql.Append("ClassId,ClassName,MajorId,Grade,StuCount,DistrictId)");
			strSql.Append(" values (");
			strSql.Append("@ClassId,@ClassName,@MajorId,@Grade,@StuCount,@DistrictId)");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@ClassName", SqlDbType.NVarChar,45),
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@Grade", SqlDbType.VarChar,45),
					new SqlParameter("@StuCount", SqlDbType.Int,4),
					new SqlParameter("@DistrictId", SqlDbType.Int,4)};
			parameters[0].Value = model.ClassId;
			parameters[1].Value = model.ClassName;
			parameters[2].Value = model.MajorId;
			parameters[3].Value = model.Grade;
			parameters[4].Value = model.StuCount;
			parameters[5].Value = model.DistrictId;

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
		public bool Update(Danyl.SnnuURP.Model.Class model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Class set ");
			strSql.Append("ClassName=@ClassName,");
			strSql.Append("Grade=@Grade,");
			strSql.Append("StuCount=@StuCount");
			strSql.Append(" where ClassId=@ClassId and MajorId=@MajorId and DistrictId=@DistrictId ");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassName", SqlDbType.NVarChar,45),
					new SqlParameter("@Grade", SqlDbType.VarChar,45),
					new SqlParameter("@StuCount", SqlDbType.Int,4),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@DistrictId", SqlDbType.Int,4)};
			parameters[0].Value = model.ClassName;
			parameters[1].Value = model.Grade;
			parameters[2].Value = model.StuCount;
			parameters[3].Value = model.ClassId;
			parameters[4].Value = model.MajorId;
			parameters[5].Value = model.DistrictId;

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
		public bool Delete(int ClassId,int MajorId,int DistrictId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Class ");
			strSql.Append(" where ClassId=@ClassId and MajorId=@MajorId and DistrictId=@DistrictId ");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@DistrictId", SqlDbType.Int,4)			};
			parameters[0].Value = ClassId;
			parameters[1].Value = MajorId;
			parameters[2].Value = DistrictId;

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
		public Danyl.SnnuURP.Model.Class GetModel(int ClassId,int MajorId,int DistrictId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ClassId,ClassName,MajorId,Grade,StuCount,DistrictId from Class ");
			strSql.Append(" where ClassId=@ClassId and MajorId=@MajorId and DistrictId=@DistrictId ");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@DistrictId", SqlDbType.Int,4)			};
			parameters[0].Value = ClassId;
			parameters[1].Value = MajorId;
			parameters[2].Value = DistrictId;

			Danyl.SnnuURP.Model.Class model=new Danyl.SnnuURP.Model.Class();
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
		public Danyl.SnnuURP.Model.Class DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.Class model=new Danyl.SnnuURP.Model.Class();
			if (row != null)
			{
				if(row["ClassId"]!=null && row["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(row["ClassId"].ToString());
				}
				if(row["ClassName"]!=null)
				{
					model.ClassName=row["ClassName"].ToString();
				}
				if(row["MajorId"]!=null && row["MajorId"].ToString()!="")
				{
					model.MajorId=int.Parse(row["MajorId"].ToString());
				}
				if(row["Grade"]!=null)
				{
					model.Grade=row["Grade"].ToString();
				}
				if(row["StuCount"]!=null && row["StuCount"].ToString()!="")
				{
					model.StuCount=int.Parse(row["StuCount"].ToString());
				}
				if(row["DistrictId"]!=null && row["DistrictId"].ToString()!="")
				{
					model.DistrictId=int.Parse(row["DistrictId"].ToString());
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
			strSql.Append("select ClassId,ClassName,MajorId,Grade,StuCount,DistrictId ");
			strSql.Append(" FROM Class ");
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
			strSql.Append(" ClassId,ClassName,MajorId,Grade,StuCount,DistrictId ");
			strSql.Append(" FROM Class ");
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
			strSql.Append("select count(1) FROM Class ");
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
				strSql.Append("order by T.DistrictId desc");
			}
			strSql.Append(")AS Row, T.*  from Class T ");
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
			parameters[0].Value = "Class";
			parameters[1].Value = "DistrictId";
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