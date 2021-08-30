using AutoMapper;
using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.DAL.Data.Entities;
using SEDC_WebApplication.DAL.Data.Interfaces;
using SEDC_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.BLL.Logic.Implementations
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerDAL _customerDAL;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerDAL customerDAL, IMapper mapper)
        {
            _customerDAL = customerDAL;
            _mapper = mapper;
        }
        public CustomerDTO Add(CustomerDTO customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            _customerDAL.Save(customerEntity);
            return customer;
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return _mapper.Map<List<CustomerDTO>>(_customerDAL.GetAll(0, 50));
        }

        public CustomerDTO GetCustomerById(int id)
        {
            return _mapper.Map<CustomerDTO>(_customerDAL.GetById(id));
        }

    }
}
