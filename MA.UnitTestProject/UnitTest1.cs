using System;
using MA.PracticalPattern;
using MA.PracticalPattern.Indexer;
using MA.PracticalPattern.Iterator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MA.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IAttributedBuilder builder = new AttributedBuilder();
            Director director = new Director();
            director.BuildUp(builder);
            Assert.AreEqual<string>("a", builder.Log[0]);
            Assert.AreEqual<string>("b", builder.Log[1]);

        }

        /// <summary>
        /// 索引器
        /// </summary>
        [TestMethod]
        public void FindData()
        {
           // float expected = 65.0F;
            Dashboard dashboard = new Dashboard();

            float actual = dashboard[
                delegate(float data)   // Predicate<float的委托>
                {
                    return data > 63F;
                }
            ];

            actual = dashboard[
                delegate (float data)   // Predicate<float的委托>
                {
                    return ( data > 63F) && (data < 100);
                }
            ];

        }

        [TestMethod]
        public void Iterator()
        {
            int count = 0;
            RawIterator iterator = new RawIterator();

            foreach (var item in iterator)
            {
                Assert.AreEqual<int>(count++, item);
            }

            count = 1;
            foreach (var item in iterator.GetRange(1,3))
            {
                var s = item;
            }

            count = 0;
            foreach (var item in iterator.Greeting)
            {
                var s = item;
            }

        }
    }
}
