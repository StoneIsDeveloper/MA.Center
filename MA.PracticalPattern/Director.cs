using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern
{

    public class Director
    {
        public void BuildUp(IAttributedBuilder builder)
        {
            object[] attributes = builder.GetType().GetCustomAttributes(typeof(DirectorAttribute), false);
            if (attributes.Length <= 0) return;

            DirectorAttribute[] directors =
                new DirectorAttribute[attributes.Length];
            for(int i=0; i< attributes.Length; i++)
            {
                directors[i] = (DirectorAttribute)attributes[i];
            }

            // 按每个DiretorAttribute 优先级逆序后，逐个执行
            Array.Sort<DirectorAttribute>(directors);
            foreach(DirectorAttribute attribute in directors)
            {
                InvokeBuildPartMethod(builder, attribute);
            }

        }

        private void InvokeBuildPartMethod(IAttributedBuilder builder, DirectorAttribute attribute)
        {
            switch (attribute.Method)
            {
                case "BuildPartA":
                    builder.BuildPartA();
                    break;
                case "BuildPartB":
                    builder.BuildPartB();
                    break;
                case "BuildPartC":
                    builder.BuildPartC();
                    break;

            }
        }
    }
}
