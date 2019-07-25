using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void CompositeData()
        {
            Stack<ObjectWithName> stack = new Stack<ObjectWithName>();
            stack.Push(new ObjectWithName("2"));
            stack.Push(new ObjectWithName("1"));
            // Queue
            Queue<ObjectWithName> queue = new Queue<ObjectWithName>();
            queue.Enqueue(new ObjectWithName("3"));
            queue.Enqueue(new ObjectWithName("4"));

            // T
            ObjectWithName[] array = new ObjectWithName[3];
            array[0] = new ObjectWithName("5");
            array[1] = new ObjectWithName("6");
            array[2] = new ObjectWithName("7");

            //BinaryTree
            BinaryTreeNode root = new BinaryTreeNode("8");
            root.Left = new BinaryTreeNode("9");
            root.Right = new BinaryTreeNode("10");
            root.Right.Left = new BinaryTreeNode("11");
            root.Right.Left.Left = new BinaryTreeNode("12");
            root.Right.Left.Right = new BinaryTreeNode("13");
            root.Right.Right = new BinaryTreeNode("14");
            root.Right.Right.Right = new BinaryTreeNode("15");
            root.Right.Right.Left = new BinaryTreeNode("16");

            // 合并所有 IEnumerator 对象
            CompositeIterator iterator = new CompositeIterator();
            iterator.Add(stack);
            iterator.Add(queue);
            iterator.Add(array);
            iterator.Add(root);

            List<string> logs = new List<string>();

            foreach (ObjectWithName item in iterator)
            {
                var s = item.ToString();
                logs.Add(s);
            }
            var length = logs.Count;
        }
    }
}
