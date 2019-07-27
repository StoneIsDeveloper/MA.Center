using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MA.PracticalPattern.Configurating.ParagraphConfigurationSectionBase;

namespace MA.PracticalPattern.Configurating
{
    public static class ConfigurationBroker
    {
        private static ChapterConfigurationSectionGroup group;

        static ConfigurationBroker()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            group = (ChapterConfigurationSectionGroup)configuration.GetSectionGroup("MA.PracticalPattern");
        }

        public static DelegatingParagramConfigurationSection Delegating
        {
            get
            {
                return group.Delegating;
            }
        }

        public static GenericsParagramConfigurationSection Generics
        {
            get
            {
                return group.Generics;
            }
        }
    }
}
