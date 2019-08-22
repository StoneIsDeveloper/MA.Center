using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.ServiceCenter
{
    public class WorkLogService : IWorkService
    {
        public readonly string ConnectionString = "Data source =DESKTOP-PTR0L8C; Initial Catalog =macenterdev; User ID =stone; Password=stone123";

        public void Process()
        {
            //创建SqlConnection的实例
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(ConnectionString);
                //打开数据库连接
                conn.Open();
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand("dbo.InsertLog", conn);
                //设置SQLCommand对象的命令类型（CommandType）是存储过程
                cmd.CommandType = CommandType.StoredProcedure;
                //设置存储过程需要的参数
                var typeID = 1;
                var description = "1232";
                var userName = "stone 1";
                cmd.Parameters.AddWithValue("@TypeID", typeID);
                cmd.Parameters.AddWithValue("@Description", description);
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
            // write daily log to db

        }
    }
}
