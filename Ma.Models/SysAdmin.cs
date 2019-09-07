using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MA.Models
{
    public class SysAdmin
    {
        public int Id { get; set; }
        public string AdminName { get; set; }

        public string LoginPwd { get; set; }
    }
}