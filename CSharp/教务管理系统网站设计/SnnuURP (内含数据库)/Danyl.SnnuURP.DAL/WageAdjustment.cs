using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:WageAdjustment
	/// </summary>
	public partial class WageAdjustment
	{
		public WageAdjustment()
		{}

		#region  BasicMethod
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Tid", "WageAdjustment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Tid,int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WageAdjustment");
			strSql.Append(" where Tid=@Tid and Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)			};
			parameters[0].Value = Tid;
			parameters[1].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Danyl.SnnuURP.Model.WageAdjustment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WageAdjustment(");
			strSql.Append("Tid,NewSalary,OldSalary,Reason,AdjustDate,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Tid,@NewSalary,@OldSalary,@Reason,@AdjustDate,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@NewSalary", SqlDbType.Decimal,9),
					new SqlParameter("@OldSalary", SqlDbType.Decimal,9),
					new SqlParameter("@Reason", SqlDbType.NVarChar,45),
					new SqlParameter("@AdjustDate", SqlDbType.Date,3),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.Tid;
			parameters[1].Value = model.NewSalary;
			parameters[2].Value = model.OldSalary;
			parameters[3].Value = model.Reason;
			parameters[4].Value = model.AdjustDate;
			parameters[5].Value = model.Remark;

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
		public bool Update(Danyl.SnnuURP.Model.WageAdjustment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WageAdjustment set ");
			strSql.Append("NewSalary=@NewSalary,");
			strSql.Append("OldSalary=@OldSalary,");
			strSql.Append("Reason=@Reason,");
			strSql.Append("AdjustDate=@AdjustDate,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@NewSalary", SqlDbType.Decimal,9),
					new SqlParameter("@OldSalary", SqlDbType.Decimal,9),
					new SqlParameter("@Reason", SqlDbType.NVarChar,45),
					new SqlParameter("@AdjustDate", SqlDbType.Date,3),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Tid", SqlDbType.Int,4)};
			parameters[0].Value = model.NewSalary;
			parameters[1].Value = model.OldSalary;
			parameters[2].Value = model.Reason;
			parameters[3].Value = model.AdjustDate;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.Id;
			parameters[6].Value = model.Tid;

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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WageAdjustment ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

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
		public bool Delete(int Tid,int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WageAdjustment ");
			strSql.Append(" where Tid=@Tid and Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)			};
			parameters[0].Value = Tid;
			parameters[1].Value = Id;

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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WageAdjustment ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
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
		public Danyl.SnnuURP.Model.WageAdjustment GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Tid,NewSalary,OldSalary,Reason,AdjustDate,Remark from WageAdjustment ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Danyl.SnnuURP.Model.WageAdjustment model=new Danyl.SnnuURP.Model.WageAdjustment();
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
		public Danyl.SnnuURP.Model.WageAdjustment DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.WageAdjustment model=new Danyl.SnnuURP.Model.WageAdjustment();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Tid"]!=null && row["Tid"].ToString()!="")
				{
					model.Tid=int.Parse(row["Tid"].ToString());
				}
				if(row["NewSalary"]!=null && row["NewSalary"].ToString()!="")
				{
					model.NewSalary=decimal.Parse(row["NewSalary"].ToString());
				}
				if(row["OldSalary"]!=null && row["OldSalary"].ToString()!="")
				{
					model.OldSalary=decimal.Parse(row["OldSalary"].ToString());
				}
				if(row["Reason"]!=null)
				{
					model.Reason=row["Reason"].ToString();
				}
				if(row["AdjustDate"]!=null && row["AdjustDate"].ToString()!="")
				{
					model.AdjustDate=DateTime.Parse(row["AdjustDate"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select Id,Tid,NewSalary,OldSalary,Reason,AdjustDate,Remark ");
			strSql.Append(" FROM WageAdjustment ");
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
			strSql.Append(" Id,Tid,NewSalary,OldSalary,Reason,AdjustDate,Remark ");
			strSql.Append(" FROM WageAdjustment ");
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
			strSql.Append("select count(1) FROM WageAdjustment ");
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
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from WageAdjustment T ");
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
			parameters[0].Value = "WageAdjustment";
			parameters[1].Value = "Id";
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