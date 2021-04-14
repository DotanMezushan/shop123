using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace shop
{
    class Program
    {
        static void Main(string[] args)
        {
            //DeleteAll();
            //InsertAllData();
            q1();//select Customers where c.CustumerAge > 50 
            


        }

        private static void q1()
        {
            
            using (ShopContext shopContext = new ShopContext())
            {
                var custumers = shopContext.Customers.ToList();
                var R = (from c in custumers
                         where c.CustumerAge > 50
                         select c).ToList();
                foreach (var item in R)
                {
                    Console.WriteLine(item);
                }
            }
            
        }

        private static void InsertAllData()
        { 
             AddCustumers();
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    List<Product> Product = new List<Product>();
                    Product.Add(new Product() { ProductID = 1, ProductName = "bamba", ProductValue = 20.5 });
                    Product.Add(new Product() { ProductID = 2, ProductName = "sugar", ProductValue = 10 });
                    Product.Add(new Product() { ProductID = 3, ProductName = "milk", ProductValue = 2 });
                    Product.Add(new Product() { ProductID = 4, ProductName = "chiz", ProductValue = 2.5 });
                    Product.Add(new Product() { ProductID = 5, ProductName = "gold", ProductValue = 250 });

                    List<Order> orders = new List<Order>();
                    orders.Add(new Order() {CustumerID=1,OredrID=101,Created=DateTime.Now });
                    orders.Add(new Order() { CustumerID = 1, OredrID = 100, Created = DateTime.Now });
                    orders.Add(new Order() { CustumerID = 2, OredrID = 102, Created = DateTime.Now });
                    orders.Add(new Order() { CustumerID = 3, OredrID = 103, Created = DateTime.Now });
                    orders.Add(new Order() { CustumerID = 4, OredrID = 104, Created = DateTime.Now });
                   orders.Add(new Order() { CustumerID = 4, OredrID = 105, Created = DateTime.Now });


                    List<OrderProduct> Order_Product = new List<OrderProduct>();
                    Order_Product.Add(new OrderProduct() { OredrID=100,ProductID=1,ProductCount=2});
                    Order_Product.Add(new OrderProduct() { OredrID = 100, ProductID = 2, ProductCount = 1 });
                    Order_Product.Add(new OrderProduct() { OredrID = 102, ProductID = 2, ProductCount = 20 });
                    Order_Product.Add(new OrderProduct() { OredrID = 103, ProductID = 3, ProductCount = 1 });
                    Order_Product.Add(new OrderProduct() { OredrID = 104, ProductID = 4, ProductCount = 1 });
                    Order_Product.Add(new OrderProduct() { OredrID = 104, ProductID = 5, ProductCount = 1 });
                    Order_Product.Add(new OrderProduct() { OredrID = 104, ProductID = 2, ProductCount = 1 });





                    using (ShopContext shopContext = new ShopContext())
                    {
                        shopContext.Products.AddRange(Product);
                        shopContext.SaveChanges();
                        Console.WriteLine("shopContext.Products.AddRange(Product);");
                        shopContext.Orders.AddRange(orders);
                        shopContext.SaveChanges();
                        Console.WriteLine(" shopContext.Orders.AddRange(orders);");
                        shopContext.OrdersProducts.AddRange(Order_Product);
                        shopContext.SaveChanges();
                        Console.WriteLine(" hopContext.OrdersProducts.AddRange(Order_Product);");
                    }


                    ts.Complete();
                    Console.WriteLine($"transaction commited");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception in transaction,{e.Message}");
                Console.WriteLine(e.InnerException);
            }

        }

        private static void AddCustumers()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    List<Customers> customers = new List<Customers>();
                    customers.Add(new Customers() {
                        CustumeID = 1,
                        CustumerAge = 30,
                        CustomerName = "dani",
                        Custumer_contact_ditals=new ContactDetails 
                        {
                            CustumeID = 1,
                            Email = "dani@gmail.com",
                            Phone = "0541111111"
                        }
                    });
                    customers.Add(new Customers()
                    {
                        CustumeID = 2,
                        CustumerAge = 33,
                        CustomerName = "mika",
                        Custumer_contact_ditals = new ContactDetails
                        {
                            CustumeID = 2,
                            Email = "mika@gmail.com",
                            Phone = "0542222222"
                        }
                    });
                    customers.Add(new Customers()
                    {
                        CustumeID = 3,
                        CustumerAge = 55,
                        CustomerName = "avi",
                        Custumer_contact_ditals = new ContactDetails
                        {
                            CustumeID = 3,
                            Email = "avi@gmail.com",
                            Phone = "0543333333"
                        }
                    });
                    customers.Add(new Customers()
                    {
                        CustumeID = 4,
                        CustumerAge = 56,
                        CustomerName = "bibi",
                        Custumer_contact_ditals = new ContactDetails
                        {
                            CustumeID = 4,
                            Email = "bibi@gmail.com",
                            Phone = "0544444444"
                        }
                    });
                    customers.Add(new Customers()
                    {
                        CustumeID = 5,
                        CustumerAge = 55,
                        CustomerName = "lena",
                        Custumer_contact_ditals = new ContactDetails
                        {
                            CustumeID = 5,
                            Email = "lana@gmail.com",
                            Phone = "0545555555"
                        }
                    });

                    using (ShopContext shopContext = new ShopContext())
                    {
                        shopContext.Customers.AddRange(customers);
                        shopContext.SaveChanges();
                    }


                    ts.Complete();
                    Console.WriteLine($"transaction commited");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception in transaction,{e.Message}");
                Console.WriteLine(e.InnerException);
            }
        }
        static void DeleteAll()
        {
            Console.WriteLine("DeleteAll:");
            using (ShopContext shopContext = new ShopContext())
            {
                shopContext.OrdersProducts.RemoveRange(shopContext.OrdersProducts.ToList());
                shopContext.Orders.RemoveRange(shopContext.Orders.ToList());
                shopContext.Orders.RemoveRange(shopContext.Orders.ToList());
                shopContext.Products.RemoveRange(shopContext.Products.ToList());
                shopContext.ContactsDetails.RemoveRange(shopContext.ContactsDetails.ToList());
                shopContext.Customers.RemoveRange(shopContext.Customers.ToList());
                shopContext.SaveChanges();
            }
        }
    }
}
