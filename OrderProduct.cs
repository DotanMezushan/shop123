using System;
using System.Collections.Generic;
using System.Text;

namespace shop
{
    class OrderProduct
    {
        public int ProductID { get; set; }
        public int OredrID { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }

        public override string ToString()
        {
            return $"{ProductID},{OredrID}";
        }
    }
}
