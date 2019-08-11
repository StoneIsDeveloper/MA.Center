using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAConsole
{
    public class SampleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return new Task(LogText);
        }

        public void LogText()
        {
            string[] lines = new string[] { $"{DateTime.Now.ToString()} :SampJob Runnig..." };
            File.AppendAllLines(@"E:\Heartbeat.txt", lines);
        }
    }
}
