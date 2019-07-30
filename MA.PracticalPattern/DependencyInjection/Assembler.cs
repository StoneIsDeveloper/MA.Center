using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MA.PracticalPattern.DependencyInjection;

namespace MA.PracticalPattern.DependencyInjection
{
    public class Assembler
    {
        // 保存 “抽象类型/实体类型” 对应关系字典
        private static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            // 注册抽象类型需要使用的实体类型
            // 实际的配置信息可以从外层机制获取， 例如通过配置定义
            dictionary.Add(typeof(ITimeProvider), typeof(TimeProvider));
        }

        // 根据客户程序需要的抽象类型选择相应的实体类型，并返回类型实例
        // 主要用于非范型
        public object Create(Type type)
        {
            if (type == null || !dictionary.ContainsKey(type))
                throw new NullReferenceException();
            Type targetType = dictionary[type];
            return Activator.CreateInstance(targetType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">抽象类型（抽象类/接口/基类）</typeparam>
        /// <returns></returns>
        // 用于泛型方法调用
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

    }
}
