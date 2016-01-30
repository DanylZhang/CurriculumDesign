using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
    /// <summary>
    /// 数据访问类:TeachCourseView
    /// </summary>
    public partial class TeachCourseView
    {
        public TeachCourseView()
        {}

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Tid, int Cid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TeachCourseView");
            strSql.Append(" where Tid=@Tid and Cid=@Cid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Tid", SqlDbType.Int,4),
                    new SqlParameter("@Cid", SqlDbType.Int,4)           };
            parameters[0].Value = Tid;
            parameters[1].Value = Cid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Danyl.SnnuURP.Model.TeachCourseView model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TeachCourseView(");
            strSql.Append("Tid,Tname,Cid,Cname,DeptId,Years,Semaster,CourseAttribute,Credit,TextBook,Hours,WeekHours,CourseRemainder,Section,Week)");
            strSql.Append(" values (");
            strSql.Append("@Tid,@Tname,@Cid,@Cname,@DeptId,@Years,@Semaster,@CourseAttribute,@Credit,@TextBook,@Hours,@WeekHours,@CourseRemainder,@Section,@Week)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Tid", SqlDbType.Int,4),
                    new SqlParameter("@Tname", SqlDbType.NVarChar,30),
                    new SqlParameter("@Cid", SqlDbType.Int,4),
                    new SqlParameter("@Cname", SqlDbType.NVarChar,30),
                    new SqlParameter("@DeptId", SqlDbType.Int,4),
                    new SqlParameter("@Years", SqlDbType.Date,3),
                    new SqlParameter("@Semaster", SqlDbType.Int,4),
                    new SqlParameter("@CourseAttribute", SqlDbType.VarChar,45),
                    new SqlParameter("@Credit", SqlDbType.Float,8),
                    new SqlParameter("@TextBook", SqlDbType.NVarChar,50),
                    new SqlParameter("@Hours", SqlDbType.Int,4),
                    new SqlParameter("@WeekHours", SqlDbType.Int,4),
                    new SqlParameter("@CourseRemainder", SqlDbType.Int,4),
                    new SqlParameter("@Section", SqlDbType.Int,4),
                    new SqlParameter("@Week", SqlDbType.VarChar,45)};
            parameters[0].Value = model.Tid;
            parameters[1].Value = model.Tname;
            parameters[2].Value = model.Cid;
            parameters[3].Value = model.Cname;
            parameters[4].Value = model.DeptId;
            parameters[5].Value = model.Years;
            parameters[6].Value = model.Semaster;
            parameters[7].Value = model.CourseAttribute;
            parameters[8].Value = model.Credit;
            parameters[9].Value = model.TextBook;
            parameters[10].Value = model.Hours;
            parameters[11].Value = model.WeekHours;
            parameters[12].Value = model.CourseRemainder;
            parameters[13].Value = model.Section;
            parameters[14].Value = model.Week;

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
        public bool Update(Danyl.SnnuURP.Model.TeachCourseView model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TeachCourseView set ");
            strSql.Append("Tid=@Tid,");
            strSql.Append("Tname=@Tname,");
            strSql.Append("Cid=@Cid,");
            strSql.Append("Cname=@Cname,");
            strSql.Append("DeptId=@DeptId,");
            strSql.Append("Years=@Years,");
            strSql.Append("Semaster=@Semaster,");
            strSql.Append("CourseAttribute=@CourseAttribute,");
            strSql.Append("Credit=@Credit,");
            strSql.Append("TextBook=@TextBook,");
            strSql.Append("Hours=@Hours,");
            strSql.Append("WeekHours=@WeekHours,");
            strSql.Append("CourseRemainder=@CourseRemainder,");
            strSql.Append("Section=@Section,");
            strSql.Append("Week=@Week");
            strSql.Append(" where Tid=@Tid and Cid=@Cid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Tid", SqlDbType.Int,4),
                    new SqlParameter("@Tname", SqlDbType.NVarChar,30),
                    new SqlParameter("@Cid", SqlDbType.Int,4),
                    new SqlParameter("@Cname", SqlDbType.NVarChar,30),
                    new SqlParameter("@DeptId", SqlDbType.Int,4),
                    new SqlParameter("@Years", SqlDbType.Date,3),
                    new SqlParameter("@Semaster", SqlDbType.Int,4),
                    new SqlParameter("@CourseAttribute", SqlDbType.VarChar,45),
                    new SqlParameter("@Credit", SqlDbType.Float,8),
                    new SqlParameter("@TextBook", SqlDbType.NVarChar,50),
                    new SqlParameter("@Hours", SqlDbType.Int,4),
                    new SqlParameter("@WeekHours", SqlDbType.Int,4),
                    new SqlParameter("@CourseRemainder", SqlDbType.Int,4),
                    new SqlParameter("@Section", SqlDbType.Int,4),
                    new SqlParameter("@Week", SqlDbType.VarChar,45)};
            parameters[0].Value = model.Tid;
            parameters[1].Value = model.Tname;
            parameters[2].Value = model.Cid;
            parameters[3].Value = model.Cname;
            parameters[4].Value = model.DeptId;
            parameters[5].Value = model.Years;
            parameters[6].Value = model.Semaster;
            parameters[7].Value = model.CourseAttribute;
            parameters[8].Value = model.Credit;
            parameters[9].Value = model.TextBook;
            parameters[10].Value = model.Hours;
            parameters[11].Value = model.WeekHours;
            parameters[12].Value = model.CourseRemainder;
            parameters[13].Value = model.Section;
            parameters[14].Value = model.Week;

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
        public bool Delete(int Tid, int Cid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TeachCourseView ");
            strSql.Append(" where Tid=@Tid and Cid=@Cid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Tid", SqlDbType.Int,4),
                    new SqlParameter("@Cid", SqlDbType.Int,4)           };
            parameters[0].Value = Tid;
            parameters[1].Value = Cid;

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
        /// 得到一个对象实体
        /// </summary>
        public Danyl.SnnuURP.Model.TeachCourseView GetModel(int Tid, int Cid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Tid,Tname,Cid,Cname,DeptId,Years,Semaster,CourseAttribute,Credit,TextBook,Hours,WeekHours,CourseRemainder,Section,Week from TeachCourseView ");
            strSql.Append(" where Tid=@Tid and Cid=@Cid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Tid", SqlDbType.Int,4),
                    new SqlParameter("@Cid", SqlDbType.Int,4)           };
            parameters[0].Value = Tid;
            parameters[1].Value = Cid;

            Danyl.SnnuURP.Model.TeachCourseView model = new Danyl.SnnuURP.Model.TeachCourseView();
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
        public Danyl.SnnuURP.Model.TeachCourseView DataRowToModel(DataRow row)
        {
            Danyl.SnnuURP.Model.TeachCourseView model = new Danyl.SnnuURP.Model.TeachCourseView();
            if (row != null)
            {
                if (row["Tid"] != null && row["Tid"].ToString() != "")
                {
                    model.Tid = int.Parse(row["Tid"].ToString());
                }
                if (row["Tname"] != null)
                {
                    model.Tname = row["Tname"].ToString();
                }
                if (row["Cid"] != null && row["Cid"].ToString() != "")
                {
                    model.Cid = int.Parse(row["Cid"].ToString());
                }
                if (row["Cname"] != null)
                {
                    model.Cname = row["Cname"].ToString();
                }
                if (row["DeptId"] != null && row["DeptId"].ToString() != "")
                {
                    model.DeptId = int.Parse(row["DeptId"].ToString());
                }
                if (row["Years"] != null && row["Years"].ToString() != "")
                {
                    model.Years = DateTime.Parse(row["Years"].ToString());
                }
                if (row["Semaster"] != null && row["Semaster"].ToString() != "")
                {
                    model.Semaster = int.Parse(row["Semaster"].ToString());
                }
                if (row["CourseAttribute"] != null)
                {
                    model.CourseAttribute = row["CourseAttribute"].ToString();
                }
                if (row["Credit"] != null && row["Credit"].ToString() != "")
                {
                    model.Credit = decimal.Parse(row["Credit"].ToString());
                }
                if (row["TextBook"] != null)
                {
                    model.TextBook = row["TextBook"].ToString();
                }
                if (row["Hours"] != null && row["Hours"].ToString() != "")
                {
                    model.Hours = int.Parse(row["Hours"].ToString());
                }
                if (row["WeekHours"] != null && row["WeekHours"].ToString() != "")
                {
                    model.WeekHours = int.Parse(row["WeekHours"].ToString());
                }
                if (row["CourseRemainder"] != null && row["CourseRemainder"].ToString() != "")
                {
                    model.CourseRemainder = int.Parse(row["CourseRemainder"].ToString());
                }
                if (row["Section"] != null && row["Section"].ToString() != "")
                {
                    model.Section = int.Parse(row["Section"].ToString());
                }
                if (row["Week"] != null)
                {
                    model.Week = row["Week"].ToString();
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
            strSql.Append("select Tid,Tname,Cid,Cname,DeptId,Years,Semaster,CourseAttribute,Credit,TextBook,Hours,WeekHours,CourseRemainder,Section,Week ");
            strSql.Append(" FROM TeachCourseView ");
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
            strSql.Append(" Tid,Tname,Cid,Cname,DeptId,Years,Semaster,CourseAttribute,Credit,TextBook,Hours,WeekHours,CourseRemainder,Section,Week ");
            strSql.Append(" FROM TeachCourseView ");
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
            strSql.Append("select count(1) FROM TeachCourseView ");
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
                strSql.Append("order by T.Cid desc");
            }
            strSql.Append(")AS Row, T.*  from TeachCourseView T ");
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
			parameters[0].Value = "TeachCourseView";
			parameters[1].Value = "Cid";
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