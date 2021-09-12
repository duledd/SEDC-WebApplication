using SEDC_WebAPI.Repositories.Interfaces;
using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.DAL.Data.Entities;
using SEDC_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebAPI.Repositories.Implementations
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
            //return _customerManager.GetCustomerById(id);
            try
            {
                return _customerManager.GetCustomerById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
