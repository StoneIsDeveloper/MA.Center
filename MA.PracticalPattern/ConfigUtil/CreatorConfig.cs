using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.ConfigUtil
{
    public class CreatorConfig : IConfigurationSource
    {
        private static CreatorConfigurationSectionGroup group;

        public void Load()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            group = (CreatorConfigurationSectionGroup)configuration.GetSectionGroup("MA.PracticalPattern.Common");

            var section = group.ObjectBuilder;

            foreach (var item in section.EntityMappings)
            {
                var s = item.ToString();
                
            }  
          //  var typeName = section.EntityMappings["EventHandler"].Name;
          //  var parentName = section.EntityMappings["EventHandler"].ParentName;

        }
    }
}
