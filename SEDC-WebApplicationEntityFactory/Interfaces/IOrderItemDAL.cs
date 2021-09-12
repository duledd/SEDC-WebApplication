using SEDC_WebApplicationEntityFactory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationEntityFactory.Interfaces
{
    public interface IOrderItemDAL
    {
        void Save(OrderItem item);

        OrderItem GetById(int id);
        List<OrderItem> GetByProductId(int id);

        List<OrderItem> GetAll(int skip, int take);
    }
}
