using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.ServiceCenter
{
    // ProcessID = 1
    public class WorkOrderService : IWorkService
    {

        public readonly string ConnectionString = DBConfiguration.ConnectionString;

        public void Process()
        {
            // insert one order work
            RunLog();
        }

        public void RunLog()
        {
            //创建SqlConnection的实例
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(ConnectionString);
                //打开数据库连接
                conn.Open();
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand("dbo.InsertLogProcess", conn);
                //设置SQLCommand对象的命令类型（CommandType）是存储过程
                cmd.CommandType = CommandType.StoredProcedure;
                //设置存储过程需要的参数
                Random ran = new Random();
                var key = ran.Next(1, 1000);
                var workLogId = 2;
                var userName = $"stone:{key}";
                var rocessTypeId = 2;
                var processTypeName = "order";
                var stageId = 1;
                var tatusId = 1;

                cmd.Parameters.AddWithValue("@WorkLogId", workLogId);
                cmd.Parameters.AddWithValue("@ProcessTypeId", rocessTypeId);
                cmd.Parameters.AddWithValue("@ProcessTypeName", processTypeName);
                cmd.Parameters.AddWithValue("@StageId", stageId);
                cmd.Parameters.AddWithValue("@StatusId", tatusId);
                cmd.Parameters.AddWithValue("@UserName", userName);
                //执行存储过程
                int returnvalue = cmd.ExecuteNonQuery();


                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {

                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }
    }
}
