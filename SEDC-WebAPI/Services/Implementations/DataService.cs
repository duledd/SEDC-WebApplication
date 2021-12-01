using SEDC_WebAPI.Services.Interfaces;
using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.Models;
using SEDC_WebApplicationDataBaseFactory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebAPI.Services.Implementations
{
    public class DataService : IDataService
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly ICustomerManager _customerManager;
        private readonly IProductManager _productManager;
        private readonly IOrderManager _orderManager;
        public DataService(IEmployeeManager employeeManager, ICustomerManager customerManager, IProductManager productManager, IOrderManager orderManager)
        {
            _employeeManager = employeeManager;
            _customerManager = customerManager;
            _productManager = productManager;
            _orderManager = orderManager;
        }

        //EMPLOYEE
        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            return await _employeeManager.GetAllEmployees();
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            try
            {
                return await _employeeManager.GetEmployeeById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmployeeDTO> Add(EmployeeDTO employee)
        {
            return await _employeeManager.Add(employee);
        }

        public async Task<EmployeeDTO> UpdateEmployee(int id, EmployeeDTO employee)
        {
            return await _employeeManager.Update(id, employee);
        }


        //CUSTOMER
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
        public CustomerDTO UpdateCustomer(int id, CustomerDTO customer)
        {
            return _customerManager.Update(id, customer);
        }


        //PRODUCT
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return _productManager.GetAllProducts();
        }

        public ProductDTO GetProductById(int id)
        {
            try
            {
                return _productManager.GetProductById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductDTO Add(ProductDTO product)
        {
            return _productManager.Add(product);
        }


        public ProductDTO Delete(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public ProductDTO UpdateProduct(int id, ProductDTO product)
        {
            return _productManager.Update(id, product);
        }


        //ORDER
        public OrderDTO AddOrder(OrderDTO order)
        {
            return _orderManager.Add(order);
        }
        public IEnumerable<OrderDTO> GetAllOrders()
        {
            return _orderManager.GetAllOrders();
        }

        public OrderDTO GetOrderById(int id)
        {
            try
            {
                return _orderManager.GetOrderById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderDTO UpdateOrder(int id, OrderDTO order)
        {
            return _orderManager.Update(id, order);
        }

        public IEnumerable<Order> GetOrdersByCustomerId(int id)
        {
            return _orderManager.GetOrdersByCustomerId(id);
        }
    }
}
