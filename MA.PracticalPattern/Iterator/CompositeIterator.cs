using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.Iterator
{
    public class CompositeIterator
    {
        // 为每个可以遍历对象提供的容器
        // 由于类型为object, 所以CompositeIterator自身也可以嵌套
        private IDictionary<object, IEnumerator> items = new Dictionary<object, IEnumerator>();

        public void Add(object data)
        {
            items.Add(data, GetEnumerator(data));
        }

        // 对外提供可遍历的 IEnumerator
        public IEnumerator GetEnumerator()
        {
            if(items != null  && items.Count > 1)
            {
                foreach (var item in items.Values)
                {
                    while (item.MoveNext())
                        yield return item.Current;
                }
            }
        }

        public static IEnumerator GetEnumerator(object data)
        {
            if (data == null)
                throw new NullReferenceException();
            Type type = data.GetType();

            //是否为 stack
            if (type.IsAssignableFrom(typeof(Stack))
                || type.IsAssignableFrom(typeof(Stack<ObjectWithName>)))
                return DynamicInvokeEnumerator(data);

            // 是否为 Queue
            if(type.IsAssignableFrom(typeof(Queue))
                || type.IsAssignableFrom(typeof(Queue<ObjectWithName>)))
            {
                return DynamicInvokeEnumerator(data);
            }

            //是否为 Array
            if(type.IsArray && type.GetElementType().IsAssignableFrom(typeof(ObjectWithName)))
            {
                return ((ObjectWithName[])data).GetEnumerator();
            }

            // 是否为 二叉树
            if (type.IsAssignableFrom(typeof(BinaryTreeNode)))
            {
                return ((BinaryTreeNode)data).GetEnumerator();
            }

            throw new NotSupportedException();

        }

        //通过反射动态调用相关实例的 GetEnumerator 方法获取 IEnumerator
        private static IEnumerator DynamicInvokeEnumerator(object data)
        {
            if (data == null)
                throw new NullReferenceException();
            Type type = data.GetType();
            return (IEnumerator)type.InvokeMember("GetEnumerator",
                System.Reflection.BindingFlags.InvokeMethod, null, data, null);
        }
    }
}
