using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplicationDataBaseFactory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.BLL.Logic.Interfaces
{
    public interface IOrderManager
    {
        IEnumerable<OrderDTO> GetAllOrders();
        OrderDTO GetOrderById(int id);
        OrderDTO Add(OrderDTO order);
        OrderDTO Update(int id, OrderDTO order);
        IEnumerable<Order> GetOrdersByCustomerId(int id);
    }
}
