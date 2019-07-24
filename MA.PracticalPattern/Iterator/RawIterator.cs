using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.Iterator
{
    public class RawIterator
    {
        private int[] data = new int[] {0, 1, 2, 3, 4, 5 };

        //最简单的基础数组的全部遍历
        //也可以采用范型声明 public IEnumerator<int>
        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        // 返回某个区间内数组的IEnumerable
        public IEnumerable GetRange(int start,int end)
        {
            for (int i = start; i < end; i++)
            {
                yield return data[i];
            }
        }

        /// <summary>
        /// 手工 捏 出来的IEnumerable<string>
        /// </summary>
        public IEnumerable<string> Greeting
        {
            get
            {
                yield return "hello";
                yield return "world";
                yield return "!";

            }
        }

    }
}
