using Dapper;
using Dapper.Tvp;
using Ma.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.DAL
{
    public class DBAccess
    {
        public void Insert()
        {

        }

        public static void Query()
        {
           

            IDbConnection connection = new SqlConnection(DBConfig.ConnectionString);
           // connection.BeginTransaction();

            var sql = "select * from [dbo].[WorkLog] where UserName=@UserName";
            var query = connection.Query<WorkLog>(sql, new { UserName = "stone:188" })
                                .OrderBy(t=> t.LogID).Take(5).ToList();

            var results = connection.QueryFirstOrDefault<WorkLog>(sql, new { UserName = "stone:188" });
            int[] typeIdList = new int[] {1,2 };

            //var spResults = connection.Query<WorkLog>("dbo.GetWorkLog_ByTypeIds", 
            //                                            new { TypeId = 1 },
            //      
            var tvpResults = QueryWithTVP();

            var result1 = QueryByIds();
        }

        /// <summary>
        /// use TableType variable
        /// </summary>
        public static List<WorkLog> QueryWithTVP()
        {
            int[] idList = new int[] { 1, 2 };
            var results = new List<WorkLog>();
            try
            {
                var typeIdsParameter = new List<SqlDataRecord>();
                var myMetaData = new SqlMetaData[] { new SqlMetaData("TypeID", SqlDbType.Int) };
                foreach (var num in idList)
                {
                    // Create a new record, i.e. row.
                    var record = new SqlDataRecord(myMetaData);
                    // Set the 1st colunm, i.e., position 0 with the correcponding value:
                    record.SetInt32(0, num);
                    // Add the new row to the table rows array:
                    typeIdsParameter.Add(record);
                }
                using (IDbConnection conn = new SqlConnection(DBConfig.ConnectionString))
                {
                    conn.Open();

                    results =  conn.Query<WorkLog>("dbo.GetWorkLog_ByTypeIds",
                                        new TableValueParameter("@TypeIds", "IDList", typeIdsParameter)
                                        , commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return results;
        }

        /// <summary>
        /// ADO.NET Table Value P
        /// </summary>
        /// <returns></returns>
        public static List<WorkLog> QueryByIds()
        {
            int[] idList = new int[] { 1, 2 };

            var results = new List<WorkLog>();

            using (SqlConnection conn = new SqlConnection(DBConfig.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.GetWorkLog_ByTypeIds", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable tvp = new DataTable();
                tvp.Columns.Add(new DataColumn("ID", typeof(int)));
                foreach (var id in idList)
                    tvp.Rows.Add(id);
                SqlParameter tvparam = cmd.Parameters.AddWithValue("@TypeIds", tvp);
                tvparam.SqlDbType = SqlDbType.Structured;
                tvparam.TypeName = "dbo.IDList";

                var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var item = new WorkLog()
                    {
                        LogID = Convert.ToInt64(reader["LogID"]),
                        TypeID = Convert.ToInt32(reader["TypeID"]),
                        InsertDate = Convert.ToDateTime(reader["InsertDate"]),
                        Description = Convert.ToString( reader["Description"]),
                        UserName = Convert.ToString(reader["UserName"]),
                        StatusId = Convert.ToInt32(reader["StatusId"]),
                    };

                    results.Add(item);
                }

            }

            return results;
        }

    }
}
