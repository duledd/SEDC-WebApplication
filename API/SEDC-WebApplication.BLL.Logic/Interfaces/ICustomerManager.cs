using SEDC_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.BLL.Logic.Interfaces
{
    public interface ICustomerManager
    {
        IEnumerable<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerById(int id);
        CustomerDTO Add(CustomerDTO customer);
        CustomerDTO Update(int id, CustomerDTO customer);
    }
}
