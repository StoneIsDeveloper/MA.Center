﻿using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.ConsoleQuartz.Util
{
    public static class LogHelper
    {
        private static readonly ILogger Errorlog;
        private static readonly ILogger Warninglog;
        private static readonly ILogger Debuglog;
        private static readonly ILogger Verboselog;
        private static readonly ILogger Fatallog;
        private static readonly ILogger Infolog;

        private static readonly string ErrorlogPath = @"F:\logs\Errorlog\log-.txt";
        private static readonly string WarninglogPath = @"F:\logs\Warninglog\log-.txt";
        private static readonly string DebuglogPath= @"F:\logs\Debuglog\log-.txt";
        private static readonly string VerboselogPath = @"F:\logs\Verboselog\log-.txt";
        private static readonly string FatallogPath= @"F:\logs\Fatallog\log-.txt";
        private static readonly string InfologPath = @"F:\logs\Infolog\log-.txt";

        static LogHelper()
        {

            // 5 MB = 5242880 bytes
            Infolog = new LoggerConfiguration()
               .MinimumLevel.Information()
              .WriteTo.File(InfologPath,
               rollingInterval: RollingInterval.Day,
               fileSizeLimitBytes: 5242880,
               rollOnFileSizeLimit: true)
               .CreateLogger();

            Errorlog = new LoggerConfiguration()
                .MinimumLevel.Error()
               .WriteTo.File(ErrorlogPath,
                rollingInterval: RollingInterval.Day,
                fileSizeLimitBytes: 5242880,
                rollOnFileSizeLimit: true)
                .CreateLogger();

            Warninglog = new LoggerConfiguration()
                .MinimumLevel.Warning()
              .WriteTo.File(WarninglogPath,
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 5242880,
                    rollOnFileSizeLimit: true)
                .CreateLogger();

            Debuglog = new LoggerConfiguration()
                .MinimumLevel.Debug()
              .WriteTo.File(DebuglogPath,
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 5242880,
                    rollOnFileSizeLimit: true)
                .CreateLogger();

            Verboselog = new LoggerConfiguration()
                .MinimumLevel.Verbose()
              .WriteTo.File(VerboselogPath,
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 5242880,
                    rollOnFileSizeLimit: true)
                .CreateLogger();

            Fatallog = new LoggerConfiguration()
                .MinimumLevel.Fatal()
              .WriteTo.File(FatallogPath,
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 5242880,
                    rollOnFileSizeLimit: true)
                .CreateLogger();

        }

        public static void WriteError(Exception ex, string message)
        {
            //Error - indicating a failure within the application or connected system
            Errorlog.Write(LogEventLevel.Error, ex, message);
        }

        public static void WriteWarning(Exception ex, string message)
        {
            //Warning - indicators of possible issues or service / functionality degradation
            Warninglog.Write(LogEventLevel.Warning, ex, message);
        }

        public static void WriteDebug(Exception ex, string message)
        {
            //Debug - internal control flow and diagnostic state dumps to facilitate 
            //          pinpointing of recognised problems
            Debuglog.Write(LogEventLevel.Debug, ex, message);
        }

        public static void WriteVerbose(Exception ex, string message)
        {
            // Verbose - tracing information and debugging minutiae; 
            //             generally only switched on in unusual situations
            Verboselog.Write(LogEventLevel.Verbose, ex, message);
        }

        public static void WriteFatal(Exception ex, string message)
        {
            //Fatal - critical errors causing complete failure of the application
            Fatallog.Write(LogEventLevel.Fatal, ex, message);
        }

        public static void WriteInformation(Exception ex, string message)
        {
            //Fatal - critical errors causing complete failure of the application
            Infolog.Write(LogEventLevel.Information, ex, message);
        }

    }
}
