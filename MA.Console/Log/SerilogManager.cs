using MA.Center.Log;
using MA.ConsoleQuartz.Util;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.ConsoleQuartz.Log
{
    public class SerilogManager
    {
        private static readonly string LogPath = @"F:\logs\log-.txt";
        public static void ConsoleLog()
        {
            Logger logger  = new LoggerConfiguration()
                             .MinimumLevel.Debug()
                             .WriteTo.Console()
                             .WriteTo.File(LogPath, rollingInterval: RollingInterval.Day)
                             .CreateLogger();
           // logger.Information("No one listens to me!");
            LogHelper.WriteInformation(null,"hello log!");
            LogStoreHelper.WriteInformation(null, "hello log!");
            int a = 10, b = 0;
            try
            {
                var log = $"Dividing {a} by {b}";
                LogHelper.WriteDebug(null, log);
                LogStoreHelper.WriteDebug(null, log);

                //  logger.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);

               
            }
            catch (Exception ex)
            {
               // logger.Error(ex, "Something went wrong");
                LogHelper.WriteError(ex, "Something went wrong");
                LogStoreHelper.WriteError(ex, "Something went wrong");
            }

           // logger.CloseAndFlush();

        }
    }
}
