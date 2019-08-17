using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.ConsoleQuartz.Util
{
    public static class JobTestUtil
    {
        public static void AssertCollectionEquality<T>(IList<T> col1, IList<T> col2)
        {
            Assert.AreEqual(col1.Count, col2.Count, "Collection sizes differ");
            for (int i = 0; i < col1.Count; ++i)
            {
                Assert.AreEqual(col1[i], col2[i], $"Collection items differ at index {i}: {col1[i]} vs {col2[i]}");
            }
        }

        /// <summary>
        /// Creates the minimal fired bundle with job detail that has
        /// given job type.
        /// </summary>
        /// <param name="jobType">Type of the job.</param>
        /// <param name="trigger">The trigger.</param>
        /// <returns>Minimal TriggerFiredBundle</returns>
        public static TriggerFiredBundle CreateMinimalFiredBundleWithTypedJobDetail(Type jobType, IOperableTrigger trigger)
        {
            JobDetailImpl jd = new JobDetailImpl("jobName", "jobGroup", jobType);
            TriggerFiredBundle bundle = new TriggerFiredBundle(jd, trigger, null, false, DateTimeOffset.UtcNow, null, null, null);
            return bundle;
        }

        public static TriggerFiredBundle NewMinimalRecoveringTriggerFiredBundle()
        {
            return NewMinimalTriggerFiredBundle(true);
        }

        public static TriggerFiredBundle NewMinimalTriggerFiredBundle()
        {
            return NewMinimalTriggerFiredBundle(false);
        }

        private static TriggerFiredBundle NewMinimalTriggerFiredBundle(bool isRecovering)
        {
            IJobDetail jd = new JobDetailImpl("jobName", "jobGroup", typeof(NoOpJob));
            IOperableTrigger trigger = new SimpleTriggerImpl("triggerName", "triggerGroup");
            TriggerFiredBundle retValue = new TriggerFiredBundle(jd, trigger, null, isRecovering, DateTimeOffset.UtcNow, null, null, null);

            return retValue;
        }

        public static IJobExecutionContext NewJobExecutionContextFor(IJob job)
        {
            return new JobExecutionContextImpl(null, NewMinimalTriggerFiredBundle(), job);
        }
    }
}
