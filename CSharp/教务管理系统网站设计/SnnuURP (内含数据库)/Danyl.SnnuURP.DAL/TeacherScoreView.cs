using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Danyl.SnnuURP.DBUtility;

namespace Danyl.SnnuURP.DAL
{
    /// <summary>
    /// 数据访问类:TeacherScoreView
    /// </summary>
    public partial class TeacherScoreView
    {
        public TeacherScoreView()
        { }

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Danyl.SnnuURP.Model.TeacherScoreView model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TeacherScoreView(");
            strSql.Append("Sid,Tid,Cname,Sname,Years,Semaster,UsualScore,MidtermScore,FinalExamScore,TotalScore)");
            strSql.Append(" values (");
            strSql.Append("@Sid,@Tid,@Cname,@Sname,@Years,@Semaster,@UsualScore,@MidtermScore,@FinalExamScore,@TotalScore)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Sid", SqlDbType.Int,4),
                    new SqlParameter("@Tid", SqlDbType.Int,4),
                    new SqlParameter("@Cname", SqlDbType.NVarChar,30),
                    new SqlParameter("@Sname", SqlDbType.NVarChar,30),
                    new SqlParameter("@Years", SqlDbType.Date,3),
                    new SqlParameter("@Semaster", SqlDbType.Int,4),
                    new SqlParameter("@UsualScore", SqlDbType.Int,4),
                    new SqlParameter("@MidtermScore", SqlDbType.Int,4),
                    new SqlParameter("@FinalExamScore", SqlDbType.Int,4),
                    new SqlParameter("@TotalScore", SqlDbType.Int,4)};
            parameters[0].Value = model.Sid;
            parameters[1].Value = model.Tid;
            parameters[2].Value = model.Cname;
            parameters[3].Value = model.Sname;
            parameters[4].Value = model.Years;
            parameters[5].Value = model.Semaster;
            parameters[6].Value = model.UsualScore;
            parameters[7].Value = model.MidtermScore;
            parameters[8].Value = model.FinalExamScore;
            parameters[9].Value = model.TotalScore;

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
        public bool Update(Danyl.SnnuURP.Model.TeacherScoreView model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TeacherScoreView set ");
            strSql.Append("TotalScore=@TotalScore");
            strSql.Append(" where Sid=@Sid and Cname=@Cname ");
            SqlParameter[] parameters = {
                new SqlParameter("@TotalScore", SqlDbType.Int,4),
                new SqlParameter("@Sid", SqlDbType.Int,4),
                new SqlParameter("@Cname", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.TotalScore;
            parameters[1].Value = model.Sid;
            parameters[2].Value = model.Cname;

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
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TeacherScoreView ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
            };

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
        public Danyl.SnnuURP.Model.TeacherScoreView GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Sid,Tid,Cname,Sname,Years,Semaster,UsualScore,MidtermScore,FinalExamScore,TotalScore from TeacherScoreView ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
            };

            Danyl.SnnuURP.Model.TeacherScoreView model = new Danyl.SnnuURP.Model.TeacherScoreView();
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
        public Danyl.SnnuURP.Model.TeacherScoreView DataRowToModel(DataRow row)
        {
            Danyl.SnnuURP.Model.TeacherScoreView model = new Danyl.SnnuURP.Model.TeacherScoreView();
            if (row != null)
            {
                if (row["Sid"] != null && row["Sid"].ToString() != "")
                {
                    model.Sid = int.Parse(row["Sid"].ToString());
                }
                if (row["Tid"] != null && row["Tid"].ToString() != "")
                {
                    model.Tid = int.Parse(row["Tid"].ToString());
                }
                if (row["Cname"] != null)
                {
                    model.Cname = row["Cname"].ToString();
                }
                if (row["Sname"] != null)
                {
                    model.Sname = row["Sname"].ToString();
                }
                if (row["Years"] != null && row["Years"].ToString() != "")
                {
                    model.Years = DateTime.Parse(row["Years"].ToString());
                }
                if (row["Semaster"] != null && row["Semaster"].ToString() != "")
                {
                    model.Semaster = int.Parse(row["Semaster"].ToString());
                }
                if (row["UsualScore"] != null && row["UsualScore"].ToString() != "")
                {
                    model.UsualScore = int.Parse(row["UsualScore"].ToString());
                }
                if (row["MidtermScore"] != null && row["MidtermScore"].ToString() != "")
                {
                    model.MidtermScore = int.Parse(row["MidtermScore"].ToString());
                }
                if (row["FinalExamScore"] != null && row["FinalExamScore"].ToString() != "")
                {
                    model.FinalExamScore = int.Parse(row["FinalExamScore"].ToString());
                }
                if (row["TotalScore"] != null && row["TotalScore"].ToString() != "")
                {
                    model.TotalScore = int.Parse(row["TotalScore"].ToString());
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
            strSql.Append("select Sid,Tid,Cname,Sname,Years,Semaster,UsualScore,MidtermScore,FinalExamScore,TotalScore ");
            strSql.Append(" FROM TeacherScoreView ");
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
            strSql.Append(" Sid,Tid,Cname,Sname,Years,Semaster,UsualScore,MidtermScore,FinalExamScore,TotalScore ");
            strSql.Append(" FROM TeacherScoreView ");
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
            strSql.Append("select count(1) FROM TeacherScoreView ");
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
                strSql.Append("order by T. desc");
            }
            strSql.Append(")AS Row, T.*  from TeacherScoreView T ");
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
			parameters[0].Value = "TeacherScoreView";
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