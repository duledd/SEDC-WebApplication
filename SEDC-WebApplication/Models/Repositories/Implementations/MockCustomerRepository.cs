using SEDC_WebApplication.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SEDC_WebApplication.Models.Repositories.Implementations
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private List<Customer> _customerList;
        public MockCustomerRepository()
        {
            _customerList = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Slavko",
                    Email = "dfsd@jhjg",
                    PicturePath = "~/img/photo2.jpg",
                },
                new Customer
                {
                    Id = 2,
                    Name = "Mirko",
                    Email = "dsfd@hgj",
                    PicturePath = "~/img/photo2.jpg",
                },
                new Customer
                {
                    Id = 3,
                    Name = "Petko",
                    Email = "dfdsf@fgfdgfd",
                    PicturePath = "~/img/photo2.jpg",
                }
            };
        }

        

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerList;
        }

        public Customer GetCustomerById(int id)
        {
            return _customerList.Where(x => x.Id == id).FirstOrDefault();
        }
        public Customer Add(Customer customer)
        {
            customer.Id = _customerList.Max(p => p.Id) + 1;
            _customerList.Add(customer);
            return _customerList.Where(x => x.Id == customer.Id).FirstOrDefault();
        }
    }
}
