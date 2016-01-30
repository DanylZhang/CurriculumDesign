using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:Teach
	/// </summary>
	public partial class Teach
	{
		public Teach()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Cid", "Teach"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Cid,int Cno,int Tid,int ClassRoomId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Teach");
			strSql.Append(" where Cid=@Cid and Cno=@Cno and Tid=@Tid and ClassRoomId=@ClassRoomId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@Cno", SqlDbType.Int,4),
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@ClassRoomId", SqlDbType.Int,4)			};
			parameters[0].Value = Cid;
			parameters[1].Value = Cno;
			parameters[2].Value = Tid;
			parameters[3].Value = ClassRoomId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.Teach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Teach(");
			strSql.Append("Cid,Cno,Tid,CourseRemainder,Period,Week,Section,SectionCount,DistrictId,BuildId,ClassRoomId)");
			strSql.Append(" values (");
			strSql.Append("@Cid,@Cno,@Tid,@CourseRemainder,@Period,@Week,@Section,@SectionCount,@DistrictId,@BuildId,@ClassRoomId)");
			SqlParameter[] parameters = {
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@Cno", SqlDbType.Int,4),
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@CourseRemainder", SqlDbType.Int,4),
					new SqlParameter("@Period", SqlDbType.NVarChar,45),
					new SqlParameter("@Week", SqlDbType.VarChar,45),
					new SqlParameter("@Section", SqlDbType.Int,4),
					new SqlParameter("@SectionCount", SqlDbType.Int,4),
					new SqlParameter("@DistrictId", SqlDbType.Int,4),
					new SqlParameter("@BuildId", SqlDbType.Int,4),
					new SqlParameter("@ClassRoomId", SqlDbType.Int,4)};
			parameters[0].Value = model.Cid;
			parameters[1].Value = model.Cno;
			parameters[2].Value = model.Tid;
			parameters[3].Value = model.CourseRemainder;
			parameters[4].Value = model.Period;
			parameters[5].Value = model.Week;
			parameters[6].Value = model.Section;
			parameters[7].Value = model.SectionCount;
			parameters[8].Value = model.DistrictId;
			parameters[9].Value = model.BuildId;
			parameters[10].Value = model.ClassRoomId;

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
		public bool Update(Danyl.SnnuURP.Model.Teach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Teach set ");
			strSql.Append("CourseRemainder=@CourseRemainder,");
			strSql.Append("Period=@Period,");
			strSql.Append("Week=@Week,");
			strSql.Append("Section=@Section,");
			strSql.Append("SectionCount=@SectionCount,");
			strSql.Append("DistrictId=@DistrictId,");
			strSql.Append("BuildId=@BuildId");
			strSql.Append(" where Cid=@Cid and Cno=@Cno and Tid=@Tid and ClassRoomId=@ClassRoomId ");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseRemainder", SqlDbType.Int,4),
					new SqlParameter("@Period", SqlDbType.NVarChar,45),
					new SqlParameter("@Week", SqlDbType.VarChar,45),
					new SqlParameter("@Section", SqlDbType.Int,4),
					new SqlParameter("@SectionCount", SqlDbType.Int,4),
					new SqlParameter("@DistrictId", SqlDbType.Int,4),
					new SqlParameter("@BuildId", SqlDbType.Int,4),
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@Cno", SqlDbType.Int,4),
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@ClassRoomId", SqlDbType.Int,4)};
			parameters[0].Value = model.CourseRemainder;
			parameters[1].Value = model.Period;
			parameters[2].Value = model.Week;
			parameters[3].Value = model.Section;
			parameters[4].Value = model.SectionCount;
			parameters[5].Value = model.DistrictId;
			parameters[6].Value = model.BuildId;
			parameters[7].Value = model.Cid;
			parameters[8].Value = model.Cno;
			parameters[9].Value = model.Tid;
			parameters[10].Value = model.ClassRoomId;

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
		public bool Delete(int Cid,int Cno,int Tid,int ClassRoomId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Teach ");
			strSql.Append(" where Cid=@Cid and Cno=@Cno and Tid=@Tid and ClassRoomId=@ClassRoomId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@Cno", SqlDbType.Int,4),
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@ClassRoomId", SqlDbType.Int,4)			};
			parameters[0].Value = Cid;
			parameters[1].Value = Cno;
			parameters[2].Value = Tid;
			parameters[3].Value = ClassRoomId;

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
		public Danyl.SnnuURP.Model.Teach GetModel(int Cid,int Cno,int Tid,int ClassRoomId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Cid,Cno,Tid,CourseRemainder,Period,Week,Section,SectionCount,DistrictId,BuildId,ClassRoomId from Teach ");
			strSql.Append(" where Cid=@Cid and Cno=@Cno and Tid=@Tid and ClassRoomId=@ClassRoomId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@Cno", SqlDbType.Int,4),
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@ClassRoomId", SqlDbType.Int,4)			};
			parameters[0].Value = Cid;
			parameters[1].Value = Cno;
			parameters[2].Value = Tid;
			parameters[3].Value = ClassRoomId;

			Danyl.SnnuURP.Model.Teach model=new Danyl.SnnuURP.Model.Teach();
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
		public Danyl.SnnuURP.Model.Teach DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.Teach model=new Danyl.SnnuURP.Model.Teach();
			if (row != null)
			{
				if(row["Cid"]!=null && row["Cid"].ToString()!="")
				{
					model.Cid=int.Parse(row["Cid"].ToString());
				}
				if(row["Cno"]!=null && row["Cno"].ToString()!="")
				{
					model.Cno=int.Parse(row["Cno"].ToString());
				}
				if(row["Tid"]!=null && row["Tid"].ToString()!="")
				{
					model.Tid=int.Parse(row["Tid"].ToString());
				}
				if(row["CourseRemainder"]!=null && row["CourseRemainder"].ToString()!="")
				{
					model.CourseRemainder=int.Parse(row["CourseRemainder"].ToString());
				}
				if(row["Period"]!=null)
				{
					model.Period=row["Period"].ToString();
				}
				if(row["Week"]!=null)
				{
					model.Week=row["Week"].ToString();
				}
				if(row["Section"]!=null && row["Section"].ToString()!="")
				{
					model.Section=int.Parse(row["Section"].ToString());
				}
				if(row["SectionCount"]!=null && row["SectionCount"].ToString()!="")
				{
					model.SectionCount=int.Parse(row["SectionCount"].ToString());
				}
				if(row["DistrictId"]!=null && row["DistrictId"].ToString()!="")
				{
					model.DistrictId=int.Parse(row["DistrictId"].ToString());
				}
				if(row["BuildId"]!=null && row["BuildId"].ToString()!="")
				{
					model.BuildId=int.Parse(row["BuildId"].ToString());
				}
				if(row["ClassRoomId"]!=null && row["ClassRoomId"].ToString()!="")
				{
					model.ClassRoomId=int.Parse(row["ClassRoomId"].ToString());
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
			strSql.Append("select Cid,Cno,Tid,CourseRemainder,Period,Week,Section,SectionCount,DistrictId,BuildId,ClassRoomId ");
			strSql.Append(" FROM Teach ");
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
			strSql.Append(" Cid,Cno,Tid,CourseRemainder,Period,Week,Section,SectionCount,DistrictId,BuildId,ClassRoomId ");
			strSql.Append(" FROM Teach ");
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
			strSql.Append("select count(1) FROM Teach ");
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
				strSql.Append("order by T.ClassRoomId desc");
			}
			strSql.Append(")AS Row, T.*  from Teach T ");
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
			parameters[0].Value = "Teach";
			parameters[1].Value = "ClassRoomId";
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

