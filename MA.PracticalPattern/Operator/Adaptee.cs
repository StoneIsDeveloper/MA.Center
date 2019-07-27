using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.Operator
{
    public class Adaptee
    {
        // 不兼容的接口方法
        public int Code { get; set; }
    }


    // 适配器
    public class Target
    {
        private int data;

        public Target(int data)
        {
            this.data = data;
        }

        // 目标接口方法
        public int Data { get { return data; } }

        // 隐式类型转换进行适配
        public static implicit operator Target(Adaptee adeptee)
        {
            return new Target(adeptee.Code);
        }

    }
}
