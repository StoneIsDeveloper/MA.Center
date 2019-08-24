using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.ServiceCenter
{
    public class ServiceFactory
    {
        public static IWorkService CreateWorkService(int processID)
        {
            // IWorkService workService = new WorkLogService();
            string typeName = GetProcessTypeName(processID);
            Type type = Type.GetType(typeName);

            IWorkService workService = Activator.CreateInstance(type) as IWorkService;

            return workService;

        }

        private static string GetProcessTypeName(int processID)
        {
            var name = "MA.ServiceCenter.WorkOrderService,MA.ServiceCenter";
            return name;
        }
    }
}
