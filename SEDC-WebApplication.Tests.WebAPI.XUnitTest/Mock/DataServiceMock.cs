using SEDC_WebAPI.Services.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.BLL.Logic.Models.Enum;
using SEDC_WebApplication.Models;
using SEDC_WebApplicationDataBaseFactory.Entities;
using SEDC_WebApplicationDataBaseFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Tests.WebAPI.XUnitTest.Mock
{
    public class DataServiceMock : IDataService
    {
        private List<EmployeeDTO> _employeeList;
        public DataServiceMock()
        {
            _employeeList = new List<EmployeeDTO>
            {
                new EmployeeDTO
                {
                    Id=1,
                    Name="Pera",
                    Role = RoleEnum.Manager,
                    Picture = "~/img/avatar.png"
                },
                new EmployeeDTO
                {
                    Id=2,
                    Name="Mika",
                    Role = RoleEnum.Manager,
                    Picture = "~/img/avatar.png"
                },
                new EmployeeDTO
                {
                    Id=3,
                    Name="Laza",
                    Role = RoleEnum.Manager,
                    Picture = "~/img/avatar.png"
                }
            };
        }

        public async Task<EmployeeDTO> Add(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }

        public CustomerDTO Add(CustomerDTO customer)
        {
            throw new NotImplementedException();
        }

        public ProductDTO Add(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public OrderDTO AddOrder(OrderDTO order)
        {
            throw new NotImplementedException();
        }

        public ProductDTO Delete(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public CustomerDTO GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDTO GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public ProductDTO GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerDTO UpdateCustomer(int id, CustomerDTO customer)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeDTO> UpdateEmployee(int id, EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }

        public OrderDTO UpdateOrder(int id, OrderDTO order)
        {
            throw new NotImplementedException();
        }

        public ProductDTO UpdateProduct(int id, ProductDTO product)
        {
            throw new NotImplementedException();
        }




        //public List<EmployeeDTO> GetAll(int skip, int take)
        //{
        //    return _employeeList;
        //}

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            return _employeeList;
        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            return _employeeList.Where(x => x.Id == id).FirstOrDefault();
        }

        public Task<EmployeeDTO> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
