using SEDC_WebApplication.DAL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.DAL.Data.Interfaces
{
    public interface ICustomerDAL
    {
        void Save(Customer item);

        Customer GetById(int id);

        List<Customer> GetAll(int skip, int take);
    }
}
