using SEDC_WebApplicationDataBaseFactory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.Interfaces
{
    public interface IOrderDAL
    {
        void Save(Order item);
        Order GetById(int id);
        List<Order> GetAll(int skip, int take);
        void Update(Order item);
        List<Order> GetByCustomerId(int skip, int take, int id);
        //List<Order> GetByCustomerId(int id, int skip, int take);
    }
}
