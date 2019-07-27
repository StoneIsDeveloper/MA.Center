using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MA.PracticalPattern.Configurating.ParagraphConfigurationSectionBase;

namespace MA.PracticalPattern.Configurating
{
    public class ChapterConfigurationSectionGroup : ConfigurationSectionGroup
    {
        private const string DelegatingItem = "delegating";
        private const string GenericsItem = "generics";

        public ChapterConfigurationSectionGroup() : base() { }

        [ConfigurationProperty(DelegatingItem,IsRequired =true)]
        public virtual DelegatingParagramConfigurationSection Delegating
        {
            get
            {
                return base.Sections[DelegatingItem] as DelegatingParagramConfigurationSection;
            }
        }

        [ConfigurationProperty(GenericsItem, IsRequired = true)]
        public virtual GenericsParagramConfigurationSection Generics
        {
            get
            {
                return base.Sections[GenericsItem] as GenericsParagramConfigurationSection;
            }
        }


    }
}
