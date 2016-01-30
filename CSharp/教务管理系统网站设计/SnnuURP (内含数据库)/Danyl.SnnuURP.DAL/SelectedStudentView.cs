using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:SelectedStudentView
	/// </summary>
	public partial class SelectedStudentView
	{
		public SelectedStudentView()
		{}

		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.SelectedStudentView model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SelectedStudentView(");
			strSql.Append("Tid,Sid,Sname,Sex,MajorName,DeptName,Years,Semaster)");
			strSql.Append(" values (");
			strSql.Append("@Tid,@Sid,@Sname,@Sex,@MajorName,@DeptName,@Years,@Semaster)");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@Sname", SqlDbType.NVarChar,30),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@MajorName", SqlDbType.NVarChar,30),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,30),
					new SqlParameter("@Years", SqlDbType.Date,3),
					new SqlParameter("@Semaster", SqlDbType.Int,4)};
			parameters[0].Value = model.Tid;
			parameters[1].Value = model.Sid;
			parameters[2].Value = model.Sname;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.MajorName;
			parameters[5].Value = model.DeptName;
			parameters[6].Value = model.Years;
			parameters[7].Value = model.Semaster;

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
		public bool Update(Danyl.SnnuURP.Model.SelectedStudentView model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SelectedStudentView set ");
			strSql.Append("Tid=@Tid,");
			strSql.Append("Sid=@Sid,");
			strSql.Append("Sname=@Sname,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("MajorName=@MajorName,");
			strSql.Append("DeptName=@DeptName,");
			strSql.Append("Years=@Years,");
			strSql.Append("Semaster=@Semaster");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@Tid", SqlDbType.Int,4),
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@Sname", SqlDbType.NVarChar,30),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@MajorName", SqlDbType.NVarChar,30),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,30),
					new SqlParameter("@Years", SqlDbType.Date,3),
					new SqlParameter("@Semaster", SqlDbType.Int,4)};
			parameters[0].Value = model.Tid;
			parameters[1].Value = model.Sid;
			parameters[2].Value = model.Sname;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.MajorName;
			parameters[5].Value = model.DeptName;
			parameters[6].Value = model.Years;
			parameters[7].Value = model.Semaster;

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
		public bool Delete(string strWhere)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SelectedStudentView ");
			strSql.Append(" where stwhere");
			SqlParameter[] parameters = {
			};

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
		public Danyl.SnnuURP.Model.SelectedStudentView GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Tid,Sid,Sname,Sex,MajorName,DeptName,Years,Semaster from SelectedStudentView ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Danyl.SnnuURP.Model.SelectedStudentView model=new Danyl.SnnuURP.Model.SelectedStudentView();
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
		public Danyl.SnnuURP.Model.SelectedStudentView DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.SelectedStudentView model=new Danyl.SnnuURP.Model.SelectedStudentView();
			if (row != null)
			{
				if(row["Tid"]!=null && row["Tid"].ToString()!="")
				{
					model.Tid=int.Parse(row["Tid"].ToString());
				}
				if(row["Sid"]!=null && row["Sid"].ToString()!="")
				{
					model.Sid=int.Parse(row["Sid"].ToString());
				}
				if(row["Sname"]!=null)
				{
					model.Sname=row["Sname"].ToString();
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
				if(row["MajorName"]!=null)
				{
					model.MajorName=row["MajorName"].ToString();
				}
				if(row["DeptName"]!=null)
				{
					model.DeptName=row["DeptName"].ToString();
				}
				if(row["Years"]!=null && row["Years"].ToString()!="")
				{
					model.Years=DateTime.Parse(row["Years"].ToString());
				}
				if(row["Semaster"]!=null && row["Semaster"].ToString()!="")
				{
					model.Semaster=int.Parse(row["Semaster"].ToString());
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
			strSql.Append("select Tid,Sid,Sname,Sex,MajorName,DeptName,Years,Semaster ");
			strSql.Append(" FROM SelectedStudentView ");
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
			strSql.Append(" Tid,Sid,Sname,Sex,MajorName,DeptName,Years,Semaster ");
			strSql.Append(" FROM SelectedStudentView ");
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
			strSql.Append("select count(1) FROM SelectedStudentView ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from SelectedStudentView T ");
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
			parameters[0].Value = "SelectedStudentView";
			parameters[1].Value = "";
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