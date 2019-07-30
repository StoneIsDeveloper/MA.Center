using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.DependencyInjection
{
    [Decorator(typeof(ITimeProvider))]
    public class Client
    {
        // 属性注入
        public ITimeProvider TimeProvider { get; set; }

        public Client()
        {

        }

        // 构造函数注入
        public Client(ITimeProvider timeProvider)
        {
            this.TimeProvider = timeProvider;
        }

        //Attribute注入
        public int GetYear()
        {
            ITimeProvider provider = AttributeHelper.Injector<ITimeProvider>(this);
            return provider.CurrentDate.Year;
        }

        //public int GetYear()
        //{
        //    return TimeProvider.CurrentDate.Year;
        //}


        //public int GetYear()
        //{
        //    ITimeProvider provider = new TimeProvider();
        //    return provider.CurrentDate.Year;
        //}
    }
}
