using log4net;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace MA.ConsoleQuartz
{
    public class QuartzServerFactory
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(QuartzServerFactory));

        public static QuartzServer CreateServer()
        {
            string typeName = Configuration.ServerImplementationType;
            Console.WriteLine("typeName:" + typeName);

            Type t = Type.GetType(typeName, true);

            logger.Debug("Creating new instance of server type '" + typeName + "'");
            QuartzServer retValue = (QuartzServer)Activator.CreateInstance(t);
            logger.Debug("Instance successfully created");
            return retValue;
        }

        //public QuartzServerFactory()
        //{
        //    //scheduler = StdSchedulerFactory.GetDefaultScheduler().ConfigureAwait(false)
        //    //                .GetAwaiter().GetResult();
        //    //InitServer();
        //}

        //public void InitServer()
        //{
        //    scheduler.Start();

        //    // define the job and tie it to our HelloJob class
        //    IJobDetail job = JobBuilder.Create<SampleJob>()
        //        .WithIdentity("myJob", "group1")
        //        .Build();

        //    // Trigger the job to run now, and then every 40 seconds
        //    ITrigger trigger = TriggerBuilder.Create()
        //        .WithIdentity("myTrigger", "group1")
        //        .StartNow()
        //        .WithSimpleSchedule(x =>
        //          x.WithIntervalInSeconds(2)
        //           .RepeatForever())
        //        .Build();

        //    scheduler.ScheduleJob(job, trigger);
        //}


    }
}
