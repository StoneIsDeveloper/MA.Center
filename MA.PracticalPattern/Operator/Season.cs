using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.Operator
{
    public class Season
    {
        public static readonly string[] Seasons =
            new string[] { "Spring", "Summer", "Autum", "Winter" };

        private int Current;

        public string Name
        {
            get
            {
               return Seasons[Current];
            }
        }

        public Season()
        {
            Current = default(int);
        }

        public static Season operator ++(Season season)
        {
            season.Current = (season.Current + 1) % 4;
            return season;
        }

        public static implicit operator string (Season season)
        {
            return season.ToString();
        }


    }
}
