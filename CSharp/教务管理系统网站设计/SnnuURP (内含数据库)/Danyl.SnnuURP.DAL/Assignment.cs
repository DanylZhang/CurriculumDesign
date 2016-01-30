using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:Assignment
	/// </summary>
	public partial class Assignment
	{
		public Assignment()
		{}

		#region  BasicMethod
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Tid", "Assignment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Tid,int Accessory,int AssignId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Assignment");
			strSql.Append(" where Tid=@Tid and Accessory=@Accessory and AssignId=@AssignId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@Accessory", SqlDbType.Int,4),
					new SqlParameter("@AssignId", SqlDbType.Int,4)			};
			parameters[0].Value = Tid;
			parameters[1].Value = Accessory;
			parameters[2].Value = AssignId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Danyl.SnnuURP.Model.Assignment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Assignment(");
			strSql.Append("Tid,Cid,ReleaseTime,Deadline,AssignDetail,Accessory)");
			strSql.Append(" values (");
			strSql.Append("@Tid,@Cid,@ReleaseTime,@Deadline,@AssignDetail,@Accessory)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@ReleaseTime", SqlDbType.DateTime),
					new SqlParameter("@Deadline", SqlDbType.DateTime),
					new SqlParameter("@AssignDetail", SqlDbType.Text),
					new SqlParameter("@Accessory", SqlDbType.Int,4)};
			parameters[0].Value = model.Tid;
			parameters[1].Value = model.Cid;
			parameters[2].Value = model.ReleaseTime;
			parameters[3].Value = model.Deadline;
			parameters[4].Value = model.AssignDetail;
			parameters[5].Value = model.Accessory;

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
		public bool Update(Danyl.SnnuURP.Model.Assignment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Assignment set ");
			strSql.Append("Cid=@Cid,");
			strSql.Append("ReleaseTime=@ReleaseTime,");
			strSql.Append("Deadline=@Deadline,");
			strSql.Append("AssignDetail=@AssignDetail");
			strSql.Append(" where AssignId=@AssignId");
			SqlParameter[] parameters = {
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@ReleaseTime", SqlDbType.DateTime),
					new SqlParameter("@Deadline", SqlDbType.DateTime),
					new SqlParameter("@AssignDetail", SqlDbType.Text),
					new SqlParameter("@AssignId", SqlDbType.Int,4),
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@Accessory", SqlDbType.Int,4)};
			parameters[0].Value = model.Cid;
			parameters[1].Value = model.ReleaseTime;
			parameters[2].Value = model.Deadline;
			parameters[3].Value = model.AssignDetail;
			parameters[4].Value = model.AssignId;
			parameters[5].Value = model.Tid;
			parameters[6].Value = model.Accessory;

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
		public bool Delete(int AssignId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Assignment ");
			strSql.Append(" where AssignId=@AssignId");
			SqlParameter[] parameters = {
					new SqlParameter("@AssignId", SqlDbType.Int,4)
			};
			parameters[0].Value = AssignId;

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
		public bool Delete(int Tid,int Accessory,int AssignId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Assignment ");
			strSql.Append(" where Tid=@Tid and Accessory=@Accessory and AssignId=@AssignId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@Accessory", SqlDbType.Int,4),
					new SqlParameter("@AssignId", SqlDbType.Int,4)			};
			parameters[0].Value = Tid;
			parameters[1].Value = Accessory;
			parameters[2].Value = AssignId;

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
		public bool DeleteList(string AssignIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Assignment ");
			strSql.Append(" where AssignId in ("+AssignIdlist + ")  ");
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
		public Danyl.SnnuURP.Model.Assignment GetModel(int AssignId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AssignId,Tid,Cid,ReleaseTime,Deadline,AssignDetail,Accessory from Assignment ");
			strSql.Append(" where AssignId=@AssignId");
			SqlParameter[] parameters = {
					new SqlParameter("@AssignId", SqlDbType.Int,4)
			};
			parameters[0].Value = AssignId;

			Danyl.SnnuURP.Model.Assignment model=new Danyl.SnnuURP.Model.Assignment();
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
		public Danyl.SnnuURP.Model.Assignment DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.Assignment model=new Danyl.SnnuURP.Model.Assignment();
			if (row != null)
			{
				if(row["AssignId"]!=null && row["AssignId"].ToString()!="")
				{
					model.AssignId=int.Parse(row["AssignId"].ToString());
				}
				if(row["Tid"]!=null && row["Tid"].ToString()!="")
				{
					model.Tid=int.Parse(row["Tid"].ToString());
				}
				if(row["Cid"]!=null && row["Cid"].ToString()!="")
				{
					model.Cid=int.Parse(row["Cid"].ToString());
				}
				if(row["ReleaseTime"]!=null && row["ReleaseTime"].ToString()!="")
				{
					model.ReleaseTime=DateTime.Parse(row["ReleaseTime"].ToString());
				}
				if(row["Deadline"]!=null && row["Deadline"].ToString()!="")
				{
					model.Deadline=DateTime.Parse(row["Deadline"].ToString());
				}
				if(row["AssignDetail"]!=null)
				{
					model.AssignDetail=row["AssignDetail"].ToString();
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
			strSql.Append("select AssignId,Tid,Cid,ReleaseTime,Deadline,AssignDetail,Accessory ");
			strSql.Append(" FROM Assignment ");
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
			strSql.Append(" AssignId,Tid,Cid,ReleaseTime,Deadline,AssignDetail,Accessory ");
			strSql.Append(" FROM Assignment ");
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
			strSql.Append("select count(1) FROM Assignment ");
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
				strSql.Append("order by T.AssignId desc");
			}
			strSql.Append(")AS Row, T.*  from Assignment T ");
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
			parameters[0].Value = "Assignment";
			parameters[1].Value = "AssignId";
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