using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern
{
    public interface ITarget
    {
        void Request();
    }

    public interface IAdapter
    {
        void SpecifiedRequest();
    }

    /// <summary>
    /// 适配器，接口转换
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericAdapterBase<T> : ITarget where T :IAdapter ,new()
    {
        public virtual void Request()
        {
            new T().SpecifiedRequest();
        }
    }
}
