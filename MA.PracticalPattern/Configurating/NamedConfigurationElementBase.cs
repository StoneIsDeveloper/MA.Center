using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.Configurating
{
    public class NamedConfigurationElementBase : ConfigurationElement
    {
        private const string NameItem = "name";
        private const string DescriptionItem = "description";

        [ConfigurationProperty(NameItem, IsKey = true, IsRequired = true)]
        public virtual string Name
        {
            get
            {
                return base[NameItem] as string;
            }
        }

        [ConfigurationProperty(DescriptionItem, IsRequired = false)]
        public virtual string Description
        {
            get
            {
                return base[DescriptionItem] as string;
            }
        }

    }

    public class ExampleConfigurationElement : NamedConfigurationElementBase { }

    public class DiagramConfigurationElement : NamedConfigurationElementBase { }

    public class PictureConfigurationElement : NamedConfigurationElementBase
    {
        private const string ColorizedItem = "colorized";

        [ConfigurationProperty(ColorizedItem,IsRequired =true)]
        public bool Colorized
        {
            get
            {
                return (bool)base[ColorizedItem];
            }
        }

    }

}
