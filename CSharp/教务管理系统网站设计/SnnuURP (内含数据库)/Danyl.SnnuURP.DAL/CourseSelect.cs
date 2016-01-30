using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:CourseSelect
	/// </summary>
	public partial class CourseSelect
	{
		public CourseSelect()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Sid", "CourseSelect"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Sid,int Cid,int Cno)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CourseSelect");
			strSql.Append(" where Sid=@Sid and Cid=@Cid and Cno=@Cno ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@Cno", SqlDbType.Int,4)			};
			parameters[0].Value = Sid;
			parameters[1].Value = Cid;
			parameters[2].Value = Cno;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.CourseSelect model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CourseSelect(");
			strSql.Append("Sid,Cid,Cno,SelectStatus,UsualScore,MidtermScore,FinalExamScore,TotalScore)");
			strSql.Append(" values (");
			strSql.Append("@Sid,@Cid,@Cno,@SelectStatus,@UsualScore,@MidtermScore,@FinalExamScore,@TotalScore)");
			SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@Cno", SqlDbType.Int,4),
					new SqlParameter("@SelectStatus", SqlDbType.VarChar,45),
					new SqlParameter("@UsualScore", SqlDbType.Int,4),
					new SqlParameter("@MidtermScore", SqlDbType.Int,4),
					new SqlParameter("@FinalExamScore", SqlDbType.Int,4),
					new SqlParameter("@TotalScore", SqlDbType.Int,4)};
			parameters[0].Value = model.Sid;
			parameters[1].Value = model.Cid;
			parameters[2].Value = model.Cno;
			parameters[3].Value = model.SelectStatus;
			parameters[4].Value = model.UsualScore;
			parameters[5].Value = model.MidtermScore;
			parameters[6].Value = model.FinalExamScore;
			parameters[7].Value = model.TotalScore;

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
		public bool Update(Danyl.SnnuURP.Model.CourseSelect model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CourseSelect set ");
			strSql.Append("SelectStatus=@SelectStatus,");
			strSql.Append("UsualScore=@UsualScore,");
			strSql.Append("MidtermScore=@MidtermScore,");
			strSql.Append("FinalExamScore=@FinalExamScore,");
			strSql.Append("TotalScore=@TotalScore");
			strSql.Append(" where Sid=@Sid and Cid=@Cid and Cno=@Cno ");
			SqlParameter[] parameters = {
					new SqlParameter("@SelectStatus", SqlDbType.VarChar,45),
					new SqlParameter("@UsualScore", SqlDbType.Int,4),
					new SqlParameter("@MidtermScore", SqlDbType.Int,4),
					new SqlParameter("@FinalExamScore", SqlDbType.Int,4),
					new SqlParameter("@TotalScore", SqlDbType.Int,4),
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@Cno", SqlDbType.Int,4)};
			parameters[0].Value = model.SelectStatus;
			parameters[1].Value = model.UsualScore;
			parameters[2].Value = model.MidtermScore;
			parameters[3].Value = model.FinalExamScore;
			parameters[4].Value = model.TotalScore;
			parameters[5].Value = model.Sid;
			parameters[6].Value = model.Cid;
			parameters[7].Value = model.Cno;

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
		public bool Delete(int Sid,int Cid,int Cno)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseSelect ");
			strSql.Append(" where Sid=@Sid and Cid=@Cid and Cno=@Cno ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@Cno", SqlDbType.Int,4)			};
			parameters[0].Value = Sid;
			parameters[1].Value = Cid;
			parameters[2].Value = Cno;

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
		public Danyl.SnnuURP.Model.CourseSelect GetModel(int Sid,int Cid,int Cno)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Sid,Cid,Cno,SelectStatus,UsualScore,MidtermScore,FinalExamScore,TotalScore from CourseSelect ");
			strSql.Append(" where Sid=@Sid and Cid=@Cid and Cno=@Cno ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@Cno", SqlDbType.Int,4)			};
			parameters[0].Value = Sid;
			parameters[1].Value = Cid;
			parameters[2].Value = Cno;

			Danyl.SnnuURP.Model.CourseSelect model=new Danyl.SnnuURP.Model.CourseSelect();
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
		public Danyl.SnnuURP.Model.CourseSelect DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.CourseSelect model=new Danyl.SnnuURP.Model.CourseSelect();
			if (row != null)
			{
				if(row["Sid"]!=null && row["Sid"].ToString()!="")
				{
					model.Sid=int.Parse(row["Sid"].ToString());
				}
				if(row["Cid"]!=null && row["Cid"].ToString()!="")
				{
					model.Cid=int.Parse(row["Cid"].ToString());
				}
				if(row["Cno"]!=null && row["Cno"].ToString()!="")
				{
					model.Cno=int.Parse(row["Cno"].ToString());
				}
				if(row["SelectStatus"]!=null)
				{
					model.SelectStatus=row["SelectStatus"].ToString();
				}
				if(row["UsualScore"]!=null && row["UsualScore"].ToString()!="")
				{
					model.UsualScore=int.Parse(row["UsualScore"].ToString());
				}
				if(row["MidtermScore"]!=null && row["MidtermScore"].ToString()!="")
				{
					model.MidtermScore=int.Parse(row["MidtermScore"].ToString());
				}
				if(row["FinalExamScore"]!=null && row["FinalExamScore"].ToString()!="")
				{
					model.FinalExamScore=int.Parse(row["FinalExamScore"].ToString());
				}
				if(row["TotalScore"]!=null && row["TotalScore"].ToString()!="")
				{
					model.TotalScore=int.Parse(row["TotalScore"].ToString());
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
			strSql.Append("select Sid,Cid,Cno,SelectStatus,UsualScore,MidtermScore,FinalExamScore,TotalScore ");
			strSql.Append(" FROM CourseSelect ");
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
			strSql.Append(" Sid,Cid,Cno,SelectStatus,UsualScore,MidtermScore,FinalExamScore,TotalScore ");
			strSql.Append(" FROM CourseSelect ");
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
			strSql.Append("select count(1) FROM CourseSelect ");
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
				strSql.Append("order by T.Cno desc");
			}
			strSql.Append(")AS Row, T.*  from CourseSelect T ");
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
			parameters[0].Value = "CourseSelect";
			parameters[1].Value = "Cno";
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

