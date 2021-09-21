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
    public class OrderRepository : IOrderDAL
    {
        private IConfiguration Configuration { get; set; }
        public OrderRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Order> GetAll(int skip, int take)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                List<Order> result = db.Orders.Skip(skip).Take(take).ToList();
                return result;
            }
        }

        public List<Order> GetByEmployeeId(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                List<Order> result = db.Orders
                    .Include(o => o.Employee).Where(e => e.Employee.Id == id).ToList();
                return result;
            }
        }

        public Order GetById(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                Order result = db.Orders.First(e => e.Id == id);
                return result;
            }
        }

        public void Save(Order item)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                //if(item.Customer == null)
                //{
                //    item.Customer = new Customer();
                //}

                //if (item.Employee == null)
                //{
                //    item.Employee = new Employee();
                //}
                //Customer customer = new Customer();
                ////customer.Orders = item;
                //db.Customers.Add(customer);

                db.Orders.Add(item);

                db.SaveChanges();
            }
        }
    }
}
