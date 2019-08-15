using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.ConsoleQuartz
{
    public class SampleJob : IJob
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(SampleJob));

        public async Task Execute(IJobExecutionContext context)
        {
            logger.Info("SampleJob running...");
            await Task.Delay(TimeSpan.FromSeconds(2));
            logger.Info("SampleJob run finished.");
            LogText();
        }

        public void LogText()
        {
            Console.WriteLine("Log Text...");
            string[] lines = new string[] { $"{DateTime.Now.ToString()} :LogText() Runnig..." };
            // File.AppendAllLines(@"E:\Heartbeat.txt", lines);
            File.AppendAllLines(@"E:\QuartzJobLog.txt", lines);
            // LoggerFactory.Info("SampleJob running...");
        }
    }
}
