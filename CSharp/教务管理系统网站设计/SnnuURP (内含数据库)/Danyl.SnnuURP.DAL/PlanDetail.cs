using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:PlanDetail
	/// </summary>
	public partial class PlanDetail
	{
		public PlanDetail()
		{}

		#region  BasicMethod
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PlanId", "PlanDetail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PlanId,int Cid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PlanDetail");
			strSql.Append(" where PlanId=@PlanId and Cid=@Cid ");
			SqlParameter[] parameters = {
					new SqlParameter("@PlanId", SqlDbType.Int,4),
					new SqlParameter("@Cid", SqlDbType.Int,4)			};
			parameters[0].Value = PlanId;
			parameters[1].Value = Cid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.PlanDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PlanDetail(");
			strSql.Append("PlanId,Cid)");
			strSql.Append(" values (");
			strSql.Append("@PlanId,@Cid)");
			SqlParameter[] parameters = {
					new SqlParameter("@PlanId", SqlDbType.Int,4),
					new SqlParameter("@Cid", SqlDbType.Int,4)};
			parameters[0].Value = model.PlanId;
			parameters[1].Value = model.Cid;

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
		public bool Update(Danyl.SnnuURP.Model.PlanDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PlanDetail set ");
			strSql.Append("PlanId=@PlanId,");
			strSql.Append("Cid=@Cid");
			strSql.Append(" where PlanId=@PlanId and Cid=@Cid ");
			SqlParameter[] parameters = {
					new SqlParameter("@PlanId", SqlDbType.Int,4),
					new SqlParameter("@Cid", SqlDbType.Int,4)};
			parameters[0].Value = model.PlanId;
			parameters[1].Value = model.Cid;

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
		public bool Delete(int PlanId,int Cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PlanDetail ");
			strSql.Append(" where PlanId=@PlanId and Cid=@Cid ");
			SqlParameter[] parameters = {
					new SqlParameter("@PlanId", SqlDbType.Int,4),
					new SqlParameter("@Cid", SqlDbType.Int,4)			};
			parameters[0].Value = PlanId;
			parameters[1].Value = Cid;

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
		public Danyl.SnnuURP.Model.PlanDetail GetModel(int PlanId,int Cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PlanId,Cid from PlanDetail ");
			strSql.Append(" where PlanId=@PlanId and Cid=@Cid ");
			SqlParameter[] parameters = {
					new SqlParameter("@PlanId", SqlDbType.Int,4),
					new SqlParameter("@Cid", SqlDbType.Int,4)			};
			parameters[0].Value = PlanId;
			parameters[1].Value = Cid;

			Danyl.SnnuURP.Model.PlanDetail model=new Danyl.SnnuURP.Model.PlanDetail();
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
		public Danyl.SnnuURP.Model.PlanDetail DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.PlanDetail model=new Danyl.SnnuURP.Model.PlanDetail();
			if (row != null)
			{
				if(row["PlanId"]!=null && row["PlanId"].ToString()!="")
				{
					model.PlanId=int.Parse(row["PlanId"].ToString());
				}
				if(row["Cid"]!=null && row["Cid"].ToString()!="")
				{
					model.Cid=int.Parse(row["Cid"].ToString());
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
			strSql.Append("select PlanId,Cid ");
			strSql.Append(" FROM PlanDetail ");
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
			strSql.Append(" PlanId,Cid ");
			strSql.Append(" FROM PlanDetail ");
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
			strSql.Append("select count(1) FROM PlanDetail ");
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
				strSql.Append("order by T.Cid desc");
			}
			strSql.Append(")AS Row, T.*  from PlanDetail T ");
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
			parameters[0].Value = "PlanDetail";
			parameters[1].Value = "Cid";
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