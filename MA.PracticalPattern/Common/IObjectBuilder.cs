using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.Common
{
    /// <summary>
    /// 根据类型名称，生成类型实例
    /// </summary>
    public interface IObjectBuilder
    {
        /// <summary>
        /// 创建类型实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">构造参数</param>
        /// <returns></returns>
        T BuildUp<T>(object[] args);

        //无参构造
        T BuildUp<T>() where T : new();

        T BuildUp<T>(string typeName);

        T BuildUp<T>(string typeName, object[] args);
    }
}
