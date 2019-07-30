using System;
using System.Collections.Generic;
using MA.PracticalPattern;
using MA.PracticalPattern.Common;
using MA.PracticalPattern.Configurating;
using MA.PracticalPattern.DependencyInjection;
using MA.PracticalPattern.Indexer;
using MA.PracticalPattern.Iterator;
using MA.PracticalPattern.Operator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MA.PracticalPattern.Configurating.ParagraphConfigurationSectionBase;

namespace MA.UnitTestProject
{
    [TestClass]
    public class DIUnitTest
    {
        // 依赖注入
        [TestMethod]
        public void TestMethod1()
        {
            ITimeProvider timeProvider = (new Assembler()).Create<ITimeProvider>();
            Client client = new Client(timeProvider);// 构造函数注入
            var year = client.GetYear();
        }

        [TestMethod]
        public void TestMethod2()
        {
            Client client = new Client();
            var year = client.GetYear();

        }


    }
}
