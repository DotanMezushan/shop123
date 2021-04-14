using System;
using System.Collections.Generic;
using System.Text;

namespace shop
{
    class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Double ProductValue { get; set; }

        public List<OrderProduct> Order_Product { get; set; }

        public override string ToString()
        {
            return $"{ProductID},{ProductName},{ProductValue}";
        }
    }
}
