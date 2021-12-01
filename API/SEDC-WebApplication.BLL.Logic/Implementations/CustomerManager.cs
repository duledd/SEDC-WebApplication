using AutoMapper;
using SEDC_WebApplication.BLL.Logic.Interfaces;
//using SEDC_WebApplication.DAL.Data.Entities;
//using SEDC_WebApplication.DAL.Data.Interfaces;
using SEDC_WebApplication.Models;
using SEDC_WebApplicationDataBaseFactory.Entities;
using SEDC_WebApplicationDataBaseFactory.Interfaces;
//using SEDC_WebApplicationEntityFactory.Entities;
//using SEDC_WebApplicationEntityFactory.Interfaces;
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
        private readonly IOrderDAL _orderDAL;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerDAL customerDAL, IOrderDAL orderDAL, IMapper mapper)
        {
            _customerDAL = customerDAL;
            _orderDAL = orderDAL;
            _mapper = mapper;
        }
        public CustomerDTO Add(CustomerDTO customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            _customerDAL.Save(customerEntity);
            customer = _mapper.Map<CustomerDTO>(customerEntity);
            return customer;
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            List<CustomerDTO> customerDTO = _mapper.Map<List<CustomerDTO>>(_customerDAL.GetAll(0, 50));
            return customerDTO;
        }

        public CustomerDTO GetCustomerById(int id)
        {
            try
            {
                Customer customer = _customerDAL.GetById(id);
                if (customer == null)
                {
                    throw new Exception($"Customer with id {id} not found.");
                }
                CustomerDTO customerDTO = _mapper.Map<CustomerDTO>(customer);
                //customerDTO.Orders = _orderDAL.GetByCustomerId((int)customer.CustomerId);
                return customerDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CustomerDTO Update(int id, CustomerDTO customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            _customerDAL.Update(customerEntity);
            customer = _mapper.Map<CustomerDTO>(customerEntity);
            return customer;
        }
    }
}
