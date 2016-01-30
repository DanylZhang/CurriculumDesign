using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using 陕西师范大学铃声小贴士.Model;

namespace 陕西师范大学铃声小贴士.DAL
{
    partial class SNNUScheduleDAL
    {
        public int AddNew(SNNUSchedule model)
        {
            string sql = "insert into SNNUSchedule(BeginTime1,EndTime1,BeginTime2,EndTime2,BeginTime3,EndTime3,BeginTime4,CloseTime1,BeginTime5,EndTime5,BeginTime6,EndTime6,BeginTime7,EndTime7,BeginTime8,CloseTime2,BeginTime9,EndTime9,BeginTime10,CloseTime3) output inserted.id values(@BeginTime1,@EndTime1,@BeginTime2,@EndTime2,@BeginTime3,@EndTime3,@BeginTime4,@CloseTime1,@BeginTime5,@EndTime5,@BeginTime6,@EndTime6,@BeginTime7,@EndTime7,@BeginTime8,@CloseTime2,@BeginTime9,@EndTime9,@BeginTime10,@CloseTime3)";
            int id = (int)SqlHelper.ExecuteScalar(sql
            , new SqlParameter("BeginTime1", model.BeginTime1 == null ? (object)DBNull.Value : model.BeginTime1.Value.TimeOfDay)
            , new SqlParameter("EndTime1", model.EndTime1 == null ? (object)DBNull.Value : model.EndTime1.Value.TimeOfDay)
            , new SqlParameter("BeginTime2", model.BeginTime2 == null ? (object)DBNull.Value : model.BeginTime2.Value.TimeOfDay)
            , new SqlParameter("EndTime2", model.EndTime2 == null ? (object)DBNull.Value : model.EndTime2.Value.TimeOfDay)
            , new SqlParameter("BeginTime3", model.BeginTime3 == null ? (object)DBNull.Value : model.BeginTime3.Value.TimeOfDay)
            , new SqlParameter("EndTime3", model.EndTime3 == null ? (object)DBNull.Value : model.EndTime3.Value.TimeOfDay)
            , new SqlParameter("BeginTime4", model.BeginTime4 == null ? (object)DBNull.Value : model.BeginTime4.Value.TimeOfDay)
            , new SqlParameter("CloseTime1", model.CloseTime1 == null ? (object)DBNull.Value : model.CloseTime1.Value.TimeOfDay)
            , new SqlParameter("BeginTime5", model.BeginTime5 == null ? (object)DBNull.Value : model.BeginTime5.Value.TimeOfDay)
            , new SqlParameter("EndTime5", model.EndTime5 == null ? (object)DBNull.Value : model.EndTime5.Value.TimeOfDay)
            , new SqlParameter("BeginTime6", model.BeginTime6 == null ? (object)DBNull.Value : model.BeginTime6.Value.TimeOfDay)
            , new SqlParameter("EndTime6", model.EndTime6 == null ? (object)DBNull.Value : model.EndTime6.Value.TimeOfDay)
            , new SqlParameter("BeginTime7", model.BeginTime7 == null ? (object)DBNull.Value : model.BeginTime7.Value.TimeOfDay)
            , new SqlParameter("EndTime7", model.EndTime7 == null ? (object)DBNull.Value : model.EndTime7.Value.TimeOfDay)
            , new SqlParameter("BeginTime8", model.BeginTime8 == null ? (object)DBNull.Value : model.BeginTime8.Value.TimeOfDay)
            , new SqlParameter("CloseTime2", model.CloseTime2 == null ? (object)DBNull.Value : model.CloseTime2.Value.TimeOfDay)
            , new SqlParameter("BeginTime9", model.BeginTime9 == null ? (object)DBNull.Value : model.BeginTime9.Value.TimeOfDay)
            , new SqlParameter("EndTime9", model.EndTime9 == null ? (object)DBNull.Value : model.EndTime9.Value.TimeOfDay)
            , new SqlParameter("BeginTime10", model.BeginTime10 == null ? (object)DBNull.Value : model.BeginTime10.Value.TimeOfDay)
            , new SqlParameter("CloseTime3", model.CloseTime3 == null ? (object)DBNull.Value : model.CloseTime3.Value.TimeOfDay)
            );
            return id;
        }
        public bool Update(SNNUSchedule model)
        {
            string sql = "update SNNUSchedule set BeginTime1=@BeginTime1,EndTime1=@EndTime1,BeginTime2=@BeginTime2,EndTime2=@EndTime2,BeginTime3=@BeginTime3,EndTime3=@EndTime3,BeginTime4=@BeginTime4,CloseTime1=@CloseTime1,BeginTime5=@BeginTime5,EndTime5=@EndTime5,BeginTime6=@BeginTime6,EndTime6=@EndTime6,BeginTime7=@BeginTime7,EndTime7=@EndTime7,BeginTime8=@BeginTime8,CloseTime2=@CloseTime2,BeginTime9=@BeginTime9,EndTime9=@EndTime9,BeginTime10=@BeginTime10,CloseTime3=@CloseTime3 where id=@id";
            int rows = SqlHelper.ExecuteNonQuery(sql
            , new SqlParameter("Id", model.Id == null ? (object)DBNull.Value : model.Id)
            , new SqlParameter("BeginTime1", model.BeginTime1 == null ? (object)DBNull.Value : model.BeginTime1.Value.TimeOfDay)
            , new SqlParameter("EndTime1", model.EndTime1 == null ? (object)DBNull.Value : model.EndTime1.Value.TimeOfDay)
            , new SqlParameter("BeginTime2", model.BeginTime2 == null ? (object)DBNull.Value : model.BeginTime2.Value.TimeOfDay)
            , new SqlParameter("EndTime2", model.EndTime2 == null ? (object)DBNull.Value : model.EndTime2.Value.TimeOfDay)
            , new SqlParameter("BeginTime3", model.BeginTime3 == null ? (object)DBNull.Value : model.BeginTime3.Value.TimeOfDay)
            , new SqlParameter("EndTime3", model.EndTime3 == null ? (object)DBNull.Value : model.EndTime3.Value.TimeOfDay)
            , new SqlParameter("BeginTime4", model.BeginTime4 == null ? (object)DBNull.Value : model.BeginTime4.Value.TimeOfDay)
            , new SqlParameter("CloseTime1", model.CloseTime1 == null ? (object)DBNull.Value : model.CloseTime1.Value.TimeOfDay)
            , new SqlParameter("BeginTime5", model.BeginTime5 == null ? (object)DBNull.Value : model.BeginTime5.Value.TimeOfDay)
            , new SqlParameter("EndTime5", model.EndTime5 == null ? (object)DBNull.Value : model.EndTime5.Value.TimeOfDay)
            , new SqlParameter("BeginTime6", model.BeginTime6 == null ? (object)DBNull.Value : model.BeginTime6.Value.TimeOfDay)
            , new SqlParameter("EndTime6", model.EndTime6 == null ? (object)DBNull.Value : model.EndTime6.Value.TimeOfDay)
            , new SqlParameter("BeginTime7", model.BeginTime7 == null ? (object)DBNull.Value : model.BeginTime7.Value.TimeOfDay)
            , new SqlParameter("EndTime7", model.EndTime7 == null ? (object)DBNull.Value : model.EndTime7.Value.TimeOfDay)
            , new SqlParameter("BeginTime8", model.BeginTime8 == null ? (object)DBNull.Value : model.BeginTime8.Value.TimeOfDay)
            , new SqlParameter("CloseTime2", model.CloseTime2 == null ? (object)DBNull.Value : model.CloseTime2.Value.TimeOfDay)
            , new SqlParameter("BeginTime9", model.BeginTime9 == null ? (object)DBNull.Value : model.BeginTime9.Value.TimeOfDay)
            , new SqlParameter("EndTime9", model.EndTime9 == null ? (object)DBNull.Value : model.EndTime9.Value.TimeOfDay)
            , new SqlParameter("BeginTime10", model.BeginTime10 == null ? (object)DBNull.Value : model.BeginTime10.Value.TimeOfDay)
            , new SqlParameter("CloseTime3", model.CloseTime3 == null ? (object)DBNull.Value : model.CloseTime3.Value.TimeOfDay)
            );
            return rows > 0;
        }
        public bool Delete(int id)
        {
            int rows = SqlHelper.ExecuteNonQuery("delete from SNNUSchedule where id=@id",
            new SqlParameter("id", id));
            return rows > 0;
        }
        private static SNNUSchedule ToModel(DataRow row)
        {
            SNNUSchedule model = new SNNUSchedule();
            model.Id = row.IsNull("Id") ? null : (System.Int32?)row["Id"];
            model.BeginTime1 = row.IsNull("BeginTime1") ? null : (DateTime?)Convert.ToDateTime(row["BeginTime1"].ToString());
            model.EndTime1 = row.IsNull("EndTime1") ? null : (DateTime?)Convert.ToDateTime(row["EndTime1"].ToString());
            model.BeginTime2 = row.IsNull("BeginTime2") ? null : (DateTime?)Convert.ToDateTime(row["BeginTime2"].ToString());
            model.EndTime2 = row.IsNull("EndTime2") ? null : (DateTime?)Convert.ToDateTime(row["EndTime2"].ToString());
            model.BeginTime3 = row.IsNull("BeginTime3") ? null : (DateTime?)Convert.ToDateTime(row["BeginTime3"].ToString());
            model.EndTime3 = row.IsNull("EndTime3") ? null : (DateTime?)Convert.ToDateTime(row["EndTime3"].ToString());
            model.BeginTime4 = row.IsNull("BeginTime4") ? null :(DateTime?)Convert.ToDateTime(row["BeginTime4"].ToString());
            model.CloseTime1 = row.IsNull("CloseTime1") ? null :(DateTime?)Convert.ToDateTime(row["CloseTime1"].ToString());
            model.BeginTime5 = row.IsNull("BeginTime5") ? null : (DateTime?)Convert.ToDateTime(row["BeginTime5"].ToString());
            model.EndTime5 = row.IsNull("EndTime5") ? null : (DateTime?)Convert.ToDateTime(row["EndTime5"].ToString());
            model.BeginTime6 = row.IsNull("BeginTime6") ? null : (DateTime?)Convert.ToDateTime(row["BeginTime6"].ToString());
            model.EndTime6 = row.IsNull("EndTime6") ? null : (DateTime?)Convert.ToDateTime(row["EndTime6"].ToString());
            model.BeginTime7 = row.IsNull("BeginTime7") ? null : (DateTime?)Convert.ToDateTime(row["BeginTime7"].ToString());
            model.EndTime7 = row.IsNull("EndTime7") ? null : (DateTime?)Convert.ToDateTime(row["EndTime7"].ToString());
            model.BeginTime8 = row.IsNull("BeginTime8") ? null :(DateTime?)Convert.ToDateTime(row["BeginTime8"].ToString());
            model.CloseTime2 = row.IsNull("CloseTime2") ? null :(DateTime?)Convert.ToDateTime(row["CloseTime2"].ToString());
            model.BeginTime9 = row.IsNull("BeginTime9") ? null : (DateTime?)Convert.ToDateTime(row["BeginTime9"].ToString());
            model.EndTime9 = row.IsNull("EndTime9") ? null : (DateTime?)Convert.ToDateTime(row["EndTime9"].ToString());
            model.BeginTime10 = row.IsNull("BeginTime10") ? null : (DateTime?)Convert.ToDateTime(row["BeginTime10"].ToString());
            model.CloseTime3 = row.IsNull("CloseTime3") ? null : (DateTime?)Convert.ToDateTime(row["CloseTime3"].ToString());
            return model;
        }
        public SNNUSchedule Get(int id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from SNNUSchedule  where id=@id",
            new SqlParameter("id", id));
            if (dt.Rows.Count > 1)
            { throw new Exception("more than 1 row was found"); }
            if (dt.Rows.Count <= 0) { return null; }
            DataRow row = dt.Rows[0];
            SNNUSchedule model = ToModel(row);
            return model;
        }
        public IEnumerable<SNNUSchedule> ListAll()
        {
            List<SNNUSchedule> list = new List<SNNUSchedule>();
            DataTable dt = SqlHelper.ExecuteDataTable("select * from SNNUSchedule");
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        }
    }
}