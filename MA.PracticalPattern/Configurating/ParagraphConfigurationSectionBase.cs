using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.Configurating
{
    public class ParagraphConfigurationSectionBase : ConfigurationSection
    {
        private const string ExamplesItem = "examples";
        private const string DiagramsItem = "diagrams";

        [ConfigurationProperty(ExamplesItem, IsRequired =false)]
        public virtual ExampleConfigurationElementCollection Examples
        {
            get
            {
                return base[ExamplesItem] as ExampleConfigurationElementCollection;
            }
        }

        [ConfigurationProperty(DiagramsItem, IsRequired = false)]
        public virtual DiagramConfigurationElementCollection Diagrams
        {
            get
            {
                return base[DiagramsItem] as DiagramConfigurationElementCollection;
            }
        }
    }

    public class DelegatingParagramConfigurationSection : ParagraphConfigurationSectionBase
    {
        private const string PictruesItem = "pictures";

        [ConfigurationProperty(PictruesItem, IsRequired = false)]
        public virtual PictureConfigurationElementCollection Pictures
        {
            get
            {
                return base[PictruesItem] as PictureConfigurationElementCollection;
            }
        }
    }

    public class GenericsParagramConfigurationSection : ParagraphConfigurationSectionBase
    {

    }

    public class ObjectBuilderParagramConfigurationSection : ConfigurationSection
    {
        private const string ObjectBuilderItem = "entityMappings";

        [ConfigurationProperty(ObjectBuilderItem, IsRequired = false)]
        public virtual EntityMappingConfigurationElementCollection EntityMappings
        {
            get
            {
                return base[ObjectBuilderItem] as EntityMappingConfigurationElementCollection;
            }
        }
    }
}
