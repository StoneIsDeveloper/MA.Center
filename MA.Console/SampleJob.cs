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
            //logger.Info("SampleJob run finished.");

            var info = "Test Sample 123...";
            new Task(() =>
            {
                LogText(info);
            }).RunSynchronously();
           
        }


        public void LogText(string info)
        {
            Console.WriteLine(info);
            string[] lines = new string[] { $"{DateTime.Now.ToString()} {info}" };
            // File.AppendAllLines(@"E:\Heartbeat.txt", lines);
            File.AppendAllLines(@"E:\QuartzJobLog.txt", lines);
            // LoggerFactory.Info("SampleJob running...");
        }
    }
}
