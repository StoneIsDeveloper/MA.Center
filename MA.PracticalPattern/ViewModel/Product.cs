using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.PracticalPattern.ViewModel
{
    public class Product
    {
        public Product()
        {

        }

        public Product(string name)
        {
            Name = name;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
