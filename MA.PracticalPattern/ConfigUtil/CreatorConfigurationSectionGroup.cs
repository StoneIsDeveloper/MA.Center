using MA.PracticalPattern.Configurating;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.ConfigUtil
{
    public class CreatorConfigurationSectionGroup : ConfigurationSectionGroup
    {
        private const string ObjectBuilderItem = "objectBuilder";

        public CreatorConfigurationSectionGroup() : base() { }

        [ConfigurationProperty(ObjectBuilderItem, IsRequired = true)]
        public virtual ObjectBuilderParagramConfigurationSection ObjectBuilder
        {
            get
            {
                return base.Sections[ObjectBuilderItem] as ObjectBuilderParagramConfigurationSection;
            }
        }
    }

  
}
