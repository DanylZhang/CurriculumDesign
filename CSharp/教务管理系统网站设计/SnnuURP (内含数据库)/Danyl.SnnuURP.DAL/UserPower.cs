using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:UserPower
	/// </summary>
	public partial class UserPower
	{
		public UserPower()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("UserType", "UserPower"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserType)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserPower");
			strSql.Append(" where UserType=@UserType ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserType", SqlDbType.Int,4)			};
			parameters[0].Value = UserType;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.UserPower model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserPower(");
			strSql.Append("UserType,UserPower1,UserPower2)");
			strSql.Append(" values (");
			strSql.Append("@UserType,@UserPower1,@UserPower2)");
			SqlParameter[] parameters = {
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@UserPower1", SqlDbType.NVarChar,50),
					new SqlParameter("@UserPower2", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.UserType;
			parameters[1].Value = model.UserPower1;
			parameters[2].Value = model.UserPower2;

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
		public bool Update(Danyl.SnnuURP.Model.UserPower model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserPower set ");
			strSql.Append("UserPower1=@UserPower1,");
			strSql.Append("UserPower2=@UserPower2");
			strSql.Append(" where UserType=@UserType ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserPower1", SqlDbType.NVarChar,50),
					new SqlParameter("@UserPower2", SqlDbType.NVarChar,50),
					new SqlParameter("@UserType", SqlDbType.Int,4)};
			parameters[0].Value = model.UserPower1;
			parameters[1].Value = model.UserPower2;
			parameters[2].Value = model.UserType;

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
		public bool Delete(int UserType)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserPower ");
			strSql.Append(" where UserType=@UserType ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserType", SqlDbType.Int,4)			};
			parameters[0].Value = UserType;

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
		public bool DeleteList(string UserTypelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserPower ");
			strSql.Append(" where UserType in ("+UserTypelist + ")  ");
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
		public Danyl.SnnuURP.Model.UserPower GetModel(int UserType)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserType,UserPower1,UserPower2 from UserPower ");
			strSql.Append(" where UserType=@UserType ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserType", SqlDbType.Int,4)			};
			parameters[0].Value = UserType;

			Danyl.SnnuURP.Model.UserPower model=new Danyl.SnnuURP.Model.UserPower();
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
		public Danyl.SnnuURP.Model.UserPower DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.UserPower model=new Danyl.SnnuURP.Model.UserPower();
			if (row != null)
			{
				if(row["UserType"]!=null && row["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(row["UserType"].ToString());
				}
				if(row["UserPower1"]!=null)
				{
					model.UserPower1=row["UserPower1"].ToString();
				}
				if(row["UserPower2"]!=null)
				{
					model.UserPower2=row["UserPower2"].ToString();
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
			strSql.Append("select UserType,UserPower1,UserPower2 ");
			strSql.Append(" FROM UserPower ");
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
			strSql.Append(" UserType,UserPower1,UserPower2 ");
			strSql.Append(" FROM UserPower ");
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
			strSql.Append("select count(1) FROM UserPower ");
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
				strSql.Append("order by T.UserType desc");
			}
			strSql.Append(")AS Row, T.*  from UserPower T ");
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
			parameters[0].Value = "UserPower";
			parameters[1].Value = "UserType";
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