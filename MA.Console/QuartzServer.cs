using log4net;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace MAConsole
{
    public class QuartzServer : ServiceControl, ServiceSuspend
    {
        private readonly ILog logger;
        private ISchedulerFactory schedulerFactory;
        private IScheduler scheduler;

        public QuartzServer()
        {
            logger = LogManager.GetLogger(GetType());
        }

        public virtual async Task Initialize()
        {
            try
            {
                schedulerFactory = CreateSchedulerFactory();
                scheduler = await GetScheduler().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                logger.Error("Server initialization failed:" + e.Message, e);
                throw;
            }
        }

        protected virtual Task<IScheduler> GetScheduler()
        {
            var list = schedulerFactory.GetAllSchedulers();
            
            return schedulerFactory.GetScheduler();
        }

        protected virtual IScheduler Scheduler => scheduler;

        protected virtual ISchedulerFactory CreateSchedulerFactory()
        {
            return new StdSchedulerFactory();
        }

        public bool Continue(HostControl hostControl)
        {
            scheduler.ResumeAll();
            return true;
        }

        public bool Pause(HostControl hostControl)
        {
            scheduler.PauseAll();
            return true;
        }

        public bool Start(HostControl hostControl)
        {
            scheduler.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            scheduler.Clear();
            return true;
        }
    }
}
