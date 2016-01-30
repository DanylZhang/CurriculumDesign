using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
    /// <summary>
    /// 数据访问类:UserInfo
    /// </summary>
    public partial class UserInfo
    {
        public UserInfo()
        {}

        #region  BasicMethod
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Uid", "UserInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserInfo");
            strSql.Append(" where Uid=@Uid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Uid", SqlDbType.Int,4)           };
            parameters[0].Value = Uid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Danyl.SnnuURP.Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserInfo(");
            strSql.Append("Uid,Uname,Pwd,UserType,UserPhone,UserEmail)");
            strSql.Append(" values (");
            strSql.Append("@Uid,@Uname,@Pwd,@UserType,@UserPhone,@UserEmail)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Uid", SqlDbType.Int,4),
                    new SqlParameter("@Uname", SqlDbType.NVarChar,45),
                    new SqlParameter("@Pwd", SqlDbType.VarChar,45),
                    new SqlParameter("@UserType", SqlDbType.Int,4),
                    new SqlParameter("@UserPhone", SqlDbType.VarChar,45),
                    new SqlParameter("@UserEmail", SqlDbType.VarChar,45)};
            parameters[0].Value = model.Uid;
            parameters[1].Value = model.Uname;
            parameters[2].Value = model.Pwd;
            parameters[3].Value = model.UserType;
            parameters[4].Value = model.UserPhone;
            parameters[5].Value = model.UserEmail;

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
        public bool Update(Danyl.SnnuURP.Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ");
            strSql.Append("Uname=@Uname,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("UserType=@UserType,");
            strSql.Append("UserPhone=@UserPhone,");
            strSql.Append("UserEmail=@UserEmail");
            strSql.Append(" where Uid=@Uid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Uname", SqlDbType.NVarChar,45),
                    new SqlParameter("@Pwd", SqlDbType.VarChar,45),
                    new SqlParameter("@UserType", SqlDbType.Int,4),
                    new SqlParameter("@UserPhone", SqlDbType.VarChar,45),
                    new SqlParameter("@UserEmail", SqlDbType.VarChar,45),
                    new SqlParameter("@Uid", SqlDbType.Int,4)};
            parameters[0].Value = model.Uname;
            parameters[1].Value = model.Pwd;
            parameters[2].Value = model.UserType;
            parameters[3].Value = model.UserPhone;
            parameters[4].Value = model.UserEmail;
            parameters[5].Value = model.Uid;

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
        public bool Delete(int Uid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserInfo ");
            strSql.Append(" where Uid=@Uid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Uid", SqlDbType.Int,4)           };
            parameters[0].Value = Uid;

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
        public bool DeleteList(string Uidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserInfo ");
            strSql.Append(" where Uid in (" + Uidlist + ")  ");
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
        public Danyl.SnnuURP.Model.UserInfo GetModel(int Uid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Uid,Uname,Pwd,UserType,UserPhone,UserEmail from UserInfo ");
            strSql.Append(" where Uid=@Uid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Uid", SqlDbType.Int,4)           };
            parameters[0].Value = Uid;

            Danyl.SnnuURP.Model.UserInfo model = new Danyl.SnnuURP.Model.UserInfo();
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
        public Danyl.SnnuURP.Model.UserInfo DataRowToModel(DataRow row)
        {
            Danyl.SnnuURP.Model.UserInfo model = new Danyl.SnnuURP.Model.UserInfo();
            if (row != null)
            {
                if (row["Uid"] != null && row["Uid"].ToString() != "")
                {
                    model.Uid = int.Parse(row["Uid"].ToString());
                }
                if (row["Uname"] != null)
                {
                    model.Uname = row["Uname"].ToString();
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["UserType"] != null && row["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(row["UserType"].ToString());
                }
                if (row["UserPhone"] != null)
                {
                    model.UserPhone = row["UserPhone"].ToString();
                }
                if (row["UserEmail"] != null)
                {
                    model.UserEmail = row["UserEmail"].ToString();
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
            strSql.Append("select Uid,Uname,Pwd,UserType,UserPhone,UserEmail ");
            strSql.Append(" FROM UserInfo ");
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
            strSql.Append(" Uid,Uname,Pwd,UserType,UserPhone,UserEmail ");
            strSql.Append(" FROM UserInfo ");
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
            strSql.Append("select count(1) FROM UserInfo ");
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
                strSql.Append("order by T.Uid desc");
            }
            strSql.Append(")AS Row, T.*  from UserInfo T ");
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
			parameters[0].Value = "UserInfo";
			parameters[1].Value = "Uid";
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