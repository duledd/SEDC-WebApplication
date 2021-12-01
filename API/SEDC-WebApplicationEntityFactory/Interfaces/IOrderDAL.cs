using SEDC_WebApplicationEntityFactory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationEntityFactory.Interfaces
{
    public interface IOrderDAL
    {
        void Save(Order item);

        Order GetById(int id);
        List<Order> GetByEmployeeId(int id);
        List<Order> GetByCustomerId(int id);

        List<Order> GetAll(int skip, int take);
    }
}
