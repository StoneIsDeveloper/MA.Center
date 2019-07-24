using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.Iterator
{
    public class BinaryTreeNode : ObjectWithName
    {
        private string name;

        public BinaryTreeNode(string name) : base(name) { }

        public BinaryTreeNode Left = null;

        public BinaryTreeNode Right = null;


        /// <summary>
        /// 二叉树的遍历器
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            yield return this;
            if (Left != null)
            {
                foreach (var item in Left)
                {
                    yield return item;
                }
            }
            if (Right != null)
            {
                foreach (var item in Right)
                {
                    yield return item;
                }
            }
        }
    }
}
