using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
    /// <summary>
    /// 数据访问类:TeacherWageAdjustmentView
    /// </summary>
    public partial class TeacherWageAdjustmentView
    {
        public TeacherWageAdjustmentView()
        { }

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TeacherWageAdjustmentView");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)            };
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Danyl.SnnuURP.Model.TeacherWageAdjustmentView model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TeacherWageAdjustmentView(");
            strSql.Append("Id,Tid,Tname,Sex,IdNumber,TeacherTypeId,Degree,DeptName,NewSalary,OldSalary,BasicWage,JobSubsidies,PersonalIncomeTax)");
            strSql.Append(" values (");
            strSql.Append("@Id,@Tid,@Tname,@Sex,@IdNumber,@TeacherTypeId,@Degree,@DeptName,@NewSalary,@OldSalary,@BasicWage,@JobSubsidies,@PersonalIncomeTax)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@Tid", SqlDbType.Int,4),
                    new SqlParameter("@Tname", SqlDbType.NVarChar,30),
                    new SqlParameter("@Sex", SqlDbType.Bit,1),
                    new SqlParameter("@IdNumber", SqlDbType.VarChar,45),
                    new SqlParameter("@TeacherTypeId", SqlDbType.Int,4),
                    new SqlParameter("@Degree", SqlDbType.NVarChar,20),
                    new SqlParameter("@DeptName", SqlDbType.NVarChar,30),
                    new SqlParameter("@NewSalary", SqlDbType.Decimal,9),
                    new SqlParameter("@OldSalary", SqlDbType.Decimal,9),
                    new SqlParameter("@BasicWage", SqlDbType.Decimal,9),
                    new SqlParameter("@JobSubsidies", SqlDbType.Decimal,9),
                    new SqlParameter("@PersonalIncomeTax", SqlDbType.VarChar,45)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Tid;
            parameters[2].Value = model.Tname;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.IdNumber;
            parameters[5].Value = model.TeacherTypeId;
            parameters[6].Value = model.Degree;
            parameters[7].Value = model.DeptName;
            parameters[8].Value = model.NewSalary;
            parameters[9].Value = model.OldSalary;
            parameters[10].Value = model.BasicWage;
            parameters[11].Value = model.JobSubsidies;
            parameters[12].Value = model.PersonalIncomeTax;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(Danyl.SnnuURP.Model.TeacherWageAdjustmentView model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TeacherWageAdjustmentView set ");
            strSql.Append("Id=@Id,");
            strSql.Append("Tid=@Tid,");
            strSql.Append("Tname=@Tname,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("IdNumber=@IdNumber,");
            strSql.Append("TeacherTypeId=@TeacherTypeId,");
            strSql.Append("Degree=@Degree,");
            strSql.Append("DeptName=@DeptName,");
            strSql.Append("NewSalary=@NewSalary,");
            strSql.Append("OldSalary=@OldSalary,");
            strSql.Append("BasicWage=@BasicWage,");
            strSql.Append("JobSubsidies=@JobSubsidies,");
            strSql.Append("PersonalIncomeTax=@PersonalIncomeTax");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@Tid", SqlDbType.Int,4),
                    new SqlParameter("@Tname", SqlDbType.NVarChar,30),
                    new SqlParameter("@Sex", SqlDbType.Bit,1),
                    new SqlParameter("@IdNumber", SqlDbType.VarChar,45),
                    new SqlParameter("@TeacherTypeId", SqlDbType.Int,4),
                    new SqlParameter("@Degree", SqlDbType.NVarChar,20),
                    new SqlParameter("@DeptName", SqlDbType.NVarChar,30),
                    new SqlParameter("@NewSalary", SqlDbType.Decimal,9),
                    new SqlParameter("@OldSalary", SqlDbType.Decimal,9),
                    new SqlParameter("@BasicWage", SqlDbType.Decimal,9),
                    new SqlParameter("@JobSubsidies", SqlDbType.Decimal,9),
                    new SqlParameter("@PersonalIncomeTax", SqlDbType.VarChar,45)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Tid;
            parameters[2].Value = model.Tname;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.IdNumber;
            parameters[5].Value = model.TeacherTypeId;
            parameters[6].Value = model.Degree;
            parameters[7].Value = model.DeptName;
            parameters[8].Value = model.NewSalary;
            parameters[9].Value = model.OldSalary;
            parameters[10].Value = model.BasicWage;
            parameters[11].Value = model.JobSubsidies;
            parameters[12].Value = model.PersonalIncomeTax;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TeacherWageAdjustmentView ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)            };
            parameters[0].Value = Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TeacherWageAdjustmentView ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Danyl.SnnuURP.Model.TeacherWageAdjustmentView GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Tid,Tname,Sex,IdNumber,TeacherTypeId,Degree,DeptName,NewSalary,OldSalary,BasicWage,JobSubsidies,PersonalIncomeTax from TeacherWageAdjustmentView ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)            };
            parameters[0].Value = Id;

            Danyl.SnnuURP.Model.TeacherWageAdjustmentView model = new Danyl.SnnuURP.Model.TeacherWageAdjustmentView();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Danyl.SnnuURP.Model.TeacherWageAdjustmentView DataRowToModel(DataRow row)
        {
            Danyl.SnnuURP.Model.TeacherWageAdjustmentView model = new Danyl.SnnuURP.Model.TeacherWageAdjustmentView();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Tid"] != null && row["Tid"].ToString() != "")
                {
                    model.Tid = int.Parse(row["Tid"].ToString());
                }
                if (row["Tname"] != null)
                {
                    model.Tname = row["Tname"].ToString();
                }
                if (row["Sex"] != null && row["Sex"].ToString() != "")
                {
                    if ((row["Sex"].ToString() == "1") || (row["Sex"].ToString().ToLower() == "true"))
                    {
                        model.Sex = true;
                    }
                    else
                    {
                        model.Sex = false;
                    }
                }
                if (row["IdNumber"] != null)
                {
                    model.IdNumber = row["IdNumber"].ToString();
                }
                if (row["TeacherTypeId"] != null && row["TeacherTypeId"].ToString() != "")
                {
                    model.TeacherTypeId = int.Parse(row["TeacherTypeId"].ToString());
                }
                if (row["Degree"] != null)
                {
                    model.Degree = row["Degree"].ToString();
                }
                if (row["DeptName"] != null)
                {
                    model.DeptName = row["DeptName"].ToString();
                }
                if (row["NewSalary"] != null && row["NewSalary"].ToString() != "")
                {
                    model.NewSalary = decimal.Parse(row["NewSalary"].ToString());
                }
                if (row["OldSalary"] != null && row["OldSalary"].ToString() != "")
                {
                    model.OldSalary = decimal.Parse(row["OldSalary"].ToString());
                }
                if (row["BasicWage"] != null && row["BasicWage"].ToString() != "")
                {
                    model.BasicWage = decimal.Parse(row["BasicWage"].ToString());
                }
                if (row["JobSubsidies"] != null && row["JobSubsidies"].ToString() != "")
                {
                    model.JobSubsidies = decimal.Parse(row["JobSubsidies"].ToString());
                }
                if (row["PersonalIncomeTax"] != null)
                {
                    model.PersonalIncomeTax = row["PersonalIncomeTax"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Tid,Tname,Sex,IdNumber,TeacherTypeId,Degree,DeptName,NewSalary,OldSalary,BasicWage,JobSubsidies,PersonalIncomeTax ");
            strSql.Append(" FROM TeacherWageAdjustmentView ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,Tid,Tname,Sex,IdNumber,TeacherTypeId,Degree,DeptName,NewSalary,OldSalary,BasicWage,JobSubsidies,PersonalIncomeTax ");
            strSql.Append(" FROM TeacherWageAdjustmentView ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TeacherWageAdjustmentView ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from TeacherWageAdjustmentView T ");
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
            parameters[0].Value = "TeacherWageAdjustmentView";
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