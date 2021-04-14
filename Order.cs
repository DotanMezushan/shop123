using System;
using System.Collections.Generic;
using System.Text;

namespace shop
{
    class Order
    {
        public int OredrID { get; set; }
        public int CustumerID { get; set; }
        public DateTime Created { get; set; }
        public Customers Custumer { get; set; }
        public List<OrderProduct> Order_Product { get; set; }
        

        public override string ToString()
        {
            return $"{OredrID},{Created}";
        }
    }
}
