using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.DependencyInjection
{
    /// <summary>
    /// 帮助客户类型和客户程序获取其Attribute定义中需要的抽象类型实例的工具类
    /// </summary>
    public static class AttributeHelper
    {
        public static T Injector<T>(object target) where T : class
        {
            if (target == null)
                throw new ArgumentNullException("target");
            Type targetType = target.GetType();
            object[] attributes = targetType.GetCustomAttributes(typeof(DecoratorAttribute), false);
            if (attributes == null || attributes.Length <= 0)
                return null;
            foreach (DecoratorAttribute attribute in (DecoratorAttribute[])attributes)
            {
                if (attribute.Type == typeof(T))
                    return (T)attribute.Injector;
            }
            return null;

        }
    }
}
