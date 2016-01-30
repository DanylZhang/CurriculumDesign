using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:RoomUse
	/// </summary>
	public partial class RoomUse
	{
		public RoomUse()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Rid", "RoomUse"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Rid,int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RoomUse");
			strSql.Append(" where Rid=@Rid and Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Rid", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)			};
			parameters[0].Value = Rid;
			parameters[1].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Danyl.SnnuURP.Model.RoomUse model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RoomUse(");
			strSql.Append("Rid,Uid,UseDate,Purpose,UseStatus,RoomUsecol)");
			strSql.Append(" values (");
			strSql.Append("@Rid,@Uid,@UseDate,@Purpose,@UseStatus,@RoomUsecol)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Rid", SqlDbType.Int,4),
					new SqlParameter("@Uid", SqlDbType.Int,4),
					new SqlParameter("@UseDate", SqlDbType.DateTime),
					new SqlParameter("@Purpose", SqlDbType.NVarChar,50),
					new SqlParameter("@UseStatus", SqlDbType.VarChar,45),
					new SqlParameter("@RoomUsecol", SqlDbType.VarChar,45)};
			parameters[0].Value = model.Rid;
			parameters[1].Value = model.Uid;
			parameters[2].Value = model.UseDate;
			parameters[3].Value = model.Purpose;
			parameters[4].Value = model.UseStatus;
			parameters[5].Value = model.RoomUsecol;

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
		public bool Update(Danyl.SnnuURP.Model.RoomUse model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RoomUse set ");
			strSql.Append("Uid=@Uid,");
			strSql.Append("UseDate=@UseDate,");
			strSql.Append("Purpose=@Purpose,");
			strSql.Append("UseStatus=@UseStatus,");
			strSql.Append("RoomUsecol=@RoomUsecol");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4),
					new SqlParameter("@UseDate", SqlDbType.DateTime),
					new SqlParameter("@Purpose", SqlDbType.NVarChar,50),
					new SqlParameter("@UseStatus", SqlDbType.VarChar,45),
					new SqlParameter("@RoomUsecol", SqlDbType.VarChar,45),
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Rid", SqlDbType.Int,4)};
			parameters[0].Value = model.Uid;
			parameters[1].Value = model.UseDate;
			parameters[2].Value = model.Purpose;
			parameters[3].Value = model.UseStatus;
			parameters[4].Value = model.RoomUsecol;
			parameters[5].Value = model.Id;
			parameters[6].Value = model.Rid;

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
			strSql.Append("delete from RoomUse ");
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
		public bool Delete(int Rid,int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RoomUse ");
			strSql.Append(" where Rid=@Rid and Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Rid", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)			};
			parameters[0].Value = Rid;
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
			strSql.Append("delete from RoomUse ");
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
		public Danyl.SnnuURP.Model.RoomUse GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Rid,Uid,UseDate,Purpose,UseStatus,RoomUsecol from RoomUse ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Danyl.SnnuURP.Model.RoomUse model=new Danyl.SnnuURP.Model.RoomUse();
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
		public Danyl.SnnuURP.Model.RoomUse DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.RoomUse model=new Danyl.SnnuURP.Model.RoomUse();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Rid"]!=null && row["Rid"].ToString()!="")
				{
					model.Rid=int.Parse(row["Rid"].ToString());
				}
				if(row["Uid"]!=null && row["Uid"].ToString()!="")
				{
					model.Uid=int.Parse(row["Uid"].ToString());
				}
				if(row["UseDate"]!=null && row["UseDate"].ToString()!="")
				{
					model.UseDate=DateTime.Parse(row["UseDate"].ToString());
				}
				if(row["Purpose"]!=null)
				{
					model.Purpose=row["Purpose"].ToString();
				}
				if(row["UseStatus"]!=null)
				{
					model.UseStatus=row["UseStatus"].ToString();
				}
				if(row["RoomUsecol"]!=null)
				{
					model.RoomUsecol=row["RoomUsecol"].ToString();
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
			strSql.Append("select Id,Rid,Uid,UseDate,Purpose,UseStatus,RoomUsecol ");
			strSql.Append(" FROM RoomUse ");
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
			strSql.Append(" Id,Rid,Uid,UseDate,Purpose,UseStatus,RoomUsecol ");
			strSql.Append(" FROM RoomUse ");
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
			strSql.Append("select count(1) FROM RoomUse ");
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
			strSql.Append(")AS Row, T.*  from RoomUse T ");
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
			parameters[0].Value = "RoomUse";
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

