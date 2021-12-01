using SEDC_WebApplicationEntityFactory.Entities;
using SEDC_WebApplicationEntityFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationEntityFactory.Implementations
{
    public class CustomerRepository : ICustomerDAL
    {
        public List<Customer> GetAll(int skip, int take)
        {
            using (var db = new PizzaShop4Context())
            {
                List<Customer> result = db.Customers.Skip(skip).Take(take).ToList();
                return result;
            }
        }

        public Customer GetById(int id)
        {
            using (var db = new PizzaShop4Context())
            {
                Customer result = db.Customers.First(e => e.CustomerId == id);
                return result;
            }
        }

        public void Save(Customer item)
        {
            using (var db = new PizzaShop4Context())
            {
                User user = new User();
                user.Customer = item;
                db.Users.Add(user);

                Contact contact = new Contact();
                contact.Customer = item;
                db.Contacts.Add(contact);
                db.SaveChanges();
            }
        }
    }
}
