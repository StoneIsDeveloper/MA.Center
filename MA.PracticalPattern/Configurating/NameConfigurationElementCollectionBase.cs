using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.Configurating
{
    public abstract class NameConfigurationElementCollectionBase<T> : ConfigurationElementCollection
        where T : NamedConfigurationElementBase, new ()
    {

        // 外部通过 index 获取集合中特定的 configurationElement
        public T this[int index] { get { return (T)base.BaseGet(index);  } }
        public new T this[string name] { get { return (T)base.BaseGet(name); } }

        // 创建一个新的 实例
        protected override ConfigurationElement CreateNewElement()
        {
            return new T();

        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as T).Name;
        }
    }

    public class ExampleConfigurationElementCollection
        : NameConfigurationElementCollectionBase<ExampleConfigurationElement>
    { }

    public class DiagramConfigurationElementCollection
        : NameConfigurationElementCollectionBase<DiagramConfigurationElement>
    { }

    public class PictureConfigurationElementCollection
       : NameConfigurationElementCollectionBase<PictureConfigurationElement>
    { }

    public class EntityMappingConfigurationElementCollection
     : NameConfigurationElementCollectionBase<EntityMappingConfigurationElement>
    { }





}
