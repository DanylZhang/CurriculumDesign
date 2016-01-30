using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:SchoolDistrict
	/// </summary>
	public partial class SchoolDistrict
	{
		public SchoolDistrict()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DistrictId", "SchoolDistrict"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DistrictId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SchoolDistrict");
			strSql.Append(" where DistrictId=@DistrictId");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictId", SqlDbType.Int,4)
			};
			parameters[0].Value = DistrictId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Danyl.SnnuURP.Model.SchoolDistrict model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SchoolDistrict(");
			strSql.Append("DistrictName,Address)");
			strSql.Append(" values (");
			strSql.Append("@DistrictName,@Address)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictName", SqlDbType.NVarChar,30),
					new SqlParameter("@Address", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.DistrictName;
			parameters[1].Value = model.Address;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Danyl.SnnuURP.Model.SchoolDistrict model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SchoolDistrict set ");
			strSql.Append("DistrictName=@DistrictName,");
			strSql.Append("Address=@Address");
			strSql.Append(" where DistrictId=@DistrictId");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictName", SqlDbType.NVarChar,30),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@DistrictId", SqlDbType.Int,4)};
			parameters[0].Value = model.DistrictName;
			parameters[1].Value = model.Address;
			parameters[2].Value = model.DistrictId;

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
		public bool Delete(int DistrictId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchoolDistrict ");
			strSql.Append(" where DistrictId=@DistrictId");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictId", SqlDbType.Int,4)
			};
			parameters[0].Value = DistrictId;

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
		public bool DeleteList(string DistrictIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SchoolDistrict ");
			strSql.Append(" where DistrictId in ("+DistrictIdlist + ")  ");
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
		public Danyl.SnnuURP.Model.SchoolDistrict GetModel(int DistrictId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DistrictId,DistrictName,Address from SchoolDistrict ");
			strSql.Append(" where DistrictId=@DistrictId");
			SqlParameter[] parameters = {
					new SqlParameter("@DistrictId", SqlDbType.Int,4)
			};
			parameters[0].Value = DistrictId;

			Danyl.SnnuURP.Model.SchoolDistrict model=new Danyl.SnnuURP.Model.SchoolDistrict();
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
		public Danyl.SnnuURP.Model.SchoolDistrict DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.SchoolDistrict model=new Danyl.SnnuURP.Model.SchoolDistrict();
			if (row != null)
			{
				if(row["DistrictId"]!=null && row["DistrictId"].ToString()!="")
				{
					model.DistrictId=int.Parse(row["DistrictId"].ToString());
				}
				if(row["DistrictName"]!=null)
				{
					model.DistrictName=row["DistrictName"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
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
			strSql.Append("select DistrictId,DistrictName,Address ");
			strSql.Append(" FROM SchoolDistrict ");
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
			strSql.Append(" DistrictId,DistrictName,Address ");
			strSql.Append(" FROM SchoolDistrict ");
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
			strSql.Append("select count(1) FROM SchoolDistrict ");
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
			strSql.Append(")AS Row, T.*  from SchoolDistrict T ");
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
			parameters[0].Value = "SchoolDistrict";
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

