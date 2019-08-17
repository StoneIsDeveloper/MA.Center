using log4net.Config;
using MA.ConsoleQuartz.Email;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace MA.ConsoleQuartz
{
    class Program
    {
        static void Main(string[] args)
        {
            // change from service account's dir to more logical one
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            var logRepository = log4net.LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            HostFactory.Run(x =>
            {
                x.RunAsLocalSystem();

                x.SetDescription(Configuration.ServiceDescription);
                x.SetDisplayName(Configuration.ServiceDisplayName);
                x.SetServiceName(Configuration.ServiceName);

                x.Service(factory =>
                {
                    QuartzServer server = QuartzServerFactory.CreateServer();
                    server.Initialize().GetAwaiter().GetResult();
                    return server;
                });
            });

            // QuartzTrainingService.InitServer();

            //var mailTo =  "1047284244@qq.com";
            //var mailSubject = "Test Mial 2019";
            //var  mailContent = $@"{DateTime.Now.ToString()} <br/>
            //                     <h3> Test Mail Contect </h3> <br/>";

            //EmailManager.SendMail(mailTo, mailSubject, mailContent);


            Console.ReadKey();


        }

      
    }

    public static class QuartzTrainingService
    {
        public static void InitServer()
        {
            var scheduler = StdSchedulerFactory.GetDefaultScheduler().ConfigureAwait(false)
                  .GetAwaiter().GetResult();
            scheduler.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<SampleJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x =>
                  x.WithIntervalInSeconds(1)
                   .RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }

        public static void Init()
        {
            HostFactory.Run(x =>
            {
                x.Service<QuartzServer>();

                x.RunAsLocalSystem();

                x.SetDescription("测试服务");
                x.SetDisplayName("TestService");
                x.SetServiceName("TopShelfQuartzDemo.TestService");

            });
        }
    }

    public static class HearBeatService
    {
        public static void InitService()
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<HeartBeat>(s =>
                {
                    s.ConstructUsing(heartBeat => new HeartBeat());
                    s.WhenStarted(heartBeat => heartBeat.Start());
                    s.WhenStopped(HeartBeat => HeartBeat.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("HearBeatService");
                x.SetDisplayName("HearBeatService");
                x.SetDescription("This is a simple heat beat service");

            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
