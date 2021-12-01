using SEDC_WebApplicationEntityFactory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationEntityFactory.Interfaces
{
    public interface ICustomerDAL
    {
        void Save(Customer item);

        Customer GetById(int id);

        List<Customer> GetAll(int skip, int take);
    }
}
