﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MA.ServiceCenter
{
    public class WorkLogService : IWorkService
    {
        public readonly string ConnectionString = DBConfiguration.ConnectionString;

        public void Process()
        {
            while (1 > 0)
            {
                RunLog();
                Thread.Sleep(1000);
            }


            // write daily log to db

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
                SqlCommand cmd = new SqlCommand("dbo.InsertLog", conn);
                //设置SQLCommand对象的命令类型（CommandType）是存储过程
                cmd.CommandType = CommandType.StoredProcedure;
                //设置存储过程需要的参数
                var typeID = 1;

                Random ran = new Random();
                typeID = ran.Next(1, 10);
                var key = ran.Next(1, 1000);

                var description = $"Log:{key}";
                var userName = $"stone:{key}";

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
        }
    }
}
