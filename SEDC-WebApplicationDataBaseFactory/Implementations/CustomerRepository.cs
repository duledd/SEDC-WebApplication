using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SEDC_WebApplicationDataBaseFactory.Entities;
using SEDC_WebApplicationDataBaseFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.Implementations
{
    public class CustomerRepository : ICustomerDAL
    {
        private IConfiguration Configuration { get; set; }
        public CustomerRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Customer> GetAll(int skip, int take)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                List<Customer> result = db.Customers.Skip(skip).Take(take).ToList();
                return result;
            }
        }

        public Customer GetById(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                Customer result = db.Customers.First(e => e.Id == id);
                return result;
            }
        }

        public void Save(Customer item)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                Contact contact = new Contact();
                contact.Customer = item;
                db.Contacts.Add(contact);

                db.Customers.Add(item);

                db.SaveChanges();
            }
        }
    }
}
