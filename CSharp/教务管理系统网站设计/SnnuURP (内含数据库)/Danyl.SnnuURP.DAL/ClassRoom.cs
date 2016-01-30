using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:ClassRoom
	/// </summary>
	public partial class ClassRoom
	{
		public ClassRoom()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Rid", "ClassRoom"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Rid,int BuildId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ClassRoom");
			strSql.Append(" where Rid=@Rid and BuildId=@BuildId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Rid", SqlDbType.Int,4),
					new SqlParameter("@BuildId", SqlDbType.Int,4)			};
			parameters[0].Value = Rid;
			parameters[1].Value = BuildId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.ClassRoom model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ClassRoom(");
			strSql.Append("Rid,Rname,BuildId,RoomType,Capacity)");
			strSql.Append(" values (");
			strSql.Append("@Rid,@Rname,@BuildId,@RoomType,@Capacity)");
			SqlParameter[] parameters = {
					new SqlParameter("@Rid", SqlDbType.Int,4),
					new SqlParameter("@Rname", SqlDbType.NVarChar,20),
					new SqlParameter("@BuildId", SqlDbType.Int,4),
					new SqlParameter("@RoomType", SqlDbType.VarChar,45),
					new SqlParameter("@Capacity", SqlDbType.Int,4)};
			parameters[0].Value = model.Rid;
			parameters[1].Value = model.Rname;
			parameters[2].Value = model.BuildId;
			parameters[3].Value = model.RoomType;
			parameters[4].Value = model.Capacity;

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
		public bool Update(Danyl.SnnuURP.Model.ClassRoom model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ClassRoom set ");
			strSql.Append("Rname=@Rname,");
			strSql.Append("RoomType=@RoomType,");
			strSql.Append("Capacity=@Capacity");
			strSql.Append(" where Rid=@Rid and BuildId=@BuildId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Rname", SqlDbType.NVarChar,20),
					new SqlParameter("@RoomType", SqlDbType.VarChar,45),
					new SqlParameter("@Capacity", SqlDbType.Int,4),
					new SqlParameter("@Rid", SqlDbType.Int,4),
					new SqlParameter("@BuildId", SqlDbType.Int,4)};
			parameters[0].Value = model.Rname;
			parameters[1].Value = model.RoomType;
			parameters[2].Value = model.Capacity;
			parameters[3].Value = model.Rid;
			parameters[4].Value = model.BuildId;

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
		public bool Delete(int Rid,int BuildId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ClassRoom ");
			strSql.Append(" where Rid=@Rid and BuildId=@BuildId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Rid", SqlDbType.Int,4),
					new SqlParameter("@BuildId", SqlDbType.Int,4)			};
			parameters[0].Value = Rid;
			parameters[1].Value = BuildId;

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
		public Danyl.SnnuURP.Model.ClassRoom GetModel(int Rid,int BuildId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Rid,Rname,BuildId,RoomType,Capacity from ClassRoom ");
			strSql.Append(" where Rid=@Rid and BuildId=@BuildId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Rid", SqlDbType.Int,4),
					new SqlParameter("@BuildId", SqlDbType.Int,4)			};
			parameters[0].Value = Rid;
			parameters[1].Value = BuildId;

			Danyl.SnnuURP.Model.ClassRoom model=new Danyl.SnnuURP.Model.ClassRoom();
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
		public Danyl.SnnuURP.Model.ClassRoom DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.ClassRoom model=new Danyl.SnnuURP.Model.ClassRoom();
			if (row != null)
			{
				if(row["Rid"]!=null && row["Rid"].ToString()!="")
				{
					model.Rid=int.Parse(row["Rid"].ToString());
				}
				if(row["Rname"]!=null)
				{
					model.Rname=row["Rname"].ToString();
				}
				if(row["BuildId"]!=null && row["BuildId"].ToString()!="")
				{
					model.BuildId=int.Parse(row["BuildId"].ToString());
				}
				if(row["RoomType"]!=null)
				{
					model.RoomType=row["RoomType"].ToString();
				}
				if(row["Capacity"]!=null && row["Capacity"].ToString()!="")
				{
					model.Capacity=int.Parse(row["Capacity"].ToString());
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
			strSql.Append("select Rid,Rname,BuildId,RoomType,Capacity ");
			strSql.Append(" FROM ClassRoom ");
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
			strSql.Append(" Rid,Rname,BuildId,RoomType,Capacity ");
			strSql.Append(" FROM ClassRoom ");
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
			strSql.Append("select count(1) FROM ClassRoom ");
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
				strSql.Append("order by T.BuildId desc");
			}
			strSql.Append(")AS Row, T.*  from ClassRoom T ");
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
			parameters[0].Value = "ClassRoom";
			parameters[1].Value = "BuildId";
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

