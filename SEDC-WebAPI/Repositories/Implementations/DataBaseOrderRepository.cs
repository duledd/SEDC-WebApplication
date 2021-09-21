using SEDC_WebAPI.Repositories.Interfaces;
using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebAPI.Repositories.Implementations
{
    public class DataBaseOrderRepository : IOrderRepository
    {
        private readonly IOrderManager _orderManager;
        public DataBaseOrderRepository(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        public OrderDTO Add(OrderDTO order)
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
    }
}
