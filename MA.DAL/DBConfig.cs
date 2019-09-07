using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.DAL
{
    public class DBConfig
    {
        public static  string ConnectionString = "Data source =DESKTOP-PTR0L8C; Initial Catalog =macenterdev; User ID =stone; Password=stone123";


        public DBConfig()
        {
            var connStr = ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString;
            if(connStr != string.Empty)
            {
                ConnectionString = connStr;
            }

        }
      

    }
}
