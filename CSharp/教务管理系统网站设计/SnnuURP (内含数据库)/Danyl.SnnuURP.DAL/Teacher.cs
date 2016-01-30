using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:Teacher
	/// </summary>
	public partial class Teacher
	{
		public Teacher()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Tid", "Teacher"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Tid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Teacher");
			strSql.Append(" where Tid=@Tid");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4)};
			parameters[0].Value = Tid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.Teacher model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Teacher(");
			strSql.Append("Tid,Tname,Sex,IdNumber,DeptId,TeacherTypeId,Degree)");
			strSql.Append(" values (");
			strSql.Append("@Tid,@Tname,@Sex,@IdNumber,@DeptId,@TeacherTypeId,@Degree)");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@Tname", SqlDbType.NVarChar,30),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@IdNumber", SqlDbType.VarChar,45),
					new SqlParameter("@DeptId", SqlDbType.Int,4),
					new SqlParameter("@TeacherTypeId", SqlDbType.Int,4),
					new SqlParameter("@Degree", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.Tid;
			parameters[1].Value = model.Tname;
			parameters[2].Value = model.Sex;
			parameters[3].Value = model.IdNumber;
			parameters[4].Value = model.DeptId;
			parameters[5].Value = model.TeacherTypeId;
			parameters[6].Value = model.Degree;

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
		public bool Update(Danyl.SnnuURP.Model.Teacher model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Teacher set ");
			strSql.Append("Tname=@Tname,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("IdNumber=@IdNumber,");
			strSql.Append("Degree=@Degree");
			strSql.Append(" where Tid=@Tid and DeptId=@DeptId and TeacherTypeId=@TeacherTypeId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Tname", SqlDbType.NVarChar,30),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@IdNumber", SqlDbType.VarChar,45),
					new SqlParameter("@Degree", SqlDbType.NVarChar,20),
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@DeptId", SqlDbType.Int,4),
					new SqlParameter("@TeacherTypeId", SqlDbType.Int,4)};
			parameters[0].Value = model.Tname;
			parameters[1].Value = model.Sex;
			parameters[2].Value = model.IdNumber;
			parameters[3].Value = model.Degree;
			parameters[4].Value = model.Tid;
			parameters[5].Value = model.DeptId;
			parameters[6].Value = model.TeacherTypeId;

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
		public bool Delete(int Tid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Teacher ");
			strSql.Append(" where Tid=@Tid");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4)};
			parameters[0].Value = Tid;

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
		public Danyl.SnnuURP.Model.Teacher GetModel(int Tid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Tid,Tname,Sex,IdNumber,DeptId,TeacherTypeId,Degree from Teacher ");
			strSql.Append(" where Tid=@Tid");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4)};
			parameters[0].Value = Tid;

			Danyl.SnnuURP.Model.Teacher model=new Danyl.SnnuURP.Model.Teacher();
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
		public Danyl.SnnuURP.Model.Teacher DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.Teacher model=new Danyl.SnnuURP.Model.Teacher();
			if (row != null)
			{
				if(row["Tid"]!=null && row["Tid"].ToString()!="")
				{
					model.Tid=int.Parse(row["Tid"].ToString());
				}
				if(row["Tname"]!=null)
				{
					model.Tname=row["Tname"].ToString();
				}
				if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					if((row["Sex"].ToString()=="1")||(row["Sex"].ToString().ToLower()=="true"))
					{
						model.Sex=true;
					}
					else
					{
						model.Sex=false;
					}
				}
				if(row["IdNumber"]!=null)
				{
					model.IdNumber=row["IdNumber"].ToString();
				}
				if(row["DeptId"]!=null && row["DeptId"].ToString()!="")
				{
					model.DeptId=int.Parse(row["DeptId"].ToString());
				}
				if(row["TeacherTypeId"]!=null && row["TeacherTypeId"].ToString()!="")
				{
					model.TeacherTypeId=int.Parse(row["TeacherTypeId"].ToString());
				}
				if(row["Degree"]!=null)
				{
					model.Degree=row["Degree"].ToString();
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
			strSql.Append("select Tid,Tname,Sex,IdNumber,DeptId,TeacherTypeId,Degree ");
			strSql.Append(" FROM Teacher ");
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
			strSql.Append(" Tid,Tname,Sex,IdNumber,DeptId,TeacherTypeId,Degree ");
			strSql.Append(" FROM Teacher ");
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
			strSql.Append("select count(1) FROM Teacher ");
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
				strSql.Append("order by T.TeacherTypeId desc");
			}
			strSql.Append(")AS Row, T.*  from Teacher T ");
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
			parameters[0].Value = "Teacher";
			parameters[1].Value = "TeacherTypeId";
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

