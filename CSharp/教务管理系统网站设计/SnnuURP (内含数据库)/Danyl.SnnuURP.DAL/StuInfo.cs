using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
	/// <summary>
	/// 数据访问类:StuInfo
	/// </summary>
	public partial class StuInfo
	{
		public StuInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Sid", "StuInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Sid,int StuMajor,int StuClassId,int PlanId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StuInfo");
			strSql.Append(" where Sid=@Sid and StuMajor=@StuMajor and StuClassId=@StuClassId and PlanId=@PlanId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@StuMajor", SqlDbType.Int,4),
					new SqlParameter("@StuClassId", SqlDbType.Int,4),
					new SqlParameter("@PlanId", SqlDbType.Int,4)			};
			parameters[0].Value = Sid;
			parameters[1].Value = StuMajor;
			parameters[2].Value = StuClassId;
			parameters[3].Value = PlanId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Danyl.SnnuURP.Model.StuInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StuInfo(");
			strSql.Append("Sid,Sname,SnameSpell,SnameEnglish,SnameOld,IdNumber,Sex,StuType,StuNationality,StuProvince,StuBirthday,StuPolitical,StuDept,StuZipCode,StuEnrollDate,StuMajor,StuGrade,StuClassId,PlanId,District)");
			strSql.Append(" values (");
			strSql.Append("@Sid,@Sname,@SnameSpell,@SnameEnglish,@SnameOld,@IdNumber,@Sex,@StuType,@StuNationality,@StuProvince,@StuBirthday,@StuPolitical,@StuDept,@StuZipCode,@StuEnrollDate,@StuMajor,@StuGrade,@StuClassId,@PlanId,@District)");
			SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@Sname", SqlDbType.NVarChar,30),
					new SqlParameter("@SnameSpell", SqlDbType.VarChar,45),
					new SqlParameter("@SnameEnglish", SqlDbType.VarChar,45),
					new SqlParameter("@SnameOld", SqlDbType.NVarChar,45),
					new SqlParameter("@IdNumber", SqlDbType.VarChar,45),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@StuType", SqlDbType.NVarChar,45),
					new SqlParameter("@StuNationality", SqlDbType.NVarChar,20),
					new SqlParameter("@StuProvince", SqlDbType.NVarChar,45),
					new SqlParameter("@StuBirthday", SqlDbType.Date,3),
					new SqlParameter("@StuPolitical", SqlDbType.NVarChar,45),
					new SqlParameter("@StuDept", SqlDbType.Int,4),
					new SqlParameter("@StuZipCode", SqlDbType.VarChar,45),
					new SqlParameter("@StuEnrollDate", SqlDbType.Date,3),
					new SqlParameter("@StuMajor", SqlDbType.Int,4),
					new SqlParameter("@StuGrade", SqlDbType.Int,4),
					new SqlParameter("@StuClassId", SqlDbType.Int,4),
					new SqlParameter("@PlanId", SqlDbType.Int,4),
					new SqlParameter("@District", SqlDbType.NVarChar,45)};
			parameters[0].Value = model.Sid;
			parameters[1].Value = model.Sname;
			parameters[2].Value = model.SnameSpell;
			parameters[3].Value = model.SnameEnglish;
			parameters[4].Value = model.SnameOld;
			parameters[5].Value = model.IdNumber;
			parameters[6].Value = model.Sex;
			parameters[7].Value = model.StuType;
			parameters[8].Value = model.StuNationality;
			parameters[9].Value = model.StuProvince;
			parameters[10].Value = model.StuBirthday;
			parameters[11].Value = model.StuPolitical;
			parameters[12].Value = model.StuDept;
			parameters[13].Value = model.StuZipCode;
			parameters[14].Value = model.StuEnrollDate;
			parameters[15].Value = model.StuMajor;
			parameters[16].Value = model.StuGrade;
			parameters[17].Value = model.StuClassId;
			parameters[18].Value = model.PlanId;
			parameters[19].Value = model.District;

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
		public bool Update(Danyl.SnnuURP.Model.StuInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StuInfo set ");
			strSql.Append("Sname=@Sname,");
			strSql.Append("SnameSpell=@SnameSpell,");
			strSql.Append("SnameEnglish=@SnameEnglish,");
			strSql.Append("SnameOld=@SnameOld,");
			strSql.Append("IdNumber=@IdNumber,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("StuType=@StuType,");
			strSql.Append("StuNationality=@StuNationality,");
			strSql.Append("StuProvince=@StuProvince,");
			strSql.Append("StuBirthday=@StuBirthday,");
			strSql.Append("StuPolitical=@StuPolitical,");
			strSql.Append("StuDept=@StuDept,");
			strSql.Append("StuZipCode=@StuZipCode,");
			strSql.Append("StuEnrollDate=@StuEnrollDate,");
			strSql.Append("StuGrade=@StuGrade,");
			strSql.Append("District=@District");
			strSql.Append(" where Sid=@Sid and StuMajor=@StuMajor and StuClassId=@StuClassId and PlanId=@PlanId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sname", SqlDbType.NVarChar,30),
					new SqlParameter("@SnameSpell", SqlDbType.VarChar,45),
					new SqlParameter("@SnameEnglish", SqlDbType.VarChar,45),
					new SqlParameter("@SnameOld", SqlDbType.NVarChar,45),
					new SqlParameter("@IdNumber", SqlDbType.VarChar,45),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@StuType", SqlDbType.NVarChar,45),
					new SqlParameter("@StuNationality", SqlDbType.NVarChar,20),
					new SqlParameter("@StuProvince", SqlDbType.NVarChar,45),
					new SqlParameter("@StuBirthday", SqlDbType.Date,3),
					new SqlParameter("@StuPolitical", SqlDbType.NVarChar,45),
					new SqlParameter("@StuDept", SqlDbType.Int,4),
					new SqlParameter("@StuZipCode", SqlDbType.VarChar,45),
					new SqlParameter("@StuEnrollDate", SqlDbType.Date,3),
					new SqlParameter("@StuGrade", SqlDbType.Int,4),
					new SqlParameter("@District", SqlDbType.NVarChar,45),
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@StuMajor", SqlDbType.Int,4),
					new SqlParameter("@StuClassId", SqlDbType.Int,4),
					new SqlParameter("@PlanId", SqlDbType.Int,4)};
			parameters[0].Value = model.Sname;
			parameters[1].Value = model.SnameSpell;
			parameters[2].Value = model.SnameEnglish;
			parameters[3].Value = model.SnameOld;
			parameters[4].Value = model.IdNumber;
			parameters[5].Value = model.Sex;
			parameters[6].Value = model.StuType;
			parameters[7].Value = model.StuNationality;
			parameters[8].Value = model.StuProvince;
			parameters[9].Value = model.StuBirthday;
			parameters[10].Value = model.StuPolitical;
			parameters[11].Value = model.StuDept;
			parameters[12].Value = model.StuZipCode;
			parameters[13].Value = model.StuEnrollDate;
			parameters[14].Value = model.StuGrade;
			parameters[15].Value = model.District;
			parameters[16].Value = model.Sid;
			parameters[17].Value = model.StuMajor;
			parameters[18].Value = model.StuClassId;
			parameters[19].Value = model.PlanId;

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
		public bool Delete(int Sid,int StuMajor,int StuClassId,int PlanId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StuInfo ");
			strSql.Append(" where Sid=@Sid and StuMajor=@StuMajor and StuClassId=@StuClassId and PlanId=@PlanId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@StuMajor", SqlDbType.Int,4),
					new SqlParameter("@StuClassId", SqlDbType.Int,4),
					new SqlParameter("@PlanId", SqlDbType.Int,4)			};
			parameters[0].Value = Sid;
			parameters[1].Value = StuMajor;
			parameters[2].Value = StuClassId;
			parameters[3].Value = PlanId;

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
		public Danyl.SnnuURP.Model.StuInfo GetModel(int Sid,int StuMajor,int StuClassId,int PlanId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Sid,Sname,SnameSpell,SnameEnglish,SnameOld,IdNumber,Sex,StuType,StuNationality,StuProvince,StuBirthday,StuPolitical,StuDept,StuZipCode,StuEnrollDate,StuMajor,StuGrade,StuClassId,PlanId,District from StuInfo ");
			strSql.Append(" where Sid=@Sid and StuMajor=@StuMajor and StuClassId=@StuClassId and PlanId=@PlanId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Sid", SqlDbType.Int,4),
					new SqlParameter("@StuMajor", SqlDbType.Int,4),
					new SqlParameter("@StuClassId", SqlDbType.Int,4),
					new SqlParameter("@PlanId", SqlDbType.Int,4)			};
			parameters[0].Value = Sid;
			parameters[1].Value = StuMajor;
			parameters[2].Value = StuClassId;
			parameters[3].Value = PlanId;

			Danyl.SnnuURP.Model.StuInfo model=new Danyl.SnnuURP.Model.StuInfo();
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
		public Danyl.SnnuURP.Model.StuInfo DataRowToModel(DataRow row)
		{
			Danyl.SnnuURP.Model.StuInfo model=new Danyl.SnnuURP.Model.StuInfo();
			if (row != null)
			{
				if(row["Sid"]!=null && row["Sid"].ToString()!="")
				{
					model.Sid=int.Parse(row["Sid"].ToString());
				}
				if(row["Sname"]!=null)
				{
					model.Sname=row["Sname"].ToString();
				}
				if(row["SnameSpell"]!=null)
				{
					model.SnameSpell=row["SnameSpell"].ToString();
				}
				if(row["SnameEnglish"]!=null)
				{
					model.SnameEnglish=row["SnameEnglish"].ToString();
				}
				if(row["SnameOld"]!=null)
				{
					model.SnameOld=row["SnameOld"].ToString();
				}
				if(row["IdNumber"]!=null)
				{
					model.IdNumber=row["IdNumber"].ToString();
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
				if(row["StuType"]!=null)
				{
					model.StuType=row["StuType"].ToString();
				}
				if(row["StuNationality"]!=null)
				{
					model.StuNationality=row["StuNationality"].ToString();
				}
				if(row["StuProvince"]!=null)
				{
					model.StuProvince=row["StuProvince"].ToString();
				}
				if(row["StuBirthday"]!=null && row["StuBirthday"].ToString()!="")
				{
					model.StuBirthday=DateTime.Parse(row["StuBirthday"].ToString());
				}
				if(row["StuPolitical"]!=null)
				{
					model.StuPolitical=row["StuPolitical"].ToString();
				}
				if(row["StuDept"]!=null && row["StuDept"].ToString()!="")
				{
					model.StuDept=int.Parse(row["StuDept"].ToString());
				}
				if(row["StuZipCode"]!=null)
				{
					model.StuZipCode=row["StuZipCode"].ToString();
				}
				if(row["StuEnrollDate"]!=null && row["StuEnrollDate"].ToString()!="")
				{
					model.StuEnrollDate=DateTime.Parse(row["StuEnrollDate"].ToString());
				}
				if(row["StuMajor"]!=null && row["StuMajor"].ToString()!="")
				{
					model.StuMajor=int.Parse(row["StuMajor"].ToString());
				}
				if(row["StuGrade"]!=null && row["StuGrade"].ToString()!="")
				{
					model.StuGrade=int.Parse(row["StuGrade"].ToString());
				}
				if(row["StuClassId"]!=null && row["StuClassId"].ToString()!="")
				{
					model.StuClassId=int.Parse(row["StuClassId"].ToString());
				}
				if(row["PlanId"]!=null && row["PlanId"].ToString()!="")
				{
					model.PlanId=int.Parse(row["PlanId"].ToString());
				}
				if(row["District"]!=null)
				{
					model.District=row["District"].ToString();
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
			strSql.Append("select Sid,Sname,SnameSpell,SnameEnglish,SnameOld,IdNumber,Sex,StuType,StuNationality,StuProvince,StuBirthday,StuPolitical,StuDept,StuZipCode,StuEnrollDate,StuMajor,StuGrade,StuClassId,PlanId,District ");
			strSql.Append(" FROM StuInfo ");
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
			strSql.Append(" Sid,Sname,SnameSpell,SnameEnglish,SnameOld,IdNumber,Sex,StuType,StuNationality,StuProvince,StuBirthday,StuPolitical,StuDept,StuZipCode,StuEnrollDate,StuMajor,StuGrade,StuClassId,PlanId,District ");
			strSql.Append(" FROM StuInfo ");
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
			strSql.Append("select count(1) FROM StuInfo ");
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
				strSql.Append("order by T.PlanId desc");
			}
			strSql.Append(")AS Row, T.*  from StuInfo T ");
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
			parameters[0].Value = "StuInfo";
			parameters[1].Value = "PlanId";
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

