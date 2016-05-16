using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Customer
    {
        public static IDictionary<int, Customer> Customers { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Customer(){ if (Customers == null) {
                Customers = new Dictionary<int, Customer>();
                Customers.Add(1, new Customer { CustomerId = 1, Email = "yes@yes.com", Name = "Yes Sir" });
                Customers.Add(2, new Customer { CustomerId = 2, Email = "hello@hello.com", Name = "Hello Hello" });
            }
        }    
    }
}