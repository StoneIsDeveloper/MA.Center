using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.ConfigUtil
{
    public interface IConfigurationSource
    {
        /// <summary>
        /// ConfigurationBroker 可以通过回调该方法，加载每个配置节需要的缓冲的配置对象
        /// </summary>
        void Load();
    }
}
