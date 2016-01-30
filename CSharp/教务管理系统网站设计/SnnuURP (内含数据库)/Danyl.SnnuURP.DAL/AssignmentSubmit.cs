using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:AssignmentSubmit
	/// </summary>
	public partial class AssignmentSubmit
	{
		public AssignmentSubmit()
		{}

		#region  BasicMethod
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AssignmentId", "AssignmentSubmit"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AssignmentId,int Accessory,int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AssignmentSubmit");
			strSql.Append(" where AssignmentId=@AssignmentId and Accessory=@Accessory and Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@AssignmentId", SqlDbType.Int,4),
					new SqlParameter("@Accessory", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)			};
			parameters[0].Value = AssignmentId;
			parameters[1].Value = Accessory;
			parameters[2].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Danyl.SnnuURP.Model.AssignmentSubmit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AssignmentSubmit(");
			strSql.Append("Sid,AssignmentId,Detail,Accessory)");
			strSql.Append(" values (");
			strSql.Append("@Sid,@AssignmentId,@Detail,@Accessory)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@AssignmentId", SqlDbType.Int,4),
					new SqlParameter("@Detail", SqlDbType.VarChar,45),
					new SqlParameter("@Accessory", SqlDbType.Int,4)};
			parameters[0].Value = model.Sid;
			parameters[1].Value = model.AssignmentId;
			parameters[2].Value = model.Detail;
			parameters[3].Value = model.Accessory;

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
		public bool Update(Danyl.SnnuURP.Model.AssignmentSubmit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AssignmentSubmit set ");
			strSql.Append("Sid=@Sid,");
			strSql.Append("Detail=@Detail");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@Detail", SqlDbType.VarChar,45),
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@AssignmentId", SqlDbType.Int,4),
					new SqlParameter("@Accessory", SqlDbType.Int,4)};
			parameters[0].Value = model.Sid;
			parameters[1].Value = model.Detail;
			parameters[2].Value = model.Id;
			parameters[3].Value = model.AssignmentId;
			parameters[4].Value = model.Accessory;

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
			strSql.Append("delete from AssignmentSubmit ");
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
		public bool Delete(int AssignmentId,int Accessory,int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AssignmentSubmit ");
			strSql.Append(" where AssignmentId=@AssignmentId and Accessory=@Accessory and Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@AssignmentId", SqlDbType.Int,4),
					new SqlParameter("@Accessory", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)			};
			parameters[0].Value = AssignmentId;
			parameters[1].Value = Accessory;
			parameters[2].Value = Id;

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
		public bool DeleteList(string Idlist)
        {
            StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AssignmentSubmit ");
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
		public Danyl.SnnuURP.Model.AssignmentSubmit GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Sid,AssignmentId,Detail,Accessory from AssignmentSubmit ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Danyl.SnnuURP.Model.AssignmentSubmit model=new Danyl.SnnuURP.Model.AssignmentSubmit();
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
		public Danyl.SnnuURP.Model.AssignmentSubmit DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.AssignmentSubmit model=new Danyl.SnnuURP.Model.AssignmentSubmit();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Sid"]!=null && row["Sid"].ToString()!="")
				{
					model.Sid=int.Parse(row["Sid"].ToString());
				}
				if(row["AssignmentId"]!=null && row["AssignmentId"].ToString()!="")
				{
					model.AssignmentId=int.Parse(row["AssignmentId"].ToString());
				}
				if(row["Detail"]!=null)
				{
					model.Detail=row["Detail"].ToString();
				}
				if(row["Accessory"]!=null && row["Accessory"].ToString()!="")
				{
					model.Accessory=int.Parse(row["Accessory"].ToString());
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
			strSql.Append("select Id,Sid,AssignmentId,Detail,Accessory ");
			strSql.Append(" FROM AssignmentSubmit ");
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
			strSql.Append(" Id,Sid,AssignmentId,Detail,Accessory ");
			strSql.Append(" FROM AssignmentSubmit ");
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
			strSql.Append("select count(1) FROM AssignmentSubmit ");
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
			strSql.Append(")AS Row, T.*  from AssignmentSubmit T ");
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
			parameters[0].Value = "AssignmentSubmit";
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