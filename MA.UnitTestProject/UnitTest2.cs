using System;
using System.Data.SqlClient;
using MA.ServiceCenter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWorkService workService = new WorkLogService();
            workService.Process();


        }

        [TestMethod]
        public void TestMethodTrigerService()
        {
            WorkTrigerService.TrackingWork();
           
        }

        [TestMethod]
        public void TestDb()
        {
            var results = new List<Contact>();
            try
            {
                int[] idList = new int[] { 1, 2 };

                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.GetContactByIdRange", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IDList", idList);

                var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var item = new Contact()
                    {
                        ContactId = Convert.ToInt64(reader["ContactId"].ToString()),
                        OwnerID = reader["OwnerID"].ToString(),
                        Address = reader["Address"].ToString(),
                        City = reader["City"].ToString(),
                        State = reader["State"].ToString(),
                        Zip = reader["Zip"].ToString(),
                        Status = (ContactStatus)Convert.ToInt64(reader["Status"].ToString()),

                    };

                    results.Add(item);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                // LogStoreHelper.WriteError(ex, $"SqlHelper.GetSingleResult error");
                throw ex;
            }
        }


    }
}
