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
    public class OrderItemRepository : IOrderItemDAL
    {
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
            using (var db = new PizzaShop4Context())
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
