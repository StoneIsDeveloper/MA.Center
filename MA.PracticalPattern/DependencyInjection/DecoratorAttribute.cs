using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DecoratorAttribute : Attribute
    {
        public readonly object Injector;

        private  Type type;

        public DecoratorAttribute(Type type)
        {
            this.type = type ?? throw new NullReferenceException();
            Injector = (new Assembler()).Create(this.type);
        }

        public Type Type
        {
            get
            {
                return type;
            }
        }

    }

}
