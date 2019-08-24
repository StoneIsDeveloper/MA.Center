using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.ServiceCenter
{
    public class WorkTrigerService
    {

        public static void TrackingWork()
        {
            // moniter work log, if have status id = 1, then Exec IWorkService Process

            int workId = GetWorkId();

            int processId = GetProcessId();
            IWorkService workService = ServiceFactory.CreateWorkService(processId);
            workService.Process();

        }

        private static int GetProcessId()
        {
            return 1;
        }

        private static int GetWorkId()
        {
            return 1;
        }
    }
}
