using SEDC_WebAPI.Repositories.Interfaces;
using SEDC_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SEDC_WebAPI.Repositories.Implementations
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private List<CustomerDTO> _customerList;
        public MockCustomerRepository()
        {
            _customerList = new List<CustomerDTO>
            {
                new CustomerDTO
                {
                    Id = 1,
                    Name = "Slavko",
                    Email = "dfsd@jhjg",
                    PicturePath = "~/img/photo2.jpg",
                },
                new CustomerDTO
                {
                    Id = 2,
                    Name = "Mirko",
                    Email = "dsfd@hgj",
                    PicturePath = "~/img/photo2.jpg",
                },
                new CustomerDTO
                {
                    Id = 3,
                    Name = "Petko",
                    Email = "dfdsf@fgfdgfd",
                    PicturePath = "~/img/photo2.jpg",
                }
            };
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return _customerList;
        }

        public CustomerDTO GetCustomerById(int id)
        {
            return _customerList.Where(x => x.Id == id).FirstOrDefault();
        }
        public CustomerDTO Add(CustomerDTO customer)
        {
            customer.Id = _customerList.Max(p => p.Id) + 1;
            _customerList.Add(customer);
            return _customerList.Where(x => x.Id == customer.Id).FirstOrDefault();
        }
        public CustomerDTO Update(CustomerDTO customer)
        {
            _customerList.Where(x => x.Id == customer.Id).FirstOrDefault();
            _customerList.Remove(customer);
            _customerList.Add(customer);
            return _customerList.Where(x => x.Id == customer.Id).FirstOrDefault();
        }

    }
}
