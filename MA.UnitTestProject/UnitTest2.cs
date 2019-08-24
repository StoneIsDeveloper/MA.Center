using System;
using MA.ServiceCenter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWorkService workService = new WorkLogService();
            workService.Process();


        }

        [TestMethod]
        public void TestMethodTrigerService()
        {
            WorkTrigerService.TrackingWork();
           
        }
    }
}
