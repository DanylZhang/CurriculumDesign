﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:Depart
	/// </summary>
	public partial class Depart
	{
		public Depart()
		{}

		#region  BasicMethod
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DeptId", "Depart"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DeptId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Depart");
			strSql.Append(" where DeptId=@DeptId");
			SqlParameter[] parameters = {new SqlParameter("@DeptId", SqlDbType.Int,4)};
			parameters[0].Value = DeptId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.Depart model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Depart(");
			strSql.Append("DeptId,DeptName,MasterName,DistrictId)");
			strSql.Append(" values (");
			strSql.Append("@DeptId,@DeptName,@MasterName,@DistrictId)");
			SqlParameter[] parameters = {
					new SqlParameter("@DeptId", SqlDbType.Int,4),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,30),
					new SqlParameter("@MasterName", SqlDbType.NVarChar,45),
					new SqlParameter("@DistrictId", SqlDbType.Int,4)};
			parameters[0].Value = model.DeptId;
			parameters[1].Value = model.DeptName;
			parameters[2].Value = model.MasterName;
			parameters[3].Value = model.DistrictId;

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
		public bool Update(Danyl.SnnuURP.Model.Depart model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Depart set ");
			strSql.Append("DeptName=@DeptName,");
			strSql.Append("MasterName=@MasterName");
			strSql.Append(" where DeptId=@DeptId and DistrictId=@DistrictId ");
			SqlParameter[] parameters = {
					new SqlParameter("@DeptName", SqlDbType.NVarChar,30),
					new SqlParameter("@MasterName", SqlDbType.NVarChar,45),
					new SqlParameter("@DeptId", SqlDbType.Int,4),
					new SqlParameter("@DistrictId", SqlDbType.Int,4)};
			parameters[0].Value = model.DeptName;
			parameters[1].Value = model.MasterName;
			parameters[2].Value = model.DeptId;
			parameters[3].Value = model.DistrictId;

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
		public bool Delete(int DeptId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Depart ");
			strSql.Append(" where DeptId=@DeptId");
			SqlParameter[] parameters = {new SqlParameter("@DeptId", SqlDbType.Int,4)};
			parameters[0].Value = DeptId;

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
		public Danyl.SnnuURP.Model.Depart GetModel(int DeptId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DeptId,DeptName,MasterName,DistrictId from Depart ");
			strSql.Append(" where DeptId=@DeptId");
			SqlParameter[] parameters = {new SqlParameter("@DeptId", SqlDbType.Int,4)};
			parameters[0].Value = DeptId;

			Danyl.SnnuURP.Model.Depart model=new Danyl.SnnuURP.Model.Depart();
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
		public Danyl.SnnuURP.Model.Depart DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.Depart model=new Danyl.SnnuURP.Model.Depart();
			if (row != null)
			{
				if(row["DeptId"]!=null && row["DeptId"].ToString()!="")
				{
					model.DeptId=int.Parse(row["DeptId"].ToString());
				}
				if(row["DeptName"]!=null)
				{
					model.DeptName=row["DeptName"].ToString();
				}
				if(row["MasterName"]!=null)
				{
					model.MasterName=row["MasterName"].ToString();
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
			strSql.Append("select DeptId,DeptName,MasterName,DistrictId ");
			strSql.Append(" FROM Depart ");
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
			strSql.Append(" DeptId,DeptName,MasterName,DistrictId ");
			strSql.Append(" FROM Depart ");
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
			strSql.Append("select count(1) FROM Depart ");
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
			strSql.Append(")AS Row, T.*  from Depart T ");
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
			parameters[0].Value = "Depart";
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

