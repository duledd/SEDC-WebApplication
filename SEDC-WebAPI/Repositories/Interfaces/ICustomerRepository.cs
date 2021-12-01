using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebAPI.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerById(int id);
        CustomerDTO Add(CustomerDTO customer);
        CustomerDTO UpdateCustomer(int id, CustomerDTO customer);
    }
}
