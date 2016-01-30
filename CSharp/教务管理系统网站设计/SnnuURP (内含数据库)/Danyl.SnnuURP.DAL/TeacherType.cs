using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:TeacherType
	/// </summary>
	public partial class TeacherType
	{
		public TeacherType()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TeaTypeId", "TeacherType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TeaTypeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TeacherType");
			strSql.Append(" where TeaTypeId=@TeaTypeId");
			SqlParameter[] parameters = {
					new SqlParameter("@TeaTypeId", SqlDbType.Int,4)
			};
			parameters[0].Value = TeaTypeId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Danyl.SnnuURP.Model.TeacherType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TeacherType(");
			strSql.Append("TeacherTypes,HoursSalary)");
			strSql.Append(" values (");
			strSql.Append("@TeacherTypes,@HoursSalary)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TeacherTypes", SqlDbType.NVarChar,20),
					new SqlParameter("@HoursSalary", SqlDbType.Decimal,9)};
			parameters[0].Value = model.TeacherTypes;
			parameters[1].Value = model.HoursSalary;

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
		public bool Update(Danyl.SnnuURP.Model.TeacherType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TeacherType set ");
			strSql.Append("TeacherTypes=@TeacherTypes,");
			strSql.Append("HoursSalary=@HoursSalary");
			strSql.Append(" where TeaTypeId=@TeaTypeId");
			SqlParameter[] parameters = {
					new SqlParameter("@TeacherTypes", SqlDbType.NVarChar,20),
					new SqlParameter("@HoursSalary", SqlDbType.Decimal,9),
					new SqlParameter("@TeaTypeId", SqlDbType.Int,4)};
			parameters[0].Value = model.TeacherTypes;
			parameters[1].Value = model.HoursSalary;
			parameters[2].Value = model.TeaTypeId;

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
		public bool Delete(int TeaTypeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TeacherType ");
			strSql.Append(" where TeaTypeId=@TeaTypeId");
			SqlParameter[] parameters = {
					new SqlParameter("@TeaTypeId", SqlDbType.Int,4)
			};
			parameters[0].Value = TeaTypeId;

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
		public bool DeleteList(string TeaTypeIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TeacherType ");
			strSql.Append(" where TeaTypeId in ("+TeaTypeIdlist + ")  ");
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
		public Danyl.SnnuURP.Model.TeacherType GetModel(int TeaTypeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TeaTypeId,TeacherTypes,HoursSalary from TeacherType ");
			strSql.Append(" where TeaTypeId=@TeaTypeId");
			SqlParameter[] parameters = {
					new SqlParameter("@TeaTypeId", SqlDbType.Int,4)
			};
			parameters[0].Value = TeaTypeId;

			Danyl.SnnuURP.Model.TeacherType model=new Danyl.SnnuURP.Model.TeacherType();
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
		public Danyl.SnnuURP.Model.TeacherType DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.TeacherType model=new Danyl.SnnuURP.Model.TeacherType();
			if (row != null)
			{
				if(row["TeaTypeId"]!=null && row["TeaTypeId"].ToString()!="")
				{
					model.TeaTypeId=int.Parse(row["TeaTypeId"].ToString());
				}
				if(row["TeacherTypes"]!=null)
				{
					model.TeacherTypes=row["TeacherTypes"].ToString();
				}
				if(row["HoursSalary"]!=null && row["HoursSalary"].ToString()!="")
				{
					model.HoursSalary=decimal.Parse(row["HoursSalary"].ToString());
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
			strSql.Append("select TeaTypeId,TeacherTypes,HoursSalary ");
			strSql.Append(" FROM TeacherType ");
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
			strSql.Append(" TeaTypeId,TeacherTypes,HoursSalary ");
			strSql.Append(" FROM TeacherType ");
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
			strSql.Append("select count(1) FROM TeacherType ");
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
				strSql.Append("order by T.TeaTypeId desc");
			}
			strSql.Append(")AS Row, T.*  from TeacherType T ");
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
			parameters[0].Value = "TeacherType";
			parameters[1].Value = "TeaTypeId";
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

