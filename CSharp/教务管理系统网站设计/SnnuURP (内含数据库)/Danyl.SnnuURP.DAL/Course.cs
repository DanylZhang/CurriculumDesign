using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:Course
	/// </summary>
	public partial class Course
	{
		public Course()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Cid", "Course"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Cid,int DeptId,int CourseCategory)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Course");
			strSql.Append(" where Cid=@Cid and DeptId=@DeptId and CourseCategory=@CourseCategory ");
			SqlParameter[] parameters = {
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@DeptId", SqlDbType.Int,4),
					new SqlParameter("@CourseCategory", SqlDbType.Int,4)			};
			parameters[0].Value = Cid;
			parameters[1].Value = DeptId;
			parameters[2].Value = CourseCategory;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.Course model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Course(");
			strSql.Append("Cid,Cname,CnameEnglish,DeptId,Years,Semaster,CourseAttribute,CourseCategory,Credit,TextBook,Hours,WeekHours)");
			strSql.Append(" values (");
			strSql.Append("@Cid,@Cname,@CnameEnglish,@DeptId,@Years,@Semaster,@CourseAttribute,@CourseCategory,@Credit,@TextBook,@Hours,@WeekHours)");
			SqlParameter[] parameters = {
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@Cname", SqlDbType.NVarChar,30),
					new SqlParameter("@CnameEnglish", SqlDbType.VarChar,45),
					new SqlParameter("@DeptId", SqlDbType.Int,4),
					new SqlParameter("@Years", SqlDbType.Date,3),
					new SqlParameter("@Semaster", SqlDbType.Int,4),
					new SqlParameter("@CourseAttribute", SqlDbType.VarChar,45),
					new SqlParameter("@CourseCategory", SqlDbType.Int,4),
					new SqlParameter("@Credit", SqlDbType.Float,8),
					new SqlParameter("@TextBook", SqlDbType.NVarChar,50),
					new SqlParameter("@Hours", SqlDbType.Int,4),
					new SqlParameter("@WeekHours", SqlDbType.Int,4)};
			parameters[0].Value = model.Cid;
			parameters[1].Value = model.Cname;
			parameters[2].Value = model.CnameEnglish;
			parameters[3].Value = model.DeptId;
			parameters[4].Value = model.Years;
			parameters[5].Value = model.Semaster;
			parameters[6].Value = model.CourseAttribute;
			parameters[7].Value = model.CourseCategory;
			parameters[8].Value = model.Credit;
			parameters[9].Value = model.TextBook;
			parameters[10].Value = model.Hours;
			parameters[11].Value = model.WeekHours;

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
		public bool Update(Danyl.SnnuURP.Model.Course model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Course set ");
			strSql.Append("Cname=@Cname,");
			strSql.Append("CnameEnglish=@CnameEnglish,");
			strSql.Append("Years=@Years,");
			strSql.Append("Semaster=@Semaster,");
			strSql.Append("CourseAttribute=@CourseAttribute,");
			strSql.Append("Credit=@Credit,");
			strSql.Append("TextBook=@TextBook,");
			strSql.Append("Hours=@Hours,");
			strSql.Append("WeekHours=@WeekHours");
			strSql.Append(" where Cid=@Cid and DeptId=@DeptId and CourseCategory=@CourseCategory ");
			SqlParameter[] parameters = {
					new SqlParameter("@Cname", SqlDbType.NVarChar,30),
					new SqlParameter("@CnameEnglish", SqlDbType.VarChar,45),
					new SqlParameter("@Years", SqlDbType.Date,3),
					new SqlParameter("@Semaster", SqlDbType.Int,4),
					new SqlParameter("@CourseAttribute", SqlDbType.VarChar,45),
					new SqlParameter("@Credit", SqlDbType.Float,8),
					new SqlParameter("@TextBook", SqlDbType.NVarChar,50),
					new SqlParameter("@Hours", SqlDbType.Int,4),
					new SqlParameter("@WeekHours", SqlDbType.Int,4),
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@DeptId", SqlDbType.Int,4),
					new SqlParameter("@CourseCategory", SqlDbType.Int,4)};
			parameters[0].Value = model.Cname;
			parameters[1].Value = model.CnameEnglish;
			parameters[2].Value = model.Years;
			parameters[3].Value = model.Semaster;
			parameters[4].Value = model.CourseAttribute;
			parameters[5].Value = model.Credit;
			parameters[6].Value = model.TextBook;
			parameters[7].Value = model.Hours;
			parameters[8].Value = model.WeekHours;
			parameters[9].Value = model.Cid;
			parameters[10].Value = model.DeptId;
			parameters[11].Value = model.CourseCategory;

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
		public bool Delete(int Cid,int DeptId,int CourseCategory)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Course ");
			strSql.Append(" where Cid=@Cid and DeptId=@DeptId and CourseCategory=@CourseCategory ");
			SqlParameter[] parameters = {
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@DeptId", SqlDbType.Int,4),
					new SqlParameter("@CourseCategory", SqlDbType.Int,4)			};
			parameters[0].Value = Cid;
			parameters[1].Value = DeptId;
			parameters[2].Value = CourseCategory;

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
		public Danyl.SnnuURP.Model.Course GetModel(int Cid,int DeptId,int CourseCategory)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Cid,Cname,CnameEnglish,DeptId,Years,Semaster,CourseAttribute,CourseCategory,Credit,TextBook,Hours,WeekHours from Course ");
			strSql.Append(" where Cid=@Cid and DeptId=@DeptId and CourseCategory=@CourseCategory ");
			SqlParameter[] parameters = {
					new SqlParameter("@Cid", SqlDbType.Int,4),
					new SqlParameter("@DeptId", SqlDbType.Int,4),
					new SqlParameter("@CourseCategory", SqlDbType.Int,4)			};
			parameters[0].Value = Cid;
			parameters[1].Value = DeptId;
			parameters[2].Value = CourseCategory;

			Danyl.SnnuURP.Model.Course model=new Danyl.SnnuURP.Model.Course();
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
		public Danyl.SnnuURP.Model.Course DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.Course model=new Danyl.SnnuURP.Model.Course();
			if (row != null)
			{
				if(row["Cid"]!=null && row["Cid"].ToString()!="")
				{
					model.Cid=int.Parse(row["Cid"].ToString());
				}
				if(row["Cname"]!=null)
				{
					model.Cname=row["Cname"].ToString();
				}
				if(row["CnameEnglish"]!=null)
				{
					model.CnameEnglish=row["CnameEnglish"].ToString();
				}
				if(row["DeptId"]!=null && row["DeptId"].ToString()!="")
				{
					model.DeptId=int.Parse(row["DeptId"].ToString());
				}
				if(row["Years"]!=null && row["Years"].ToString()!="")
				{
					model.Years=DateTime.Parse(row["Years"].ToString());
				}
				if(row["Semaster"]!=null && row["Semaster"].ToString()!="")
				{
					model.Semaster=int.Parse(row["Semaster"].ToString());
				}
				if(row["CourseAttribute"]!=null)
				{
					model.CourseAttribute=row["CourseAttribute"].ToString();
				}
				if(row["CourseCategory"]!=null && row["CourseCategory"].ToString()!="")
				{
					model.CourseCategory=int.Parse(row["CourseCategory"].ToString());
				}
				if(row["Credit"]!=null && row["Credit"].ToString()!="")
				{
					model.Credit=decimal.Parse(row["Credit"].ToString());
				}
				if(row["TextBook"]!=null)
				{
					model.TextBook=row["TextBook"].ToString();
				}
				if(row["Hours"]!=null && row["Hours"].ToString()!="")
				{
					model.Hours=int.Parse(row["Hours"].ToString());
				}
				if(row["WeekHours"]!=null && row["WeekHours"].ToString()!="")
				{
					model.WeekHours=int.Parse(row["WeekHours"].ToString());
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
			strSql.Append("select Cid,Cname,CnameEnglish,DeptId,Years,Semaster,CourseAttribute,CourseCategory,Credit,TextBook,Hours,WeekHours ");
			strSql.Append(" FROM Course ");
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
			strSql.Append(" Cid,Cname,CnameEnglish,DeptId,Years,Semaster,CourseAttribute,CourseCategory,Credit,TextBook,Hours,WeekHours ");
			strSql.Append(" FROM Course ");
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
			strSql.Append("select count(1) FROM Course ");
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
				strSql.Append("order by T.CourseCategory desc");
			}
			strSql.Append(")AS Row, T.*  from Course T ");
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
			parameters[0].Value = "Course";
			parameters[1].Value = "CourseCategory";
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

