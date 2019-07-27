using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.Operator
{
    public class ErrorEntity
    {
        public static ErrorEntity  operator +(ErrorEntity entity,string message)
        {
            entity.Messages.Add(message);
            return entity;
        }

        public static ErrorEntity operator +(ErrorEntity entity, int code)
        {
            entity.Codes.Add(code);
            return entity;
        }

        public IList<string> Messages { get; } = new List<string>();
        public IList<int> Codes { get; } = new List<int>();

    }
}
