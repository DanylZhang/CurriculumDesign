using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:TrainPlan
	/// </summary>
	public partial class TrainPlan
	{
		public TrainPlan()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MajorId", "TrainPlan"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MajorId,int PlanId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TrainPlan");
			strSql.Append(" where MajorId=@MajorId and PlanId=@PlanId ");
			SqlParameter[] parameters = {
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@PlanId", SqlDbType.Int,4)			};
			parameters[0].Value = MajorId;
			parameters[1].Value = PlanId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Danyl.SnnuURP.Model.TrainPlan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TrainPlan(");
			strSql.Append("PlanName,Grade,MajorId,CourseCount,CourseCredit,CourseHours,Remark)");
			strSql.Append(" values (");
			strSql.Append("@PlanName,@Grade,@MajorId,@CourseCount,@CourseCredit,@CourseHours,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PlanName", SqlDbType.NVarChar,45),
					new SqlParameter("@Grade", SqlDbType.VarChar,45),
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@CourseCount", SqlDbType.Int,4),
					new SqlParameter("@CourseCredit", SqlDbType.Float,8),
					new SqlParameter("@CourseHours", SqlDbType.Float,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.PlanName;
			parameters[1].Value = model.Grade;
			parameters[2].Value = model.MajorId;
			parameters[3].Value = model.CourseCount;
			parameters[4].Value = model.CourseCredit;
			parameters[5].Value = model.CourseHours;
			parameters[6].Value = model.Remark;

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
		public bool Update(Danyl.SnnuURP.Model.TrainPlan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TrainPlan set ");
			strSql.Append("PlanName=@PlanName,");
			strSql.Append("Grade=@Grade,");
			strSql.Append("CourseCount=@CourseCount,");
			strSql.Append("CourseCredit=@CourseCredit,");
			strSql.Append("CourseHours=@CourseHours,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where PlanId=@PlanId");
			SqlParameter[] parameters = {
					new SqlParameter("@PlanName", SqlDbType.NVarChar,45),
					new SqlParameter("@Grade", SqlDbType.VarChar,45),
					new SqlParameter("@CourseCount", SqlDbType.Int,4),
					new SqlParameter("@CourseCredit", SqlDbType.Float,8),
					new SqlParameter("@CourseHours", SqlDbType.Float,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@PlanId", SqlDbType.Int,4),
					new SqlParameter("@MajorId", SqlDbType.Int,4)};
			parameters[0].Value = model.PlanName;
			parameters[1].Value = model.Grade;
			parameters[2].Value = model.CourseCount;
			parameters[3].Value = model.CourseCredit;
			parameters[4].Value = model.CourseHours;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.PlanId;
			parameters[7].Value = model.MajorId;

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
		public bool Delete(int PlanId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TrainPlan ");
			strSql.Append(" where PlanId=@PlanId");
			SqlParameter[] parameters = {
					new SqlParameter("@PlanId", SqlDbType.Int,4)
			};
			parameters[0].Value = PlanId;

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
		public bool Delete(int MajorId,int PlanId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TrainPlan ");
			strSql.Append(" where MajorId=@MajorId and PlanId=@PlanId ");
			SqlParameter[] parameters = {
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@PlanId", SqlDbType.Int,4)			};
			parameters[0].Value = MajorId;
			parameters[1].Value = PlanId;

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
		public bool DeleteList(string PlanIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TrainPlan ");
			strSql.Append(" where PlanId in ("+PlanIdlist + ")  ");
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
		public Danyl.SnnuURP.Model.TrainPlan GetModel(int PlanId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PlanId,PlanName,Grade,MajorId,CourseCount,CourseCredit,CourseHours,Remark from TrainPlan ");
			strSql.Append(" where PlanId=@PlanId");
			SqlParameter[] parameters = {
					new SqlParameter("@PlanId", SqlDbType.Int,4)
			};
			parameters[0].Value = PlanId;

			Danyl.SnnuURP.Model.TrainPlan model=new Danyl.SnnuURP.Model.TrainPlan();
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
		public Danyl.SnnuURP.Model.TrainPlan DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.TrainPlan model=new Danyl.SnnuURP.Model.TrainPlan();
			if (row != null)
			{
				if(row["PlanId"]!=null && row["PlanId"].ToString()!="")
				{
					model.PlanId=int.Parse(row["PlanId"].ToString());
				}
				if(row["PlanName"]!=null)
				{
					model.PlanName=row["PlanName"].ToString();
				}
				if(row["Grade"]!=null)
				{
					model.Grade=row["Grade"].ToString();
				}
				if(row["MajorId"]!=null && row["MajorId"].ToString()!="")
				{
					model.MajorId=int.Parse(row["MajorId"].ToString());
				}
				if(row["CourseCount"]!=null && row["CourseCount"].ToString()!="")
				{
					model.CourseCount=int.Parse(row["CourseCount"].ToString());
				}
				if(row["CourseCredit"]!=null && row["CourseCredit"].ToString()!="")
				{
					model.CourseCredit=decimal.Parse(row["CourseCredit"].ToString());
				}
				if(row["CourseHours"]!=null && row["CourseHours"].ToString()!="")
				{
					model.CourseHours=decimal.Parse(row["CourseHours"].ToString());
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
			strSql.Append("select PlanId,PlanName,Grade,MajorId,CourseCount,CourseCredit,CourseHours,Remark ");
			strSql.Append(" FROM TrainPlan ");
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
			strSql.Append(" PlanId,PlanName,Grade,MajorId,CourseCount,CourseCredit,CourseHours,Remark ");
			strSql.Append(" FROM TrainPlan ");
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
			strSql.Append("select count(1) FROM TrainPlan ");
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
				strSql.Append("order by T.PlanId desc");
			}
			strSql.Append(")AS Row, T.*  from TrainPlan T ");
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
			parameters[0].Value = "TrainPlan";
			parameters[1].Value = "PlanId";
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

