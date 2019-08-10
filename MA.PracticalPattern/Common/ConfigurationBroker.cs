using MA.PracticalPattern.ConfigUtil;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.Common
{
    public static class ConfigurationBroker
    {
        /// <summary>
        /// 用于保存所有需要等级的通过配置获取的类型的实体，使用线程安全的内存缓冲对象保存
        /// </summary>
        private static readonly GenericCache<Type, object> cache;


        static ConfigurationBroker()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cache = new GenericCache<Type, object>();
            // 查找自定义的IConfigurationSource 配置节组，并调用Load方法加载配置缓冲对象
            foreach (ConfigurationSectionGroup group in config.SectionGroups)
            {
                var s = group.GetType();
                if (typeof(IConfigurationSource).IsAssignableFrom(group.GetType()))
                {
                    ((IConfigurationSource)group).Load();
                }
                var en = group.Sections;

            }

         //   DelegatingParagramConfigurationSection section = PracticalPattern.Configurating.ConfigurationBroker.Delegating;

        }

        /// <summary>
        /// 各配置将客户程序需要使用的配置对象通过该方法缓存
        /// </summary>
        /// <param name="type"></param>
        /// <param name="item"></param>
        public static void Add(Type type,object item)
        {
            if(type == null || item == null)
            {
                throw new NullReferenceException();
            }
            cache.Add(type, item);
        }

        public static void Add(KeyValuePair<Type,object> item)
        {
            Add(item.Key, item.Value);
        }

        public static void Add(object item)
        {
            Add(item.GetType(), item);
        }

        public static T GetConfigurationObject<T>() where  T : class
        {
            if(cache.Count <= 0)
            {
                return null;
            }
            object result;
            if (!cache.TryGetValue(typeof(T), out result))
            {
                return null;
            }
            else
            {
                return (T)result;
            }
        }


    }
}
