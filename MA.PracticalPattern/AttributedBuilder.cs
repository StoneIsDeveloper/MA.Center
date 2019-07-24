using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern
{
    public interface IAttributedBuilder
    {
        IList<string> Log { get; }

        void BuildPartA();

        void BuildPartB();

        void BuildPartC();

    }

    [Director(1, "BuildPartA")]
    [Director(2,"BuildPartB")]
    [Director(3, "BuildPartC")]
    public class AttributedBuilder : IAttributedBuilder
    {
        public IList<string> log = new List<string>();

        public IList<string> Log
        {
            get
            {
                return log;
            }
        }

        public void BuildPartA()
        {
            log.Add("a");
        }

        public void BuildPartB()
        {
            log.Add("b");
        }

        public void BuildPartC()
        {
            log.Add("c");
        }
    }

}
