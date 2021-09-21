using SEDC_WebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebAPI.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<OrderDTO> GetAllOrders();
        OrderDTO GetOrderById(int id);
        OrderDTO Add(OrderDTO order);
    }
}
