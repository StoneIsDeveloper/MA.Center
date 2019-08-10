using System;
using System.Collections.Generic;
using MA.PracticalPattern;
using MA.PracticalPattern.Common;
using MA.PracticalPattern.Configurating;
using MA.PracticalPattern.ConfigUtil;
using MA.PracticalPattern.DependencyInjection;
using MA.PracticalPattern.Indexer;
using MA.PracticalPattern.Iterator;
using MA.PracticalPattern.Operator;
using MA.PracticalPattern.ViewModel;
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
            //ITimeProvider timeProvider = (new Assembler()).Create<ITimeProvider>();
            //Client client = new Client(timeProvider);// 构造函数注入
            //var year = client.GetYear();
        }

        [TestMethod]
        public void TestMethod2()
        {
            Client client = new Client();
            var year = client.GetYear();

        }

        [TestMethod]
        public void ConfigTest()
        {
            //new CreatorConfig().Load();
            // IObjectBuilder builder = 
            //    PracticalPattern.Common.ConfigurationBroker.GetConfigurationObject<IObjectBuilder>();
            //var s = builder.ToString();

            //IObjectBuilder builder2 = new TypeCreator();
            //builder2.BuildUp<Product>("Apple");

            //创建 MA.PracticalPattern.Common / objectBuilder 的配置节处理程序时出错: 
         //   类型“MA.PracticalPattern.Common.IObjectBuilder”不从“System.Configuration.IConfigurationSectionHandler”继承。 
           // (F:\2019Projects\MA.Center\MA.UnitTestProject\bin\Debug\MA.UnitTestProject.dll.config line 9)

        }


    }
}
