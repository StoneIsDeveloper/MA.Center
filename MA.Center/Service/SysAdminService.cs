using Ma.Models;
using MA.Center.Log;
using MA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.Center.DBCommon
{
    public class SysAdminService
    {
        public SysAdminInfo AdminLogin(SysAdmin admin)
        {
            var adminInfo = new SysAdminInfo();
            string sql = $"select * from dbo.AspNetUsers where [UserName]={admin.AdminName} and [Email]={admin.LoginPwd}";
            try
            {
                SqlDataReader objReader = SqlHelper.GetReader(sql);
                if (objReader.Read())
                {
                    adminInfo.Id = Convert.ToInt64(objReader["UserName"].ToString());
                    adminInfo.UserName = objReader["UserName"].ToString();
                    adminInfo.Email = objReader["Email"].ToString();
                    objReader.Close();
                }
                else
                {
                    admin = null;
                }
            }
            catch (Exception ex)
            {
                LogStoreHelper.WriteError(ex, $"SqlHelper.GetSingleResult error");
                throw ex;
            }
            return adminInfo;

        }


    }
}
