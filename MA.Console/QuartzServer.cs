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
        private readonly IScheduler scheduler;

        public QuartzServer()
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler().ConfigureAwait(false)
                            .GetAwaiter().GetResult();
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
