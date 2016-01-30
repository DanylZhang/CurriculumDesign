using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:CourseCategory
	/// </summary>
	public partial class CourseCategory
	{
		public CourseCategory()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CouseCateId", "CourseCategory"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CouseCateId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CourseCategory");
			strSql.Append(" where CouseCateId=@CouseCateId ");
			SqlParameter[] parameters = {
					new SqlParameter("@CouseCateId", SqlDbType.Int,4)			};
			parameters[0].Value = CouseCateId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.CourseCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CourseCategory(");
			strSql.Append("CouseCateId,Category)");
			strSql.Append(" values (");
			strSql.Append("@CouseCateId,@Category)");
			SqlParameter[] parameters = {
					new SqlParameter("@CouseCateId", SqlDbType.Int,4),
					new SqlParameter("@Category", SqlDbType.NVarChar,45)};
			parameters[0].Value = model.CouseCateId;
			parameters[1].Value = model.Category;

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
		public bool Update(Danyl.SnnuURP.Model.CourseCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CourseCategory set ");
			strSql.Append("Category=@Category");
			strSql.Append(" where CouseCateId=@CouseCateId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Category", SqlDbType.NVarChar,45),
					new SqlParameter("@CouseCateId", SqlDbType.Int,4)};
			parameters[0].Value = model.Category;
			parameters[1].Value = model.CouseCateId;

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
		public bool Delete(int CouseCateId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseCategory ");
			strSql.Append(" where CouseCateId=@CouseCateId ");
			SqlParameter[] parameters = {
					new SqlParameter("@CouseCateId", SqlDbType.Int,4)			};
			parameters[0].Value = CouseCateId;

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
		public bool DeleteList(string CouseCateIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseCategory ");
			strSql.Append(" where CouseCateId in ("+CouseCateIdlist + ")  ");
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
		public Danyl.SnnuURP.Model.CourseCategory GetModel(int CouseCateId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CouseCateId,Category from CourseCategory ");
			strSql.Append(" where CouseCateId=@CouseCateId ");
			SqlParameter[] parameters = {
					new SqlParameter("@CouseCateId", SqlDbType.Int,4)			};
			parameters[0].Value = CouseCateId;

			Danyl.SnnuURP.Model.CourseCategory model=new Danyl.SnnuURP.Model.CourseCategory();
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
		public Danyl.SnnuURP.Model.CourseCategory DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.CourseCategory model=new Danyl.SnnuURP.Model.CourseCategory();
			if (row != null)
			{
				if(row["CouseCateId"]!=null && row["CouseCateId"].ToString()!="")
				{
					model.CouseCateId=int.Parse(row["CouseCateId"].ToString());
				}
				if(row["Category"]!=null)
				{
					model.Category=row["Category"].ToString();
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
			strSql.Append("select CouseCateId,Category ");
			strSql.Append(" FROM CourseCategory ");
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
			strSql.Append(" CouseCateId,Category ");
			strSql.Append(" FROM CourseCategory ");
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
			strSql.Append("select count(1) FROM CourseCategory ");
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
				strSql.Append("order by T.CouseCateId desc");
			}
			strSql.Append(")AS Row, T.*  from CourseCategory T ");
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
			parameters[0].Value = "CourseCategory";
			parameters[1].Value = "CouseCateId";
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

