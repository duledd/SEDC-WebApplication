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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Save(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
