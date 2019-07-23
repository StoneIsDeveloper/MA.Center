using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class DirectorAttribute : Attribute, IComparable<DirectorAttribute>
    {
        private string method;

        public int Priority { get; }
        public string Method { get { return method; } }

        public DirectorAttribute(int priority,string method)
        {
            this.Priority = priority;
            this.method = method;
        }

        /// <summary>
        /// 比较的方式为 “输入的参数优先级 - 当前实例优先级”
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public int CompareTo(DirectorAttribute attribute)
        {
            return attribute.Priority - this.Priority;
        }


    }
}
