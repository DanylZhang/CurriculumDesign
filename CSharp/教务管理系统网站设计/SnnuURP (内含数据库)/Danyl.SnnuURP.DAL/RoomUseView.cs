using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
    /// <summary>
    /// 数据访问类:RoomUseView
    /// </summary>
    public partial class RoomUseView
    {
        public RoomUseView()
        {}

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RoomUseView");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)            };
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Danyl.SnnuURP.Model.RoomUseView model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RoomUseView(");
            strSql.Append("Id,Uid,Uname,UserPhone,Rname,RoomType,Capacity,Purpose,UseDate,UseStatus,Rid,UserEmail)");
            strSql.Append(" values (");
            strSql.Append("@Id,@Uid,@Uname,@UserPhone,@Rname,@RoomType,@Capacity,@Purpose,@UseDate,@UseStatus,@Rid,@UserEmail)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@Uid", SqlDbType.VarChar,45),
                    new SqlParameter("@Uname", SqlDbType.NVarChar,45),
                    new SqlParameter("@UserPhone", SqlDbType.VarChar,45),
                    new SqlParameter("@Rname", SqlDbType.NVarChar,20),
                    new SqlParameter("@RoomType", SqlDbType.VarChar,45),
                    new SqlParameter("@Capacity", SqlDbType.Int,4),
                    new SqlParameter("@Purpose", SqlDbType.NVarChar,50),
                    new SqlParameter("@UseDate", SqlDbType.DateTime),
                    new SqlParameter("@UseStatus", SqlDbType.VarChar,45),
                    new SqlParameter("@Rid", SqlDbType.Int,4),
                    new SqlParameter("@UserEmail", SqlDbType.VarChar,45)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Uid;
            parameters[2].Value = model.Uname;
            parameters[3].Value = model.UserPhone;
            parameters[4].Value = model.Rname;
            parameters[5].Value = model.RoomType;
            parameters[6].Value = model.Capacity;
            parameters[7].Value = model.Purpose;
            parameters[8].Value = model.UseDate;
            parameters[9].Value = model.UseStatus;
            parameters[10].Value = model.Rid;
            parameters[11].Value = model.UserEmail;

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
        public bool Update(Danyl.SnnuURP.Model.RoomUseView model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RoomUseView set ");
            strSql.Append("Id=@Id,");
            strSql.Append("Uid=@Uid,");
            strSql.Append("Uname=@Uname,");
            strSql.Append("UserPhone=@UserPhone,");
            strSql.Append("Rname=@Rname,");
            strSql.Append("RoomType=@RoomType,");
            strSql.Append("Capacity=@Capacity,");
            strSql.Append("Purpose=@Purpose,");
            strSql.Append("UseDate=@UseDate,");
            strSql.Append("UseStatus=@UseStatus,");
            strSql.Append("Rid=@Rid,");
            strSql.Append("UserEmail=@UserEmail");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@Uid", SqlDbType.VarChar,45),
                    new SqlParameter("@Uname", SqlDbType.NVarChar,45),
                    new SqlParameter("@UserPhone", SqlDbType.VarChar,45),
                    new SqlParameter("@Rname", SqlDbType.NVarChar,20),
                    new SqlParameter("@RoomType", SqlDbType.VarChar,45),
                    new SqlParameter("@Capacity", SqlDbType.Int,4),
                    new SqlParameter("@Purpose", SqlDbType.NVarChar,50),
                    new SqlParameter("@UseDate", SqlDbType.DateTime),
                    new SqlParameter("@UseStatus", SqlDbType.VarChar,45),
                    new SqlParameter("@Rid", SqlDbType.Int,4),
                    new SqlParameter("@UserEmail", SqlDbType.VarChar,45)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Uid;
            parameters[2].Value = model.Uname;
            parameters[3].Value = model.UserPhone;
            parameters[4].Value = model.Rname;
            parameters[5].Value = model.RoomType;
            parameters[6].Value = model.Capacity;
            parameters[7].Value = model.Purpose;
            parameters[8].Value = model.UseDate;
            parameters[9].Value = model.UseStatus;
            parameters[10].Value = model.Rid;
            parameters[11].Value = model.UserEmail;

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
            strSql.Append("delete from RoomUseView ");
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
            strSql.Append("delete from RoomUseView ");
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
        public Danyl.SnnuURP.Model.RoomUseView GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Uid,Uname,UserPhone,Rname,RoomType,Capacity,Purpose,UseDate,UseStatus,Rid,UserEmail from RoomUseView ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)            };
            parameters[0].Value = Id;

            Danyl.SnnuURP.Model.RoomUseView model = new Danyl.SnnuURP.Model.RoomUseView();
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
        public Danyl.SnnuURP.Model.RoomUseView DataRowToModel(DataRow row)
        {
            Danyl.SnnuURP.Model.RoomUseView model = new Danyl.SnnuURP.Model.RoomUseView();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Uid"] != null)
                {
                    model.Uid = row["Uid"].ToString();
                }
                if (row["Uname"] != null)
                {
                    model.Uname = row["Uname"].ToString();
                }
                if (row["UserPhone"] != null)
                {
                    model.UserPhone = row["UserPhone"].ToString();
                }
                if (row["Rname"] != null)
                {
                    model.Rname = row["Rname"].ToString();
                }
                if (row["RoomType"] != null)
                {
                    model.RoomType = row["RoomType"].ToString();
                }
                if (row["Capacity"] != null && row["Capacity"].ToString() != "")
                {
                    model.Capacity = int.Parse(row["Capacity"].ToString());
                }
                if (row["Purpose"] != null)
                {
                    model.Purpose = row["Purpose"].ToString();
                }
                if (row["UseDate"] != null && row["UseDate"].ToString() != "")
                {
                    model.UseDate = DateTime.Parse(row["UseDate"].ToString());
                }
                if (row["UseStatus"] != null)
                {
                    model.UseStatus = row["UseStatus"].ToString();
                }
                if (row["Rid"] != null && row["Rid"].ToString() != "")
                {
                    model.Rid = int.Parse(row["Rid"].ToString());
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
            strSql.Append("select Id,Uid,Uname,UserPhone,Rname,RoomType,Capacity,Purpose,UseDate,UseStatus,Rid,UserEmail ");
            strSql.Append(" FROM RoomUseView ");
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
            strSql.Append(" Id,Uid,Uname,UserPhone,Rname,RoomType,Capacity,Purpose,UseDate,UseStatus,Rid,UserEmail ");
            strSql.Append(" FROM RoomUseView ");
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
            strSql.Append("select count(1) FROM RoomUseView ");
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
            strSql.Append(")AS Row, T.*  from RoomUseView T ");
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
			parameters[0].Value = "RoomUseView";
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