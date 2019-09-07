using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ma.Models
{
    public class WorkLog
    {
        public long LogID { get; set; }
        public int TypeID { get; set; }
        public DateTime InsertDate { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public int StatusId { get; set; }

    }
}
