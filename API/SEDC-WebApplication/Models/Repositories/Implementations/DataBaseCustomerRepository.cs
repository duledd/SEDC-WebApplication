using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.DAL.Data.Entities;
using SEDC_WebApplication.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Models.Repositories.Implementations
{
    public class DataBaseCustomerRepository : ICustomerRepository
    {
        private readonly ICustomerManager _customerManager;
        public DataBaseCustomerRepository(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return _customerManager.GetAllCustomers();
        }

        public CustomerDTO GetCustomerById(int id)
        {
            return _customerManager.GetCustomerById(id);
        }

        public CustomerDTO Add(CustomerDTO customer)
        {
            return _customerManager.Add(customer);
        }

        //public CustomerDTO Update(CustomerDTO customer)
        //{
        //    return _customerManager.Add(customer);
        //}
    }
}
