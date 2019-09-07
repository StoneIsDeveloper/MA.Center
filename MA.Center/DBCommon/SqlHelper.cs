using MA.Center.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.Center.DBCommon
{
    public class SqlHelper
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        public static int Update(string sql)
        {
            int returnResult = 0;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                returnResult = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                LogStoreHelper.WriteError(ex, $"SqlHelper.Update error");
                throw ex;
            }
            finally
            {
                conn.Close();
                returnResult = -1;
            }
            return returnResult;
        }

        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                LogStoreHelper.WriteError(ex, $"SqlHelper.GetSingleResult error");
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                LogStoreHelper.WriteError(ex, $"SqlHelper.GetSingleResult error");
                throw ex;
            }
            finally
            {
            }
        }

    }
}
