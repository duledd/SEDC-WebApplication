using Microsoft.EntityFrameworkCore;
using SEDC_WebApplicationEntityFactory.Entities;
using SEDC_WebApplicationEntityFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationEntityFactory.Implementations
{
    public class OrderRepository : IOrderDAL
    {
        public List<Order> GetAll(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetByEmployeeId(int id)
        {
            using (var db = new PizzaShop4Context())
            {
                List<Order> result = db.Orders
                    .Include(o => o.Customer).Where(e => e.EmployeeId == id).ToList();
                return result;
            }
        }

        public List<Order> GetByCustomerId(int id)
        {
            using (var db = new PizzaShop4Context())
            {
                List<Order> result = db.Orders
                    .Include(o => o.Employee).Where(c => c.CustomerId == id).ToList();
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
