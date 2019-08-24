using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.ServiceCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            int batchId = 0;
            int processId = 0;
           IWorkService workService = ServiceFactory.CreateWorkService(processId);

            workService.Process();

        }
    }
}
