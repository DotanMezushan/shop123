using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace shop
{
    class Customers
    {
        public int CustumeID { get; set; }
        public string CustomerName { get; set; }
        public int CustumerAge { get; set; }

        public ContactDetails Custumer_contact_ditals { get; set; }
        public List<Order> Orders { get; set; }
        public override string ToString()
        {
            return $"{CustumeID},{CustomerName},{CustumerAge}"; 
        }
    }
}
