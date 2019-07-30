using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.DependencyInjection
{
    public class Client
    {
        private ITimeProvider timeProvider;

        public Client(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }

        public int GetYear()
        {
            return timeProvider.CurrentDate.Year;
        }


        //public int GetYear()
        //{
        //    ITimeProvider provider = new TimeProvider();
        //    return provider.CurrentDate.Year;
        //}
    }
}
