using Ma.Models;
using MA.Center.DBCommon;
using MA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MA.Center.Service
{
    public class SysAdminManager
    {
        public SysAdminInfo AdminLogin(SysAdmin admin)
        {
            var adminInfo = new SysAdminInfo();
            var service = new SysAdminService();
            adminInfo = service.AdminLogin(admin);
            if(admin != null)
            {
                HttpContext.Current.Session["CurrentAdmin"] = admin;
                return adminInfo;
            }
            return null;
           

        }
    }
}
