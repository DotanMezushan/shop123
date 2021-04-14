using System;
using System.Collections.Generic;
using System.Text;

namespace shop
{
    class ContactDetails
    {
        public Customers Cusrumer { get; set; }
        
        public int CustumeID { get; set; }
        public  string Email { get; set; }
        public string Phone { get; set; }
       

        public override string ToString()
        {
            return $"{Email},{Phone}";
        }

    }
}
