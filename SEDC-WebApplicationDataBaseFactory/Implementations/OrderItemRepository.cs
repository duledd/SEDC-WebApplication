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
    public class OrderItemRepository : IOrderItemDAL
    {
        private IConfiguration Configuration { get; set; }
        public OrderItemRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<OrderItem> GetAll(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public OrderItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderItem> GetByProductId(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                List<OrderItem> result = db.OrderItems
                    .Include(o => o.Order).Where(e => e.ProductId == id).ToList();
                return result;
            }
        }

        public void Save(OrderItem item)
        {
            throw new NotImplementedException();
        }
    }
}
