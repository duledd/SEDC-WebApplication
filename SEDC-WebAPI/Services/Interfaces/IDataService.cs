using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.Models;
using SEDC_WebApplicationDataBaseFactory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebAPI.Services.Interfaces
{
    public interface IDataService
    {
        //EMPLOYEE
        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();
        Task<EmployeeDTO> GetEmployeeById(int id);
        Task<EmployeeDTO> Add(EmployeeDTO employee);
        Task<EmployeeDTO> UpdateEmployee(int id, EmployeeDTO employee);

        //CUSTOMER
        IEnumerable<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerById(int id);
        CustomerDTO Add(CustomerDTO customer);
        CustomerDTO UpdateCustomer(int id, CustomerDTO customer);


        //PRODUCT
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        ProductDTO Add(ProductDTO product);
        ProductDTO UpdateProduct(int id, ProductDTO product);
        ProductDTO Delete(ProductDTO product);


        //ORDER
        OrderDTO AddOrder(OrderDTO order);
        IEnumerable<OrderDTO> GetAllOrders();
        OrderDTO GetOrderById(int id);
        OrderDTO UpdateOrder(int id, OrderDTO order);
        IEnumerable<Order> GetOrdersByCustomerId(int id);
    }
}
